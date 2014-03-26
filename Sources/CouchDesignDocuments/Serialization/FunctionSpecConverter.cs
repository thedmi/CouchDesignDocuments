namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;

    using Newtonsoft.Json;

    public class FunctionSpecConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var spec = (FunctionSpec)value;
            serializer.Serialize(writer, spec.Content);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FunctionSpec);
        }

        public override bool CanRead { get { return false; } }
    }
}