using System;
using System.Collections.Generic;
using System.Configuration;
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
        private IDataService _destinationDataService;

        private IAsyncDataService _asyncSourceDataService;
        private IAsyncDataService _asyncDestinationDataService;

        public MainPresenter(IMainView view, IApplicationController appController)
            : base(view, appController)
        {
            View.InitializeView += () => OnInitializeView();
            View.ExecuteImport += () => OnExecuteImport();
            View.ExecuteImportAsync += () => OnExecuteImportAsync();
            View.DeleteDataAsync += () => OnDeleteDataAsync();

            View.InitializeSource += () => OnInitializeSource();
            View.InitializeSourceAsync += () => OnInitializeSourceAsync();
            View.SelectSourceTable += () => OnSourceTableSelect();

            View.InitializeDestination += () => OnInitializeDestination();
            View.InitializeDestinationAsync += () => OnInitializeDestinationAsync();
            View.SelectDestinationTable += () => OnDestinationTableSelect();
        }


        #region General 

        private void OnInitializeView()
        {
            var fileTypes = new FileType[] 
            {
                new FileType("OleDb", DataServicesTypes.OleDb),
                new FileType("MS Sql", DataServicesTypes.Sql),
            };

            View.FileTypes = fileTypes;
        }


        private void OnExecuteImport()
        {
            var sourceTableName = View.SelectedSourceTable.Name;
            var sourceColumnsNames = View.SourceMarkedColumns;

            var destinationTableName = View.SelectedDestinationTable.Name;
            var destinationColumnsNames =
                ColumnsNamesFromColumnsData(View.SelectedDestinationTable.Columns);

            var mappings = CreateMappings(sourceColumnsNames, destinationColumnsNames);

            using (var sourceDataReader = _sourceDataService.GetDataReader(sourceTableName))
            {
                _destinationDataService.ImportData(sourceDataReader, destinationTableName, mappings);
            }

            View.Error = "Done";
        }

        private async Task OnExecuteImportAsync()
        {
            var sourceTableName = View.SelectedSourceTable.Name;
            var sourceColumnsNames = View.SourceMarkedColumns;

            var destinationTableName = View.SelectedDestinationTable.Name;
            var destinationColumnsNames =
                ColumnsNamesFromColumnsData(View.SelectedDestinationTable.Columns);

            var mappings = CreateMappings(sourceColumnsNames, destinationColumnsNames);

            var totalRows = View.SelectedSourceTable.RowsCount;

            var isTruncate = View.IsTruncateDestinationTable;
            

            View.ProgressValue = 0;

            View.ApplicationStatus = "Import in progress...";
            View.IsImportExecuting = true;

            //*** eeem... what?!
            await Task.Run(async () =>
                {
                    if (isTruncate)
                    {
                        await _asyncDestinationDataService.TruncateTableAsync(destinationTableName);
                    }
                    using (var sourceDataReader = await _asyncSourceDataService.GetDataReader(sourceTableName))
                    {
                        await _asyncDestinationDataService.ImportData(
                            sourceDataReader, destinationTableName, mappings, 
                            (rowsCopied) => 
                                {
                                    View.ProgressValue = (int)((100 * rowsCopied) / totalRows);
                                });
                    }
                });

            View.ApplicationStatus = "Import is completed!";
            View.Notify = "Import successfully completed!";
            View.IsImportExecuting = false;
        }

        private async Task OnDeleteDataAsync()
        {
            var sourceTableName = View.SelectedSourceTable.Name;
            var destinationTableName = View.SelectedDestinationTable.Name;

            await Task.Run(async () =>
            {
                using (var sourceDataReader = await _asyncSourceDataService.GetDataReader(sourceTableName))
                {
                    await _asyncDestinationDataService.DeleteTableDataAsync(
                        sourceDataReader, destinationTableName);
                }
            });

            View.Notify = "Data delete completed!";
        }

        #endregion General


        //-------------------------------------------------


        #region Source

        private void OnInitializeSource()
        {
            var sourceConnectionString = View.SourceConnectionString.Trim();
            //*** check for correct file type
            var sourceFileType = View.SourceDataType;

            /***
             * if source was uploaded already and an error has occurred
             * should DataService be reseted (set to null)?
             */
            _sourceDataService = CreateDataService(sourceConnectionString, sourceFileType);
            if (_sourceDataService != null)
            {
                View.IsLoadingSource = true;
                View.SourceMetadata = LoadMetadata(_sourceDataService);
                View.IsLoadingSource = false;
            }
        }

        private async Task OnInitializeSourceAsync()
        {
            var sourceConnectionString = View.SourceConnectionString.Trim();
            //*** check for correct file type
            var sourceFileType = View.SourceDataType;

            /***
             * if source was uploaded already and an error has occurred
             * should DataService be reseted (set to null)?
             */
            _asyncSourceDataService = CreateAsyncDataService(sourceConnectionString, sourceFileType);
            if (_asyncSourceDataService != null)
            {
                View.IsLoadingSource = true;

                ICollection<Data.Metadata.Table> metadata =
                   await LoadMetadataAsync(_asyncSourceDataService);

                View.SourceMetadata = metadata;

                View.IsLoadingSource = false;
            }
        }

        private void OnSourceTableSelect()
        {
            var tableMetadata = View.SelectedSourceTable;
            View.SelectedSourceTableColumns = tableMetadata.Columns.ToList();
        }

        #endregion Source


        //-------------------------------------------------


        #region Destination

        private void OnInitializeDestination()
        {
            var destinationConnectionString =
                ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            var destinationFileType = new FileType("ms sql", DataServicesTypes.Sql);

            /***
             * if source was uploaded already and an error has occurred
             * should DataService be reseted (set to null)?
             */
            _destinationDataService = CreateDataService(destinationConnectionString, destinationFileType);
            if (_destinationDataService != null)
            {
                View.IsLoadingDestination = true;
                View.DestinationMetadata = LoadMetadata(_destinationDataService);
                View.IsLoadingDestination = false;
            }
        }

        // doesn't block UI
        private async Task OnInitializeDestinationAsync()
        {
            var destinationConnectionString =
                ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            var destinationFileType = new FileType("ms sql", DataServicesTypes.Sql);

            /***
             * if source was uploaded already and an error has occurred
             * should DataService be reseted (set to null)?
             */
            _asyncDestinationDataService = CreateAsyncDataService(destinationConnectionString, destinationFileType);
            if (_asyncDestinationDataService != null)
            {
                View.IsLoadingDestination = true;
                
                ICollection<Data.Metadata.Table> metadata =
                    await LoadMetadataAsync(_asyncDestinationDataService);

                View.DestinationMetadata = metadata;
                View.IsLoadingDestination = false;
            }
        }


        private void OnDestinationTableSelect()
        {
            var tableMetadata = View.SelectedDestinationTable;
            View.SelectedDestinationTableColumns = tableMetadata.Columns.ToList();
        }

        #endregion Destination


        //-------------------------------------------------



        #region Helper methods (private)

        /// <summary>
        /// Check connection string and creates IDataService instance.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private IDataService CreateDataService(string connectionString, FileType fileType)
        {
            var isEmptyConnectionString = (string.Compare(connectionString, string.Empty) == 0);
            if (!isEmptyConnectionString)
            {
                // hmm... try to avoid useless data type conversions
                var dataServiceType = (DataServicesTypes)fileType.Type;
                var dataService = DataServiceFactory.Create(dataServiceType, connectionString);

                return dataService;
            }
            else
            {
                View.Error = "Connection string can't be empty.";
                return null;
            }
        }

        private IAsyncDataService CreateAsyncDataService(string connectionString, FileType fileType)
        {
            var isEmptyConnectionString = (string.Compare(connectionString, string.Empty) == 0);
            if (!isEmptyConnectionString)
            {
                // hmm... try to avoid useless data type conversions
                var dataServiceType = (DataServicesTypes)fileType.Type;
                var dataService = DataServiceFactory.CreateAsync(dataServiceType, connectionString);

                return dataService;
            }
            else
            {
                View.Error = "Connection string can't be empty.";
                return null;
            }
        }

        /// <summary>
        /// Check connection availability and loads metadata from IDataService
        /// </summary>
        /// <param name="dataService">IDataService instance</param>
        /// <returns>Collection of tables metadata</returns>
        private ICollection<Data.Metadata.Table> LoadMetadata(IDataService dataService)
        {
            // check availability of connection 
            // create IDataService and load metadata if connection is available
            // show error if connection is not available
            var isConnectionAvailable = dataService.TestConnection();
            if (isConnectionAvailable)
            {
                var metadata = dataService.GetMetaData();
                return metadata.ToList();
            }
            else
            {
                View.Error = "Can't initialize connection. Check connection string.";
                return null;
            }
        }

        private async Task<ICollection<Data.Metadata.Table>> LoadMetadataAsync(IAsyncDataService dataService)
        {
            // check availability of connection 
            // create IDataService and load metadata if connection is available
            // show error if connection is not available
            var isConnectionAvailable = dataService.TestConnection();
            if (isConnectionAvailable)
            {
                IEnumerable<Data.Metadata.Table> metadata = null;
                await Task.Run(() =>
                    {
                        metadata = dataService.GetMetaData();
                    });
                return metadata.ToList();
            }
            else
            {
                View.Error = "Can't initialize connection. Check connection string.";
                return null;
            }
        }

        private string ConnectionStringFromConfig()
        {
            //var rootFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            //var configPath = rootFolderPath + "\\" + "App.config";
            throw new NotImplementedException();
        }


        private ICollection<string> ColumnsNamesFromColumnsData(IEnumerable<Data.Metadata.Column> columns)
        {
            var columnsNames = new List<string>();
            foreach (var column in columns)
            {
                columnsNames.Add(column.Name);
            }

            return columnsNames;
        }

        private IEnumerable<Data.ColumnsMapping> CreateMappings(ICollection<string> sourceColumnsNames, 
            ICollection<string> destinationColumnsNames)
        {
            var mappings = new List<Data.ColumnsMapping>();
            for (int i = 0; i < sourceColumnsNames.Count; ++i)
            {
                if (string.Compare(sourceColumnsNames.ElementAt(i), string.Empty) != 0)
                {
                    var mapping =
                        new Data.ColumnsMapping(
                            sourceColumnsNames.ElementAt(i), destinationColumnsNames.ElementAt(i));

                    mappings.Add(mapping);
                }
            }

            return mappings;
        }
        
        #endregion

    }
}
