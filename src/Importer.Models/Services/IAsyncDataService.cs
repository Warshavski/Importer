using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;

namespace Escyug.Importer.Models.Services
{
    public interface IAsyncDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Table> GetMetaData();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        Task<IDataReader> GetDataReader(string tableName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="destinationTable"></param>
        Task ImportData(IDataReader dataReader, string destinationTable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="destinationTable"></param>
        /// <param name="columnsMapping"></param>
        Task ImportData(IDataReader dataReader, string destinationTable,
              IEnumerable<Data.ColumnsMapping> columnsMapping);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool TestConnection();
    }
}
