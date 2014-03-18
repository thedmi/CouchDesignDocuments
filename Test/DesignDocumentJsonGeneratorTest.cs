namespace TheDmi.CouchDesignDocuments.Test
{
    using System.Diagnostics;

    using TheDmi.CouchDesignDocuments.Serialization;
    using TheDmi.CouchDesignDocuments.Test.Example;

    using Xunit;

    public class DesignDocumentJsonGeneratorTest
    {
        [Fact]
        public void Example_document_is_correctly_converted_to_json()
        {
            var example = new ExampleDesignDocument();

            var json = DesignDocumentConvert.Serialize(example);

            Debug.WriteLine(json);
        }
    }
}
