using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.BETA.Common;
using Escyug.Importer.Presentations.BETA.Views;
using Escyug.Importer.Presentations.BETA.ViewModels;


namespace Escyug.Importer.Presentations.BETA.Presenters
{
    public sealed class MainPresenter : BasePresenter<IMainView>
    {
        private IDataService _sourceDataService;
        
        public MainPresenter(IMainView view, IApplicationController appController)
            : base(view, appController)
        {
            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            
            var connectionStrings = new List<string>();
            using (var reader = new StreamReader(connectionStringsFilePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    connectionStrings.Add(reader.ReadLine());
                }
            }

            var fileTypes = new FileType[] 
            {
                new FileType("OleDb", DataServicesTypes.OleDb),
                new FileType("MS Sql", DataServicesTypes.Sql),
            };

            View.FileTypes = fileTypes;
            View.SourceConnectionString = connectionStrings[1];


            View.InitializeSource += () => OnInitializeSource();
            View.SelectSourceTable += () => OnSourceTableSelect();
        }

        
        private void OnInitializeSource()
        {
            var connectionString = View.SourceConnectionString.Trim();

            // check connection string on empty data
            var isEmptyConnectionString = (string.Compare(connectionString, string.Empty) == 0);
            if (isEmptyConnectionString)
            {
                View.Error = "Connection string can't be empty";
            }
            else
            {
                //hmm... try to avoid useless data type conversions
                var sourceServiceType = (DataServicesTypes)View.SourceDataType.Type;

                // check availability of connection 
                // create IDataService and load metadata if connection is available
                // show error if connection is not available
                var isConnectionAvailable = _sourceDataService.TestConnection();
                if (isConnectionAvailable)
                {
                    _sourceDataService = DataServiceFactory.Create(sourceServiceType, connectionString);

                    var metadata = _sourceDataService.GetMetaData();
                    View.SourceMetadata = metadata.ToList();
                }
                else
                {
                    View.Error = "Can't initialize connection. Check connection string";
                }
            }
        }

        private void OnSourceTableSelect()
        {
            var tableMetadata = View.SelectedSourceTable;
            View.SelectedSourceTableColumns = tableMetadata.Columns.ToList();
        }

        #region Helper methods (private)

        private IDataService InitializeDataService(string connectionString, FileType fileType)
        {
            // check connection string on empty data
            var isEmptyConnectionString = (string.Compare(connectionString, string.Empty) == 0);
            if (isEmptyConnectionString)
            {
                View.Error = "Connection string can't be empty";
            }
            else
            {
                //hmm... try to avoid useless data type conversions
                var serviceType = (DataServicesTypes)View.SourceDataType.Type;
                var dataService = DataServiceFactory.Create(serviceType, connectionString);

                // check availability of connection 
                // load metadata if connection is available
                // show error if connection is not available
                var isConnectionAvailable = _sourceDataService.TestConnection();
                if (isConnectionAvailable)
                {
                    

                }
                else
                {
                    View.Error = "Can't initialize connection. Check connection string";
                }
            }
        }

        #endregion

    }
}
