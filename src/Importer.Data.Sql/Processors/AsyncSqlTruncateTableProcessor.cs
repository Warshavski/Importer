using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql.Processors
{
    public class AsyncSqlTruncateTableProcessor : SqlProcessor,
        IAsyncTruncateTableProcessor
    {
        public async Task TruncateTableAsync(string connectionString, string targetTableName)
        {
            string truncateCommandText = "TRUNCATE TABLE dbo.[" + targetTableName + "]";
            using (var connection = DbCommonHelper.CreateDbConnection(PROVIDER_NAME, connectionString))
            {
                using (var command = DbCommonHelper.CreateCommand(truncateCommandText, connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
