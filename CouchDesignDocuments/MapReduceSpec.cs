namespace TheDmi.CouchDesignDocuments
{
    using System;

    using Newtonsoft.Json;

    public class MapReduceSpec
    {
        private readonly Lazy<string> _mapFunction;

        private readonly Lazy<string> _reduceFunction; // May evaluate to null

        public MapReduceSpec(Lazy<string> mapFunction, Lazy<string> reduceFunction)
        {
            _mapFunction = mapFunction;
            _reduceFunction = reduceFunction;
        }

        [JsonProperty(PropertyName = "map")]
        public string Map { get { return _mapFunction.Value; } }

        [JsonProperty(PropertyName = "reduce", NullValueHandling = NullValueHandling.Ignore)]
        public string Reduce { get { return _reduceFunction.Value; } }

    }
}