using System.Data;
using Importer.Engine.Models;
using Importer.Engine.Views.Common;

namespace Importer.Engine.Views
{
    public interface IDataViewer : IView, ILoading
    {
        Table SelectedTable { get; set; }

        DataTable TableData { get; set; }

        long TotalRows { get; set; }
    }
}
