namespace TheDmi.CouchDesignDocuments.Resources
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public class JavaScriptResourceReader
    {
        public string ReadJs(Assembly assembly, string resourceName)
        {
            return ReadResourceContent(assembly, resourceName);
        }

        private static string ReadResourceContent(Assembly assembly, string resourceName)
        {
            var buffer = new StringBuilder();
            
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = ReduceWhitespace(reader.ReadLine());

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (!line.StartsWith(@"//")) // Drop single line comments
                        {
                            buffer.Append(line);
                            buffer.Append(' ');
                        }
                    }
                }
            }

            return buffer.ToString();
        }

        private static string ReduceWhitespace(string s)
        {
            return Regex.Replace(s, @"\s+", " ").Trim();
        }
    }
}
