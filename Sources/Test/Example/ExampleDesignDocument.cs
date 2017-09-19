namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocument : DesignDocument
    {
        public override string Name => "example";

        public class Views : ViewsSection<Views>
        {
            public static ViewSpec MyView1 => MapView();

            public static ViewSpec MyView2 => MapReduceView();
        }

        public class Shows : ShowsSection<Shows>
        {
            public static FunctionSpec MyShow => Function();
        }

        public class Lists : ListsSection<Lists>
        {
            public static FunctionSpec MyList => Function();
        }

        public class Updates : UpdatesSection<Updates>
        {
            public static FunctionSpec MyUpdate => Function();
        }

        public class Filters : FiltersSection<Filters>
        {
            public static FunctionSpec MyFilter => Function();
        }

        public class Indexes : IndexesSection<Indexes>
        {
            public static IndexSpec MyIndex => Index();
        }

        public FunctionSpec ValidateDocUpdate => Function();
    }
}
