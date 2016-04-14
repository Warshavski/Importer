using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Presentation;
using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.UI.WindowsFormsApp
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);

            this.buttonLoadSource.Click += (sender, e) => Invoke(SourceInstanceLoad);
        }

        public Constants.FilesTypes SelectedSourceType
        {
            get { return Constants.FilesTypes.OleDb; }
        }

        public string SourceConnectionString
        {
            get { return listBoxConnectionStrings.SelectedItem.ToString(); }
        }

        public Models.DataInstance SourceDataInstance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                treeView1.Nodes.Clear();

                foreach (var table in value.Tables)
                {
                    TreeNode rootNode = new TreeNode(table.Name);
                    
                    foreach (var column in table.Columns)
                    {
                        TreeNode childNode = new TreeNode(column.Name);
                        childNode.Nodes.Add(column.Type);
                        childNode.Nodes.Add(column.Length.ToString());

                        rootNode.Nodes.Add(childNode);
                    }

                    treeView1.Nodes.Add(rootNode);
                }
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
                throw new NotImplementedException();
            }
        }

        public event Action SourceInstanceLoad;

        public event Action DestinationInstanceLoad;

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var csFilePath = @"C:\test\connectionStrings.txt";
            using (var csReader = new StreamReader(csFilePath, Encoding.UTF8))
            {
                while (!csReader.EndOfStream)
                    listBoxConnectionStrings.Items.Add(csReader.ReadLine());
            }
        }
    }
}
