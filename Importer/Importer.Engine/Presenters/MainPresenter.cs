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
    * 7. Do something with backgroundWorker and delegates (rework)
    *    7.1. Separate backgroudWorkers for each async operation
    *    7.1. All backgroudWorkers as anonymous methods
    */

    /// <summary>
    /// presenter for main view
    /// </summary>
    public class MainPresenter
    {
        #region Delegates

        //delegate object BackgroundWork();
        //delegate void WorkCompleted();

        //private WorkCompleted _FinishWork;
        //private CopyProgress _ChangeProgressStatus;

        #endregion

        private const bool IS_SOURCE = true;

        // instace of IMainView interface
        private readonly IMainView _view;

        //private BackgroundWork _DoWork;

        // Main constructor
        public MainPresenter(IMainView view)
        {
            _view = view;
            //_DoWork = null;
            //_FinishWork = null;
        }

        /* TODO : Add loading targer file types */
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
                }
            }
            // catch connection exception
            catch (DbException e)
            {
                // show error message in view
                _view.ShowErrorMessage(
                    string.Format("Connection error\n{0}\n{1}", e.Message, e.Source));
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
            // initialize backgroundWorker
            //InitializeBackgroundWorker();

            // create SqlCreator
            SqlCreator creator = null;

            // create IFile instance
            IFile sqlFile = null;

            _view.ExecutionStatusText = "Loading target tables list...";
            _view.ProgressBarStyle = ProgressStyle.Marguee;
            _view.IsLoading = true;
            //_view.IsBlocks = false;

            var backgroungTest = new BackgroundWorker();
            //backgroungTest.WorkerReportsProgress = true;
            
            backgroungTest.DoWork += (sender, e) =>
            {
                try
                {
                    /* create main connection string
                    * ************************ !!! WARNING !!! !!! NOT SAFE !!! ************************
                    *                                                                                  *
                    *   Persist Security Info=True; - but with this option GetData() method can work   *
                    *                                                                                  *
                    * ************************ !!! WARNING !!! !!! NOT SAFE !!! ************************
                    * 
                    * ----------------------------------------------------------------------------------
                    * 
                    * TODO : (think how to rebuild Table class, m.b. exclude GetData() method)  
                    * 
                    *************************************************************************************/
                    // replace to Engine
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

            backgroungTest.RunWorkerCompleted += (sender , e) => 
            {
                if (e.Result is List<Table>)
                {
                    _view.TargetTablesList = e.Result as List<Table>;
                    _view.ExecutionStatusText = "Done";
                }
                else
                {
                    _view.ExecutionStatusText = "Error";
                    //?? StringBuilder insted of string.Format ??
                    var errorEx = e.Result as Exception;
                    _view.ShowErrorMessage(string.Format("{0}\n{1}\n{2}",
                        errorEx.Message, errorEx.Source, errorEx.StackTrace));
                }
                _view.IsLoading = false;

                backgroungTest.Dispose();
                backgroungTest = null;
            };

            if (!backgroungTest.IsBusy)
                // start backgroungWorker
                backgroungTest.RunWorkerAsync();
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

        SqlCopy importer;
        public void Import()
        {
            /* Under reconstruction
             * 
            // initialize backgroundWorker
            InitializeBackgroundWorker();

            _ChangeProgressStatus = delegate(long rowsCopied, long rowsTotal)
            {
                _view.ExecutionStatusValue = (int)(rowsCopied * 100 / rowsTotal);
                //_view.ExecutionStatusText = string.Format("Loaded : {0} of {1}", rowsCopied, rowsTotal);
            };

            importer = new SqlCopy(_ChangeProgressStatus);

            _view.ExecutionStatusText = "Import in progress...";
            _view.ProgressBarStyle = ProgressStyle.Blocks;
            _view.IsLoading = true;

            _DoWork = delegate
            {
                try
                {
                    //SqlCopy importer = new SqlCopy(_ChangeProgressStatus);
                    importer.Import(_view.SelectedSourceTable, _view.SelectedTargetTable,
                        _view.Mappings.ToArray(), _view.IsTruncate);
                    return true;
                }
                catch (Exception ex)
                {
                    return ex;
                }
                finally
                {
                    //_mappings.Clear();
                }
            };

           
            if (!_backgroundWorker.IsBusy)
                // start backgroungWorker
                _backgroundWorker.RunWorkerAsync();
            */

            /*
           _FinishWork = delegate
           {
               _view.ExecutionStatusText = "Import complete!";
               _view.ShowNoticeMessage("Done!");
               _view.IsLoading = false;
               _view.ExecutionStatusValue = 0;

               // dispose backgroungWorker instance
               _backgroundWorker.Dispose();
               // delete link to backgroundWorker instance
               _backgroundWorker = null;
           };
           */
        }

        public void Abort()
        {
            importer.Abort = true;
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