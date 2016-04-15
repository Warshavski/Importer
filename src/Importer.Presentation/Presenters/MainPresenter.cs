using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

namespace Escyug.Importer.Presentations.Presenters
{
    public class MainPresenter
    {
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

            _view.Initialize += () => OnInitialize();
        }

        #region Helper methods

        private void InitializeSource(Constants.FilesTypes sourceType, string connectionString)
        {
            _sourceDataInstanceService =
                DataInstanceServiceCreator.CreateService(sourceType);

            _sourceDataInstance =
                _sourceDataInstanceService.CreateInstance(connectionString);
        }

        private void InitializeDestination(Constants.FilesTypes destinationType, string connectionString)
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
            
            ChangeOperationStatus("done");
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
                InitializeSource(fileType, connectionString);
            });

            _view.DestinationDataInstance = _sourceDataInstance;

            ChangeOperationStatus("done");
        }

        #endregion
    }
}
