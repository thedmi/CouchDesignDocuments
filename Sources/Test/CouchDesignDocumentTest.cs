namespace TheDmi.CouchDesignDocuments.Test
{
    using System.Diagnostics;

    using Newtonsoft.Json;

    using TheDmi.CouchDesignDocuments.Serialization;
    using TheDmi.CouchDesignDocuments.Test.Example;

    using Xunit;
    using Xunit.Abstractions;

    public class CouchDesignDocumentTest
    {
        private readonly ITestOutputHelper _output;

        public CouchDesignDocumentTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Example_document_contains_all_specified_members()
        {
            var example = new ExampleDesignDocument();

            var json = DesignDocumentConvert.Serialize(example);

            _output.WriteLine(json);

            dynamic deserialized = JsonConvert.DeserializeObject(json);

            Assert.Equal("_design/example", (string)deserialized._id);

            Assert.Contains("view1 map", (string)deserialized.views.my_view1.map);
            Assert.Contains("view2 map", (string)deserialized.views.my_view2.map);
            Assert.Contains("view2 reduce", (string)deserialized.views.my_view2.reduce);

            Assert.Contains("show", (string)deserialized.shows.my_show);
            Assert.Contains("list", (string)deserialized.lists.my_list);
            Assert.Contains("update", (string)deserialized.updates.my_update);
            Assert.Contains("filter", (string)deserialized.filters.my_filter);
            Assert.Contains("index", (string)deserialized.indexes.my_index.index);

            Assert.Contains("validate_doc_update", (string)deserialized.validate_doc_update);
        }

        [Fact]
        public void Can_derive_view_identifier_from_example()
        {
            var example = new ExampleDesignDocument();

            var viewIdentifier = example.GetViewIdentifier(() => ExampleDesignDocument.Views.MyView1);

            Assert.Equal("example", viewIdentifier.DesignDocumentName);
            Assert.Equal("_design/example", viewIdentifier.DesignDocumentId);
            Assert.Equal("my_view1", viewIdentifier.ViewId);
        }
    }
}
