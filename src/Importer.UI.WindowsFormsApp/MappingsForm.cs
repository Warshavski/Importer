using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.UI.WindowsFormsApp
{
    public partial class MappingsForm : Form, IMappingsView
    {
        public MappingsForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            ShowDialog();
        }

        // create and use ViewModel
        public IEnumerable<Models.Table> SourceTablesList
        {
            set 
            { 
                comboBoxSourceTables.DataSource = value;
                comboBoxSourceTables.DisplayMember = "Name";
            }
        }
    }
}
