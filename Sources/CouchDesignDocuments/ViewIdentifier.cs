namespace TheDmi.CouchDesignDocuments
{
    public class ViewIdentifier
    {
        private readonly string _designDocumentName;

        private readonly string _viewId;

        public ViewIdentifier(string designDocumentName, string viewId)
        {
            _designDocumentName = designDocumentName;
            _viewId = viewId;
        }

        public string DesignDocumentId { get { return "_design/" + _designDocumentName; } }

        public string DesignDocumentName { get { return _designDocumentName; } }

        public string ViewId { get { return _viewId; } }
    }
}