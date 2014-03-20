namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;

    public abstract class DesignDocument<TViews> : IDesignDocument
        where TViews : new()
    {
        private readonly TViews _views;

        [JsonProperty(PropertyName = "_id")]
        public string Id { get { return "_design/" + Name; } }

        [JsonIgnore]
        public abstract string Name { get; }

        protected DesignDocument()
        {
            _views = new TViews();
        }

        [JsonIgnore]
        public TViews Views { get { return _views; } }
    }
}