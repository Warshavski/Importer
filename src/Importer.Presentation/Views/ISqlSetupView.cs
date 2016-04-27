using System;

using Escyug.Importer.Presentations.Common;

namespace Escyug.Importer.Presentations.Views
{
    public interface ISqlSetupView : IView, ISetupView
    {
        event Action Initialize;
        event Action TestConnection;
    }
}
