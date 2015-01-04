namespace TheDmi.CouchDesignDocuments.Resources
{
    using System.Reflection;

    public class ResourceLocator
    {
        private readonly Assembly _sourceAssembly;

        private readonly ResourceMatcher _matcher;

        public ResourceLocator(Assembly sourceAssembly, ResourceMatcher matcher)
        {
            _sourceAssembly = sourceAssembly;
            _matcher = matcher;
        }

        public string GetResourceFqn(string name, params string[] requiredNamespaceParts)
        {
            var resourceNames = _sourceAssembly.GetManifestResourceNames();
            return _matcher.FindResourceName(resourceNames, name, requiredNamespaceParts, _sourceAssembly.FullName);
        }
    }
}
