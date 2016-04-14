using System;
using System.Collections.Generic;

using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.MetaData;
using Escyug.Importer.Data.OleDb.Processors;

namespace Escyug.Importer.Models.Repository
{
    internal sealed class OleDbDataInstanceRepository : IDataInstanceRepository
    {
        private readonly IDataReaderProcessor _dataReaderProcessor;
        private readonly IMetaDataProcessor _metaDataProcessor;

        // DI or not DI ?
        public OleDbDataInstanceRepository()
        {
            _dataReaderProcessor = new OleDbDataReaderProcessor();
            _metaDataProcessor = new OleDbMetaDataProcessor();
        }

        public IEnumerable<Table> GetMetaData(string connectionString)
        {
            var metaDataTables = _metaDataProcessor.SelectTablesMetaData(connectionString);
            return ModelBinder.CreateModelTablesList(metaDataTables);
        }

        // how to test connection?
        public bool TestConnection(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
