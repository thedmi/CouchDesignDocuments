namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class UpdatesSection<TSelf> : StandardSection, IUpdatesSection
    {
        protected static FunctionSpec Update([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Updates", typeof(TSelf));
        }
    }
}