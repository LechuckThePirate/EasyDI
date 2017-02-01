using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EasyDI.Core.Classes;
using EasyDI.Core.Contracts;
using EasyDI.Core.Contracts.Attributes;
using EasyDI.Core.Contracts.Enums;
using EasyDI.Core.Contracts.Interfaces;

namespace EasyDI.Core
{
    public class EasyDIService 
    {
        #region .: Fields and Services :.

        private readonly IEasyDIEngine _engine;
        private IEnumerable<Type> _allTypes;
        protected IEasyDIEngine Engine => _engine;

        #endregion

        #region .: Ctor :.

        public EasyDIService(IEasyDIEngine engine)
        {
            _engine = engine;
        }

        #endregion

        #region .: Public methods :.

        public virtual void RegisterDependencies(EasyDISettings options = null)
        {
            var assemblies = new List<Assembly>();
            assemblies.AddRange(GetReferencedAssemblies(options?.AssemblyFilter));
            assemblies.AddRange(GetNonReferencedAssemblies(options?.ExternalAssemblyFilter));

            _allTypes = assemblies.SelectMany(a => a.ExportedTypes);
            var typesToRegister = _allTypes
                .Where(t => t.GetCustomAttributes(typeof(RegisterThisServiceAttribute), false).Any()
                         && !t.GetCustomAttributes(typeof(DontRegisterThisServiceAttribute),false).Any())
                .Distinct().ToList();

            typesToRegister.Where(t => t.IsInterface).ToList()
                .ForEach(RegisterInterface);

            typesToRegister.Where(t => t.IsClass && !t.IsAbstract).ToList()
                .ForEach(RegisterClass);

            options?.ClassesForcedToRegister?.ForEach(RegisterClassAsSelf);

            Engine.BuildDependencies();

        }

        public T GetService<T>() where T : class => _engine.GetService<T>();

        public T GetService<T>(params object[] parameters) where T : class => _engine.GetService<T>(parameters);

        public T GetNamedService<T>(string name) where T : class => _engine.GetNamedService<T>(name);

        public T GetNamedService<T>(string name, params object[] parameters) where T : class => _engine.GetNamedService<T>(name, parameters);

        #endregion

        #region .: Protected / Virtual methods :.

        protected RegistrationScopeEnum GetRegistrationType(Type t)
        {
            var attr = t.GetCustomAttribute<RegisterThisServiceAttribute>(false);
            attr = attr ?? new RegisterThisServiceAttribute();
            return attr.RegistrationType;
        }

        protected virtual void RegisterClass(Type t)
        {
            if (t.GetInterfaces().Any())
                t.GetInterfaces()
                    .Where(i => !i.GetCustomAttributes<DontRegisterThisServiceAttribute>(false).Any())
                    .ToList()
                    .ForEach(i => _engine.Register(t, i, GetRegistrationType(t)));
            else
                RegisterClassAsSelf(t);
        }

        protected virtual void RegisterClassAsSelf(Type t)
        {
            _engine.Register(t, GetRegistrationType(t));
        }

        protected virtual void RegisterInterface(Type @interface)
        {
            _allTypes.Where(t => !t.IsAbstract && t.IsClass && @interface.IsAssignableFrom(t))
                .ToList()
                .ForEach(t => _engine.Register(t,@interface, GetRegistrationType(t)));
        }

        protected virtual void Register<TClass>(Type @interface) where TClass : class
        {
            var attr = typeof(TClass).GetCustomAttributes(typeof(RegisterThisServiceAttribute), false).FirstOrDefault()
                as RegisterThisServiceAttribute;
            _engine.Register(typeof(TClass), @interface, attr?.RegistrationType ?? RegistrationScopeEnum.Default);
        }

        #endregion

        #region .: Private methods :.

        private bool IsAnyMatch(string s, IEnumerable<string> matches)
        {
            var result = (matches != null && matches.Any(m => s.Equals(m) || s.StartsWith(m)));
            return result;
        }

        private IEnumerable<Assembly> GetReferencedAssemblies(IEnumerable<string> filter )
        {
            var result = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => filter == null || IsAnyMatch(a.GetName().Name,filter));
            return result;
        }

        private IEnumerable<Assembly> GetNonReferencedAssemblies(IEnumerable<string> matches)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var result =  Directory.GetFiles(path, "*.dll")
                .Concat(Directory.GetFiles(path, "*.exe"))
                .Where(file => matches == null || IsAnyMatch(file,matches) && AssemblyIsNotLoaded(file))
                .Select(Assembly.LoadFrom);
            return result;
        }

        private bool AssemblyIsNotLoaded(string filename)
        {
            var result =
                AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly => assembly.Location)
                    .All(location => !string.Equals(filename, location, StringComparison.InvariantCultureIgnoreCase));
            return result;
        }

        #endregion

    }
}
