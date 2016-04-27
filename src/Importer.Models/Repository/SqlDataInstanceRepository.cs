using System;
using System.Collections.Generic;

using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql.Processors;

namespace Escyug.Importer.Models.Repository
{
    internal sealed class SqlDataInstanceRepository : IDataInstanceRepository
    {
        private readonly IDataReaderProcessor _dataReaderProcessor;
        private readonly IMetadataProcessor _metadataProcessor;

        // DI or not DI
        public SqlDataInstanceRepository()
        {
            _dataReaderProcessor = new SqlDataReaderProcessor();
            _metadataProcessor = new SqlMetadataProcessor();
        }

        public IEnumerable<Table> GetMetadata(string connectionString)
        {
            var metadataTables = _metadataProcessor.SelectTablesMetadata(connectionString);
            return ModelBinder.CreateModelTablesList(metadataTables);
        }

        // how to test? use helper classes?
        public bool TestConnection(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
