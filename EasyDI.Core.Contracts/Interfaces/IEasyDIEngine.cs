using System;
using EasyDI.Core.Contracts.Enums;

namespace EasyDI.Core.Contracts.Interfaces
{
    public interface IEasyDIEngine
    {
        void Register(Type TClass, Type @interface, RegistrationScopeEnum registrationType);
        void Register(Type TClass, RegistrationScopeEnum registrationType);
        void BuildDependencies();

        T GetService<T>() where T : class;
        T GetService<T>(params object[] parameters) where T : class;
        T GetNamedService<T>(string name) where T : class;
        T GetNamedService<T>(string name, params object[] parameters) where T : class;
    }
}
