namespace TheDmi.CouchDesignDocuments.Resources
{
    using System;

    public static class SectionJsReader
    {
        public static string ReadJsFromResources(string baseName, string part, Type concreteSectionType)
        {
            var resourceLocator = new ResourceLocator(concreteSectionType.Assembly, new ResourceMatcher());
            var resourceName = resourceLocator.GetResourceFqn(baseName + ".js", concreteSectionType.Namespace, part);

            return new JavaScriptResourceReader().ReadJs(concreteSectionType.Assembly, resourceName);
        }
    }
}