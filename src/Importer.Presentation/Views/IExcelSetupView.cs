using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Views
{
    public interface IExcelSetupView : IView, ISetupView
    {
        event Action Initialize;
        
        IEnumerable<PropertyInfo> ExtendedProperties { set; }
    }
}
