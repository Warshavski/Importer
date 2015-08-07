using System;
using System.Data;
using System.Windows.Forms;
using Importer.Engine.Presenters;
using Importer.Engine.Views;

namespace Importer.UI.WinView.Forms
{
    public partial class FormDataViewer : Form, IDataViewer
    {
        private readonly DataViewerPresenter _presenter;

        public FormDataViewer(Importer.Engine.Models.Table selectedTable)
        {
            InitializeComponent();
            _presenter = new DataViewerPresenter(this, selectedTable);
        }

        #region Члены IDataViewer

        Importer.Engine.Models.Table IDataViewer.SelectedTable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DataTable IDataViewer.TableData
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                dataGridView1.DataSource = value;
            }
        }

        long IDataViewer.TotalRows
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                toolStripStatusLabel1.Text = string.Format("Total rows : {0}", value);
            }
        }

        #endregion

        #region Члены IView

        void Importer.Engine.Views.Common.IView.ShowNoticeMessage(string message)
        {
            throw new NotImplementedException();
        }

        void Importer.Engine.Views.Common.IView.ShowWarningMessage(string message)
        {
            throw new NotImplementedException();
        }

        void Importer.Engine.Views.Common.IView.ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Члены ILoading

        bool Importer.Engine.Views.Common.ILoading.IsLoading
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                if (value)
                {
                    dataGridView1.Visible = false;
                    progressBar1.Visible = true;
                    toolStripBtnClose.Enabled = false;
                }
                else
                {
                    dataGridView1.Visible = true;
                    progressBar1.Visible = false;
                    toolStripBtnClose.Enabled = true;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        Importer.Engine.Views.Common.ProgressStyle Importer.Engine.Views.Common.ILoading.ProgressBarStyle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string Importer.Engine.Views.Common.ILoading.ExecutionStatusText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                toolStripStatusLabel1.Text = value;
            }
        }

        int Importer.Engine.Views.Common.ILoading.ExecutionStatusValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion


        #region Event handlers

        private void OnFormDataViewer_Load(object sender, EventArgs e)
        {
            _presenter.LoadData();
        }

        private void OnFormDataViewer_SizeChanged(object sender, EventArgs e)
        {
            const int DIVIDER = 2;
            progressBar1.Location =
                new System.Drawing.Point(progressBar1.Location.X, this.dataGridView1.Height / DIVIDER - progressBar1.Height / DIVIDER);
        }

        private void OnToolStripBtnClose_Click(object sender, EventArgs e)
        {
            _presenter.DisposeData();
            this.Close();
        }

        #endregion
    }
}
