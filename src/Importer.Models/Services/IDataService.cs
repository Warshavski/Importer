using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;

namespace Escyug.Importer.Models.Services
{
    public interface IDataService
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
        IDataReader GetDataReader(string tableName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="destinationTable"></param>
        void ImportData(IDataReader dataReader, string destinationTable);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool TestConnection();
    }
}
