using System.Collections.Generic;

using Escyug.Importer.Data.Metadata;

namespace Escyug.Importer.Data.Processors
{
    public interface IMetadataProcessor
    {
        IEnumerable<Table> SelectTablesMetadata(string connectionString);
    }
}
