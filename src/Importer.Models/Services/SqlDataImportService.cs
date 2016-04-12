using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escyug.Importer.Common;
using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public class SqlDataImportService
    {
        private const string TARGET_FILE_TYPE = "sql";

        private ImportRepository _importRepo;

        public SqlDataImportService(string sourceFileType)
        {
            _importRepo = new ImportRepository(sourceFileType, TARGET_FILE_TYPE);
        }

        private string GetTableNameForImport(IEnumerable<Table> tablesList)
        {
            var tableName = string.Empty;
            foreach (var table in tablesList)
            {
                if (table.IsForImport)
                {
                    tableName = table.Name;
                    break;
                }
            }

            return tableName;
        }

        public void Import(IDataInstance sourceInstance, IDataInstance targetInstance)
        {
            var sourceTableName = string.Empty;
            Parallel.ForEach(sourceInstance.Tables, (table) => 
                { 
                    if (table.IsForImport) 
                        sourceTableName = table.Name; 
                });

            var targetTableName = string.Empty;
            Parallel.ForEach(targetInstance.Tables, (table) =>
            {
                if (table.IsForImport)
                    targetTableName = table.Name;
            });

            _importRepo.Import(sourceInstance.ConnectionString, sourceTableName,
                targetInstance.ConnectionString, targetTableName);

        }
    }
}
