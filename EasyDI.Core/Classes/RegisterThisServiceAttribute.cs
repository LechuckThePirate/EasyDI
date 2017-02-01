using System;

namespace EasyDI.Core.Classes
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