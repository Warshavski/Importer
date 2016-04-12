using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public class SqlDataImporter : IDataImporter
    {
        public event Action<string> ImportStatusChanged;

        private void Invoke(Action<string> action, string message)
        {
            if (action != null)
                action.Invoke(message);
        }

        /* use for source select command (need for IDataReader instance creation) */
        private string ConstructSelectCommand(Table table)
        {
            StringBuilder commnadTextBuilder = new StringBuilder("SELECT ");

            foreach (var column in table.Columns)
            {
                if (column.IsForImport)
                    commnadTextBuilder.AppendFormat("{0},", column.Name);
            }

            // removes last ',' sign
            commnadTextBuilder.Remove(commnadTextBuilder.Length - 1, 1);

            commnadTextBuilder.AppendFormat(" FROM dbo.[{0}]", table.Name);

            return commnadTextBuilder.ToString();
        }

        /** Creates list of Mapping class which contains mapping between columns 
        *  (source and target)
        * TODO : 
        *  1. Decide what gonna be source and target.
        */
        private IEnumerable<Mapping> ExtractColumnMappings(Table table)
        {
            var columnMappings = new List<Mapping>();
            foreach (var column in table.Columns)
            {
                if (column.IsForImport)
                {
                    columnMappings.Add(
                        new Mapping(column.Name, column.MappingColumnName));
                }
            }

            return columnMappings;
        }

        // clear all data from table
        private void TruncateTable(string tableName, string connectionString)
        {
            var commandText = string.Format("TRUNCATE TABLE dbo.[{0}]", tableName);

            using (var connection = DbCommonHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, connectionString))
            {
                connection.Open();
                try
                {
                    var command = DbCommonHelper.CreateCommand(commandText, connection);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void ImportData(IDataReader sourceReader, IEnumerable<Mapping> mappings,
            string targerConnectionString, string targetTableName)
        {
            using (var bulkCopy = new SqlBulkCopy(targerConnectionString))
            {
                bulkCopy.DestinationTableName = targetTableName;

                // create mappings for SqlBulkCopy instance
                // !! too many object that contains mappings !!
                foreach (var map in mappings)
                    bulkCopy.ColumnMappings.Add(map.SourceColumnName, map.TargetTableName);

                // ?? dynamic count ??
                bulkCopy.BatchSize = 5000;
                bulkCopy.BulkCopyTimeout = 60;
                bulkCopy.NotifyAfter = 5000;

                try
                {
                    bulkCopy.WriteToServer(sourceReader);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public void Import(IDataInstance source, IDataInstance target, bool truncateTarget)
        {
            using (var connection = DbCommonHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, source.ConnectionString))
            {
                connection.Open();

                foreach (var table in source.Tables)
                {
                    if (!table.IsForImport)
                        continue;

                    var selectCommandText = ConstructSelectCommand(table);
                    using (var reader = DbCommonHelper.CreateCommand(
                        selectCommandText, connection).ExecuteReader())
                    {
                        var targetTableName = table.MappingTableName;
                        var targetConnectionString = target.ConnectionString;
                        var mappings = ExtractColumnMappings(table);

                        TruncateTable(targetTableName, targetConnectionString);
                        ImportData(reader, mappings, targetConnectionString, targetTableName);
                    }
                }
            }

           
        }
    }
}

/* old prototype version of Import method
if (_targetConnectionString == string.Empty)
    throw new ArgumentException("Connection string should be set");

// should use target connection string 
using (var bulkCopy = new SqlBulkCopy(_targetConnectionString))
{
    bulkCopy.DestinationTableName = _targetTable;

    Invoke(ImportStatusChanged, "creating mappings...");

    // create mappings for SqlBulkCopy instance
    foreach (var map in _mappings)
        bulkCopy.ColumnMappings.Add(map.SourceColumnName, map.TargetTableName);

    // dynamic count
    bulkCopy.BatchSize = 5000;
    bulkCopy.BulkCopyTimeout = 60;
    bulkCopy.NotifyAfter = 5000;

    try
    {
        if (truncateTarget)
        {
            Invoke(ImportStatusChanged, "truncate table...");

            TruncateTable(_targetTable, _targetConnectionString);
        }

        bulkCopy.SqlRowsCopied += (sender, e) =>
            Invoke(ImportStatusChanged, string.Format("rows copied : {0}", e.RowsCopied));

        bulkCopy.WriteToServer(_sourceReader);
    }
    catch (SqlException ex)
    {
        throw ex;
    }
}
*/