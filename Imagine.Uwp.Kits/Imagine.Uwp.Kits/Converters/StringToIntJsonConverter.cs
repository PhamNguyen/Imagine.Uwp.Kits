using Newtonsoft.Json;
using Imagine.Uwp.Kits.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Uwp.Kits.Converters
{
    public class StringToIntJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader != null && reader.Value != null)
            {
                return ParseHelper.TryGetValue<int>(reader.Value.ToString());
            }
            return 0;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
