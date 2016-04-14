using System;
using System.Collections.Generic;

using Escyug.Importer.Data.MetaData;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql.Processors;

namespace Escyug.Importer.Models.Repository
{
    internal sealed class SqlDataInstanceRepository : IDataInstanceRepository
    {
        private readonly IDataReaderProcessor _dataReaderProcessor;
        private readonly IMetaDataProcessor _metaDataProcessor;

        // DI or not DI
        public SqlDataInstanceRepository()
        {
            _dataReaderProcessor = new SqlDataReaderProcessor();
            _metaDataProcessor = new SqlMetaDataProcessor();
        }

        public IEnumerable<Table> GetMetaData(string connectionString)
        {
            var metaDataTables = _metaDataProcessor.SelectTablesMetaData(connectionString);
            return ModelBinder.CreateModelTablesList(metaDataTables);
        }

        // how to test? use helper classes?
        public bool TestConnection(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
