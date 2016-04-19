using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class SetupBuilderForm : Form, ISetupBuilderView
    {
        private readonly ApplicationContext _context;

        public SetupBuilderForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        //public new void Show()
        //{
        //    base.Show();
        //}

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

    }
}
