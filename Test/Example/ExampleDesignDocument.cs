namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocument : DesignDocument<ExampleDesignDocument.ExampleViews>
    {
        public override string Name { get { return "example"; } }

        public class ExampleViews : ViewsSection
        {
            public ViewSpec ByDate { get { return MapView(); } }

            public ViewSpec SumQuantities { get { return MapReduceView(); } }
        }

        public class ExampleShows : ShowsSection
        {
            public FunctionSpec Index { get { return Show(); } }
        }
    }
}
