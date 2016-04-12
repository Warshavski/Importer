using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype
{
    public class SqlDataImporter : IDataImporter<IDataReader, Mapping>
    {
        private readonly SqlBulkCopy _bulkCopy;

        public SqlDataImporter(string connectionString)
        {
            _bulkCopy = InitializeBulkCopy(connectionString);
        }

        private SqlBulkCopy InitializeBulkCopy(string connectionString)
        {
            var bulkCopy = new SqlBulkCopy(connectionString);
            
            bulkCopy.BatchSize = 5000;
            bulkCopy.BulkCopyTimeout = 60;
            bulkCopy.NotifyAfter = 5000;

            return bulkCopy;
        }

        public void Copy(string targetTableName, IDataReader sourceReader, IEnumerable<Mapping> mappings)
        {
            _bulkCopy.DestinationTableName = targetTableName;

            if (_bulkCopy.ColumnMappings.Count != 0)
                _bulkCopy.ColumnMappings.Clear();

            foreach (var map in mappings)
                _bulkCopy.ColumnMappings.Add(map.SourceColumnName, map.TargetTableName);

            try
            {
                _bulkCopy.WriteToServer(sourceReader);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _bulkCopy.Close();
        }
    }
}
