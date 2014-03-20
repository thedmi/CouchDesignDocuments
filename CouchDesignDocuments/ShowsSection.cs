namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class ShowsSection<TSelf> : StandardSection, IShowsSection
    {
        protected static FunctionSpec Show([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Shows", typeof(TSelf));
        }
    }
}