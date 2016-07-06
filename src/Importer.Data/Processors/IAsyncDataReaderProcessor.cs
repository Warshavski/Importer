using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IAsyncDataReaderProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        Task<IDataReader> CreateReaderAsync(string tableName, string connectionString);
    }
}
