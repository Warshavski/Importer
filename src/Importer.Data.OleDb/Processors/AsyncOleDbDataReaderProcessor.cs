using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    public class AsyncOleDbDataReaderProcessor : OleDbProcessor,
        IAsyncDataReaderProcessor
    {
        public AsyncOleDbDataReaderProcessor()
        {

        }

        public async Task<IDataReader> CreateReaderAsync(string tableName, string connectionString)
        {
            string commandText = CreateSelectCommandText(tableName);
            
            return await DbCommonHelper.CreateDataReaderAsync(PROVIDER_NAME, connectionString, commandText);
        }
    }
}
