using System;
using System.ComponentModel;
using System.Data;
using Importer.Engine.Models;
using Importer.Engine.Views;

namespace Importer.Engine.Presenters
{
    public class DataViewerPresenter
    {
        private readonly IDataViewer _view = null;
        private readonly Table _selectedTable = null;

        public DataViewerPresenter(IDataViewer view, Table selectedTable)
        {
            _view = view;
            _selectedTable = selectedTable;
        }

        public void LoadData()
        {
            _view.ExecutionStatusText = "Loading data...";
            _view.IsLoading = true;

            var backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += (sender, e) =>
            {
                try
                {
                    e.Result = CommonData.GetData(_selectedTable);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            backgroundWorker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Result is DataTable)
                {
                    _view.TableData = e.Result as DataTable;
                    _view.TotalRows = (e.Result as DataTable).Rows.Count;
                }
                else if (e.Result is Exception)
                {
                    var errorEx = e.Result as Exception;
                    _view.ExecutionStatusText = "Error!";
                    _view.ShowErrorMessage(string.Format("{0}\n{1}\n{2}",
                        errorEx.Message, errorEx.Source, errorEx.StackTrace));
                }
                _view.IsLoading = false;

                backgroundWorker.Dispose();
                backgroundWorker = null;
            };

            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        public void DisposeData()
        {
            //_view.TableData.Dispose();
            _view.TableData = null;
        }
    } 
}



/*
DataTable data = null;

_DoWork = delegate
{
   data = _selectedTable.GetData(); //_view.SelectedTable.GetData();
};

_FinishWork = delegate
{
   try
   {
       _view.TableData = data;
       _view.TotalRows = data.Rows.Count;
   }
   catch (Exception er)
   {
       _view.ExecutionStatusText = "Error!";
       _view.ShowErrorMessage(er.Message + '\n' + er.Source + '\n' + er.StackTrace);
   }
   finally
   {
       _view.IsLoading = false;
       _backgroundWorker.Dispose();
       _backgroundWorker = null;
   }
};
*/