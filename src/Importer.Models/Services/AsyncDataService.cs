using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Data;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Models.Services
{
    public class AsyncDataService : IAsyncDataService
    {
        private readonly string _connectionString;

        private readonly IMetadataProcessor _metadataProcessor;
        private readonly IAsyncDataImportProcessor _importProcessor;
        private readonly IAsyncDataReaderProcessor _readerProcessor;

        internal AsyncDataService(string connectioString,
            IMetadataProcessor metadataProcessor,
            IAsyncDataImportProcessor importProcessor,
            IAsyncDataReaderProcessor readerProcessor)
        {
            _connectionString = connectioString;

            _metadataProcessor = metadataProcessor;
            _importProcessor = importProcessor;
            _readerProcessor = readerProcessor;
        }

        //*** use async
        public IEnumerable<Table> GetMetaData()
        {
            var tablesMetadata = _metadataProcessor.GetTablesMetadata(_connectionString);
            return tablesMetadata;
        }

        public async Task<IDataReader> GetDataReader(string tableName)
        {
            var dataReader = await _readerProcessor.CreateReaderAsync(tableName, _connectionString);
            return dataReader;
        }

        public async Task ImportData(IDataReader dataReader, string destinationTable)
        {
            await _importProcessor.ImportAsync(
                dataReader, _connectionString, destinationTable);
        }

        public async Task ImportData(IDataReader dataReader, string destinationTable,
            IEnumerable<ColumnsMapping> columnsMapping)
        {
            await _importProcessor.ImportAsync(
                dataReader, _connectionString, destinationTable, columnsMapping);
        }

        public bool TestConnection()
        {
            //*** use async 
            return _metadataProcessor.TestConnection(_connectionString);
        }
    }
}
