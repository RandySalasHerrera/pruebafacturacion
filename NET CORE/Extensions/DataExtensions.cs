using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using Microsoft.AspNetCore.Routing;
using EPublico.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace EPublico.Core.Extensions
{

    public static class DataExtensions
    {
        public static ICollection<T> ToCollection<T>(this List<T> items)
        {
            ICollection<T> collection = new Collection<T>();

            for (int i = 0; i < items.Count; i++)
            { 
                collection.Add(items[i]);
            }

            return collection;
        }

        public static dynamic ToDynamic<T>(this T obj, object addProperties = null, params string[] ignoreProperties)
        { //IEnumerable<string> ignoreProperties = null) {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var currentValue = propertyInfo.GetValue(obj);
                expando.Add(propertyInfo.Name, currentValue);
            }

            if (addProperties != null)
            {
                var properties = new RouteValueDictionary(addProperties);

                foreach (var entry in properties)
                {
                    expando.Add(entry.Key, entry.Value);
                }
            }

            if (ignoreProperties != null)
            {
                // var properties = new RouteValueDictionary (ignoreProperties);
                foreach (var entry in ignoreProperties)
                {
                    expando.Remove(entry);
                }
            }

            return expando as ExpandoObject;
        }

        public static XElement ToXmlElement<T>(this T obj, string elementName, object addProperties = null, params string[] ignoreProperties)
        {

            XElement xItem = new XElement(elementName);
            if(obj == null){
                return xItem;
            }

            dynamic expando = null;

            if (obj.GetType() == typeof(ExpandoObject))
            {
                expando = obj;
            }
            else
            {
                expando = ToDynamic<T>(obj, addProperties, ignoreProperties);
            }

            var properties = new RouteValueDictionary(expando);

            foreach (var entry in properties)
            {
                xItem.Add(new XAttribute(entry.Key, entry.Value == null ? string.Empty : entry.Value));
            }

            return xItem;
        }

        public static XElement ToXmlElement(this string obj, string elementName, string fieldName)
        {

            XElement xItem = new XElement(elementName);
            xItem.Add(new XAttribute(fieldName, obj == null ? string.Empty : obj));

            return xItem;
        }

        public static XDocument ToXmlDocument<T>(this List<T> list, string rootElement, string elementName)
        {
            // public XDocument BuildXDocument (List<object> list, string rootElement, string elementName) {
            XDocument xItems = XDocument.Parse(string.Format("<{0}></{0}>", rootElement));

            foreach (var item in list)
            {
                XElement element = item.ToXmlElement(elementName);
                xItems.Root.Add(element);
            }

            return xItems;
            // }
        }

        public static XDocument ToXmlDocument<T>(this T entity, string rootElement, string elementName)
        {
            XDocument xItems = XDocument.Parse(string.Format("<{0}></{0}>", rootElement));
            XElement element = entity.ToXmlElement(elementName);
            xItems.Root.Add(element);

            return xItems;
        }

        /// <summary>
        /// Convierte un JObject en XDocument, solo recorre el primer nivel de nodos
        /// </summary>
        /// <param name="rootElementName">El nombre del nodo ROOT en el XML</param>
        public static XDocument ToXmlDocument(this JObject values, string rootElementName)
        {
            var converter = new ExpandoObjectConverter();
            dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(values.ToString(), converter);


            XDocument xDoc = XDocument.Parse(string.Format("<{0}></{0}>", rootElementName));
            var properties = new RouteValueDictionary(data);

            foreach (var f in properties)
            {
                string name = f.Key;
                ExpandoObject val = (ExpandoObject)f.Value;

                XElement element = val.ToXmlElement(name);

                xDoc.Root.Add(element);
            }

            return xDoc;
        }




        
        public static byte[] GetBytes(this IFormFile file)
        {
            // get the file and convert it to the byte[]
            byte[] fileBytes = new Byte[file.Length];
            file.OpenReadStream().Read(fileBytes, 0, Int32.Parse(file.Length.ToString()));

            return fileBytes;
        }

        public static string ToJson(this dynamic[] v)
        {
            // get the file and convert it to the byte[]

            return JArray.FromObject(v).ToString();
        }
    }

}