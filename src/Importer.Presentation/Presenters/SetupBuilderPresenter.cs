using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Common;

using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Views;

namespace Escyug.Importer.Presentations.Presenters
{
    public class SetupBuilderPresenter : BasePresenter<ISetupBuilderView, ViewContainer<DataInstance, IView>>
    {
        private DataInstance _dataInstace;

        public SetupBuilderPresenter(IApplicationController controller, ISetupBuilderView view) 
            : base(controller, view) 
        {
            View.SelectFileType += () => OnSelectFileType();
        }

        public override void Run(ViewContainer<DataInstance, IView> argument)
        {
            _dataInstace = argument.Argument;
            Initialize();
            View.Append(argument.Container);
        }

        /*
         * 
          public override void Run(DataInstance argument)
          {
              _dataInstace = argument;
              Initialize();
              View.Append(View);
              //View.Show();
          }
        */

        private void Initialize()
        {
            var fileTypesList = new List<ViewModel.FileType>();

            fileTypesList.Add(new ViewModel.FileType(null, "<select file type>"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.Sql, "Sql data instance"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.OleDb, "Dbf file"));
            fileTypesList.Add(new ViewModel.FileType(Constants.DataInstanceTypes.OleDb, "Excel file"));

            View.FileTypesList = fileTypesList;
        }

        private void OnSelectFileType()
        {
            /* NOTE : setup presenter should be created by Application controller.
             *        Application controller should use DI and dependency resolver.
             * 
             *  1. Create DataInsanceService depends on selected file type.
             *  2. Create SetupPresenter and Run it with parameter (DataInstance).
             */
        }
    }
}
