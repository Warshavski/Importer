using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class ExcelSetupForm : Form, IExcelSetupView
    {
        public ExcelSetupForm()
        {
            InitializeComponent();

            this.Load += (sender, e) => Invoker.Invoke(Initialize);

            this.buttonBrowse.Click += (sender, e) => { openFileDialog1.ShowDialog(); };
            this.buttonOk.Click += (sender, e) => Invoker.Invoke(CreateConnectionString);
            this.buttonCancel.Click += (sender, e) => Invoker.Invoke(Cancel);
        }

        public new void Show()
        {
            ShowDialog();
        }

        public string Error
        {
            set { MessageBox.Show(value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public event Action Initialize;
        public event Action CreateConnectionString;
        public event Action Cancel;

        public string ConnectionString
        {
            get 
            {
                return string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties={1};",
                    textBoxFilePath.Text.Trim(), comboBoxProperties.SelectedValue.ToString());
            }
            set
            {

            }
        }

        public IEnumerable<PropertyInfo> ExtendedProperties
        {
            set 
            {
                comboBoxProperties.DataSource = value;
                comboBoxProperties.DisplayMember = "DisplayName";
                comboBoxProperties.ValueMember = "Value";
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBoxFilePath.Text = openFileDialog1.FileName;
        }


       
    }
}
