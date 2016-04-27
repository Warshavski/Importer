using System;
using System.Collections.Generic;

using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.OleDb.Processors;

namespace Escyug.Importer.Models.Repository
{
    internal sealed class OleDbDataInstanceRepository : IDataInstanceRepository
    {
        private readonly IDataReaderProcessor _dataReaderProcessor;
        private readonly IMetadataProcessor _metadataProcessor;

        // DI or not DI ?
        public OleDbDataInstanceRepository()
        {
            _dataReaderProcessor = new OleDbDataReaderProcessor();
            _metadataProcessor = new OleDbMetadataProcessor();
        }

        public IEnumerable<Table> GetMetadata(string connectionString)
        {
            var metadataTables = _metadataProcessor.SelectTablesMetadata(connectionString);
            return ModelBinder.CreateModelTablesList(metadataTables);
        }

        // how to test connection?
        public bool TestConnection(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
