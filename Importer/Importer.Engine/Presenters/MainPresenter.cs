using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using Importer.Engine.Models;
using Importer.Engine.Models.Importers;
using Importer.Engine.Views;
using Importer.Engine.Views.Common;

namespace Importer.Engine.Presenters
{
    // 
    delegate void BackgroundWork();
    // 
    delegate void WorkCompleted();

    /* TODO : 
    * 1.- done - Create delegate for BackgroundWorker 
    * 2.- done - Create method that initialize Sql server instance
    * 3.- done - Create method that select tables from Sql server
    * 4.- done - Create method that select columns from Sql table
    * 5.- done - Create import method
    * 6. refactoring (go harder)
    */

    /// <summary>
    /// presenter for main view
    /// </summary>
    public class MainPresenter
    {
        private const bool IS_SOURCE = true;

        // instace of IMainView interface
        private readonly IMainView _view;

        private BackgroundWork _DoWork;
        private WorkCompleted _FinishWork;
        private CopyProgress _ChangeProgressStatus;

        // MainPresenter main constructor
        public MainPresenter(IMainView view)
        {
            _view = view;
            _DoWork = null;
            _FinishWork = null;
        }

        /* TODO : Add loading targer file types */
        // load list of supported source files
        public void LoadFileTypesList()
        {
            // create list of supported source files
            IList<ICreator> listOfFiles = new List<ICreator>()
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
            try
            {
                // initialize backgroundWorker
                InitializeBackgroundWorker();

                // create SqlCreator
                SqlCreator creator = null;

                // create IFile instance
                IFile sqlFile = null;

                _view.IsLoading = true;
                //_view.IsBlocks = false;

                // initilize delegate that executing in background
                _DoWork = delegate
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
                };

                // initilize delegate that executing when background operation is complete
                _FinishWork = delegate
                {
                    // bind initialized tables to view container
                    _view.TargetTablesList = sqlFile.TableList;

                    // delete link to creator
                    creator = null;
                    // delete link to sqlFile
                    sqlFile = null;

                    // set view loading property to false
                    _view.IsLoading = false;

                    // dispose backgroungWorker instance
                    _backgroundWorker.Dispose();
                    // delete link to backgroundWorker instance
                    _backgroundWorker = null;
                };

                // if backgroungWorker is not running
                if (!_backgroundWorker.IsBusy)
                    // start backgroungWorker
                    _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception er)
            {
                // show error message in view
                _view.ShowErrorMessage(er.Message + '\n' + er.Source);
            }
        }

        public void LoadSourceColumns()
        {
            // bind source file columns to view container
            _view.SourceTableColumnsList = _view.SelectedSourceTable.Columns;
        }

        public void LoadTargetColumns()
        {
            // bind target file columns to view container
            _view.TargetTableColumnsList = _view.SelectedTargetTable.Columns;
        }


        public List<ColumnsMapping> _mappings = new List<ColumnsMapping>();
        public void SetMapping(string sourceColumn, string targetColumn)
        {
            if (sourceColumn != Column.EmptyColumn)
                _mappings.Add(new ColumnsMapping(sourceColumn, targetColumn));
        }

        public void Import()
        {
            // initialize backgroundWorker
            InitializeBackgroundWorker();

            _ChangeProgressStatus = delegate(int value)
            {
                _view.ExecutionStatusValue = value;
                _view.ExecutionStatusText = string.Format("Loaded : {0}", value);
            };

            _view.ProgressBarStyle = ProgressStyle.Blocks;
            _view.IsLoading = true;

            _DoWork = delegate
            {
                try
                {
                    SqlCopy importer = new SqlCopy(_ChangeProgressStatus);
                    importer.Import(_view.SelectedSourceTable, _view.SelectedTargetTable,
                        _mappings.ToArray(), _view.IsTruncate);
                }
                finally
                {
                    _mappings.Clear();
                }
            };

            _FinishWork = delegate
            {
                _view.ExecutionStatusText = "Complete";
                _view.ShowNoticeMessage("Done!");
                _view.IsLoading = false;
                _view.ExecutionStatusValue = 0;

                // dispose backgroungWorker instance
                _backgroundWorker.Dispose();
                // delete link to backgroundWorker instance
                _backgroundWorker = null;
            };

            if (!_backgroundWorker.IsBusy)
                // start backgroungWorker
                _backgroundWorker.RunWorkerAsync();

        }

        // create backgroundWorker instance
        private BackgroundWorker _backgroundWorker = null;
        private void InitializeBackgroundWorker()
        {
            // initialize backgroungWorker instance
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
        }

        #region Backgroung worker EventHandlers
       
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
             * This method runs in a background thread.
             * while (work not done) 
             * {
             *     Do some work here
             *     _backgroundWorker.ReportProgress(percentage_done, user_state);
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