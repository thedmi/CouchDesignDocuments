namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class ListsSection<TSelf> : StandardSection<TSelf>, IListsSection
    {
        protected static FunctionSpec Function([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Lists");
        }
    }
}