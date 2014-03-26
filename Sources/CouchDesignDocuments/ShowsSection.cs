namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class ShowsSection<TSelf> : StandardSection<TSelf>, IShowsSection
    {
        protected static FunctionSpec Function([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Shows");
        }
    }
}