namespace TheDmi.CouchDesignDocuments
{
    using System;

    public class FunctionSpec
    {
        private readonly Lazy<string> _content;

        public FunctionSpec(Lazy<string> content)
        {
            _content = content;
        }

        public string Content { get { return _content.Value; } }
    }
}