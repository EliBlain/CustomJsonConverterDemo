using JsonConverterDemo.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CustomJsonConverter
{
    public class CustomConverter : JsonConverter<ComplexCustomClass>
    {
        public override ComplexCustomClass ReadJson(JsonReader reader, Type objectType, [AllowNull] ComplexCustomClass existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            var jobj = new JObject(s);
            var obj = new ComplexCustomClass();
            var toAdd= new List<CustomClass>();

            var collection = jobj["collection"];
            if(collection != null)
            {
                foreach (var token in collection)
                {
                    toAdd.Add(token.ToObject<CustomClass>());
                }
            }

            obj.Collection = toAdd;

            return obj;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ComplexCustomClass value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            
            writer.WritePropertyName("Collection");
            if (value.Collection == null)
                writer.WriteNull();
            else
            {
                writer.WriteStartArray();
                foreach(var val in value.Collection)
                {
                    serializer.Serialize(writer, val as CustomClass);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
