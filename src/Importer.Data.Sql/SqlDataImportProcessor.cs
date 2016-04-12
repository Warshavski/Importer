using System;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql
{
    public class SqlDataImportProcessor : IDataImportProcessor
    {
        public event Action<long> RowsCopiedNotify;

        public SqlDataImportProcessor()
        {
            
        }

        private void SetupBulkCopyInstance(SqlBulkCopy bulkCopyInstance, string tableName)
        {
            bulkCopyInstance.DestinationTableName = tableName;

            bulkCopyInstance.BatchSize = 5000;
            bulkCopyInstance.NotifyAfter = 1000;
            bulkCopyInstance.SqlRowsCopied += (sender, e) => { if (RowsCopiedNotify != null) RowsCopiedNotify(e.RowsCopied); };
        }

        public void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
        {
            try
            {
                using (var bulkCopy = new SqlBulkCopy(targetConnectionString))
                {
                    SetupBulkCopyInstance(bulkCopy, targetTableName);
                    bulkCopy.WriteToServer(sourceDataReader);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
