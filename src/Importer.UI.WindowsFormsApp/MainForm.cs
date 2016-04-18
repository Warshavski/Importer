using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Common;
using Escyug.Importer.Presentations.Presenters;
using Escyug.Importer.Presentations.ViewModel;
using Escyug.Importer.Presentations.Views;

using Escyug.Importer.UI.WindowsFormsApp.Setup;

namespace Escyug.Importer.UI.WindowsFormsApp
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
            
            this.Load += (sender, e) =>
                {
                    var setupForm = new MainSetupForm();
                    setupForm.TopLevel = false;
                    setupForm.Visible = true;
                    setupForm.FormBorderStyle = FormBorderStyle.None;
                    setupForm.Dock = DockStyle.Fill;

                    splitContainerMenu.Panel1.Controls.Add(setupForm);
                };
        }

        // create separate class 
        #region Helper methods 

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        private async Task InvokeAsync(Func<Task> func)
        {
            if (func != null)
                await func.Invoke();
        }

        #endregion
    }
}






/* Test events binding 
* NOTE : see MainPresenter.cs comments: "Test methods"
 *  #region IMainView events

        public event Action Initialize;

        public event Action ImportExecute;
        public event Func<Task> ImportExecuteAsync;

        public event Action DestinationInstanceLoad;
        public event Func<Task> DestinationInstanceLoadAsync;

        public event Action SourceInstanceLoad;
        public event Func<Task> SourceInstanceLoadAsync;


        #endregion
 * 
 * 
_presenter = new MainPresenter(this);
this.Load += (sender, e) => Invoke(Initialize);

this.buttonLoadSource.Click += async (sender, e) =>
    await InvokeAsync(SourceInstanceLoadAsync);

this.buttonDestinationLoad.Click += async (sender, e) =>
    await InvokeAsync(DestinationInstanceLoadAsync);

this.buttonImportExecute.Click += async (sender, e) =>
    await InvokeAsync(ImportExecuteAsync);

// UI events 
this.cmBoxSourceTables.SelectedValueChanged += (sender, e) =>
    {
        dgvMetadata.DataSource =
            ((Models.Table)cmBoxSourceTables.SelectedValue).Columns;
    };
*/