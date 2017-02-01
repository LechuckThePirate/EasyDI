using System;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using EasyDI.Core.Classes;
using EasyDI.Core.Contracts;


namespace EasyDI.Autofac
{
    public class AutofacEasyDIEngine : IEasyDIEngine
    {

        #region .: Fields and services :.

        protected ContainerBuilder _containerBuilder;
        private IContainer _container = null;
        protected IContainer Container => _container; 

        #endregion

        #region .: Ctor :.

        public AutofacEasyDIEngine()
        {
            _containerBuilder = new ContainerBuilder();
            foreach (var referencedAssembly in AppDomain.CurrentDomain.GetAssemblies())
                _containerBuilder.RegisterControllers(referencedAssembly);
        }

        #endregion

        #region .: Public methods :.

        public void Register(Type TClass, Type @interface, RegistrationScopeEnum registrationType = RegistrationScopeEnum.Default)
        {
            RegisterAsType(_containerBuilder.RegisterType(TClass).As(@interface), registrationType);
        }

        public void Register(Type TClass, RegistrationScopeEnum registrationType)
        {
            RegisterAsType(_containerBuilder.RegisterType(TClass).AsSelf(), registrationType);
        }

        public virtual void BuildDependencies()
        {
            _container = _containerBuilder.Build();
        }

        public T GetService<T>() where T : class => Container.Resolve<T>();

        public T GetService<T>(params object[] parameters) where T : class
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        public T GetNamedService<T>(string name) where T : class => Container.ResolveNamed<T>(name);

        public T GetNamedService<T>(string name, params object[] parameters) where T : class
        {
            // TODO: Implement (use reflection to get param names)
            throw new NotImplementedException();
        }

        #endregion

        #region .: Private methods :.

        private void RegisterAsType(IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder,
            RegistrationScopeEnum registrationType)
        {
            switch (registrationType)
            {
                case RegistrationScopeEnum.Default:
                    registrationBuilder.InstancePerDependency();
                    break;
                case RegistrationScopeEnum.Singleton:
                    registrationBuilder.SingleInstance();
                    break;
            }
        }

        #endregion

    }
}