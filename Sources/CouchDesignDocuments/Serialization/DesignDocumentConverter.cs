namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Collections.Generic;
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
            WriteSection<IFiltersSection>(doc, "filters", writer, serializer);

            WriteSection<IIndexesSection>(doc, "indexes", writer, serializer);

            WriteValidateFunction(writer, doc);

            writer.WriteEndObject();
        }

        private static void WriteSection<TSectionInterface>(IDesignDocument doc, string sectionName, JsonWriter writer, JsonSerializer serializer)
        {
            var sectionType = doc.GetType().GetTypeInfo().GetNestedTypes().SingleOrDefault(t => t.ImplementsInterface(typeof(TSectionInterface)));
            if (sectionType != null)
            {
                writer.WritePropertyName(sectionName);
                serializer.Serialize(writer, ReflectSectionFunctions(sectionType));
            }
        }

        private static IDictionary<string, object> ReflectSectionFunctions(Type sectionType)
        {
            var properties = sectionType.GetTypeInfo().GetMembers(BindingFlags.Public | BindingFlags.Static).OfType<PropertyInfo>();
            return properties.ToDictionary(info => info.Name, info => info.GetValue(null));
        }

        private static void WriteProperty(JsonWriter writer, string name, string value)
        {
            writer.WritePropertyName(name);
            writer.WriteValue(value);
        }

        private static void WriteValidateFunction(JsonWriter writer, IDesignDocument doc)
        {
            var validateProperty = doc.GetType().GetTypeInfo().GetProperty("ValidateDocUpdate");
            if (validateProperty != null)
            {
                WriteProperty(writer, "validate_doc_update", ((FunctionSpec)validateProperty.GetValue(doc)).Content);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // This converter does not support deserialization
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.ImplementsInterface(typeof(IDesignDocument));
        }

        public override bool CanRead { get { return false; } }
    }
}
