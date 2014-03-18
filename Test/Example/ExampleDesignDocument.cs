namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocument : DesignDocument
    {
        public override string Name { get { return "example"; } }

        public ExampleViews Views { get {  return new ExampleViews(this);} }

        public class ExampleViews : DesignDocumentViews
        {
            public ExampleViews(DesignDocument designDocument) : base(designDocument) { }

            public MapReduceSpec ByDate { get { return View(); } }
        }
    }
}
