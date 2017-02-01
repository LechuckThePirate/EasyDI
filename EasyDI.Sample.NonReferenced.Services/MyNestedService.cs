using EasyDI.Core.Contracts.Attributes;
using EasyDI.Sample.Contracts.Interfaces;

namespace EasyDI.Sample.NonReferenced.Services
{
    [RegisterThisService]
    public class MyNestedService : INestedExternalService
    {
        public string ThisIsAString => "HELLO!";
    }
}
