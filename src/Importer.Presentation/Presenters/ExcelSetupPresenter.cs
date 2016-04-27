using System;
using System.Collections.Generic;

using Escyug.Importer.Common;

using Escyug.Importer.Models;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Presenters;
using Escyug.Importer.Presentations.Views;
using Escyug.Importer.Presentations.ViewModel;

namespace Escyug.Importer.Presentations.Presenters
{
    public class ExcelSetupPresenter : BasePresenter<IExcelSetupView, ConnectionContext>
    {
        private ConnectionContext _excelConnectionContext;

        public ExcelSetupPresenter(IApplicationController controller, IExcelSetupView view)
            : base(controller, view)
        {
            View.Initialize += () => OnInitialize();

            View.CreateConnectionString += () => OnCreateConnectionString();
            View.Cancel += () => OnCancel();
        }

        public override void Run(ConnectionContext argument)
        {
            _excelConnectionContext = argument;

            View.Show();
        }

        private void OnInitialize()
        {
            /************* Excel extended properties : *************
             *                                                     *
             *   Value :          "'Excel 8.0; HDR=YES'; "         *
             *   Display name :   "Microsoft Excel 97-2003"        *
             *                                                     *
             * --------------------------------------------------- *
             *                                                     *
             *   Value :          "'Excel 12.0 Xml; HDR=YES'; "    *
             *   Display name :   "Microsoft Excel 2007"           *
             *                                                     *
             * *****************************************************/
            var extendedProperties = new PropertyInfo[2];

            extendedProperties[0] = new PropertyInfo(
                "Microsoft Excel 97-2003", "'Excel 8.0; HDR=YES'; ");

            extendedProperties[1] = new PropertyInfo(
                "Microsoft Excel 2007", "'Excel 12.0 Xml; HDR=YES'; ");

            View.ExtendedProperties = extendedProperties;
        }

        private void OnCreateConnectionString()
        {
            _excelConnectionContext.ConnectionString = View.ConnectionString;
            View.Close();
        }

        private void OnCancel()
        {
            _excelConnectionContext.ConnectionString = string.Empty;
            View.Close();
        }
    }
}
