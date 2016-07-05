using System.Data;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataReaderProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IDataReader CreateReader(string tableName, string connectionString);
    }
}
