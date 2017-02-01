using System;
using EasyDI.Core.Classes;
using EasyDI.Sample.Contracts.Interfaces;

namespace EasyDI.Sample.NonReferenced.Services
{
    [RegisterThisService]
    public class MyService : IExternalService
    {
        private INestedExternalService NestedService { get; }


        public MyService(INestedExternalService nestedService)
        {
            NestedService = nestedService;
        }

        public void TerrificMethodOne()
        {
            Console.WriteLine("Boo!!!");
        }

        public string SayHello()
        {
            return $"Hi there! My nested service says: {NestedService.ThisIsAString}";
        }
    }
}
