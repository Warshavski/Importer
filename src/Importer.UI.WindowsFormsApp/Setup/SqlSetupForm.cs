using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    public partial class SqlSetupForm : Form
    {
        public SqlSetupForm()
        {
            InitializeComponent();
        }

        private void radioButtonWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWindowsAuth.Checked)
                panelSqlAuth.Enabled = false;
        }

        private void radioButtonSqlAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSqlAuth.Checked)
                panelSqlAuth.Enabled = true;
        }

        private void SqlSetupForm_Load(object sender, EventArgs e)
        {
            this.radioButtonWindowsAuth.Checked = true;
        }
    }
}
