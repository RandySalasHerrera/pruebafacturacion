using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace EPublico.Core.Helpers {
    public class DynamicEntityToDTO {

        public static T ToStatic<T> (object expando) {
            if (expando == null)
                return default (T);

            var entity = Activator.CreateInstance<T> ();
            //ExpandoObject implements dictionary
            // var properties = expando as IDictionary<string, object>;
            var properties = new RouteValueDictionary (expando);

            if (properties == null)
                return entity;

            foreach (var entry in properties) {
                var propertyInfo = entity.GetType ().GetProperty (entry.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                    try {
                        propertyInfo.SetValue (entity, entry.Value, null);
                    }
                catch (System.Exception) {

                }

            }
            return entity;
        }

        public static T EntityToDTO<T> (object values) {
            if (values == null)
                return default (T);

            var entity = Activator.CreateInstance<T> ();
            Type valType = values.GetType ();

            foreach (var p in valType.GetProperties (
                    BindingFlags.Public |
                    BindingFlags.Instance)) {
                // do stuff here

                object value = p.GetValue (values, null);
                PropertyInfo pInfo = null;

                pInfo = entity.GetType ().GetProperty (p.Name.ToLower (), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (pInfo == null) {
                    pInfo = entity.GetType ().GetProperty (p.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }

                if (pInfo != null)
                    try {
                        pInfo.SetValue (entity, value, null);
                    }
                catch (System.Exception) {

                }
            }

            return entity;
        }

    }
}