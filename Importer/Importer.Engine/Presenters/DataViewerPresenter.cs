using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Models;
using Importer.Engine.Views;
using Importer.Engine.Views.Common;
using System.ComponentModel;
using System.Data;

namespace Importer.Engine.Presenters
{
    public class DataViewerPresenter
    {
        private readonly IDataViewer _view = null;

        BackgroundWorker _backgroundWorker = null;

        BackgroundWork _DoWork;
        WorkCompleted _FinishWork;

        public DataViewerPresenter(IDataViewer view)
        {
            // initialize backgroundWorker
             _backgroundWorker = new BackgroundWorker();

            // set report progress property
            _backgroundWorker.WorkerReportsProgress = true;

            // set DoWork EventHandler
            _backgroundWorker.DoWork +=
              new DoWorkEventHandler(BackgroundWorker_DoWork);
            // set ProgressChanged EventHandler
            _backgroundWorker.ProgressChanged +=
              new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            // set RunWorkerCompleted EventHandler
            _backgroundWorker.RunWorkerCompleted +=
              new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

            _view = view;
        }

        public void LoadData()
        {
            _view.IsLoading = true;

            DataTable data = null;

            _DoWork = delegate
            {
                data = _view.SelectedTable.GetData();
            };

            _FinishWork = delegate
            {
                try
                {
                    _view.TableData = data;
                    _view.TotalRows = data.Rows.Count;
                }
                finally
                {
                    _view.IsLoading = false;
                    _backgroundWorker.Dispose();
                    _backgroundWorker = null;
                }
            };

            if (!_backgroundWorker.IsBusy)
                _backgroundWorker.RunWorkerAsync();
        }

        #region Backgroung worker EventHandlers

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /* This method runs in a background thread.
             * 
             * while (work not done) 
             * {
             *     // Do some work here
             *     _backgroundWorker.ReportProgress(percentage_done, user_state);
             *     
             *     // You don't need to calculate the percentage number if you don't
             *     // need it in BackgroundWorker_ProgressChanged.
             * }
             * // You can set e.Result = to some result;
             */
            _DoWork();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method runs in the UI thread.
            // Report progress using the value e.ProgressPercentage and e.UserState
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This method runs in the UI thread.
            // Work is finished! You can display the work done by using e.Result
            _FinishWork();
        }

        #endregion
    } 
}
