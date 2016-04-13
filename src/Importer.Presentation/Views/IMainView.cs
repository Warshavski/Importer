using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView
    {
        event Action ConnectionTest;

        string ConnectionString { get; }
        bool ConnectionTestResult { set; }
    }
}
