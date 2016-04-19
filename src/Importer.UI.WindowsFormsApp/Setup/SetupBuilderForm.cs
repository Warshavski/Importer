using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class SetupBuilderForm : Form, ISetupBuilderView
    {
        public SetupBuilderForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            //Append
            //base.Show();
        }

        #region ISetupBuilderView members

        public event Action SelectFileType;

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
            get 
            {
               return (FileType)comboBoxSourceType.SelectedValue;
            }
        }

        #endregion

        // look like ugly crutch
        public void Append(Presentations.Common.IView view)
        {
            foreach (var ctrl in ((Form)view).Controls)
            {
                if (ctrl is SplitContainer)
                {
                    this.TopLevel = false;
                    this.ControlBox = false;
                    this.Dock = DockStyle.Fill;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    ((SplitContainer)ctrl).Panel2.Controls.Add(this);
                    this.Visible = true;
                }
                    
            }
        }
    }
}
