using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public class Target : IImportable
    {
        private readonly IDataInstance _dataInstance;
        private readonly IImporter _importer;

        public Target(IDataInstance dataInstance, IImporter importer)
        {
            _dataInstance = dataInstance;
            _importer = importer;
        }

        public void ImportData(IDataInstance source, bool truncate)
        {
            _importer.Import(source, _dataInstance, truncate);
        }

        public void ImportData(GenericInstance source, bool isTruncate)
        {
            throw new NotImplementedException();
        }
    }
}
