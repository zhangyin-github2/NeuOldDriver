using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace NeuOldDriver.Extensions {

    public static class ReflectionExtensions {

        /// <summary>
        /// Retrieve value from object by name
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="propname">name of property</param>
        /// <returns>value of property</returns>
        public static object GetValue(this object obj, string propname) {
            return obj?.GetType().GetProperty(propname)?.GetValue(obj, null);
        }

        /// <summary>
        /// Retrieve value from object by name, generic version
        /// </summary>
        /// <typeparam name="T">specified result type</typeparam>
        /// <param name="obj">object</param>
        /// <param name="propname">name of property</param>
        /// <exception cref=""></exception>
        /// <returns>value of property casted to type T</returns>
        public static T GetValue<T>(this object obj, string propname) {
            return (T)obj.GetValue(propname);
        }

        public static IEnumerable<string> GetPropertyNames(this object obj) {
            return obj?.GetType().GetProperties().Select(prop => prop.Name);
        }

        public static IDictionary<string, object> GetPropertyValuePairs(this object obj) {
            var props = obj?.GetType().GetProperties();
            var ret = new Dictionary<string, object>();
            props?.ForEach((prop) => {
                ret.Add(prop.Name, prop.GetValue(obj, null));
            });
            return ret;
        }
    }
}
