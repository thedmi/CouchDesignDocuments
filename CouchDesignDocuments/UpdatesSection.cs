namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class UpdatesSection<TSelf> : StandardSection<TSelf>, IUpdatesSection
    {
        protected static FunctionSpec Function([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Updates");
        }
    }
}