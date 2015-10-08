using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Test.Files;
using Importer.Presentation.Test.Views;

namespace Importer.Presentation.Test.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private const string SOURCE_CONNECTION_STRING =
            @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\Остатки; 
                User ID=Admin; Password=; Extended Properties=dBase 5.0;";
        private const string TARGET_CONNECTION_STRING =
            @"Data Source=localhost; Initial Catalog=rls; Integrated Security=true";

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.DataLoad += () => OnDataLoad();
        }

        private void OnDataLoad()
        { 
            FileFactory factory = new FileFactory();
            _view.FilesList = factory.ProvidersList;

            _view.SourceFile = factory.Create(SOURCE_CONNECTION_STRING, factory.ProvidersList["Dbf"], true);
            _view.TargetFile = factory.Create(TARGET_CONNECTION_STRING, factory.ProvidersList["Sql"], false);
        }
    }
}
