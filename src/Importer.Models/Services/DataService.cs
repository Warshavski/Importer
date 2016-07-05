using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Models.Services
{
    public class DataService : IDataService
    {
        private readonly string _connectionString;

        private readonly IMetadataProcessor _metadataProcessor;
        private readonly IDataImportProcessor _importProcessor;
        private readonly IDataReaderProcessor _readerProcessor;

        internal DataService(string connectioString, 
            IMetadataProcessor metadataProcessor,
            IDataImportProcessor importProcessor,
            IDataReaderProcessor readerProcessor)
        {
            _connectionString = connectioString;

            _metadataProcessor = metadataProcessor;
            _importProcessor = importProcessor;
            _readerProcessor = readerProcessor;
        }

        public IEnumerable<Table> GetMetaData()
        {
            var tablesMetadata = _metadataProcessor.GetTablesMetadata(_connectionString);
            return tablesMetadata;
        }

        public IDataReader GetDataReader(string tableName)
        {
            var dataReader = _readerProcessor.CreateReader(tableName, _connectionString);
            return dataReader;
        }

        public void ImportData(IDataReader dataReader, string destinationTable)
        {
            _importProcessor.Import(dataReader, _connectionString, destinationTable);
        }

        public void ImportData(IDataReader dataReader, string destinationTable, 
            IEnumerable<ColumnsMapping> columnsMapping)
        {
            _importProcessor.Import(dataReader, _connectionString, destinationTable, columnsMapping);
        }

        public bool TestConnection()
        {
            return _metadataProcessor.TestConnection(_connectionString);
        }
    }
}
