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

        public void Import(DataInstance sourceInstance, DataInstance destinationInstance)
        {
            _importRepo.Import(sourceInstance.ConnectionString, "test1",
                destinationInstance.ConnectionString, "test1");
        }
    }
}
