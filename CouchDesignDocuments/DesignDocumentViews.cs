namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    using Newtonsoft.Json;

    using TheDmi.CouchDesignDocuments.Resources;

    public abstract class DesignDocumentViews
    {
        [JsonIgnore]
        public Type ConcreteViewsType { get; internal set; }

        protected MapReduceSpec MapView([CallerMemberName] string mapFunctionName = null)
        {
            return new MapReduceSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName)),
                new Lazy<string>(() => null));
        }

        protected MapReduceSpec MapReduceView([CallerMemberName] string mapFunctionName = null)
        {
            return new MapReduceSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName)),
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName + ".reduce")));
        }

        private string ReadJsFromResources(string baseName)
        {
            if (ConcreteViewsType == null)
            {
                throw new InvalidOperationException("ConcreteViewsType not available. Do not instantiate DesignDocumentViews objects directly.");
            }

            var resourceLocator = new ResourceLocator(ConcreteViewsType.Assembly);
            var resourceName = resourceLocator.GetResourceFqn(baseName + ".js", ConcreteViewsType.Namespace, "Views");

            return new JavaScriptResourceReader().ReadJs(ConcreteViewsType.Assembly, resourceName);
        }
    }
}