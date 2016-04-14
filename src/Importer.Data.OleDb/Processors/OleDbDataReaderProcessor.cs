using System.Data;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    public class OleDbDataReaderProcessor : IDataReaderProcessor
    {
        public OleDbDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            string commandText = "SELECT * FROM [" + tableName + "]";
            string dataProviderName = Constants.ProviderName.OLEDB_PROVIDER;

            return DbCommonHelper.CreateDataReader(dataProviderName, connectionString, commandText);
        }
    }
}
