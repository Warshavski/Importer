using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

namespace Escyug.Importer.Presentations.Presentation
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        
        private DataInstanceService _sourceDataInstanceService;

        private DataInstance _sourceDataInstance;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.SourceInstanceLoad += () => OnSourceLoad();
        }

        private void OnSourceLoad()
        {
            _sourceDataInstanceService = 
                DataInstanceServiceCreator.CreateService(_view.SelectedSourceType);

            _sourceDataInstance = 
                _sourceDataInstanceService.CreateInstance(_view.SourceConnectionString);

            _view.SourceDataInstance = _sourceDataInstance;
        }

        private void OnDestinationLoad()
        {

        }
    }
}
