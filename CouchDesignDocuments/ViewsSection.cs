namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class ViewsSection<TSelf> : IViewsSection
    {
        protected static ViewSpec MapView([CallerMemberName] string mapFunctionName = null)
        {
            return new ViewSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName, typeof(TSelf))),
                new Lazy<string>(() => null));
        }

        protected static ViewSpec MapReduceView([CallerMemberName] string mapFunctionName = null)
        {
            return new ViewSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName, typeof(TSelf))),
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName + ".reduce", typeof(TSelf))));
        }

        private static string ReadJsFromResources(string baseName, Type viewsType)
        {
            return SectionJsReader.ReadJsFromResources(baseName, "Views", viewsType);
        }
    }
}