using System.Data;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    public sealed class SqlDataReaderProcessor : SqlProcessor,
        IDataReaderProcessor
    {
        

        public SqlDataReaderProcessor()
        {

        }

        // (done) - replace implementation to DbHelperClass 
        public IDataReader CreateReader(string tableName, string connectionString)
        {
            string commandText = CreateSelectCommandText(tableName);
            
            return DbCommonHelper.CreateDataReader(PROVIDER_NAME, connectionString, commandText);
        }
    }
}
