using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public interface IImportable
    {
        void ImportData(GenericInstance source, bool isTruncate);
    }
}
