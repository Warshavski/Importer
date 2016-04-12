using System;
using System.Data;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataImportProcessor
    {
        event Action<long> RowsCopiedNotify;

        void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName);
    }
}
