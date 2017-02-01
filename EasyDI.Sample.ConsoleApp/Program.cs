using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyDI.Core;
using EasyDI.nInject;
using EasyDI.Sample.Contracts;
using EasyDI.Sample.NonReferenced.Services;

namespace EasyDI.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var diService = RegisterDependencies();
            diService.GetService<Runner>().Run();

        }

        static EasyDIService RegisterDependencies()
        {
            var result = new EasyDIService(new NInjectEasyDIEngine());
            result.RegisterDependencies();
            return result;
        }
    }
}
