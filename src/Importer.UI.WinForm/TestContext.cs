using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escyug.Importer.UI.WinForm
{
    public class TestContext : ApplicationContext
    {
        private Form1 logOnForm;

        private Form2 shellForm;

        public TestContext()
        {
            this.logOnForm = new Form1();
            this.MainForm = this.logOnForm;
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (this.MainForm == this.logOnForm
                && this.logOnForm.DialogResult == DialogResult.OK)
            {
                // Assume the log on form validated credentials
                this.shellForm = new Form2();
                this.MainForm = this.shellForm;
                this.MainForm.Show();
            }
            else
            {
                // No substitution, so context will stop and app will close
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
