using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public class TargetInstance
    {
        private readonly IDataInstance _targetInstance;
        private readonly IDataImporter _importer;

        public TargetInstance(IDataInstance dataInstance, IDataImporter importer)
        {
            _targetInstance = dataInstance;
            _importer = importer;

            _targetInstance.Initialize();
        }

        // ?? use SourceInstance instead of IDataInstance
        public void ImportData(IDataInstance source, bool truncate)
        {
            _importer.Import(source, _targetInstance, truncate);
        }
    }
}
