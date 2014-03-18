namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class ShowsSection : AbstractSection
    {
        protected FunctionSpec Show([CallerMemberName] string showFunctionName = null)
        {
            return new FunctionSpec(new Lazy<string>(() => ReadJsFromResources(showFunctionName, "Shows")));
        }
    }
}