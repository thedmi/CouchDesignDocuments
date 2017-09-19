namespace TheDmi.CouchDesignDocuments
{
    using System;

    using Newtonsoft.Json;

    public class IndexSpec
    {
        private readonly Lazy<string> _indexFunction;

        internal IndexSpec(Lazy<string> indexFunction)
        {
            _indexFunction = indexFunction;
        }

        [JsonProperty(PropertyName = "index")]
        public string Map => _indexFunction.Value;
    }
}