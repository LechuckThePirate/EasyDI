using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using EasyDI.Autofac.MVC;
using EasyDI.Core;
using EasyDI.Core.Classes;
using EasyDI.Core.Contracts;
using EasyDI.Sample.WebUI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EasyDI.Sample.WebUI.Startup))]
namespace EasyDI.Sample.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Change here to your preferred IoC framework
            //   available: UnityEasyDIEngine, 
            //              AutofacEasyDIEngine, 
            //              NInjectEasyDIEngine
            // Don't forget to reference the library in the project, 
            // and don't reference more than one engine at a time 
            // since they have incompatibilities and your app would't run
            ConfigureSimpleDependencyInjector(new AutofacEasyDIEngineMVC());
        }

        private void ConfigureSimpleDependencyInjector(IEasyDIEngine engine)
        {
            new EasyDIService(engine).RegisterDependencies(new EasyDISettings()
            {
                AssemblyFilter = new List<string> { "EasyDI." }
            });
        }


        // Here is a custom settings option if you wanna do more tests...
        // To use this one, you should "de-reference" DITest.NonReferenced.Service, as it's assembly 
        // is loaded as External (the .dll should be copied manually to the /bin project's folder
        private void ConfigureCustomDependencyInjector(IEasyDIEngine engine)
        {

            new EasyDIService(engine)
                .RegisterDependencies(new EasyDISettings
                {
                    // Filters types to avoid scanning too much classes... you can set it null if you don't mind
                    AssemblyFilter = new List<string> { "EasyDI.",  },
                    // Assembly files (.dll or .exe) that aren't referenced and you want to include. Normally not needed
                    ExternalAssemblyFilter = new List<string> { "EasyDI.Sample.NonReferenced.Services" },
                    // Classes you want to include without having the DependencyIndectionRegisterAttribute
                    ClassesForcedToRegister = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => typeof (Controller).IsAssignableFrom(t))
                        .ToList()
                });

        }

    }
}
