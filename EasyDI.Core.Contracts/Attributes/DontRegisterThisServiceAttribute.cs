using System;

namespace EasyDI.Core.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class DontRegisterThisServiceAttribute : Attribute
    {
    }
}
