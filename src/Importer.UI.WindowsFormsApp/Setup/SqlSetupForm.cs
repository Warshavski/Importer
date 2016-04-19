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
                    this.textBoxDataBase.Text = "liss";
                    this.textBoxServerName.Text = "localhost";
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

            this.buttonInitializeTest.Click += (sender, e) => Invoker.Invoke(InitializeDataInstance);
        }

        public event Action InitializeDataInstance;

        public new void Show()
        {
            ShowDialog();
        }

        public string ConnectionString
        {
            get 
            {
                return string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True;",
                    textBoxServerName.Text, textBoxDataBase.Text);
            }
        }     
    }
}
