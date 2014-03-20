namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class ListsSection<TSelf> : StandardSection<TSelf>, IListsSection
    {
        protected static FunctionSpec List([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Lists");
        }
    }
}