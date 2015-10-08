using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Presentation.Test.Views;
using Importer.Presentation.Test.Presenters;
using Importer.Engine.Test.Files;


namespace Importer.UI.ConsoleView
{
    class Main : IMainView
    {
        private readonly MainPresenter _presenter;

        public Main()
        {
            _presenter = new MainPresenter(this);    
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region Члены IMainView

        public event Action DataLoad;

        public Dictionary<string, string> FilesList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                foreach (var element in value)
                    Console.WriteLine(string.Format("{0} : {1}", element.Key, element.Value));
            }
        }


        public IFile SourceFile 
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                Console.WriteLine("\nSource file tables :\n");
                foreach (var element in value.TableList)
                {
                    Console.WriteLine(element.Name);
                }
                Console.WriteLine("\n");
            }
        }

        public IFile TargetFile
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                Console.WriteLine("\nTarget file tables :\n");
                foreach (var element in value.TableList)
                {
                    Console.WriteLine(element.Name);
                }
                Console.WriteLine("\n");
            }
        }

        #endregion

        public void Execute()
        {
            Invoke(DataLoad);
        }
    }
}
