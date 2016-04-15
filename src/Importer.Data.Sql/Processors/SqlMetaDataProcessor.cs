using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    // same class implementation in OleDbMetadataProcessor (different connections)
    public sealed class SqlMetadataProcessor : IMetadataProcessor
    {
        public IEnumerable<Table> SelectTablesMetadata(string connectionString)
        {
            return DbCommonHelper.GetTablesMetadata(Constants.ProviderName.SQL_PROVIDER, connectionString);
        }
    }
}
