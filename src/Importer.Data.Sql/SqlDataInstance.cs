using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Escyug.Importer.Common;

namespace Escyug.Importer.Data.Sql
{
    public sealed class SqlDataInstance : IDataInstance
    {
        private IEnumerable<MetaData.Table> _tablesList;
        public IEnumerable<MetaData.Table> Tables
        {
            get { return _tablesList; }
        }

        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public SqlDataInstance(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void SetupBulkCopyInstance(SqlBulkCopy bulkCopyInstance, string tableName, Action<long> rowsCopied)
        {
            bulkCopyInstance.DestinationTableName = tableName;

            bulkCopyInstance.BulkCopyTimeout = 0;
            bulkCopyInstance.BatchSize = 5000;
            bulkCopyInstance.NotifyAfter = 1000;
            bulkCopyInstance.SqlRowsCopied += (sender, e) => { if (rowsCopied != null) rowsCopied(e.RowsCopied); };
        }

        private void SetupMappings(SqlBulkCopy bulkCopyInstance, IEnumerable<ColumnsMapping> columnsMappings)
        {
            foreach (var mapping in columnsMappings)
            {
                bulkCopyInstance.ColumnMappings.Add(
                    new SqlBulkCopyColumnMapping(mapping.SourceColumnName, mapping.TargetColunmName));
            }
        }

        public bool TestConnection()
        {
             return DbCommonHelper.TestConnection(
                 Constants.ProviderName.SQL_PROVIDER, _connectionString);
        }

        public void Initialize()
        {
            _tablesList = DbCommonHelper.GetTablesMetaData(
                Constants.ProviderName.SQL_PROVIDER, _connectionString);
        }

        public void Import(Action<long> RowsCopied, string targetTableName, 
            IDataReader sourceDataReader)
        {
            try
            {
                using (var bulkCopy = new SqlBulkCopy(_connectionString))
                {
                    SetupBulkCopyInstance(bulkCopy, targetTableName, RowsCopied);
                    bulkCopy.WriteToServer(sourceDataReader);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /* Import() - version with mappings
         public void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName,
             IEnumerable<ColumnsMapping> columnsMappings)
         {
             throw new NotImplementedException();
             try
             {
                 using (var bulkCopy = new SqlBulkCopy(targetConnectionString))
                 {
                     SetupBulkCopyInstance(bulkCopy, targetTableName);
                     SetupMappings(bulkCopy, columnsMappings);
                     bulkCopy.WriteToServer(sourceDataReader);
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
         }
         */
    }
}
