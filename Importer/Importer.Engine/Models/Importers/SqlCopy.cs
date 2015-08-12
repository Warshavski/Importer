using System.Data.Common;
using System.Data.SqlClient;

namespace Importer.Engine.Models.Importers
{
    /* TODO : 
      *   1. - done (+/-) - Add constructors (rewrite)
      *   2. Add a function to check the allowable values
      *   3. Add type conversion function
      *   4. Add import method for tables with fewer rows
      *   5. - done - Rewrite SqlBulk import method
      *   6. Add something for operation status indications
      *   7. ?? Add SqlBulkCopyOptions in SqlBulkCopy constructor ??
      *   8. ?? Errors and copy abort ??
      *   9. How to set SqlBulkCopy events
      */   

    public class SqlCopy : ICopy
    {
        #region Class constants

        private const int BATCH_SIZE = 1000;
        private const int NOTIFY_AFTER = 1;

        #endregion

        private CopyProgress _ProgressChange;

        private bool _abort = false;
        public bool Abort
        {
            set { _abort = value; }
        }

        private long _rowsTotal = -1;

        #region Constructors

        public SqlCopy(CopyProgress ProgressChange)
        {
            _ProgressChange = ProgressChange;
        }

        #endregion

        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            _ProgressChange(e.RowsCopied, _rowsTotal);
            e.Abort = _abort;
            //if (SqlRowsCopied != null)


            /*
            // (int)((100 * e.RowsCopied) / [total rows])
            if (_abort)
                e.Abort = true;
            else 
                _ChangeInStatus(e.RowsCopied, _rowsTotal);
             */
        }

        #region Public members

        public bool Import(Table sourceTable, Table targetTable, ColumnsMapping[] columnsMapping, bool truncate)
        {
            _rowsTotal = sourceTable.RowsCount;
            string commandText = string.Empty;
            
            using (DbConnection sourceConnection = DataAccess.CreateDbConnection(sourceTable.ProviderName, sourceTable.ConnectionString))
            {
                commandText = string.Format("SELECT * FROM [{0}]", sourceTable.Name);

                sourceConnection.Open();
                using (DbDataReader reader = DataAccess.CreateCommand(commandText, sourceConnection).ExecuteReader())
                {
                    using (DbConnection targetConnection = DataAccess.CreateDbConnection(targetTable.ProviderName, targetTable.ConnectionString))
                    {
                        targetConnection.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(targetConnection.ConnectionString))
                        {
                            bulkCopy.DestinationTableName = targetTable.Name;
                            bulkCopy.BatchSize = BATCH_SIZE;
                            bulkCopy.NotifyAfter = NOTIFY_AFTER;
                            bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                            // TODO : m.b. create separate function
                            foreach (ColumnsMapping element in columnsMapping)
                                bulkCopy.ColumnMappings.Add(
                                    new SqlBulkCopyColumnMapping(element.SourceColumn, element.TargetColumn));

                            if (truncate)
                            {
                                commandText = string.Format("TRUNCATE TABLE dbo.[{0}]", targetTable.Name);
                                DataAccess.CreateCommand(commandText, targetConnection).ExecuteNonQuery();
                            }

                            bulkCopy.WriteToServer(reader);
                        }
                        targetConnection.Close();
                    }
                }
                sourceConnection.Close();
            }
            return true;
        }

        #endregion
    }
}



/*
* string commandText = string.Format("SELECT {0} FROM [{1}]",
* string.Join(", ", sourceTable.Columns.Select(i => i.Name).ToArray<string>()),
*     sourceTable.Name);
*/

/* Old import variant
public bool Import(Table sourceTable, Table targetTable, ColumnsMapping[] columnsMapping, bool truncate)
{
    _rowsTotal = sourceTable.RowsCount;
    
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
                // TODO : m.b. create separate function
                foreach (ColumnsMapping element in columnsMapping)
                    _sqlCopy.ColumnMappings.Add(
                        new SqlBulkCopyColumnMapping(element.SourceColumn, element.TargetColumn));
                
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
*/