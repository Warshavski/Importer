using System;
using System.Collections.Generic;
using System.Data;

using Escyug.Importer.Common;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataImportProcessor
    {
        event Action<long> RowsCopiedNotify;

        void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName);
        void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName, 
            IEnumerable<ColumnsMapping> columnsMappings);
    }
}
