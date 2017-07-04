using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace NFine.Code.Json
{
    public static class Json
    {
        public static object ToJson(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject(json);
        }

        public static object ToJson(this object obj)
        {
            return ToJson(obj, "yyyy-MM-dd HH:mm:ss");
        }

        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = datetimeformats
            };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        public static T ToObject<T>(this string json)
        {
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static JObject ToJObject(this string json)
        {
            return json == null ? JObject.Parse("{}") :
                JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}
