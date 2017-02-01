namespace EasyDI.Core.Contracts.Enums
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