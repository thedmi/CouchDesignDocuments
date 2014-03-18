namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public abstract class DesignDocumentViews
    {
        private readonly Type _designDocumentType;

        protected DesignDocumentViews(DesignDocument designDocument)
        {
            _designDocumentType = designDocument.GetType();
        }

        protected DesignDocumentView View([CallerMemberName] string mapFunctionName = null)
        {
            return new DesignDocumentView(
                new Lazy<string>(() => LoadMapFunction(mapFunctionName)),
                new Lazy<string>(() => LoadReduceFunction(mapFunctionName)));
        }

        private string LoadMapFunction(string baseName)
        {
            var jsName = baseName + ".js";

            var content = LoadStringResource(jsName);

            if (content == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The resource for the map function with name '{0}' could not be found in the assembly resources. Did you set the 'Build Action' property to 'Embedded Resource'?",
                        jsName));
            }

            return content;
        }

        private string LoadReduceFunction(string baseName)
        {
            return LoadStringResource(baseName + "_reduce.js");
        }

        private string LoadStringResource(string jsName)
        {
            var matchingResource = FindResource(jsName);
            return matchingResource != null ? ReadResourceContent(_designDocumentType.Assembly, matchingResource) : null;
        }

        private string FindResource(string jsName)
        {
            var viewResources = GetAllDesignDocumentResourceNames();
            return viewResources.SingleOrDefault(n => n.ToLower().Contains(jsName.ToLower()));
        }

        private IEnumerable<string> GetAllDesignDocumentResourceNames()
        {
            var resourceNames =
                _designDocumentType.Assembly.GetManifestResourceNames()
                    .Where(n => n.StartsWith(_designDocumentType.Namespace + ".Design"));

            return resourceNames.Where(n => n.Contains("Views"));
        }

        private static string ReadResourceContent(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}