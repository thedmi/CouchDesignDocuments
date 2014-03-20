namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    using Newtonsoft.Json;

    public abstract class DesignDocument : IDesignDocument
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get { return "_design/" + Name; } }

        [JsonIgnore]
        public abstract string Name { get; }
        
        protected FunctionSpec Function([CallerMemberName] string functionName = null)
        {
            return
                new FunctionSpec(
                    new Lazy<string>(
                        () => SectionJsReader.ReadJsFromResources(functionName, "", GetType())));
        }
    }
}