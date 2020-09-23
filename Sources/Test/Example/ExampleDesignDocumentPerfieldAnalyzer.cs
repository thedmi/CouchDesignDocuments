namespace TheDmi.CouchDesignDocuments.Test.Example
{
    using TheDmi.CouchDesignDocuments;

    public class ExampleDesignDocumentPerfieldAnalyzer : DesignDocument
    {
        public override string Name => "exampleWithPerfieldAnalyzer";

        public class Indexes : IndexesSection<Indexes>
        {
            public static IndexSpec MyIndex =>
                Index(
                    analyzer: new AnalyzerDictionary()
                              {
                                  { "name", "perfield" },
                                  { "default", "keyword" },
                                  {
                                      "fields",
                                      new AnalyzerDictionary()
                                      {
                                          { "CapitalizedCamelCaseField", "classic" },
                                          { "camelCaseField", "email" },
                                          { "Capitalized_Snake_Case", "keyword" },
                                          { "snake_case", "simple" },
                                          { "Capitalized-Kebab-Case", "standard" },
                                          { "kebab-case", "whitespace" },
                                          { "CompLetELY_ranDoM-CASE", "standard" },
                                          { "spaced Word", "standard" }
                                      }
                                  }
                              });
        }
    }
}
