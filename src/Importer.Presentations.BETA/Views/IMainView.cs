using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;

using Escyug.Importer.Presentations.BETA.ViewModels;

using Escyug.Importer.Presentations.BETA.Common;


namespace Escyug.Importer.Presentations.BETA.Views
{
    public interface IMainView : IView
    {
        #region General

        event Action InitializeView;
        event Action ExecuteImport;
        
        event Func<Task> ExecuteImportAsync;
        event Func<Task> DeleteDataAsync;

        ICollection<FileType> FileTypes { get; set; }

        int ProgressValue { get; set; }

        bool IsImportExecuting { set; }

        string ApplicationStatus { get; set; }

        #endregion General


        //-------------------------------------------------


        #region Source

        event Action InitializeSource;
        event Func<Task> InitializeSourceAsync;
        event Action SelectSourceTable;

        FileType SourceDataType { get; }
        string SourceConnectionString { get; set; }

        ICollection<Table> SourceMetadata { get; set; }
        Table SelectedSourceTable { get; }
        ICollection<Column> SelectedSourceTableColumns { get; set; }

        ICollection<string> SourceMarkedColumns { get; set; }

        bool IsLoadingSource { get; set; }

        #endregion Source


        //-------------------------------------------------


        #region Destination

        event Action InitializeDestination;
        event Func<Task> InitializeDestinationAsync;
        event Action SelectDestinationTable;

        ICollection<Table> DestinationMetadata { get; set; }
        Table SelectedDestinationTable { get; }
        ICollection<Column> SelectedDestinationTableColumns { get; set; }

        bool IsLoadingDestination { get; set; }

        bool IsTruncateDestinationTable { get; set; }

        #endregion Destination
    }
}
