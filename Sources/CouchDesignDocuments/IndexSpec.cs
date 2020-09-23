namespace TheDmi.CouchDesignDocuments
{
    using System;

    using Newtonsoft.Json;

    public class IndexSpec
    {
        private readonly Lazy<string> _indexFunction;

        internal IndexSpec(Lazy<string> indexFunction, dynamic analyzer)
        {
            _indexFunction = indexFunction;
            Analyzer = analyzer;
        }

        [JsonProperty(PropertyName = "index")]
        public string Map => _indexFunction.Value;

        public dynamic Analyzer { get; }

        public bool ShouldSerializeAnalyzer()
        {
            return (Analyzer != null);
        }
    }
}