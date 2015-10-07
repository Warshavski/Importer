using Importer.Engine.Models;
using Importer.Engine.Views;

namespace Importer.Engine.Presenters
{
    public class SettingsPresenter
    {
        private ISettingsView _view = null;

        public SettingsPresenter(ISettingsView view)
        {
            _view = view;
            _view.Server = Properties.Settings.Default.Server;
            _view.Catalog = Properties.Settings.Default.Catalog;

            _view.IsWindowsSecurity = Properties.Settings.Default.WIS;
            _view.User = Properties.Settings.Default.User;
            _view.Pass = Properties.Settings.Default.Pass;
        }

        public void TestConnection()
        {
            string mainString = string.Format("Data Source={0}; Initial Catalog={1};", _view.Server, _view.Catalog);

            string extendedString = string.Empty;
            if (_view.IsWindowsSecurity)
                extendedString = string.Format("Integrated Security=True");
            else
                extendedString = string.Format("User={0}; Password={1};", _view.User, _view.Pass);

            string connectionString = string.Format("{0} {1}", mainString, extendedString);

            if (SqlFile.TestConnection(connectionString))
                _view.ShowNoticeMessage("Test connection succeeded");
            else
                _view.ShowErrorMessage("Connection error");
        }

        public void SaveChanges()
        {
            Properties.Settings.Default.Server = _view.Server;
            Properties.Settings.Default.Catalog = _view.Catalog;

            Properties.Settings.Default.WIS = _view.IsWindowsSecurity;

            Properties.Settings.Default.User = _view.User;
            Properties.Settings.Default.Pass = _view.Pass;

            Properties.Settings.Default.Save();

            _view.ShowNoticeMessage("Save complete");
        }
    }
}
