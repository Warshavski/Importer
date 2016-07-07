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
    public class AsyncSqlDataImportProcessor : IAsyncDataImportProcessor
    {
        //public event Action<long> RowsCopiedNotify;

        private readonly int _batchSize;
        private readonly int _notifyAfter;
        private readonly int _bulkCopyTimeout;

        public AsyncSqlDataImportProcessor()
        {
            _batchSize = 5000;
            _notifyAfter = 100;
            _bulkCopyTimeout = 1800;
        }

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

                await BulkCopyExecuteAsync(
                    sourceDataReader, connection, targetTableName, columnsMappings, null);
            }
        }

        public async Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString,
            string targetTableName, IEnumerable<ColumnsMapping> columnsMappings, Action<long> rowsCopiedNotify)
        {
            using (var connection = new SqlConnection(targetConnectionString))
            {
                await connection.OpenAsync();

                await BulkCopyExecuteAsync(
                    sourceDataReader, connection, targetTableName, columnsMappings, rowsCopiedNotify);
            }
        }

        private async Task BulkCopyExecuteAsync(IDataReader sourceDataReader, SqlConnection targetConnection, string targetTableName,
           IEnumerable<ColumnsMapping> columnsMappings, Action<long> rowsCopiedNotify)
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
                bulkCopy.BulkCopyTimeout = _bulkCopyTimeout;

                if (rowsCopiedNotify != null)
                {
                    bulkCopy.SqlRowsCopied += (sender, e) => rowsCopiedNotify(e.RowsCopied);
                }
                
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

        #endregion Asynchronous execution section

    }
}
