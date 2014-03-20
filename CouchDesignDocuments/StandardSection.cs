namespace TheDmi.CouchDesignDocuments
{
    using System;

    public abstract class StandardSection
    {
        protected static FunctionSpec SectionPart(string showFunctionName, string partNamespace, Type concreteSectionType)
        {
            return
                new FunctionSpec(
                    new Lazy<string>(
                        () => SectionJsReader.ReadJsFromResources(showFunctionName, partNamespace, concreteSectionType)));
        }
    }
}