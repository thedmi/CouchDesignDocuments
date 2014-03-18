namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocument : DesignDocument<ExampleDesignDocument.ExampleViews>
    {
        public override string Name { get { return "example"; } }

        public class ExampleViews : DesignDocumentViews
        {
            public MapReduceSpec ByDate { get { return MapView(); } }
        }
    }
}
