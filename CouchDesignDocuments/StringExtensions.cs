namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Linq;

    internal static class StringExtensions
    {
        public static string DeCamelCase(this string source)
        {
            return string.Concat(source.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : Convert.ToString(x)));
        }
    }
}
