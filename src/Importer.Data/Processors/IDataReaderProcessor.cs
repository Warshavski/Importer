using System.Data;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataReaderProcessor
    {
        IDataReader CreateReader(string tableName, string connectionString);
    }
}
