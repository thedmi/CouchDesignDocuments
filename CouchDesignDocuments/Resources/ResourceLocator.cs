namespace TheDmi.CouchDesignDocuments.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ResourceLocator
    {
        private readonly Assembly _sourceAssembly;

        public ResourceLocator(Assembly sourceAssembly)
        {
            _sourceAssembly = sourceAssembly;
        }

        public string GetResourceFqn(string name, params string[] requiredNamespaceParts)
        {
            var resourceNames = _sourceAssembly.GetManifestResourceNames();
            var foundName = resourceNames.SingleOrDefault(n => MeetsRequirements(n, name, requiredNamespaceParts));

            if (foundName == null)
            {
                throw new InvalidOperationException(ResourceNotFoundErrorMessage(name));
            }

            return foundName;
        }

        private static bool MeetsRequirements(string canditate, string name, IEnumerable<string> requiredNamespaceParts)
        {
            return canditate.ToLower().EndsWith(name.ToLower()) && requiredNamespaceParts.All(canditate.Contains);
        }

        private string ResourceNotFoundErrorMessage(string name)
        {
            return
                string.Format(
                    "The resource with name '{0}' that matches the given namesspace could not be found in the assembly '{2}'. "
                    + "Did you set the 'Build Action' property to 'Embedded Resource'? \n\nFound resources: {1}",
                    name,
                    _sourceAssembly.GetManifestResourceNames().Aggregate("", (accu, s) => accu + "\n" + s),
                    _sourceAssembly.FullName);
        }
    }
}
