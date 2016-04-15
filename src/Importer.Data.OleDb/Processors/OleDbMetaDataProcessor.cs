using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    // same class implementation in SqlMetadataProcessor (different connections)
    public class OleDbMetadataProcessor : IMetadataProcessor
    {
        public IEnumerable<Table> SelectTablesMetadata(string connectionString)
        {
            return DbCommonHelper.GetTablesMetadata(Constants.ProviderName.OLEDB_PROVIDER, connectionString);
        }
    }
}
