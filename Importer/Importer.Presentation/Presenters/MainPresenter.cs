using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using Importer.Engine.Models;
using Importer.Engine.Models.Importers;
using Importer.Engine.Views;
using Importer.Engine.Views.Common;
using System.IO;

namespace Importer.Engine.Presenters
{
    /* TODO : 
    * 1.- done - Create delegate for BackgroundWorker 
    * 2.- done - Create method that initialize Sql server instance
    * 3.- done - Create method that select tables from Sql server
    * 4.- done - Create method that select columns from Sql table
    * 5.- done - Create import method
    * 6. Refactoring (go harder)
    * 7.- done - Do something with backgroundWorker and delegates (rework)
    *       - done - 7.1. Separate backgroudWorkers for each async operation
    *       - done - 7.1. All backgroudWorkers as anonymous methods
    * 8. Add loading target file types 
    */

    /// <summary>
    /// presenter for main view
    /// </summary>
    public class MainPresenter
    {
        private delegate void AbortProcess();

        private AbortProcess _Abort;
        private CopyProgress _ChangeProgressStatus;

        private const bool IS_SOURCE = true;

        // instace of IMainView interface
        private readonly IMainView _view;

        // Main constructor
        public MainPresenter(IMainView view)
        {
            _view = view;
        }

        // load list of supported source files
        public void LoadFileTypesList()
        {
            // create list of supported source files
            List<ICreator> listOfFiles = new List<ICreator>()
            {
                // excel files
                new ExcelCreator(),
                // dbf files
                new DbfCreator(),
            };

            // bind list of supported source file to view container
            _view.FileTypesList = listOfFiles;
        }

        // load extended properties for each class that implement ICreator interface
        public void LoadExtendedProperties()
        {
            // bind extended properties to view container
            _view.ExtendedProperties = _view.SelectedSourceFileType.GetProperties();
        }

        public FileBrowse GetFileBrowser()
        {
            // return type of file browser
            return _view.SelectedSourceFileType.FileBrowse;
        }

        // initialize source file (from what we import data)
        public void InitializeSourceFile()
        {
            // create instance of file 
            IFile file = _view.SelectedSourceFileType.CreateInstance(
                    _view.FilePath, _view.SelectedProperty);
            try
            {
                // test connection
                if (file.TestConnection())
                {
                    file.InitializeTables(IS_SOURCE);
                    _view.SourceTablesList = file.TableList;
                }
                else
                {
                    // hmmmm...
                    _view.ShowErrorMessage(file.ConnectionString);
                    //_view.ShowErrorMessage(
                    //string.Format("Connection error\n{0}\n{1}", e.Message, e.Source));
                }
            }
            finally
            {
                // delete link to file instance
                file = null;
            }
        }

        // TODO : rebuild (still too ugly)
        public void LoadTargetTables()
        {
            // prepare UI for background load
            _view.ExecutionStatusText = "Loading target tables list...";
            _view.ProgressBarStyle = ProgressStyle.Marguee;
            _view.IsLoading = true;

            // create backgroungWorker instance
            var backgroungWork = new BackgroundWorker();
            //backgroungTest.WorkerReportsProgress = true;

            // set backgroundWorker event handlers using lambda expression
            backgroungWork.DoWork += (sender, e) =>
            {
                // create SqlCreator
                SqlCreator creator = null;

                // create IFile instance
                IFile sqlFile = null;

                try
                {
                   /* create main connection string
                    * TODO : work with connection strings replace to Engine
                    * ************************ !!! WARNING !!! !!! NOT SAFE !!! ************************
                    *                                                                                  *
                    *   Persist Security Info=True; - but with this option GetData() method can work   *
                    *                                                                                  *
                    * ************************ !!! WARNING !!! !!! NOT SAFE !!! ************************/
                    string connectionString = string.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User={2}; Password={3};",
                                Properties.Settings.Default.Server, Properties.Settings.Default.Catalog, Properties.Settings.Default.User, Properties.Settings.Default.Pass);

                    // iitilize creator
                    creator = new SqlCreator();

                    // get creator properties
                    PropertyInfo[] properties = creator.GetProperties();

                    // if windows security
                    if (Properties.Settings.Default.WIS)
                        // initialize sqlFile by creator with windows security property
                        sqlFile = creator.CreateInstance(
                            connectionString, properties[0]);
                    else
                        sqlFile = creator.CreateInstance(
                            connectionString, properties[1]);

                    // initialize sqlFile tables
                    sqlFile.InitializeTables(!IS_SOURCE);
                    e.Result = sqlFile.TableList;
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
                finally
                {
                    creator = null;
                    sqlFile = null;
                }
            };

            backgroungWork.RunWorkerCompleted += (sender , e) => 
            {
                if (e.Result is List<Table>)
                {
                    _view.TargetTablesList = e.Result as List<Table>;
                    _view.ExecutionStatusText = "Done";
                }
                else
                {
                    _view.ExecutionStatusText = "Error";
                    //TODO : ?? StringBuilder insted of string.Format ??
                    var errorEx = e.Result as Exception;
                    _view.ShowErrorMessage(string.Format("{0}\n{1}\n{2}",
                        errorEx.Message, errorEx.Source, errorEx.StackTrace));
                }
                _view.IsLoading = false;

                backgroungWork.Dispose();
                backgroungWork = null;
            };

            // check if backgroundWorker is already running
            if (!backgroungWork.IsBusy)
                // start backgroungWorker
                backgroungWork.RunWorkerAsync();
        }

        public void LoadSourceColumns()
        {
            // if selected source table is not empty table
            if (_view.SelectedSourceTable != Table.EmptyTable)
                // bind source file columns to view container
                _view.SourceTableColumnsList = _view.SelectedSourceTable.Columns;
        }

        public void LoadTargetColumns()
        {
            if (_view.SelectedTargetTable != Table.EmptyTable)
                // bind target file columns to view container
                _view.TargetTableColumnsList = _view.SelectedTargetTable.Columns;
        }

        public void Import()
        {
            _view.ExecutionStatusText = "Import in progress...";
            _view.ProgressBarStyle = ProgressStyle.Blocks;
            _view.IsLoading = true;

            var backgroungTest = new BackgroundWorker();
            backgroungTest.WorkerSupportsCancellation = true;
           

            SqlCopy importer = null;
            
            _ChangeProgressStatus = (rowsCopied, rowsTotal) =>
            {
                _view.ExecutionStatusValue = (int)(rowsCopied * 100 / rowsTotal);
            };

            backgroungTest.DoWork += (sender, e) =>
            {
                try
                {
                    importer = new SqlCopy(_ChangeProgressStatus);
                    importer.Import(_view.SelectedSourceTable, _view.SelectedTargetTable,
                            _view.Mappings.ToArray(), _view.IsTruncate);

                    e.Result = true;
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
                finally
                {
                    importer = null;
                }
            };

            backgroungTest.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Result is bool)
                {
                    _view.ExecutionStatusText = "Import complete!";
                    _view.ShowNoticeMessage("Import complete!");
                }
                else if (e.Result is Exception)
                {
                    var errorEx = e.Result as Exception;
                    _view.ShowErrorMessage(string.Format("{0}\n{1}\n{2}",
                        errorEx.Message, errorEx.Source, errorEx.StackTrace));
                }
                else if (e.Cancelled)
                {
                    _view.ExecutionStatusText = "Import canceled";
                }
               
                _view.IsLoading = false;
                _view.ExecutionStatusValue = 0;

                backgroungTest.Dispose();
                backgroungTest = null;
            };

            /* this throw exception
             * TODO : fix it */ 
            _Abort = () =>
            {
                if (backgroungTest.IsBusy)
                {
                    importer.Abort = true;
                    backgroungTest.CancelAsync();
                }
            };

            if (!backgroungTest.IsBusy)
                backgroungTest.RunWorkerAsync();
        }

        public void Abort()
        {
            _Abort();
        }
    }
}

/* Table data loading
      private DataTable _dtTableData = null;
      // loading data from selected source table
      public void LoadTableData()
      {
          // initialize BackgroungWorker instance
          InitializeBackgroundWorker();

          // add function to backgroung work delegate
          _DoWork = delegate
              {
                  _dtTableData = _view.SelectedTable.GetData();
              };

          // add  function to delegate
          _FinishWork = delegate
              {
                  _view.IsLoading = false;

                  _dtTableData.Dispose();
                  _dtTableData = null;

                  _backgroundWorker.Dispose();
                  _backgroundWorker = null;
              };

          // if BackgroungWorker instance is not running
          if (!_backgroundWorker.IsBusy)
          {
              // set view property for controls while opetation is executing
              // (hide some controls, set enable, etc...)
              _view.IsLoading = true;

              // start the BackgroundWorker
              _backgroundWorker.RunWorkerAsync();
          }
      }
      */