namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class ShowsSection<TSelf> : IShowsSection
    {
        protected static FunctionSpec Show([CallerMemberName] string showFunctionName = null)
        {
            return
                new FunctionSpec(
                    new Lazy<string>(
                        () => SectionJsReader.ReadJsFromResources(showFunctionName, "Shows", typeof(TSelf))));
        }
    }
}