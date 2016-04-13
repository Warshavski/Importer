using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Models.Services;

namespace Escyug.Importer.Presentations.Presentation
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly SqlDataImportService _importService;
        private readonly 

        public MainPresenter(IMainView view)
        {
            _view = view;

            _view.SourceInstanceLoad  += () => OnSourceLoad();
            _view.DestinationInstanceLoad += () => OnDestinationLoad();
        }

        private void OnSourceLoad()
        {
            
        }

        private void OnDestinationLoad()
        {

        }
    }
}
