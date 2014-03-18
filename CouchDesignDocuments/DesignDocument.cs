namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;

    public abstract class DesignDocument<TViews> : IDesignDocument  
        where TViews : DesignDocumentViews, new()
    {
        private readonly TViews _views;

        protected DesignDocument()
        {
            _views = new TViews { ConcreteViewsType = typeof(TViews) };
        }

        [JsonProperty(PropertyName = "_id")]
        public string Id { get { return "_design/" + Name; } }

        [JsonIgnore]
        public abstract string Name { get; }

        [JsonProperty(PropertyName = "views")]
        public TViews Views { get { return _views; } }
    }
}