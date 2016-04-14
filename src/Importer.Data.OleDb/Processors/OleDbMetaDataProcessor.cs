using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using Escyug.Importer.Common;
using Escyug.Importer.Data.MetaData;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    // same class implementation in SqlMetaDataProcessor (different connections)
    public class OleDbMetaDataProcessor : IMetaDataProcessor
    {
        public IEnumerable<Table> SelectTablesMetaData(string connectionString)
        {
            return DbCommonHelper.GetTablesMetaData(Constants.ProviderName.OLEDB_PROVIDER, connectionString);
        }
    }
}
