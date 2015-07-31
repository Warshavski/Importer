using System.Data.Common;
using System.Data.SqlClient;

namespace Importer.Engine.Models.Importers
{
    /* TODO : 
     *   1. Add constructors
     *   2. Add a function to check the allowable values
     *   3. Add type conversion function
     *   4. Add import method for tables with fewer rows
     *   5. Rewrite SqlBulk import method
     */

    public class SqlCopy : ICopy
    {
        private const int BATCH_SIZE = 1000;
        private const int NOTIFY_AFTER = 1;
        //private const int TIMEOUT = 0; 

        private SqlBulkCopy _sqlCopy = null;
        private CopyProgress _ChangeInStatus;

        private int _rowsCount = 0;

        public SqlCopy(CopyProgress ChangeInStatus)
        {
            _ChangeInStatus = ChangeInStatus;

            // initialization of _sqlCopy 
            _sqlCopy.NotifyAfter = NOTIFY_AFTER;
            _sqlCopy.BatchSize = BATCH_SIZE;
            _sqlCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
        }

        private void CreateSqlBulkMapping(ColumnsMapping colMapp)
        {
            _sqlCopy.ColumnMappings.Add(
                new SqlBulkCopyColumnMapping(colMapp.SourceColumn, colMapp.TargetColumn));
        }

        
        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            // (int)((100 * e.RowsCopied) / _testRowsCount)
            _ChangeInStatus((int)((100 * e.RowsCopied) / _rowsCount));
        }

        public bool Import(Table sourceTable, Table targetTable, ColumnsMapping[] columnsMapping, bool truncate)
        {
            _rowsCount = sourceTable.RowsCount;
            
            /*
             * string commandText = string.Format("SELECT {0} FROM [{1}]",
             * string.Join(", ", sourceTable.Columns.Select(i => i.Name).ToArray<string>()),
             *     sourceTable.Name);
             */
            
            _sqlCopy = new SqlBulkCopy(targetTable.ConnectionString);

            _sqlCopy.DestinationTableName = targetTable.Name;

           

            try
            {
                string commandText = string.Empty;

                using (DbConnection targetConnection = CommonData.CreateDbConnection(
                    targetTable.ProviderName, targetTable.ConnectionString))
                {
                    targetConnection.Open();

                    if (truncate)
                    {
                        commandText = string.Format("TRUNCATE TABLE [{0}]", targetTable.Name);
                        CommonData.CreateCommand(commandText, targetConnection).ExecuteNonQuery();
                    }

                    using (DbConnection sourceConnection = CommonData.CreateDbConnection(
                        sourceTable.ProviderName, sourceTable.ConnectionString))
                    {
                        foreach (ColumnsMapping element in columnsMapping)
                            CreateSqlBulkMapping(element);
                        
                        sourceConnection.Open();

                        commandText = string.Format("SELECT * FROM [{0}]", sourceTable.Name);
                        
                        using (DbDataReader reader = CommonData.CreateCommand(
                            commandText, sourceConnection).ExecuteReader())
                            _sqlCopy.WriteToServer(reader);
                        sourceConnection.Close();
                    }
                    targetConnection.Close();
                }
                return true;
            }
            finally
            {
                _sqlCopy.Close();
                _sqlCopy = null;
            }
        }
    }
}