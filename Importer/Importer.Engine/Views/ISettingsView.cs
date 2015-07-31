using Importer.Engine.Views.Common;

namespace Importer.Engine.Views
{
    /// <summary>
    ///     interface for settings view
    /// </summary>
    public interface ISettingsView : IView
    {
        /* Connection string for SQL Server
         * Initialize from app.config
         * 
         */
        string Server { get; set; }
        string Catalog { get; set; }
        string User { get; set; }
        string Pass { get; set; }

        bool IsWindowsSecurity { get; set; }
        bool IsLoading { get; set; }
    }
}
