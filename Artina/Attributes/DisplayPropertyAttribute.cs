using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artina.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisplayPropertyAttribute : Attribute
    {
        public DisplayPropertyAttribute() : base() { }
    }
}
