using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IAsyncDataImportProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataReader"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTableName"></param>
        /// <returns></returns>
        Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString, string targetTableName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataReader"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTableName"></param>
        /// <param name="columnsMapping"></param>
        /// <returns></returns>
        Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString,
            string targetTableName, IEnumerable<ColumnsMapping> columnsMapping);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataReader"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTableName"></param>
        /// <param name="columnsMappings"></param>
        /// <param name="rowsCopiedNotify"></param>
        /// <returns></returns>
        Task ImportAsync(IDataReader sourceDataReader, string targetConnectionString,
            string targetTableName, IEnumerable<ColumnsMapping> columnsMappings, Action<long> rowsCopiedNotify);
    }
}
