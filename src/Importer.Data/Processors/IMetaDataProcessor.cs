using System.Collections.Generic;

using Escyug.Importer.Data.Entities;

namespace Escyug.Importer.Data.Processors
{
    public interface IMetaDataProcessor
    {
        IEnumerable<Table> SelectTablesMetaData(string connectionString);
    }
}
