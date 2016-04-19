
using System.Collections.Generic;

using Escyug.Importer.Models;
using Escyug.Importer.Presentations.Common;

namespace Escyug.Importer.Presentations.Views
{
    public interface IMappingsView : IView
    {
        IEnumerable<Table> SourceTablesList { set; }
    }
}
