using System.Data;

namespace Escyug.Importer.Data.Processors
{
    public interface IDataImportProcessor
    {
        void Import(IDataReader sourceDataReader, string targetConnectionString, string targetTableName);
    }
}
