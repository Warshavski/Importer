using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    public class AsyncSqlCustomQueryProcessor : SqlProcessor,
        IAsyncCustomQueryProcessor
    {

        public AsyncSqlCustomQueryProcessor()
        {

        }

        public async Task ExecuteQueryAsync(string query, string connectionString)
        {
            using (var connection = DbCommonHelper.CreateDbConnection(PROVIDER_NAME, connectionString))
            {
                using (var command = DbCommonHelper.CreateCommand(query, connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
