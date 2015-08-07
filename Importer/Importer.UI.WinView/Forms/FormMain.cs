using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Importer.Engine.Presenters;
using Importer.Engine.Views;

namespace Importer.UI.WinView.Forms
{
    public partial class FormMain : Form, IMainView
    {
        private readonly MainPresenter _presenter = null;

        public FormMain()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);

            ofdFileBrowse.FilterIndex = 1;
            ofdFileBrowse.RestoreDirectory = true;
            ofdFileBrowse.FileName = string.Empty;
            ofdFileBrowse.Filter = "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007 (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        }

        #region Члены IMainView

        List<Importer.Engine.Models.ICreator> IMainView.FileTypesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmBoxSourceFileTypes.DataSource = value;
                cmBoxSourceFileTypes.DisplayMember = "DisplayName";
            }
        }

        Importer.Engine.Models.PropertyInfo[] IMainView.ExtendedProperties
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmBoxExtendedProperty.DataSource = value;
                cmBoxExtendedProperty.DisplayMember = "DisplayName";
            }
        }

        Importer.Engine.Models.PropertyInfo IMainView.SelectedProperty
        {
            get
            {
                return (Importer.Engine.Models.PropertyInfo)cmBoxExtendedProperty.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<Importer.Engine.Models.Table> IMainView.SourceTablesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmBoxSourceTablesList.DataSource = value;
                cmBoxSourceTablesList.DisplayMember = "Name";
            }
        }

        Importer.Engine.Models.Table IMainView.SelectedSourceTable
        {
            get
            {
                return (Importer.Engine.Models.Table)cmBoxSourceTablesList.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<Importer.Engine.Models.Table> IMainView.TargetTablesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmBoxTargetTablesList.DataSource = value;
                cmBoxTargetTablesList.DisplayMember = "Name";
            }
        }

        Importer.Engine.Models.Table IMainView.SelectedTargetTable
        {
            get
            {
                return (Importer.Engine.Models.Table)cmBoxTargetTablesList.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<Importer.Engine.Models.Column> IMainView.SourceTableColumnsList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.linkedColumn.DataSource = value;
                this.linkedColumn.DisplayMember = "Name";

                foreach (DataGridViewRow row in dgvColumnsMapping.Rows)
                    row.Cells["linkedColumn"].Value = Importer.Engine.Models.Column.EmptyColumn.Name;
            }
        }

        List<Importer.Engine.Models.Column> IMainView.TargetTableColumnsList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                dgvColumnsMapping.DataSource = value;

                if (linkedColumn.DataSource != null)
                    foreach (DataGridViewRow row in dgvColumnsMapping.Rows)
                        row.Cells["linkedColumn"].Value = Importer.Engine.Models.Column.EmptyColumn.Name;
            }
        }

        Importer.Engine.Models.ICreator IMainView.SelectedSourceFileType
        {
            get
            {
                return (Importer.Engine.Models.ICreator)cmBoxSourceFileTypes.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMainView.IsTruncate
        {
            get
            {
                return chBoxTruncate.Checked;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IMainView.FilePath
        {
            get
            {
                return txtBoxFilePath.Text.Trim();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        // too ugly, rework
        List<Importer.Engine.Models.Importers.ColumnsMapping> IMainView.Mappings
        {
            get
            {
                List<Importer.Engine.Models.Importers.ColumnsMapping> mapp = new List<Importer.Engine.Models.Importers.ColumnsMapping>();
                for (int i = 0; i < dgvColumnsMapping.Rows.Count; ++i)
                {
                    if (dgvColumnsMapping.Rows[i].Cells["linkedColumn"].Value.ToString() != Importer.Engine.Models.Column.EmptyColumn.Name)
                    {
                        mapp.Add(new Importer.Engine.Models.Importers.ColumnsMapping(
                            dgvColumnsMapping.Rows[i].Cells["linkedColumn"].Value.ToString(),
                            dgvColumnsMapping.Rows[i].Cells["nameColumn"].Value.ToString()));
                    }
                }
                return mapp;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Члены IView

        void Importer.Engine.Views.Common.IView.ShowNoticeMessage(string message)
        {
            MessageBox.Show(message, "Notice", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    grBoxTargetFile.Enabled = false;
                    toolStripProgressBar1.Visible = true;
                    statusStripBtnCancel.Visible = true;
                }
                else
                {
                    grBoxTargetFile.Enabled = true;
                    toolStripProgressBar1.Visible = false;
                    statusStripBtnCancel.Visible = false;
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
                switch (value)
                {
                    case Importer.Engine.Views.Common.ProgressStyle.Blocks:
                        toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                        break;
                    case Importer.Engine.Views.Common.ProgressStyle.Marguee:
                        toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                        break;
                }
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
                toolStripProgressBar1.Value = value;
            }
        }

        #endregion

        #region Event handlers

        private void OnBtnTargetFileSettings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog();
        }

        private void OnFormMain_Load(object sender, EventArgs e)
        {
            _presenter.LoadFileTypesList();
            OnCmBoxSourceFileTypes_SelectionChangeCommitted(sender, e);
        }

        // initialization of selected source file
        private void OnBtnBrowse_Click(object sender, EventArgs e)
        {
            switch (_presenter.GetFileBrowser())
            {
                case Importer.Engine.Models.FileBrowse.Folder:
                    using (var result = new FolderBrowserDialog())
                    {
                        if (result.ShowDialog() == DialogResult.OK)
                        {
                            txtBoxFilePath.Text = result.SelectedPath;
                            _presenter.InitializeSourceFile();
                        }
                    }
                    break;
                case Importer.Engine.Models.FileBrowse.File:
                    ofdFileBrowse.ShowDialog();
                    break;
                case Importer.Engine.Models.FileBrowse.None:
                    _presenter.InitializeSourceFile();
                    break;
            }
        }

        // OpenFileBrowser event when file is selected (for Excel Files)
        private void OnOfdSourceFileBrowse_FileOk(object sender, CancelEventArgs e)
        {
            txtBoxFilePath.Text = ofdFileBrowse.FileName;
            _presenter.InitializeSourceFile();
        }

        // load extended properties for selected source file
        private void OnCmBoxSourceFileTypes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _presenter.LoadExtendedProperties();
        }

        // load source columns list
        private void OnCmBoxSourceTablesList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _presenter.LoadSourceColumns();
        }

        // load target tables list
        private void OnBtnLoadTargetTables_Click(object sender, EventArgs e)
        {
            _presenter.LoadTargetTables();
        }

        // load target columns list
        private void OnCmBoxTargetTablesList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _presenter.LoadTargetColumns();
        }

        // load selected source table data
        private void OnBtnShowSourceData_Click(object sender, EventArgs e)
        {
            if (((IMainView)this).SelectedTargetTable != Importer.Engine.Models.Table.EmptyTable)
            {
                FormDataViewer frm = new FormDataViewer(((IMainView)this).SelectedSourceTable);
                frm.ShowDialog();
            }
        }

        private void OnBtnShowTargetData_Click(object sender, EventArgs e)
        {
            if (((IMainView)this).SelectedTargetTable != Importer.Engine.Models.Table.EmptyTable)
            {
                FormDataViewer frm = new FormDataViewer(((IMainView)this).SelectedTargetTable);
                frm.ShowDialog();
            }
        }

        private void OnBtnLoadTargetTablesList_Click(object sender, EventArgs e)
        {
            _presenter.LoadTargetTables();
            
        }
        
        private void OnBtnCreateTable_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnBtnImport_Click(object sender, EventArgs e)
        {
            _presenter.Import();
        }

        private void OnBtnMappingsLoad_Click(object sender, EventArgs e)
        {

        }

        private void OnBtnSaveMappings_Click(object sender, EventArgs e)
        {

        }

        private void OnStatusStripBtnCancel_Click(object sender, EventArgs e)
        {
            _presenter.Abort();
        }

        #endregion
    }
}
