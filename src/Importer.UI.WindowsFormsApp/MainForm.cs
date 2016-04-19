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
        private readonly ApplicationContext _context;
   
        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            this.comboBoxSourceType.SelectionChangeCommitted += (sender, e) => Invoker.Invoke(SelectFileType);
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public event Action SelectFileType;

        public IEnumerable<FileType> FileTypesList
        {
            set 
            {
                comboBoxSourceType.DataSource = value;
                comboBoxSourceType.DisplayMember = "Name";
            }
        }

        public FileType SelectedFileType
        {
            get { return (FileType)comboBoxSourceType.SelectedValue; }
        }
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