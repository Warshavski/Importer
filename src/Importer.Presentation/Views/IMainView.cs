using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Models;
using System.Threading.Tasks;


namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView
    {
        IEnumerable<string> ConnectionStrings { set; }

        Constants.FilesTypes SelectedSourceType { get; }
        string SourceConnectionString { get; }

        Constants.FilesTypes SelectedDestinationType { get; }
        string DestinationConnectionString { get; }

        object OperationStatus { set; }

        DataInstance SourceDataInstance { get; set; }
        DataInstance DestinationDataInstance { get; set; }

        event Action SourceInstanceLoad;
        event Func<Task> SourceInstanceLoadAsync;

        event Action DestinationInstanceLoad;
        event Func<Task> DestinationInstanceLoadAsync;

        event Action Initialize;
    }
}
