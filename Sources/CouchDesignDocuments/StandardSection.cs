namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Reflection;

    using TheDmi.CouchDesignDocuments.Resources;

    public abstract class StandardSection<TSelf>
    {
        protected static FunctionSpec SectionPart(string functionName, string partNamespace)
        {
            return
                new FunctionSpec(
                    new Lazy<string>(
                        () => SectionJsReader.ReadJsFromResources(functionName, partNamespace, typeof(TSelf))));
        }
    }
}