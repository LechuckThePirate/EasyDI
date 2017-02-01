using System;
using EasyDI.Core.Contracts.Enums;

namespace EasyDI.Core.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class RegisterThisServiceAttribute : Attribute
    {

        private readonly RegistrationScopeEnum _registrationType;
        public RegistrationScopeEnum RegistrationType { get { return _registrationType; } }

        public RegisterThisServiceAttribute(RegistrationScopeEnum registrationType)
        {
            _registrationType = registrationType;
        }

        public RegisterThisServiceAttribute()
        {
            _registrationType = RegistrationScopeEnum.Default;
        }

    }
}