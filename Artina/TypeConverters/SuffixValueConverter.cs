using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Artina.TypeConverters
{
    public class SuffixValueConverter : TypeConverter
    {
        public virtual Type DataType { get { return typeof(int); } }
        public virtual string FormatString { get { return "{0}{1}"; } }
        public virtual string Suffix { get { return string.Empty; } }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            else return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string)) return true;
            else return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value.GetType() == DataType)
                return string.Format(FormatString, value, Suffix);
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                try
                {
                    string input = Regex.Replace((string)value, @"[^-?\d]", "");
                    return DataType.InvokeMember("Parse", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, new object[] { input, culture });
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return base.ConvertFrom(context, culture, value);
        }
    }

    public class PercentageByteConverter : SuffixValueConverter
    {
        public override Type DataType { get { return typeof(byte); } }
        public override string FormatString { get { return "{0}{1}"; } }
        public override string Suffix { get { return "%"; } }
    }

    public class PercentageSbyteConverter : SuffixValueConverter
    {
        public override Type DataType { get { return typeof(sbyte); } }
        public override string FormatString { get { return "{0}{1}"; } }
        public override string Suffix { get { return "%"; } }
    }
}
