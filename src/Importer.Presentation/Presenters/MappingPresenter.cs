using System;
using System.Threading.Tasks;

using Escyug.Importer.Models;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.Presentations.Presenters
{
    public sealed class MappingPresenter : BasePresenter<IMappingsView, DataInstance>
    {
        private DataInstance _sourceDataInstance;
        private DataInstance _destinationDataInstance;

        public MappingPresenter(IApplicationController controller, IMappingsView view) 
            : base (controller, view)
        {

        }

        public override void Run(DataInstance argument)
        {
            _sourceDataInstance = argument;
            Initialize();
            View.Show();
        }

        private void Initialize()
        {
            View.SourceTablesList = _sourceDataInstance.Tables;
        }
    }
}
