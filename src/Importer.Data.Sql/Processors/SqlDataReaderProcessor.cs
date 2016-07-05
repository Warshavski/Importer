using System.Data;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    public sealed class SqlDataReaderProcessor : IDataReaderProcessor
    {
        public const string PROVIDER_NAME = "System.Data.SqlClient";

        public SqlDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass 
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            string commandText = "SELECT * FROM dbo.[" + tableName + "]";
            string dataProviderName = PROVIDER_NAME;

            return DbCommonHelper.CreateDataReader(dataProviderName, connectionString, commandText);
        }
    }
}
