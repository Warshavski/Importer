using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Presenters
{
    public class SetupPresenter
    {
        private readonly ISetupView _view;

        public SetupPresenter(ISetupView view)
        {
            _view = view;

            _view.Initialize += () => OnInitialize();
        }

        private void OnInitialize()
        {
            // separate factory class 
            var filesTypes = new List<FileType>();

            filesTypes.Add(new FileType(null, "<select source type>"));
            filesTypes.Add(new FileType(Constants.DataInstanceTypes.OleDb, "Dbf"));
            filesTypes.Add(new FileType(Constants.DataInstanceTypes.OleDb, "Excel"));
            filesTypes.Add(new FileType(Constants.DataInstanceTypes.Sql, "Sql"));

            _view.FilesTypesList = filesTypes;
        }
    }
}
