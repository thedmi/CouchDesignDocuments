namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class UpdatesSection<TSelf> : StandardSection<TSelf>, IUpdatesSection
    {
        protected static FunctionSpec Update([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Updates");
        }
    }
}