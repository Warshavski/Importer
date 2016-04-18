using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Presenters;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;
using Escyug.Importer.Common;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class MainSetupForm : Form, ISetupView
    {
        private readonly SetupPresenter _presenter;

        public event Action Initialize;

        public MainSetupForm()
        {
            InitializeComponent();
            
            _presenter = new SetupPresenter(this);

            this.Load += (sender, e) => Invoke(Initialize);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        public IEnumerable<Presentations.ViewModel.FileType> FilesTypesList
        {
            set 
            { 
                comboBoxSourceType.DataSource = value;
                comboBoxSourceType.DisplayMember = "Name";
            }
        }

        public Presentations.ViewModel.FileType SelectedFileType
        {
            get { return (Presentations.ViewModel.FileType)comboBoxSourceType.SelectedValue; }
        }

        private Form CreateSetupForm(Presentations.ViewModel.FileType selectedFileType)
        {
            switch (selectedFileType.DataInstanceType)
            {
                case Constants.DataInstanceTypes.Sql :
                    return new SqlSetupForm();
                case Constants.DataInstanceTypes.OleDb :
                    return new OleDbSetupForm();
                default :
                    return null;
            }
        }

        private void comboBoxSourceType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            var setupForm = CreateSetupForm(this.SelectedFileType);

            setupForm.Visible = true;
            setupForm.TopLevel = false;
            setupForm.Dock = DockStyle.Fill;
            setupForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.splitContainer1.Panel2.Controls.Add(setupForm);
        }
    }
}
