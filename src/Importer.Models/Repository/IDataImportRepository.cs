using System.Collections.Generic;

using Escyug.Importer.Common;

namespace Escyug.Importer.Models.Repository
{
    public interface IDataImportRepository
    {
        void Import(string sourceConnectionString, string sourceTableName,
            string targetConnectionString, string targetTableName);
        void Import(string sourceConnectionString, string sourceTableName,
            string targetConnectionString, string targetTableName, IEnumerable<ColumnsMapping> columnsMappings);
    }
}
