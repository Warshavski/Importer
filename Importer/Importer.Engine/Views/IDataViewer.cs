using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Importer.Engine.Views.Common;
using Importer.Engine.Models;

namespace Importer.Engine.Views
{
    public interface IDataViewer : IView
    {
        Table SelectedTable { get; set; }

        DataTable TableData { get; set; }

        int RowsCount { get; set; }

        bool IsLoading { get; set; }
    }
}
