
using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Presenters
{
    public class DbfSetupPresenter : BasePresenter<IDbfSetupView, ConnectionContext> 
    {
        private ConnectionContext _dbfConnectionContext;

        public DbfSetupPresenter(IApplicationController controller, IDbfSetupView view)
            : base(controller, view)
        {
            View.CreateConnectionString += () => OnCreateConnectionString();
            View.Cancel += () => OnCancel();
        }

        public override void Run(ConnectionContext argument)
        {
            _dbfConnectionContext = argument;
            View.Show();
        }

        private void OnCreateConnectionString()
        {
            _dbfConnectionContext.ConnectionString = View.ConnectionString;
            View.Close();
        }

        private void OnCancel()
        {
            _dbfConnectionContext.ConnectionString = string.Empty;
            View.Close();
        }
    }
}
