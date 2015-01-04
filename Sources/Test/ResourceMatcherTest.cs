namespace TheDmi.CouchDesignDocuments.Test
{
    using System;

    using TheDmi.CouchDesignDocuments.Resources;

    using Xunit;

    public class ResourceMatcherTest
    {
        [Fact]
        public void Match_is_found()
        {
            var candidates = new[]
                             {
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView1.js",
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView2.js",
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView2.reduce.js"
                             };

            var matcher = new ResourceMatcher();

            var name = matcher.FindResourceName(
                candidates,
                "MyView1.js",
                new[] { "TheDmi.CouchDesignDocuments.Test.Example", "Views" },
                "Test");

            Assert.Equal("TheDmi.CouchDesignDocuments.Test.Example.Views.MyView1.js", name);
        }

        [Fact]
        public void Not_found_throws()
        {
            var candidates = new[]
                             {
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView1.js",
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView2.js",
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.MyView2.reduce.js"
                             };

            var matcher = new ResourceMatcher();

            Assert.Throws<InvalidOperationException>(
                () =>
                    matcher.FindResourceName(
                        candidates,
                        "MyView42.js",
                        new[] { "TheDmi.CouchDesignDocuments.Test.Example", "Views" },
                        "Test"));
        }

        [Fact]
        public void Substring_names_are_found_in_isolation()
        {
            var candidates = new[]
                             {
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.SpecificView.js",
                                 "TheDmi.CouchDesignDocuments.Test.Example.Views.View.js"
                             };

            var matcher = new ResourceMatcher();

            var name = matcher.FindResourceName(
                candidates,
                "View.js",
                new[] { "TheDmi.CouchDesignDocuments.Test.Example", "Views" },
                "Test");

            Assert.Equal("TheDmi.CouchDesignDocuments.Test.Example.Views.View.js", name);
        }
    }
}
