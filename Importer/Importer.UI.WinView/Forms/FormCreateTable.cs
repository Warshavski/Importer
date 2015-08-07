using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Importer.UI.WinView.Forms
{
    public partial class FormCreateTable : Form
    {
        public FormCreateTable()
        {
            InitializeComponent();
        }

        private void FormCreateTable_Load(object sender, EventArgs e)
        {
            txtBoxCommand.Text = string.Format(@"CREATE TABLE [Назначение SQL Server] (\n
                                                [id_category] int,\n
                                                [name] nvarchar(150))");
        }
    }
}
