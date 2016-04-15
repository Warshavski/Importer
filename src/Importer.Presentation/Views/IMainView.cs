using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Escyug.Importer.Common;
using Escyug.Importer.Models;
using Escyug.Importer.Presentations.ViewModel;



namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView
    {
        IEnumerable<string> ConnectionStrings { set; }
        IEnumerable<FileTypeVM> FilesTypes { set; }

        Constants.FilesTypes SelectedSourceType { get; }
        string SourceConnectionString { get; }
        Table SelectedSourceTable { set; get; }

        Constants.FilesTypes SelectedDestinationType { get; }
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
    }
}
