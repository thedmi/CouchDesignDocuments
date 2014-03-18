namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    using Newtonsoft.Json;

    public abstract class DesignDocumentViews
    {
        [JsonIgnore]
        public Type ConcreteViewsType { get; internal set; }

        protected MapReduceSpec MapView([CallerMemberName] string mapFunctionName = null)
        {
            return new MapReduceSpec(
                new Lazy<string>(() => LoadRequiredStringResource(mapFunctionName)),
                new Lazy<string>(() => null));
        }

        protected MapReduceSpec MapReduceView([CallerMemberName] string mapFunctionName = null)
        {
            return new MapReduceSpec(
                new Lazy<string>(() => LoadRequiredStringResource(mapFunctionName)),
                new Lazy<string>(() => LoadRequiredStringResource(mapFunctionName + ".reduce")));
        }

        private string LoadRequiredStringResource(string baseName)
        {
            var jsName = baseName + ".js";

            var content = LoadStringResource(jsName);

            if (content == null)
            {
                throw new InvalidOperationException(JsFileNotFoundErrorMessage(jsName));
            }

            return content;
        }

        private string LoadStringResource(string jsName)
        {
            var matchingResource = FindResource(jsName);
            return matchingResource != null ? ReadResourceContent(ConcreteViewsType.Assembly, matchingResource) : null;
        }

        private string FindResource(string jsName)
        {
            var viewResources = GetAllViewResourceNames();
            return viewResources.SingleOrDefault(n => n.ToLower().Contains(jsName.ToLower()));
        }

        private IEnumerable<string> GetAllViewResourceNames()
        {
            var resourceNames =
                ConcreteViewsType.Assembly.GetManifestResourceNames()
                    .Where(n => n.StartsWith(ConcreteViewsType.Namespace));

            return resourceNames.Where(n => n.Contains("Views"));
        }

        private static string ReadResourceContent(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return Regex.Replace(reader.ReadToEnd(), @"\s+", " ");
            }
        }

        private string JsFileNotFoundErrorMessage(string jsName)
        {
            return
                string.Format(
                    "The resource for the map function with name '{0}' could not be found in the assembly resources. "
                    + "Did you set the 'Build Action' property to 'Embedded Resource'? \n\nFound resources for {1}: {2}",
                    jsName, ConcreteViewsType.Name, GetAllViewResourceNames().Aggregate("", (accu, s) => accu + "\n" + s));
        }
    }
}