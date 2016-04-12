using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Common;

namespace Escyug.Importer.Data.Sql.QueryProcessors
{
    public class ImportQueryProcessor
    {
        private string _targetConnectionString;
        private SqlBulkCopy _bulkCopyInstance;

        private void SetupBulkCopy(string targetTableName,IEnumerable<TablesMapping> mappings)
        {
            _bulkCopyInstance.DestinationTableName = targetTableName;

            foreach(var map in mappings)
                _bulkCopyInstance.ColumnMappings.Add(
                    new SqlBulkCopyColumnMapping(map.SourceTableName, map.TargetTableName));

            _bulkCopyInstance.BatchSize = 5000;
            _bulkCopyInstance.NotifyAfter = 1000;
        }

        public void Import(IDataReader sourceDataReader, string targetTableName, 
            IEnumerable<TablesMapping> tablesMappings)
        {
            using (_bulkCopyInstance = new SqlBulkCopy(_targetConnectionString))
            {
                SetupBulkCopy(targetTableName, tablesMappings);
                _bulkCopyInstance.WriteToServer(sourceDataReader);
            }
        }
    }
}
