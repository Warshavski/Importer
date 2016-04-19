using System;
using System.Collections.Generic;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Views
{
    public interface ISetupBuilderView : IView, INestedView
    {
        event Action SelectFileType;

        IEnumerable<ViewModel.FileType> FileTypesList { set; }

        ViewModel.FileType SelectedFileType { get; }
    }
}
