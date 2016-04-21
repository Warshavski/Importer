using System;
using System.Collections.Generic;

using Escyug.Importer.Common;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.Presentations.Presenters
{
    public sealed class SqlSetupPresenter : BasePresenter<ISqlSetupView, DataInstance>
    {
        //private readonly DataInstanceService _dataInstanceService;
        private DataInstance _sqlDataInstance;

        public SqlSetupPresenter(IApplicationController controller, ISqlSetupView view) 
            : base(controller, view) 
        {
            //_dataInstanceService = 
            //    DataInstanceServiceCreator.CreateService(Constants.DataInstanceTypes.Sql);

            View.InitializeDataInstance += () => OnInitializeDataInstance();
        }

        public override void Run(DataInstance argument)
        {
            _sqlDataInstance = argument;
            //_sqlDataInstance = argument;
            View.Show();
        }
        
        private void OnInitializeDataInstance()
        {
            _sqlDataInstance.ConnectionString = View.ConnectionString;
            View.Close();   
        }
    }
}
