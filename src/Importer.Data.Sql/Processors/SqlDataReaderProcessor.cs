using System.Data;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    internal sealed class SqlDataReaderProcessor : IDataReaderProcessor
    {
        public SqlDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass 
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            string commandText = "SELECT * FROM dbo.[" + tableName + "]";
            string dataProviderName = Constants.ProviderName.SQL_PROVIDER;

            return DbCommonHelper.CreateDataReader(dataProviderName, connectionString, commandText);
        }
    }
}
