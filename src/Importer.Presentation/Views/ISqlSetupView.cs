using System;

using Escyug.Importer.Presentations.Common;

namespace Escyug.Importer.Presentations.Views
{
    public interface ISqlSetupView : IView
    {
        event Action InitializeDataInstance;

        string ConnectionString { get; }
    }
}
