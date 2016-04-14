using System;

using Escyug.Importer.Common;
using Escyug.Importer.Models;


namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView
    {
        Constants.FilesTypes SelectedSourceType { get; }
        string SourceConnectionString { get; }

        DataInstance SourceDataInstance { get; set; }
        DataInstance DestinationDataInstance { get; set; }

        event Action SourceInstanceLoad;
        event Action DestinationInstanceLoad;
    }
}
