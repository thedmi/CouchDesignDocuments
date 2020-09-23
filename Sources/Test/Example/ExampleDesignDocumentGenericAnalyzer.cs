namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocumentGenericAnalyzer : DesignDocument
    {
        public override string Name => "exampleWithGenericAnalyzer";

        public class Indexes : IndexesSection<Indexes>
        {
            public static IndexSpec MyIndex => Index(analyzer: "simple");
        }
    }
}
