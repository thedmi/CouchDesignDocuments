namespace TheDmi.CouchDesignDocuments.Test
{
    using TheDmi.CouchDesignDocuments.Test.Example;

    using Xunit;

    public class ViewIdentifierDerivationTest
    {
        [Fact]
        public void Can_derive_view_identifier_from_example()
        {
            var example = new ExampleDesignDocument();

            var viewIdentifier = example.GetViewIdentifier(d => d.Views.ByDate);

            Assert.Equal("example", viewIdentifier.DesignDocumentName);
            Assert.Equal("_design/example", viewIdentifier.DesignDocumentId);
            Assert.Equal("by_date", viewIdentifier.ViewId);
        }
    }
}
