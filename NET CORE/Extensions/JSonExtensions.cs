
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EPublico.Core.Extensions
{
    public static class JSonExtensions
    {
        public static dynamic GetDynamicFromJToken(this JToken json){
            dynamic jsonDynamic = json;

            ExpandoObject converter = new ExpandoObject();
            var properties = new RouteValueDictionary(jsonDynamic);
            

            // foreach (var p in properties)
            // {
            //     converter.AddProperty(p.Key, p.Value);
            // }
            foreach (var item in json)
            {
                
            }

            return converter as dynamic;
        }
    }
}