using System;
using EasyDI.Core.Classes;
using EasyDI.Core.Contracts;
using Ninject;

namespace EasyDI.nInject
{
    public class NInjectEasyDIEngine : IEasyDIEngine
    {
        #region .: Fields and services :.

        private IKernel _kernel;
        protected IKernel Kernel => _kernel;

        #endregion

        #region .: Ctor :.

        public NInjectEasyDIEngine()
        {
            _kernel = new StandardKernel();
        }

        #endregion

        #region .: Public methods :.

        public void Register(Type TClass, Type @interface, RegistrationScopeEnum registrationType)
        {
            var binder = Kernel.Bind(@interface).To(TClass);
            if (registrationType == RegistrationScopeEnum.Singleton)
                binder.InSingletonScope();
        }

        public void Register(Type TClass, RegistrationScopeEnum registrationType)
        {
            var binder = Kernel.Bind(TClass).ToSelf();
            if (registrationType == RegistrationScopeEnum.Singleton)
                binder.InSingletonScope();
        }

        public virtual void BuildDependencies() {}

        public T GetService<T>() where T : class => Kernel.Get<T>();

        public T GetService<T>(params object[] parameters) where T : class 
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        public T GetNamedService<T>(string name) where T : class => Kernel.Get<T>(name);

        public T GetNamedService<T>(string name, params object[] parameters) where T : class
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        #endregion
    }
}