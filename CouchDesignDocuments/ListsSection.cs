namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class ListsSection<TSelf> : StandardSection, IListsSection
    {
        protected static FunctionSpec List([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Lists", typeof(TSelf));
        }
    }
}