using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public interface IDataImporter
    {
        event Action<string> ImportStatusChanged;

        void Import(IDataInstance source, IDataInstance target, bool truncateTarget);
    }
}
