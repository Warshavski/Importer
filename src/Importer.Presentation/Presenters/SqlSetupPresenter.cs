using System;
using System.Collections.Generic;
using System.Linq;

using Escyug.Importer.Common;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;
using System.Configuration;

namespace Escyug.Importer.Presentations.Presenters
{
    public sealed class SqlSetupPresenter : BasePresenter<ISqlSetupView, ConnectionContext>
    {
        //private readonly DataInstanceService _dataInstanceService;
        private ConnectionContext _sqlConnectionContext;

        public SqlSetupPresenter(IApplicationController controller, ISqlSetupView view) 
            : base(controller, view) 
        {
            View.Initialize += () => OnInitialize();
            View.CreateConnectionString += () => OnCreateConnectionString();
            View.Cancel += () => OnCancel();
            View.TestConnection += () => OnTestConnetion();
        }

        public override void Run(ConnectionContext argument)
        {
            _sqlConnectionContext = argument;
            View.Show();
        }

        private void OnInitialize()
        {
            
            if (_sqlConnectionContext.IsDestination)
            {
                var settings = ConfigurationManager.AppSettings;

                var source = settings["Source"];
                var catalog = settings["Catalog"];
                var userId = settings["UserID"];
                var password = settings["Password"];

                var isSqlAuth = (string.Compare(userId, string.Empty)==0) ? "false" : "true";

                View.ConnectionString = string.Format("{0}-{1}-{2}-{3}-{4}",
                    isSqlAuth, source, catalog, userId, password);
            }
            // read connection data from file if is source
        }

        private void OnCreateConnectionString()
        {
            _sqlConnectionContext.ConnectionString = View.ConnectionString;
            if (_sqlConnectionContext.IsDestination)
            {
                // write to config file
            }

            View.Close();   
        }

        private void OnCancel()
        {
            _sqlConnectionContext.ConnectionString = string.Empty;
            View.Close();
        }

        private void OnTestConnetion()
        {
            View.Error = "Not implemented. I don't know how to implement, for now";
        }
    }
}
