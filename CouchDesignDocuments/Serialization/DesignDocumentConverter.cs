namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;

    public class DesignDocumentConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var doc = (IDesignDocument)value;

            writer.WriteStartObject();
            WriteProperty(writer, "_id", doc.Id);

            WriteSection<IViewsSection>(doc, "views", writer, serializer);
            WriteSection<IShowsSection>(doc, "shows", writer, serializer);
            WriteSection<IListsSection>(doc, "lists", writer, serializer);
            WriteSection<IUpdatesSection>(doc, "updates", writer, serializer);

            writer.WriteEndObject();
        }

        private static void WriteSection<TSectionInterface>(IDesignDocument doc, string sectionName, JsonWriter writer, JsonSerializer serializer)
        {
            var sectionType = doc.GetType().GetNestedTypes().SingleOrDefault(t => t.ImplementsInterface(typeof(TSectionInterface)));
            if (sectionType != null)
            {
                var sectionFunctions = sectionType.GetMembers(BindingFlags.Public | BindingFlags.Static);

                var expando = new ExpandoObject() as IDictionary<string, object>;

                foreach (var sectionFunction in sectionFunctions)
                {
                    var info = sectionFunction as PropertyInfo;
                    if (info != null)
                    {
                        expando.Add(info.Name, info.GetValue(null));
                    }
                }

                writer.WritePropertyName(sectionName);
                serializer.Serialize(writer, expando);
            }
        }

        private static void WriteProperty(JsonWriter writer, string name, string value)
        {
            writer.WritePropertyName(name);
            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.ImplementsInterface(typeof(IDesignDocument));
        }
    }
}
