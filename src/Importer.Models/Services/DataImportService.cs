using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Common;
using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public class DataImportService
    {
        private readonly IDataImportRepository _importRepo;

        public DataImportService(Constants.FilesTypes sourceFileType)
        {
            _importRepo = ImportRepositoryCreator.Create(sourceFileType);
        }

        // create async method
        public void Import(DataInstance sourceInstance, DataInstance destinationInstance)
        {
            // check tables for import.
            // check colunms for mappings.
            // call import method for each table in source instance.

            foreach (var table in sourceInstance.Tables)
            {
                if (table.IsForImport)
                {
                    var sourceTableName = table.Name;
                    var destinationTableName = table.MappedTableName;

                    var columnsMappings = new List<ColumnsMapping>();
                    foreach (var column in table.Columns)
                    {
                        if (column.IsForImport)
                        {
                            columnsMappings.Add(
                                new ColumnsMapping(column.Name, column.MappedColumnName));
                        }
                    }

                    if (columnsMappings.Equals(null) || columnsMappings.Count == 0)
                        _importRepo.Import(sourceInstance.ConnectionString, sourceTableName,
                            destinationInstance.ConnectionString, destinationTableName);
                    else
                        _importRepo.Import(sourceInstance.ConnectionString, sourceTableName,
                            destinationInstance.ConnectionString, destinationTableName, columnsMappings);
                }
            }
        }
    }
}
