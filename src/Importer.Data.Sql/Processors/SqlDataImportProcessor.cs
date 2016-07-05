using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;


namespace Escyug.Importer.Data.Sql.Processors
{
    public static class SqlBulkCopyMappingExtension
    {
        public static void AddMappings(this SqlBulkCopy bulkCopy, IEnumerable<SqlBulkCopyColumnMapping> mappings)
        {
            foreach (var mapping in mappings)
            {
                bulkCopy.ColumnMappings.Add(mapping);
            }
        }
    }

    public sealed class SqlDataImportProcessor : IDataImportProcessor, IAsyncDataImportProcessor
    {
        public event Action<long> RowsCopiedNotify;

        private readonly int _batchSize;
        private readonly int _notifyAfter;

        public SqlDataImportProcessor()
        {
            _batchSize = 5000;
            _notifyAfter = 5000;
        }

        #region Synchronous execution section

        public void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
        {
            Import(sourceDataReader, targetConnectionString, targetTableName, null);
        }

        public void Import(IDataReader sourceDataReader, string targetConnectionString, 
            string targetTableName, IEnumerable<ColumnsMapping> columnsMappings)
        {
            using (var connection = new SqlConnection(targetConnectionString))
            {
                connection.Open();

                BulkCopyExecute(sourceDataReader, connection, targetTableName, columnsMappings);
            }
        }

        #endregion Synchronous execution section


        #region Asynchronous execution section

        public async Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
        {
            await ImportAsync(sourceDataReader, targetConnectionString, targetTableName, null);
        }

        public async Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString, 
            string targetTableName, IEnumerable<ColumnsMapping> columnsMappings)
        {
            using (var connection = new SqlConnection(targetConnectionString))
            {
                await connection.OpenAsync();

                await BulkCopyExecuteAsync(sourceDataReader, connection, targetTableName, columnsMappings);
            }
        }

       
        #endregion Asynchronous execution section


        #region Private helper methods 

        private void BulkCopyExecute(IDataReader sourceDataReader, SqlConnection targetConnection, string targetTableName,
            IEnumerable<ColumnsMapping> columnsMappings)
        {
            using (var bulkCopy = new SqlBulkCopy(targetConnection))
            {
                if (columnsMappings != null)
                {
                    var bulkMappings = CreateBulkCopyMappings(columnsMappings);
                    bulkCopy.AddMappings(bulkMappings);
                }

                bulkCopy.DestinationTableName = targetTableName;
                bulkCopy.BatchSize = _batchSize;
                bulkCopy.NotifyAfter = _notifyAfter;

                bulkCopy.WriteToServer(sourceDataReader);
            }
        }

        private async Task BulkCopyExecuteAsync(IDataReader sourceDataReader, SqlConnection targetConnection, string targetTableName,
           IEnumerable<ColumnsMapping> columnsMappings)
        {
            using (var bulkCopy = new SqlBulkCopy(targetConnection))
            {
                if (columnsMappings != null)
                {
                    var bulkMappings = CreateBulkCopyMappings(columnsMappings);
                    bulkCopy.AddMappings(bulkMappings);
                }

                bulkCopy.DestinationTableName = targetTableName;
                bulkCopy.BatchSize = _batchSize;
                bulkCopy.NotifyAfter = _notifyAfter;

                await bulkCopy.WriteToServerAsync(sourceDataReader);
            }
        }

        private IEnumerable<SqlBulkCopyColumnMapping> CreateBulkCopyMappings(IEnumerable<ColumnsMapping> columnsMappings)
        {
            var bulkCopyMappings = new List<SqlBulkCopyColumnMapping>();
            foreach (var mapping in columnsMappings)
            {
                var sourceColumn = mapping.SourceColumnName;
                var destinationColumn = mapping.DestinationColumnName;

                bulkCopyMappings.Add(
                    new SqlBulkCopyColumnMapping(sourceColumn, destinationColumn));
            }

            return bulkCopyMappings;
        }

        #endregion Private helper methods 
    }
}





//public event Action<long> RowsCopiedNotify;

//public SqlDataImportProcessor()
//{

//}

//private void SetupBulkCopyInstance(SqlBulkCopy bulkCopyInstance, string tableName)
//{
//    bulkCopyInstance.DestinationTableName = tableName;

//    bulkCopyInstance.BulkCopyTimeout = 0;
//    bulkCopyInstance.BatchSize = 5000;
//    bulkCopyInstance.NotifyAfter = 1000;
//    bulkCopyInstance.SqlRowsCopied += (sender, e) => { if (RowsCopiedNotify != null) RowsCopiedNotify(e.RowsCopied); };
//}

//private void SetupMappings(SqlBulkCopy bulkCopyInstance, IEnumerable<ColumnsMapping> columnsMappings)
//{
//    foreach (var mapping in columnsMappings)
//    {
//        bulkCopyInstance.ColumnMappings.Add(
//            new SqlBulkCopyColumnMapping(mapping.SourceColumnName, mapping.TargetColunmName));
//    }
//}

//public void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName,
//    IEnumerable<ColumnsMapping> columnsMappings)
//{
//    try
//    {
//        using (var bulkCopy = new SqlBulkCopy(targetConnectionString))
//        {
//            SetupBulkCopyInstance(bulkCopy, targetTableName);
//            SetupMappings(bulkCopy, columnsMappings);
//            bulkCopy.WriteToServer(sourceDataReader);
//        }
//    }
//    catch (SqlException ex)
//    {
//        throw ex;
//    }
//}

//public void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
//{
//    try
//    {
//        using (var bulkCopy = new SqlBulkCopy(targetConnectionString))
//        {
//            SetupBulkCopyInstance(bulkCopy, targetTableName);
//            bulkCopy.WriteToServer(sourceDataReader);
//        }
//    }
//    catch (SqlException ex)
//    {
//        throw ex;
//    }
//}
