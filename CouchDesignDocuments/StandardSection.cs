namespace TheDmi.CouchDesignDocuments
{
    using System;

    public abstract class StandardSection<TSelf>
    {
        protected static FunctionSpec SectionPart(string showFunctionName, string partNamespace)
        {
            return
                new FunctionSpec(
                    new Lazy<string>(
                        () => SectionJsReader.ReadJsFromResources(showFunctionName, partNamespace, typeof(TSelf))));
        }
    }
}