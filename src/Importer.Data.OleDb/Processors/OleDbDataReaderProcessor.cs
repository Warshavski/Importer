using System.Data;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    public class OleDbDataReaderProcessor : OleDbProcessor,
        IDataReaderProcessor
    {
        public OleDbDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            var commandText = CreateSelectCommandText(tableName);

            return DbCommonHelper.CreateDataReader(PROVIDER_NAME, connectionString, commandText);
        }
    }
}
