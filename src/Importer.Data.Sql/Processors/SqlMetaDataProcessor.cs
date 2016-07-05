using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    // same class implementation in OleDbMetadataProcessor (different connections)
    public sealed class SqlMetadataProcessor : IMetadataProcessor
    {
        public const string PROVIDER_NAME = "System.Data.SqlClient";

        public SqlMetadataProcessor()
        {

        }

        #region IMetadataProcessor members

        public IEnumerable<Table> GetTablesMetadata(string connectionString)
        {
            return DbCommonHelper.GetTablesMetadata(connectionString, PROVIDER_NAME);
        }

        
        public IEnumerable<Column> GetColumnsMetadata(string connectionString, string tableName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return DbCommonHelper.GetColumnsMetadata(connection, tableName);
            }
        }

        public bool TestConnection(string connectionString)
        {
            return DbCommonHelper.TestConnection(PROVIDER_NAME, connectionString);
        }

        #endregion IMetadataProcessor members

       
    }
}
