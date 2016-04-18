using System;
using System.Collections.Generic;

using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Views
{
    public interface ISetupView
    {
        event Action Initialize;

        IEnumerable<FileType> FilesTypesList { set; }
    }
}
