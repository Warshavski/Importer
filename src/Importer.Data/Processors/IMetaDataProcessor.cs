using System.Collections.Generic;

using Escyug.Importer.Data.MetaData;

namespace Escyug.Importer.Data.Processors
{
    public interface IMetaDataProcessor
    {
        IEnumerable<Table> SelectTablesMetaData(string connectionString);
    }
}
