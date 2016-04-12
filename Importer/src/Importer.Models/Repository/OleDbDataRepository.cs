using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Data.OleDb;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Models.Repository
{
    public class OleDbDataRepository
    {
        private readonly IMetaDataProcessor _metaDataProcessor;
        
        public OleDbDataRepository()
        {
            _metaDataProcessor = new OleDbMetaDataProcessor();
        }

        public IEnumerable<Models.Table> SelectTables(string connectionString)
        {
            var dataTables = _metaDataProcessor.SelectTablesMetaData(connectionString);

            var modelTablesList = ModelBinder.CreateModelTablesList(dataTables);
            
            return modelTablesList;
        }
    }
}
