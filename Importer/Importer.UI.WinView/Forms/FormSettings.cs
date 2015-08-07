using System.Windows.Forms;
using Importer.Engine.Presenters;
using Importer.Engine.Views;

namespace Importer.UI.WinView.Forms
{
    public partial class FormSettings : Form, ISettingsView
    {
        private readonly SettingsPresenter _presenter = null;

        public FormSettings()
        {
            InitializeComponent();
            _presenter = new SettingsPresenter(this);
        }

        #region Члены ISettingsView

        string ISettingsView.Server
        {
            get
            {
                return txtBoxServerName.Text.Trim();
            }
            set
            {
                txtBoxServerName.Text = value;
            }
        }

        string ISettingsView.Catalog
        {
            get
            {
                return tbCatalogName.Text.Trim();
            }
            set
            {
                tbCatalogName.Text = value;
            }
        }

        string ISettingsView.User
        {
            get
            {
                return txtBoxUserName.Text.Trim();
            }
            set
            {
                txtBoxUserName.Text = value;
            }
        }

        string ISettingsView.Pass
        {
            get
            {
                return txtBoxPass.Text.Trim();
            }
            set
            {
                txtBoxPass.Text = value;
            }
        }

        bool ISettingsView.IsWindowsSecurity
        {
            get
            {
                return (bool)rbWindowsTrust.Checked;
            }
            set
            {
                if (value)
                    this.rbWindowsTrust.Checked = true;
                else
                    this.rbSqlTrust.Checked = true;
            }
        }

        #endregion

        #region Члены IView

        void Importer.Engine.Views.Common.IView.ShowNoticeMessage(string message)
        {
            MessageBox.Show(message, "Notice", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Importer.Engine.Views.Common.IView.ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void Importer.Engine.Views.Common.IView.ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Event handlers 

        private void OnBtnTestConnect_Click(object sender, System.EventArgs e)
        {
            _presenter.TestConnection();
        }

        private void OnTrust_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbWindowsTrust.Checked)
                pnlSqlTrust.Enabled = false;
            else
                pnlSqlTrust.Enabled = true;
        }

        private void OnBtnSaveProperties_Click(object sender, System.EventArgs e)
        {
            _presenter.SaveChanges();
            this.Close();
        }

        #endregion
    }
}
