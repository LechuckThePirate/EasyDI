using EasyDI.Core.Classes;
using EasyDI.Core.Contracts.Attributes;
using EasyDI.Core.Contracts.Enums;

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