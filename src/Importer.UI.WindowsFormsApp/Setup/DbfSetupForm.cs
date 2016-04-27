using System;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class DbfSetupForm : Form, IDbfSetupView
    {
        public DbfSetupForm()
        {
            InitializeComponent();

            this.buttonOk.Click += (sender, e) => Invoker.Invoke(CreateConnectionString);
            this.buttonCancel.Click += (sender, e) => Invoker.Invoke(Cancel);
        }

        public new void Show()
        {
            ShowDialog();
        }

        public event Action CreateConnectionString;

        public event Action Cancel;

        public string Error
        {
            set { MessageBox.Show(value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        string ISetupView.ConnectionString
        {
            get
            {
                return string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; User ID=Admin; Password=; Extended Properties={1};",
                     textBoxFilePath.Text, "dBASE IV");
            }
            set {}
        }


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var result = new FolderBrowserDialog())
            {
                if (result.ShowDialog() == DialogResult.OK)
                    textBoxFilePath.Text = result.SelectedPath;
            }
        }
    }
}
