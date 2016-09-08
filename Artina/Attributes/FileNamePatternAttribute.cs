using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artina.Attributes
{
    public class FileNamePatternAttribute : Attribute
    {
        public string Pattern;

        public FileNamePatternAttribute(string pattern)
            : base()
        {
            Pattern = pattern;
        }
    }
}
