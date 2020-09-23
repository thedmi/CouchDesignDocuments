namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    using TheDmi.CouchDesignDocuments.Resources;

    public abstract class IndexesSection<TSelf> : IIndexesSection
    {
        protected static IndexSpec Index([CallerMemberName] string indexName = null, dynamic analyzer = null)
        {
            return new IndexSpec(
                new Lazy<string>(() => ReadJsFromResources(indexName, typeof(TSelf))), analyzer);
        }

        private static string ReadJsFromResources(string baseName, Type viewsType)
        {
            return SectionJsReader.ReadJsFromResources(baseName, "Indexes", viewsType);
        }
    }
}