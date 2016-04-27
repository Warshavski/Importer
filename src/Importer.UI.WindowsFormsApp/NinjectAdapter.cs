using System;
using System.Linq.Expressions;

using Ninject;

using Escyug.Importer.Presentations.Common;


namespace Escyug.Importer.UI.WindowsFormsApp
{
    internal class NinjectAdapter : IContainer
    {
        private IKernel _kernel = new StandardKernel();

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _kernel.Bind<TService, TImplementation>();
        }

        public void Register<TService>()
        {
            _kernel.Bind<TService>();
        }

        public void RegisterInstance<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public TService Resolve<TService>()
        {
            throw new NotImplementedException();
            //return _kernel.Resolve
        }

        public bool IsRegistered<TService>()
        {
            throw new NotImplementedException();
        }

        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            throw new NotImplementedException();
        }
    }
}
