namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocument : DesignDocument
    {
        public override string Name { get { return "example"; } }

        public class Views : ViewsSection<Views>
        {
            public static ViewSpec MyView1 { get { return MapView(); } }

            public static ViewSpec MyView2 { get { return MapReduceView(); } }
        }

        public class Shows : ShowsSection<Shows>
        {
            public static FunctionSpec MyShow { get { return Function(); } }
        }

        public class Lists : ListsSection<Lists>
        {
            public static FunctionSpec MyList { get { return Function(); } }
        }

        public class Updates : UpdatesSection<Updates>
        {
            public static FunctionSpec MyUpdate { get { return Function(); } }
        }

        public class Filters : FiltersSection<Filters>
        {
            public static FunctionSpec MyFilter { get { return Function(); } }
        }

        public FunctionSpec ValidateDocUpdate { get { return Function(); } } 
    }
}
