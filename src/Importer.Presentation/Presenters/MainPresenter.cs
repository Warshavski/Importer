using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Escyug.Importer.Common;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.Presentations.Presenters
{
    public sealed class MainPresenter : BasePresenter<IMainView>
    {
        public MainPresenter(IApplicationController controller, IMainView view)
            : base(controller, view)
        {
            Initialize();

            View.SelectFileType += () => OnSelectFileType();
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

        private void OnSelectFileType()
        {
            /* NOTE : setup presenter should be created by Application controller.
             *        Application controller should use DI and dependency resolver.
             * 
             *  1. Create DataInsanceService depends on selected file type.
             *  2. Create SetupPresenter and Run it with parameter (DataInstance).
             */
            var fileType = View.SelectedFileType.DataInstanceType.Value;

            // clear form and load new one
            // should depend on selected file type
            Controller.Run<SqlSetupPresenter>();
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