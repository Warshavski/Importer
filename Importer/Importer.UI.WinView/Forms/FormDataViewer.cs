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
    public partial class FormDataViewer : Form
    {
        public FormDataViewer()
        {
            InitializeComponent();
        }

        private void EventHandler_FormDataViewer_SizeChanged(object sender, EventArgs e)
        {
            const int DIVIDER = 2;
            progressBar1.Location =
                new System.Drawing.Point(progressBar1.Location.X, this.dataGridView1.Height / DIVIDER - progressBar1.Height / DIVIDER);
        }
    }
}
