using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Presentations.BETA.Common
{
    /// <summary>
    /// Base interface for all views
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Show up view
        /// </summary>
        void Show();

        /// <summary>
        /// Close view
        /// </summary>
        void Close();

        /// <summary>
        /// Set error message
        /// </summary>
        string Error { set; }
    }
}
