using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Common;
using Escyug.Importer.Data.MetaData;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    // same class implementation in OleDbMetaDataProcessor (different connections)
    public sealed class SqlMetaDataProcessor : IMetaDataProcessor
    {
        public IEnumerable<Table> SelectTablesMetaData(string connectionString)
        {
            return DbCommonHelper.GetTablesMetaData(Constants.ProviderName.SQL_PROVIDER, connectionString);
        }
    }
}
