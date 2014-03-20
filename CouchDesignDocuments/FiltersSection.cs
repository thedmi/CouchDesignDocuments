namespace TheDmi.CouchDesignDocuments
{
    using System.Runtime.CompilerServices;

    public abstract class FiltersSection<TSelf> : StandardSection<TSelf>, IFiltersSection
    {
        protected static FunctionSpec Function([CallerMemberName] string showFunctionName = null)
        {
            return SectionPart(showFunctionName, "Filters");
        }
    }
}