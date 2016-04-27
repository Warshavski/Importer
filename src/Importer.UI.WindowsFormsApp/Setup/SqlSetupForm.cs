using System;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class SqlSetupForm : Form, ISqlSetupView
    {
        public SqlSetupForm()
        {
            InitializeComponent();
            
            this.Load += (sender, e) => 
                { 
                    this.radioButtonWindowsAuth.Checked = true;
                    //this.textBoxDataBase.Text = "liss";
                    //this.textBoxServerName.Text = "localhost";

                    Invoker.Invoke(Initialize);
                };

            this.radioButtonWindowsAuth.CheckedChanged += (sender, e) =>
                {
                    if (radioButtonWindowsAuth.Checked)
                        panelSqlAuth.Enabled = false;
                };
            this.radioButtonSqlAuth.CheckedChanged += (sender, e) =>
                {
                    if (radioButtonSqlAuth.Checked)
                        panelSqlAuth.Enabled = true;
                };

            this.buttonOk.Click += (sender, e) => Invoker.Invoke(CreateConnectionString);
            this.buttonCancel.Click += (sender, e) => Invoker.Invoke(Cancel);
            this.buttonTestConnection.Click += (sender, e) => Invoker.Invoke(TestConnection);
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

        public event Action TestConnection;

        public event Action CreateConnectionString;

        public event Action Cancel;

        public string ConnectionString
        {
            get 
            {
                if (radioButtonSqlAuth.Checked)
                    return string.Format(@"Server={0};Database={1};User ID={2};Password={3};Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;",
                        textBoxServerName.Text, textBoxDataBase.Text, textBoxUserName.Text, textBoxPassword.Text);
                else
                    return string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True;",
                        textBoxServerName.Text, textBoxDataBase.Text);
            }
            set
            {
                var parameters = value.Split('-');

                textBoxServerName.Text = parameters[1];
                textBoxDataBase.Text = parameters[2];
                textBoxUserName.Text = parameters[3];
                textBoxPassword.Text = parameters[4];

                radioButtonSqlAuth.Checked = bool.Parse(parameters[0]);
            }
        }

      
    }
}
