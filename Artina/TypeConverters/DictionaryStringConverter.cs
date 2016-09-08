using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Artina.TypeConverters
{
    public abstract class DictionaryStringConverter : TypeConverter
    {
        public virtual Dictionary<ushort, string> Dictionary { get { return null; } }

        StandardValuesCollection values;

        public DictionaryStringConverter()
        {
            if (values == null)
            {
                List<ushort> valueList = new List<ushort>();
                foreach (KeyValuePair<ushort, string> pair in Dictionary) valueList.Add(pair.Key);
                values = new StandardValuesCollection(valueList.ToArray());
            }
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return values;
        }

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
            if (destinationType == typeof(string) && value.GetType() == typeof(ushort) && Dictionary != null)
                return (Dictionary.ContainsKey((ushort)value) ? Dictionary[(ushort)value] : string.Format("[{0}]", value));
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                try
                {
                    return Dictionary.FirstOrDefault(x => x.Value.ToLowerInvariant().Contains((value as string).ToLowerInvariant())).Key;
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

    public class EvilityStringConverter : DictionaryStringConverter
    {
        public override Dictionary<ushort, string> Dictionary { get { return DataManager.EvilityNames; } }
    }

    public class SkillStringConverter : DictionaryStringConverter
    {
        public override Dictionary<ushort, string> Dictionary { get { return DataManager.SkillNames; } }
    }

    public class InnocentStringConverter : DictionaryStringConverter
    {
        public override Dictionary<ushort, string> Dictionary { get { return DataManager.InnocentNames; } }
    }
}
