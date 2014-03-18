namespace TheDmi.CouchDesignDocuments.Resources
{
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class JavaScriptResourceReader
    {
        public string ReadJs(Assembly assembly, string resourceName)
        {
            return ReduceWhitespace(ReadResourceContent(assembly, resourceName));
        }

        private static string ReadResourceContent(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string ReduceWhitespace(string s)
        {
            return Regex.Replace(s, @"\s+", " ");
        }
    }
}
