using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;

using Escyug.Importer.Common;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;
using System.Configuration;

namespace Escyug.Importer.Presentations.Presenters
{

   /* NOTE : setup presenter should be created by Application controller.
    *        Application controller should use DI and dependency resolver.
    * 
    *  1. Create DataInsanceService depends on selected file type.
    *  2. Create SetupPresenter and Run it with parameter (DataInstance).
    */

    /* clear form and load new one
     * should depend on selected file type
     */

    //var fileType = View.SelectedFileType.DataInstanceType.Value;
    //Controller.Run<SqlSetupPresenter>();

    public sealed class MainPresenter : BasePresenter<IMainView>
    {
        private List<string> _testConnectionStrings;

        private readonly IDataInstanceService _destinationService;
        
        private DataInstance _sourceDataInstance;
        private DataInstance _destinationDataInstance;

        public MainPresenter(IApplicationController controller, IMainView view)
            : base(controller, view)
        {
            Initialize();

            View.DestinationInitialize += () => OnDestinationInitialize();
            view.DestinationInitializeAsync += () => OnDestinationInitializeAsync();

            View.SourceInitialize += () => OnSourceInitialize();
            View.SourceInitializeAsync += () => OnSourceInitializeAsync();

            View.ImportAsync += () => OnImportAsync();

            _destinationService =
                DataInstanceServiceCreator.CreateService(Constants.DataInstanceTypes.Sql);

            _testConnectionStrings = new List<string>();

            ReadConnectionStringsAsync();
        }

        private async void ReadConnectionStringsAsync()
        {
            var csFilePath = @"C:\test\connectionStrings.txt";
            var connectioStringsList = new List<string>();
            string cs;
            using (var csReader = new StreamReader(csFilePath, Encoding.UTF8))
            {
                while (!csReader.EndOfStream)
                {
                    cs = await csReader.ReadLineAsync();
                    _testConnectionStrings.Add(cs);
                }
            }
        }

        private void Initialize()
        {
            var fileTypesList = new List<ViewModel.FileType>();

            fileTypesList.Add(new ViewModel.FileType(null, "<select file type>"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.Sql, "Sql data instance"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.OleDb, "Dbf file"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.OleDb, "Excel file"));

            View.FileTypesList = fileTypesList;
        }

        private void OnDestinationInitialize()
        {
            _destinationDataInstance = 
                _destinationService.CreateInstance(_testConnectionStrings[1]);

            View.DestinationTablesList = _destinationDataInstance.Tables;
        }

        private async Task OnDestinationInitializeAsync()
        {
            var context = new ViewModel.ConnectionContext(true);

            Controller.Run<SqlSetupPresenter, ViewModel.ConnectionContext>(context);

            if (string.Compare(context.ConnectionString, string.Empty) != 0)
            {
                View.IsDestinationLoad = true;

                await Task.Run(() =>
                {
                    _destinationDataInstance =
                        _destinationService.CreateInstance(context.ConnectionString);
                });

                View.DestinationTablesList = _destinationDataInstance.Tables;

                View.IsDestinationLoad = false;
            }
        }

        private void OnSourceInitialize()
        {
            View.IsSourceLoad = true;

            _sourceDataInstance = 
                _destinationService.CreateInstance(_sourceDataInstance.ConnectionString);

            View.IsSourceLoad = false;

            /* 
            var destinationService =
                DataInstanceServiceCreator.CreateService(Constants.DataInstanceTypes.Sql);

            _sourceDataInstance = destinationService.CreateInstance(@"Data Source=localhost;Initial Catalog=liss;Integrated Security=True;");

            View.SourceTablesList = _sourceDataInstance.Tables;
            */
        }

        private async Task OnSourceInitializeAsync()
        {
            var sourceConnectionContext = new ViewModel.ConnectionContext();

            switch (View.SelectedFileType.Name)
            {
                case "Sql data instance" :
                    Controller.Run<SqlSetupPresenter, ViewModel.ConnectionContext>(sourceConnectionContext);
                    break;
                case "Dbf file" :
                    Controller.Run<ExcelSetupPresenter, ViewModel.ConnectionContext>(sourceConnectionContext);
                    break;
                case "Excel file" :
                    Controller.Run<ExcelSetupPresenter, ViewModel.ConnectionContext>(sourceConnectionContext);
                    break;
                default :
                    View.Error = "Select file type";
                    break;
            }

            if (string.Compare(sourceConnectionContext.ConnectionString, string.Empty) != 0)
            {
                View.IsSourceLoad = true;

                var sourceService = 
                    DataInstanceServiceCreator.CreateService(
                        View.SelectedFileType.DataInstanceType.Value);

                await Task.Run(() =>
                {
                    _sourceDataInstance =
                        sourceService.CreateInstance(
                            sourceConnectionContext.ConnectionString);
                });

                View.SourceTablesList = _sourceDataInstance.Tables;

                View.IsSourceLoad = false;
            }
        }

        private async Task OnImportAsync()
        {
            View.IsImportInProgress = true;

            View.OperationState = "Create mapping";

            var destinationTableName = View.SelectedDestinationTable;
            var sourceTableName = View.SelectedSourceTable;

            var columnsMappings = View.ColumnsMappings;

            var mapping = new Mapping(sourceTableName, destinationTableName, columnsMappings);

            View.OperationState = "Import...";

            var importService =
                new DataImportService(
                    View.SelectedFileType.DataInstanceType.Value, (rows) => { View.RowsCopied = rows; });

            await Task.Run(() =>
            {
                importService.Import(_sourceDataInstance, _destinationDataInstance, mapping);
            });

            View.OperationState = "Import complete";
            View.IsImportInProgress = false;
        }
    }
}


/* Test methods (works pretty well)
        private readonly IMainView _view;

        private DataInstanceService _sourceDataInstanceService;
        private DataInstance _sourceDataInstance;

        private DataInstanceService _destinationInstanceService;
        private DataInstance _destinationInstance;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _view.SourceInstanceLoad += () => OnSourceLoad();
            _view.SourceInstanceLoadAsync += () => OnSourceLoadAsync();

            _view.DestinationInstanceLoadAsync += () => OnDestinationLoadAsync();

            _view.ImportExecuteAsync += () => OnImportExecuteAsync();

            _view.Initialize += () => OnInitialize();
        }

        #region Helper methods

        private void InitializeSource(Constants.DataInstanceTypes sourceType, string connectionString)
        {
            _sourceDataInstanceService =
                DataInstanceServiceCreator.CreateService(sourceType);

            _sourceDataInstance =
                _sourceDataInstanceService.CreateInstance(connectionString);
        }

        private void InitializeDestination(Constants.DataInstanceTypes destinationType, string connectionString)
        {
            _destinationInstanceService =
                DataInstanceServiceCreator.CreateService(destinationType);

            _destinationInstance =
                _sourceDataInstanceService.CreateInstance(connectionString);
        }

        private void ChangeOperationStatus(object statusState)
        {
            _view.OperationStatus = statusState;
        }

        private async void ReadConnectionStringsAsync()
        {
            var csFilePath = @"C:\test\connectionStrings.txt";
            var connectioStringsList = new List<string>();
            string cs;
            using (var  csReader = new StreamReader(csFilePath, Encoding.UTF8))
            {
                while (!csReader.EndOfStream)
                {
                    cs = await csReader.ReadLineAsync();
                    connectioStringsList.Add(cs);
                }
                    
            }
            _view.ConnectionStrings = connectioStringsList;
        }

        #endregion

        #region Events methods

        private void OnInitialize()
        {
            ReadConnectionStringsAsync();

            var filesTypes =  new List<FileType>();

            filesTypes.Add(new FileType(Constants.DataInstanceTypes.Sql, "SQL instance"));
            filesTypes.Add(new FileType(Constants.DataInstanceTypes.OleDb, "OleDb instance"));

            _view.FilesTypes = filesTypes;
        }

        private async Task OnImportExecuteAsync()
        {
            DataImportService importService = new DataImportService(Constants.DataInstanceTypes.Sql);

            await Task.Run(() =>
                {
                    importService.Import(_sourceDataInstance, _destinationInstance);
                });

            ChangeOperationStatus("Import complete");
        }

        private async Task OnSourceLoadAsync()
        {
            var fileType = _view.SelectedSourceType;
            var connectionString = _view.SourceConnectionString;
            
            await Task.Run(() =>
                {
                    InitializeSource(fileType, connectionString);
                });

            _view.SourceDataInstance = _sourceDataInstance;
            
            ChangeOperationStatus("Source metadata load completed");
        }

        private void OnSourceLoad()
        {
            InitializeSource(_view.SelectedSourceType, _view.SourceConnectionString);
         
            _view.SourceDataInstance = _sourceDataInstance;

            ChangeOperationStatus("done");
        }

        private async Task OnDestinationLoadAsync()
        {
            var fileType = _view.SelectedDestinationType;
            var connectionString = _view.DestinationConnectionString;

            await Task.Run(() =>
            {
                InitializeDestination(fileType, connectionString);
            });

            _view.DestinationDataInstance = _destinationInstance;

            ChangeOperationStatus("Destination metadata load completed");
        }

        #endregion
 */