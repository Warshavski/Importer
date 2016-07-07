using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IAsyncCustomQueryProcessor
    {
        Task ExecuteQueryAsync(string query, string connectionString);
    }
}
