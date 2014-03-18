namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;

    public abstract class DesignDocument
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get { return "_design/" + Name; } }

        [JsonIgnore]
        public abstract string Name { get; }
    }
}