using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;
using System;

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
        /// <param name="dataReader"></param>
        /// <param name="destinationTable"></param>
        /// <param name="columnsMapping"></param>
        /// <param name="copyNotify"></param>
        /// <returns></returns>
        Task ImportData(IDataReader dataReader, string destinationTable,
              IEnumerable<Data.ColumnsMapping> columnsMapping, Action<long> copyNotify);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        Task TruncateTableAsync(string tableName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool TestConnection();
    }
}
