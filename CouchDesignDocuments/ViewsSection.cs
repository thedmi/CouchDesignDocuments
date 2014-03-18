namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    using Newtonsoft.Json;

    public abstract class ViewsSection : AbstractSection
    {
        protected ViewSpec MapView([CallerMemberName] string mapFunctionName = null)
        {
            return new ViewSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName)),
                new Lazy<string>(() => null));
        }

        protected ViewSpec MapReduceView([CallerMemberName] string mapFunctionName = null)
        {
            return new ViewSpec(
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName)),
                new Lazy<string>(() => ReadJsFromResources(mapFunctionName + ".reduce")));
        }

        private string ReadJsFromResources(string baseName)
        {
            return ReadJsFromResources(baseName, "Views");
        }
    }
}