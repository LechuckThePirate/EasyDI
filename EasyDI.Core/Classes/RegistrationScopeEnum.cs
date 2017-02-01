namespace EasyDI.Core.Classes
{
    public enum RegistrationScopeEnum
    {
        Default,
        Singleton,
        // TODO: Implement this in all engines
        InstancePerDependency,
        InstancePerRequest,
        InstancePerThread
    }
}