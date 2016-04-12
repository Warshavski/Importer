using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql;
//using Escyug.Importer.Data.Sql.QueryProcessors;

namespace Escyug.Importer.Models.Repository
{
    public class SqlDataRepository 
    {
        private readonly IMetaDataProcessor _metaDataProcessor;
        
        public SqlDataRepository()
        {
            _metaDataProcessor = new SqlMetaDataProcessor();
        }

        public IEnumerable<Models.Table> SelectTables(string connectionString)
        {
            var dataTables = _metaDataProcessor.SelectTablesMetaData(connectionString);

            var modelTablesList = ModelBinder.CreateModelTablesList(dataTables);
            
            return modelTablesList;
        }
    }
}
