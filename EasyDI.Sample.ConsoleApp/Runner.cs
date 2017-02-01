using System;
using EasyDI.Core.Contracts.Attributes;
using EasyDI.Sample.Contracts.Interfaces;

namespace EasyDI.Sample.ConsoleApp
{
    [RegisterThisService]
    public class Runner
    {
        private IExternalService ExternalService { get; }

        public Runner(IExternalService externalService)
        {
            ExternalService = externalService;
        }

        public void Run()
        {
            Console.WriteLine("EasyDI Console App Demo");
            Console.WriteLine("=======================");
            Console.WriteLine();
            Console.WriteLine(ExternalService.SayHello());
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
