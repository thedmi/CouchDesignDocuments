namespace TheDmi.CouchDesignDocuments
{
    using System;

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