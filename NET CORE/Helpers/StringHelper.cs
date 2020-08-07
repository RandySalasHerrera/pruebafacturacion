using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EPublico.Core.Extensions;

namespace EPublico.Core.Helpers {
    public static class StringHelper {
        public static bool CsvIntegerValid (string csv) {
            if (string.IsNullOrEmpty (csv))
                return true;

            if (!csv.Contains (",")) {
                try {
                    Convert.ToInt64 (csv);
                } catch (System.Exception) {
                    return false;
                }
            } else {
                string[] splitted = csv.Split (',');
                if (splitted.Length == 0)
                    return false;

                if (splitted.Where (i => string.IsNullOrEmpty (i)).Count () > 0) {
                    return false;
                }
            }
            return true;
        }

        public static List<string> CsvToList (string csv) {
            List<string> items = new List<string> ();

            if (string.IsNullOrEmpty (csv))
                return items;

            string[] splitted = csv.Split (',');
            if (splitted.Length == 0)
                return items;

            foreach (var i in splitted) {
                items.Add (i);
            }

            return items;
        }

        public static XDocument CsvToXml (string csv, string rootName, string elementName, string fieldName) {
            string root = string.Format ("<{0}></{0}>", rootName);
            XDocument xDoc = XDocument.Parse (root);
            foreach (var item in CsvToList (csv)) {
                xDoc.Root.Add (item.ToXmlElement (elementName, fieldName));
            }

            return xDoc;
        }
    }
}