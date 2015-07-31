using System.Data;
using Importer.Engine.Models;
using Importer.Engine.Views.Common;

namespace Importer.Engine.Views
{
    public interface IDataViewer : IView
    {
        Table SelectedTable { get; set; }

        DataTable TableData { get; set; }

        int RowsCount { get; set; }
    }
}
