namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    public class DesignDocumentConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var doc = (IDesignDocument)value;

            writer.WriteStartObject();
            WriteProperty(writer, "_id", doc.Id);

            WriteSection<ViewsSection>(doc, "views", writer, serializer);
            WriteSection<ShowsSection>(doc, "shows", writer, serializer);

            writer.WriteEndObject();
        }

        private static void WriteSection<TSection>(IDesignDocument doc, string sectionName, JsonWriter writer, JsonSerializer serializer) where TSection : AbstractSection
        {
            var viewsSectionType = doc.GetType().GetNestedTypes().SingleOrDefault(t => t.IsSubclassOf(typeof(TSection)));
            if (viewsSectionType != null)
            {
                var viewsSection = (TSection)Activator.CreateInstance(viewsSectionType);
                viewsSection.ConcreteSectionType = viewsSectionType;
                writer.WritePropertyName(sectionName);
                serializer.Serialize(writer, viewsSection);
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
            return objectType.GetInterfaces().Any(i => i == typeof(IDesignDocument));
        }
    }
}
