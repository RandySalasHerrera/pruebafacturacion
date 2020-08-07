using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EPublico.Core.Classes {
    public class LowercaseContractResolver : DefaultContractResolver {
        protected override string ResolvePropertyName (string propertyName) {
            return propertyName.ToLower ();
        }

    }

    public class JsonSerializerDefault {
        public static JsonSerializer LowerCaseJsonSerializer () {
            var st = new JsonSerializer ();
            st.ContractResolver = new LowercaseContractResolver ();
            st.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            return st;

        }

        public static JsonSerializerSettings LowerCaseSerializerSettings () {
            var st = new JsonSerializerSettings ();
            st.ContractResolver = new LowercaseContractResolver ();
            st.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            return st;

        }
    }

    public class LowerCasePropertyNameJsonReader : JsonTextReader
    {
        public LowerCasePropertyNameJsonReader(TextReader textReader)
            : base(textReader)
        {
        }

        public override object Value
        {
            get
            {
                if (TokenType == JsonToken.PropertyName)
                    return ((string)base.Value).ToLower();

                return base.Value;
            }
        }
    }

    public static class JsonHelper
    {
        public static JToken DeserializeWithLowerCasePropertyNames(string json)
        {
            using (TextReader textReader = new StringReader(json))
            using (JsonReader jsonReader = new LowerCasePropertyNameJsonReader(textReader))
            {
                JsonSerializer ser = new JsonSerializer();
                // ser.Deserialize()
                
                // var token = JObject.FromObject(jsonReader);
                var token = ser.Deserialize<JToken>(jsonReader);
                return token;
            }
        }
    }

}