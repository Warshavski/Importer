using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Presentations.BETA.Views;
using Escyug.Importer.Presentations.BETA.ViewModels;

namespace Escyug.Importer.WinForms.App
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;

        public MainForm(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();

            this.Load += (sender, e) => Invoke(InitializeView);
            //this.buttonImportExecute.Click += (sender, e) => Invoke(ExecuteImport);
            this.buttonImportExecute.Click += async (sender, e) => 
                await Invoker.InvokeAsync(ExecuteImportAsync);

            /** 
             * controls for source data service
             */
            //this.buttonLoadSource.Click += (sender, e) => Invoke(InitializeSource);
            this.buttonLoadSource.Click += async (sender, e) => 
                await Invoker.InvokeAsync(InitializeSourceAsync);

            this.comboBoxSourceTables.SelectionChangeCommitted += (sender, e) => Invoke(SelectSourceTable);

            /** 
             * controls for destination data service
             */
            //this.toolStripButtonDestinationLoad.Click += (sender, e) => Invoke(InitializeDestination);
            this.toolStripButtonDestinationLoad.Click += 
                async (sender, e) => await Invoker.InvokeAsync(InitializeDestinationAsync);

            this.treeView1.AfterSelect += (sender, e) => Invoke(SelectDestinationTable);

            this.comboBoxSourceTables.SelectedValueChanged += (sender, e) =>
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["sourceColumn"].Value = null;
                }
            };
        }

        #region General

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public string Error
        {
            set 
            { 
                MessageBox.Show(value, "Application error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public string Notify
        {
            set
            {
                MessageBox.Show(value, "Application information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public event Action InitializeView;

        public event Action ExecuteImport;

        public event Func<Task> ExecuteImportAsync;

        public ICollection<FileType> FileTypes
        {
            get
            {
                return comboBoxSourceType.DataSource as ICollection<FileType>;
            }
            set
            {
                comboBoxSourceType.DataSource = value;
                comboBoxSourceType.DisplayMember = "Name";
            }
        }


        public int ProgressValue
        {
            get
            {
                return toolStripProgressBar1.Value;
            }
            set
            {
                toolStripProgressBar1.Value = value;
            }
        }

        public bool IsImportExecuting
        {
            set
            {
                toolStripProgressBar1.Visible = value;
            }
        }

        public string ApplicationStatus
        {
            get
            {
                return toolStripStatusLabel1.Text;
            }
            set
            {
                toolStripStatusLabel1.Text = value;
            }
        }

        #endregion General


        //-------------------------------------------------


        #region Source 

        public event Action InitializeSource;

        public event Func<Task> InitializeSourceAsync;

        public event Action SelectSourceTable;

        public FileType SourceDataType
        {
            get
            {
                return comboBoxSourceType.SelectedValue as FileType;
            }
        }

        public string SourceConnectionString
        {
            get
            {
                return textBoxSourceConnection.Text;
            }
            set
            {
                textBoxSourceConnection.Text = value;
            }
        }

        public ICollection<Data.Metadata.Table> SourceMetadata
        {
            get
            {
                return comboBoxSourceTables.DataSource as ICollection<Data.Metadata.Table>;
            }
            set
            {
                comboBoxSourceTables.DataSource = value;
                comboBoxSourceTables.DisplayMember = "Name";
            }
        }

        public Data.Metadata.Table SelectedSourceTable
        {
            get
            {
                return comboBoxSourceTables.SelectedValue as Data.Metadata.Table;
            }
        }

        public ICollection<Data.Metadata.Column> SelectedSourceTableColumns
        {
            get
            {
                return sourceColumn.DataSource as ICollection<Data.Metadata.Column>;
            }
            set
            {
                sourceColumn.DataSource = value;
                sourceColumn.DisplayMember = "Name";
                //dataGridView1.DataSource = value;
            }
        }

        public ICollection<string> SourceMarkedColumns 
        {
            get
            {
                var markedColumnsNames = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cellValue = row.Cells["sourceColumn"].Value;
                    markedColumnsNames.Add(
                        cellValue == null ? string.Empty : (string)cellValue);
                }

                return markedColumnsNames;
            }
            set
            {
                sourceColumn.DataSource = value;
                //sourceColumn.DisplayMember = "Name";
            }
        }

        public bool IsLoadingSource 
        { 
            get
            {
                return sourceLoadProgress.Visible;
            }
            set 
            {
                sourceLoadProgress.Visible = value;
            }
        }

        #endregion


        //-------------------------------------------------


        #region Destination

        public event Action InitializeDestination;

        public event Func<Task> InitializeDestinationAsync;

        public event Action SelectDestinationTable;

        public ICollection<Data.Metadata.Table> DestinationMetadata
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.AddRange(
                    CreateTreeViewNodes(value).ToArray());

                dataGridView1.DataSource = null;
            }
        }

        public Data.Metadata.Table SelectedDestinationTable
        {
            get 
            {
                return treeView1.SelectedNode.Tag as Data.Metadata.Table;
            }
        }

        public ICollection<Data.Metadata.Column> SelectedDestinationTableColumns
        {
            get
            {
                return dataGridView1.DataSource as ICollection<Data.Metadata.Column>;
            }
            set
            {
                if (dataGridView1.DataSource == null)
                {
                    sourceColumn.DataSource = null;
                }

                dataGridView1.DataSource = value;
            }
        }

        public bool IsLoadingDestination
        {
            get
            {
                return destinationLoadProgress.Visible;
            }
            set
            {
                destinationLoadProgress.Visible = value;
            }
        }

        public bool IsTruncateDestinationTable 
        {
            get
            {
                return checkBoxTruncate.Checked;
            }
            set
            {
                checkBoxTruncate.Checked = value;
            }
        }

        #endregion Destination


        //-------------------------------------------------


        #region Helper methods

        private IEnumerable<TreeNode> CreateTreeViewNodes(IEnumerable<Data.Metadata.Table> tablesList)
        {
            var treeNodes = new List<TreeNode>();
            foreach (var table in tablesList)
            {
                TreeNode rootNode = new TreeNode(table.Name);
                rootNode.ImageIndex = 0;
                rootNode.Tag = table;

                foreach (var column in table.Columns)
                {
                    TreeNode childNode = new TreeNode(column.Name);
                    childNode.ImageIndex = 1;
                    childNode.Nodes.Add("Type : " + column.Type, "1", 1);
                    childNode.Nodes.Add("Lenght : " + column.Length.ToString(), "1", 1);

                    rootNode.Nodes.Add(childNode);
                }

                treeNodes.Add(rootNode);
            }

            return treeNodes;
        }

        #endregion Helper methods
    }
}

