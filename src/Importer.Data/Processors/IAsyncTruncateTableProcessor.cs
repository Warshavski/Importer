using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IAsyncTruncateTableProcessor
    {
        Task TruncateTableAsync(string connectionString, string targetTableName);
    }
}
