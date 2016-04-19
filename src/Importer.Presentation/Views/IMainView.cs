using System;
using System.Collections.Generic;

using Escyug.Importer.Common;

using Escyug.Importer.Models;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView : IView
    {
        event Action SelectFileType;

        IEnumerable<ViewModel.FileType> FileTypesList { set; }

        ViewModel.FileType SelectedFileType { get; }
    }
}


/* Test members 
 * NOTE : see MainPresenter.cs comments "Test methods"
        IEnumerable<string> ConnectionStrings { set; }
        IEnumerable<FileType> FilesTypes { set; }

        Constants.DataInstanceTypes SelectedSourceType { get; }
        string SourceConnectionString { get; }
        Table SelectedSourceTable { set; get; }

        Constants.DataInstanceTypes SelectedDestinationType { get; }
        string DestinationConnectionString { get; }

        object OperationStatus { set; }

        DataInstance SourceDataInstance { get; set; }
        DataInstance DestinationDataInstance { get; set; }

        event Action SourceInstanceLoad;
        event Func<Task> SourceInstanceLoadAsync;

        event Action DestinationInstanceLoad;
        event Func<Task> DestinationInstanceLoadAsync;

        event Action ImportExecute;
        event Func<Task> ImportExecuteAsync;

        event Action Initialize;
 */