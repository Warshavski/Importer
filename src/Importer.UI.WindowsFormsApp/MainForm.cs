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

namespace Escyug.Importer.UI.WindowsFormsApp
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        #region IMainView events

        public event Action Initialize;

        public event Action ImportExecute;
        public event Func<Task> ImportExecuteAsync;

        public event Action DestinationInstanceLoad;
        public event Func<Task> DestinationInstanceLoadAsync;

        public event Action SourceInstanceLoad;
        public event Func<Task> SourceInstanceLoadAsync;


        #endregion

        public MainForm()
        {
            InitializeComponent();
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
        }

        #region IMainView properties

        public IEnumerable<FileTypeVM> FilesTypes
        {
            set 
            { 
                cmBoxFilesTypes.DataSource = value;
                cmBoxFilesTypes.DisplayMember = "Name";
                cmBoxFilesTypes.ValueMember = "Value";
            }
        }

        public IEnumerable<string> ConnectionStrings
        {
            set { listBoxConnectionStrings.Items.AddRange(value.ToArray()); }
        }

        public Constants.FilesTypes SelectedSourceType
        {
            get { return (Constants.FilesTypes)cmBoxFilesTypes.SelectedValue; }
        }

        public string SourceConnectionString
        {
            get { return listBoxConnectionStrings.SelectedItem.ToString(); }
        }

        public Models.Table SelectedSourceTable
        {
            get
            {
                return (Models.Table)cmBoxSourceTables.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Constants.FilesTypes SelectedDestinationType
        {
            get { return Constants.FilesTypes.Sql; }
        }

        public string DestinationConnectionString
        {
            get { return listBoxConnectionStrings.SelectedItem.ToString(); }
        }

        public object OperationStatus
        {
            set { MessageBox.Show(value.ToString()); }
        }

        public Models.DataInstance SourceDataInstance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmBoxSourceTables.DataSource = value.Tables;
                cmBoxSourceTables.DisplayMember = "Name";
            }
        }

        public Models.DataInstance DestinationDataInstance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                treeView2.Nodes.Clear();
                treeView2.Nodes.AddRange(
                    CreateTreeViewNodes(value).ToArray());
            }
        }

        #endregion

        #region Helper methods

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        private async Task InvokeAsync(Func<Task> func)
        {
            if (func != null)
                await func.Invoke();
        }

        private IEnumerable<TreeNode> CreateTreeViewNodes(Models.DataInstance dataInstance)
        {
            var treeNodes = new List<TreeNode>();
            foreach (var table in dataInstance.Tables)
            {
                TreeNode rootNode = new TreeNode(table.Name);

                foreach (var column in table.Columns)
                {
                    TreeNode childNode = new TreeNode(column.Name);
                    childNode.Nodes.Add(column.Type);
                    childNode.Nodes.Add(column.Length.ToString());

                    rootNode.Nodes.Add(childNode);
                }

                treeNodes.Add(rootNode);
            }

            return treeNodes;
        }

        #endregion

    }
}
