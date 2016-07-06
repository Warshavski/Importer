using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    public class AsyncSqlDataReaderProcessor : SqlProcessor, 
        IAsyncDataReaderProcessor
    {
        public AsyncSqlDataReaderProcessor()
        {

        }

        public async Task<IDataReader> CreateReaderAsync(string tableName, string connectionString)
        {
            var commandText = CreateSelectCommandText(tableName);

            return await DbCommonHelper.CreateDataReaderAsync(PROVIDER_NAME, connectionString, commandText);
        }
    }
}
