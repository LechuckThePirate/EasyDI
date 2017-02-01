# EasyDI
Multi DI engine library for easy Dependency Injection with class auto-registration

Registering your classes at any project, as you may know if you've worked in a medium/big project is a tedious work and can be a real mess ending with a "RegisterTypes" class with hundreds or thousands of lines in the worst case.

For this, I've created this little library that will help you auto-registering classes for your projects in any IoC/DI library of your choice. It's already got implemented engines for Autofac, Unity and nInject, but you can easily use your own DI engine by just implementing the interface "IEasyDIEngine".

The usage is pretty simple, at your Global.asax.cs / Startup.cs or Program.cs you just need to initialize the EasyDIService class like this:
    
    new EasyDIService(new AutofacEasyDIEngineMVC()).RegisterDependencies();
    
If your project uses a lot of libraries, you can filter the assembly scan scope by passing a list of partial namespaces you want to include, so the library won't look for classes in the namespaces that doesn't match, like this:

    new EasyDIService(new AutofacEasyDIEngineMVC()).RegisterDependencies(new EasyDISettings()
      {
          AssemblyFilter = new List<string> { "EasyDI." }
      });
      
The library can even register classes that aren't referenced by the application if their .dll is deployed at the solution's directory and included in the "ExternalAssemblyFilter" of the settings, like this:

    new EasyDIService(new AutofacEasyDIEngineMVC()).RegisterDependencies(new EasyDISettings
         {
            ExternalAssemblyFilter = new List<string> { "EasyDI.Sample.NonReferenced.Services" }
         });
         
If you want to force registration of classes - for example all classes descending from Controller - you can also specify it like this:

    new EasyDIService(new AutofacEasyDIEngineMVC()).RegisterDependencies(new EasyDISettings
         {
            ClassesForcedToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof (Controller).IsAssignableFrom(t))
                .ToList()
         });
         
Finally, the classes or interfaces you want to be registered, must have the attribute "RegisterThisService", and the classes/interfaces you don't want to be auto-registered must have the attribute "DontRegisterThisService". You can add a scope from the "RegistrationScopeEnum" to change their lifetime.

There are demo projects in the solution so you can see the usage under MVC or a console application, for example.

THIS IS A WORK-IN-PROGRESS ... check the "Project" tab in GitHub to see the TODO items. If you find something interesting that could be implemented or something totally wrong, you can always contact me at joan.vilarino at gmail.com
