using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Models;

namespace Escyug.Importer.Presentations.Presentation
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.ConnectionTest += () => OnConnectionTest();
        }

        private void OnConnectionTest()
        {
            var sqlDataInstance = DataInstanceCreator.CreateInstance(Constants.FilesTypes.Sql, _view.ConnectionString);
            _view.ConnectionTestResult = sqlDataInstance.TestConnection();
        }
    }
}
