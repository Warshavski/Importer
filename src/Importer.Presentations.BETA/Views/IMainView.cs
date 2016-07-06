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
        event Action InitializeView;
        event Action ExecuteImport;

        ICollection<FileType> FileTypes { get; set; }

        #region Source

        event Action InitializeSource;
        event Action SelectSourceTable;

        FileType SourceDataType { get; }
        string SourceConnectionString { get; set; }

        ICollection<Table> SourceMetadata { get; set; }
        Table SelectedSourceTable { get; }
        ICollection<Column> SelectedSourceTableColumns { get; set; }

        ICollection<string> SourceMarkedColumns { get; set; }

        #endregion

        #region Desctination

        event Action InitializeDestination;
        event Action SelectDestinationTable;

        ICollection<Table> DestinationMetadata { get; set; }
        Table SelectedDestinationTable { get; }
        ICollection<Column> SelectedDestinationTableColumns { get; set; }

        #endregion
    }
}
