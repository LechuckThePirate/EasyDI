using System;
using EasyDI.Core.Classes;
using EasyDI.Core.Contracts;
using Microsoft.Practices.Unity;

namespace EasyDI.Unity
{
    public class UnityDependencyInjectionEngine : IEasyDIEngine
    {
        #region .: Fields and services :.

        protected UnityContainer Container { get; }

        #endregion

        #region .: Ctor :.

        public UnityDependencyInjectionEngine()
        {
            Container = new UnityContainer();
        }

        #endregion

        #region .: Public methods

        public void Register(Type TClass, Type @interface, RegistrationScopeEnum registrationType)
        {
            Container.RegisterType(@interface, TClass, GetLifetimeManager(registrationType));
        }

        public void Register(Type TClass, RegistrationScopeEnum registrationType)
        {
            Container.RegisterType(TClass, GetLifetimeManager(registrationType));
        }

        public virtual void BuildDependencies()
        {
        }

        public T GetService<T>() where T : class => Container.Resolve<T>();

        public T GetService<T>(params object[] parameters) where T : class
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        public T GetNamedService<T>(string name) where T : class => Container.Resolve<T>(name);

        public T GetNamedService<T>(string name, params object[] parameters) where T : class
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        #endregion

        #region .: Private methods :.

        private LifetimeManager GetLifetimeManager(RegistrationScopeEnum registrationType)
        {
            switch (registrationType)
            {
                case RegistrationScopeEnum.Default:
                    return null;
                case RegistrationScopeEnum.Singleton:
                    return new ContainerControlledLifetimeManager();
            }
            return null;
        }

        #endregion

    }
}
