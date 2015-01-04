namespace TheDmi.CouchDesignDocuments.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ResourceMatcher
    {
        public string FindResourceName(
            IReadOnlyList<string> candidates,
            string name,
            IReadOnlyList<string> requiredNamespaceParts,
            string assemblyName)
        {
            var foundNames = candidates.Where(c => MeetsRequirements(c, name, requiredNamespaceParts)).ToList();

            if (foundNames.Count > 1)
            {
                throw new InvalidOperationException(MultipleMatchingErrorMessage(name, candidates, assemblyName));
            }
            if (foundNames.Count < 1)
            {
                throw new InvalidOperationException(ResourceNotFoundErrorMessage(name, candidates, assemblyName));
            }

            return foundNames.Single();
        }

        private static bool MeetsRequirements(string canditate, string name, IEnumerable<string> requiredNamespaceParts)
        {
            var nameMatches = canditate.ToLower().EndsWith(name.ToLower()) && canditate[canditate.Length - name.Length - 1] == '.';
            var namespacePartsMatch = requiredNamespaceParts.All(canditate.Contains);

            return nameMatches && namespacePartsMatch;
        }

        private static string ResourceNotFoundErrorMessage(string name, IReadOnlyList<string> candidates, string assemblyName)
        {
            return
                string.Format(
                    "The resource with name '{0}' that matches the given namesspace could not be found in the assembly '{2}'. "
                    + "Did you set the 'Build Action' property to 'Embedded Resource'? \n\nFound resources: {1}",
                    name,
                    candidates.Aggregate("", (accu, s) => accu + "\n" + s),
                    assemblyName);
        }

        private static string MultipleMatchingErrorMessage(string name, IReadOnlyList<string> candidates, string assemblyName)
        {
            return
                string.Format(
                    "Multiple matches for name '{0}' were found in the assembly '{2}'. \n\nFound resources: {1}",
                    name,
                    candidates.Aggregate("", (accu, s) => accu + "\n" + s),
                    assemblyName);
        }
    }
}
