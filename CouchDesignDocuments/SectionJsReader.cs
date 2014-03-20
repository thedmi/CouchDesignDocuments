namespace TheDmi.CouchDesignDocuments
{
    using System;

    using TheDmi.CouchDesignDocuments.Resources;

    public static class SectionJsReader
    {
        public static string ReadJsFromResources(string baseName, string part, Type concreteSectionType)
        {
            var resourceLocator = new ResourceLocator(concreteSectionType.Assembly);
            var resourceName = resourceLocator.GetResourceFqn(baseName + ".js", concreteSectionType.Namespace, part);

            return new JavaScriptResourceReader().ReadJs(concreteSectionType.Assembly, resourceName);
        }
    }
}