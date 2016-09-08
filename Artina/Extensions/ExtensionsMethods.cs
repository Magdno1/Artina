using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Artina.Extensions
{
    public static class ExtensionsMethods
    {
        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return obj.GetType().GetAttribute<T>();
        }

        public static T GetAttribute<T>(this PropertyInfo propInfo) where T : Attribute
        {
            return (propInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault() as T);
        }

        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            return (type.GetCustomAttributes(typeof(T), true).FirstOrDefault() as T);
        }

        public static string ToPropertiesString(this object obj)
        {
            List<string> propStrings = new List<string>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                propStrings.Add(string.Format("{0}={1}", prop.Name, prop.GetValue(obj, null)));
            }
            return string.Format("[{0}]", string.Join(", ", propStrings));
        }
    }
}
