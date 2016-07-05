using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Models.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;

        private readonly IMetadataProcessor _metadataProcessor;
        private readonly IDataImportProcessor _importProcessor;
        private readonly IDataReaderProcessor _readerProcessor;

        public DataRepository(string connectionString,
            IMetadataProcessor metadataProcessor,
            IDataImportProcessor importProcessor)
        {
            _connectionString = connectionString;

            _metadataProcessor = metadataProcessor;
            _importProcessor = importProcessor;
        }

        public IEnumerable<Table> GetMetaData()
        {
            var tablesMetadata = _metadataProcessor.GetTablesMetadata(_connectionString);
            return tablesMetadata;
        }

        public void ImportData(IDataReader dataReader, string destinationTable)
        {
            _importProcessor.Import(dataReader, _connectionString, destinationTable);
        }
    }
}
