using System;
using System.Collections.Generic;

namespace EasyDI.Core.Classes
{
    public class EasyDISettings
    {
        public List<string> AssemblyFilter { get; set; } 
        public List<string> ExternalAssemblyFilter { get; set; }
        public List<Type> ClassesForcedToRegister { get; set; }
    }
}
