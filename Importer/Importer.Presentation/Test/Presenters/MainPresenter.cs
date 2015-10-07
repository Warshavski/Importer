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

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.DataLoad += () => OnDataLoad();
        }

        private void OnDataLoad()
        { 
            FileFactory factory = new FileFactory();
            _view.FilesList = factory.ProvidersList;
        }
    }
}
