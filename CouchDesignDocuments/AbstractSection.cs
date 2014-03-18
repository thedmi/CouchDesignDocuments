namespace TheDmi.CouchDesignDocuments
{
    using System;

    using Newtonsoft.Json;

    using TheDmi.CouchDesignDocuments.Resources;

    public abstract class AbstractSection
    {
        [JsonIgnore]
        public Type ConcreteSectionType { get; internal set; }

        protected string ReadJsFromResources(string baseName, string part)
        {
            if (ConcreteSectionType == null)
            {
                throw new InvalidOperationException(
                    "ConcreteSectionType not available. Do not instantiate ViewsSection objects directly.");
            }

            var resourceLocator = new ResourceLocator(ConcreteSectionType.Assembly);
            var resourceName = resourceLocator.GetResourceFqn(baseName + ".js", ConcreteSectionType.Namespace, part);

            return new JavaScriptResourceReader().ReadJs(ConcreteSectionType.Assembly, resourceName);
        }
    }
}