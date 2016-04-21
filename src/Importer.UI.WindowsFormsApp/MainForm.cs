using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Presenters;
using Escyug.Importer.Presentations.ViewModel;
using Escyug.Importer.Presentations.Views;

using Escyug.Importer.UI.WindowsFormsApp.Setup;

namespace Escyug.Importer.UI.WindowsFormsApp
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;

        public MainForm(ApplicationContext context)
        {
            _context = context;
            
            InitializeComponent();

            //this.toolStripButtonLoadDestination.Click += (sender, e) => Invoker.Invoke(DestinationInitialize);
            this.toolStripButtonLoadDestination.Click += async (sender, e) => await Invoker.InvokeAsync(DestinationInitializeAsync);

            //this.buttonLoadSource.Click += (sender, e) => Invoker.Invoke(SourceInitialize);
            this.buttonLoadSource.Click += async (sender, e) => await Invoker.InvokeAsync(SourceInitializeAsync);
            

            this.comboBoxSourceTables.SelectionChangeCommitted += (sender, e) =>
                {
                    this.SelectedSourceTableColumns =
                        (comboBoxSourceTables.SelectedValue as Models.Table).Columns;
                };

            this.treeView1.AfterSelect += (sender, e) =>
                {
                    if (treeView1.SelectedNode.Tag is Models.Table)
                        this.SelectedDestinationTableColumns =
                            (treeView1.SelectedNode.Tag as Models.Table).Columns;
                };
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public event Action DestinationInitialize;
        public event Func<Task> DestinationInitializeAsync;

        public event Action SourceInitialize;
        public event Func<Task> SourceInitializeAsync;

        public bool IsDestinationLoad
        {
            set { pictureBoxLoading.Visible = value; }
        }

        public bool IsSourceLoad
        {
            set { pictureBox1.Visible = value; }
        }

        public string OperationState
        {
            set { toolStripStatusLabel1.Text = value; }
        }

        public IEnumerable<FileType> FileTypesList
        {
            set 
            { 
                comboBoxSourceType.DataSource = value;
                comboBoxSourceType.DisplayMember = "Name";
            }
        }

        public FileType SelectedFileType
        {
            get { return comboBoxSourceType.SelectedValue as FileType; }
        }

        public IEnumerable<Models.Table> SourceTablesList
        {
            set 
            {
                comboBoxSourceTables.DataSource = value;
                comboBoxSourceTables.DisplayMember = "Name";
            }
        }

        public IEnumerable<Models.Table> DestinationTablesList
        {
            set 
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.AddRange(
                    CreateTreeViewNodes(value).ToArray());

                dataGridView1.DataSource = null;
            }
        }

        public IEnumerable<Models.Column> SelectedSourceTableColumns
        {
            set 
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.Cells["sourceColumn"].Value = null;

                sourceColumn.DataSource = value;
                sourceColumn.DisplayMember = "Name";
            }
        }

        public IEnumerable<Models.Column> SelectedDestinationTableColumns
        {
            set 
            {
                dataGridView1.DataSource = value;
            }
        }


        #region Helper methods

        private IEnumerable<TreeNode> CreateTreeViewNodes(IEnumerable<Models.Table> tablesList)
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

        #endregion

    }
}






/* Test events binding 
* NOTE : see MainPresenter.cs comments: "Test methods"
 *  #region IMainView events

        public event Action Initialize;

        public event Action ImportExecute;
        public event Func<Task> ImportExecuteAsync;

        public event Action DestinationInstanceLoad;
        public event Func<Task> DestinationInstanceLoadAsync;

        public event Action SourceInstanceLoad;
        public event Func<Task> SourceInstanceLoadAsync;


        #endregion
 * 
 * 
_presenter = new MainPresenter(this);
this.Load += (sender, e) => Invoke(Initialize);

this.buttonLoadSource.Click += async (sender, e) =>
    await InvokeAsync(SourceInstanceLoadAsync);

this.buttonDestinationLoad.Click += async (sender, e) =>
    await InvokeAsync(DestinationInstanceLoadAsync);

this.buttonImportExecute.Click += async (sender, e) =>
    await InvokeAsync(ImportExecuteAsync);

// UI events 
this.cmBoxSourceTables.SelectedValueChanged += (sender, e) =>
    {
        dgvMetadata.DataSource =
            ((Models.Table)cmBoxSourceTables.SelectedValue).Columns;
    };
*/