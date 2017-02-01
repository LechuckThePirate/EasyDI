using EasyDI.Core.Classes;

namespace EasyDI.Sample.WebUI.Services
{
    [RegisterThisService(RegistrationScopeEnum.Singleton)]
    public class MyLocalService : ILocalService
    {
        public string GuessWhat()
        {
            return "I'm another service";
        }
    }
}