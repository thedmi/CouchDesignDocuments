namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;

    public abstract class DesignDocument<TViews, TShows> : IDesignDocument  
        where TViews : ViewsSection, new()
        where TShows : ShowsSection, new()
    {
        private readonly TViews _views;

        private TShows _shows;

        protected DesignDocument()
        {
            _views = new TViews { ConcreteSectionType = typeof(TViews) };
            _shows = new TShows { ConcreteSectionType = typeof(TShows) };
        }

        [JsonProperty(PropertyName = "_id")]
        public string Id { get { return "_design/" + Name; } }

        [JsonIgnore]
        public abstract string Name { get; }

        [JsonProperty(PropertyName = "views")]
        public TViews Views { get { return _views; } }

        [JsonProperty(PropertyName = "shows")]
        public TShows Shows { get { return _shows; } }
    }
}