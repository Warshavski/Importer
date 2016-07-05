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
        event Action InitializeSource;

        event Action SelectSourceTable;

        ICollection<FileType> FileTypes { get; set; }

        FileType SourceDataType { get; }

        string SourceConnectionString { get; set; }

        ICollection<Table> SourceMetadata { get; set; }

        Table SelectedSourceTable { get; }

        ICollection<Column> SelectedSourceTableColumns { get; set; }
    }
}
