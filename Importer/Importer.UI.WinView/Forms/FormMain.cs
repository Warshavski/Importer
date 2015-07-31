using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Importer.Engine.Views;
using Importer.Engine.Presenters;

namespace Importer.UI.WinView.Forms
{
    public partial class FormMain : Form, IMainView
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region Члены IMainView

        IList<Importer.Engine.Models.ICreator> IMainView.FileTypesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Models.PropertyInfo[] IMainView.ExtendedProperties
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Models.PropertyInfo IMainView.SelectedProperty
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<Importer.Engine.Models.Table> IMainView.SourceTablesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Models.Table IMainView.SelectedSourceTable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<Importer.Engine.Models.Table> IMainView.TargetTablesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Models.Table IMainView.SelectedTargetTable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<Importer.Engine.Models.Column> IMainView.SourceTableColumnsList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<Importer.Engine.Models.Column> IMainView.TargetTableColumnsList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Models.ICreator IMainView.SelectedSourceFileType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMainView.IsTruncate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IMainView.FilePath
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Члены IView

        void Importer.Engine.Views.Common.IView.ShowNoticeMessage(string message)
        {
            throw new NotImplementedException();
        }

        void Importer.Engine.Views.Common.IView.ShowWarningMessage(string message)
        {
            throw new NotImplementedException();
        }

        void Importer.Engine.Views.Common.IView.ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }

        bool Importer.Engine.Views.Common.IView.IsLoading
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Importer.Engine.Views.Common.ProgressStyle Importer.Engine.Views.Common.IView.ProgressBarStyle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string Importer.Engine.Views.Common.IView.ExecutionStatusText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        int Importer.Engine.Views.Common.IView.ExecutionStatusValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
