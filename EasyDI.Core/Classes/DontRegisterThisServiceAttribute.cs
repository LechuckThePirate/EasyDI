using System;

namespace EasyDI.Core.Classes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class DontRegisterThisServiceAttribute : Attribute
    {
    }
}
