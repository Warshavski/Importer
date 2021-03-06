﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataImportProcessor
    {
        event Action<long> RowsCopiedNotify;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataReader"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTableName"></param>
        void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataReader"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTableName"></param>
        /// <param name="columnsMapping"></param>
        void Import(IDataReader sourceDataReader, string targetConnectionString, 
            string targetTableName, IEnumerable<ColumnsMapping> columnsMapping);
    }
}
