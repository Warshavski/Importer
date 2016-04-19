using System;
using System.Collections.Generic;

using Escyug.Importer.Common;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Presenters
{
    public sealed class SetupPresenter : BasePresenter<ISetupView, DataInstance>
    {
        private readonly DataInstanceService _dataInstanceService;

        private DataInstance _sourceDataInstance;
        
        public SetupPresenter(IApplicationController controller, ISetupView view, 
            DataInstanceService dataInstanceService) 
            : base(controller, view) 
        {
            _dataInstanceService = dataInstanceService;

            View.InitializeDataInstance += () => OnInitializeDataInstance();
        }

        public override void Run(DataInstance argument)
        {
            _sourceDataInstance = argument;
            View.Show();
        }

        private void OnInitializeDataInstance()
        {
            _sourceDataInstance = _dataInstanceService.CreateInstance(View.ConnectionString);

            View.Close();
        }
    }
}
