using System.Data;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    public class OleDbDataReaderProcessor : IDataReaderProcessor
    {
        private const string PROVIDER_NAME = "System.Data.OleDb";

        public OleDbDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            string commandText = "SELECT * FROM [" + tableName + "]";
            string dataProviderName = PROVIDER_NAME;

            return DbCommonHelper.CreateDataReader(dataProviderName, connectionString, commandText);
        }
    }
}
