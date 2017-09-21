namespace TheDmi.CouchDesignDocuments
{
    public class IndexIdentifier
    {
        public IndexIdentifier(string designDocumentName, string indexId)
        {
            DesignDocumentName = designDocumentName;
            IndexId = indexId;
        }

        public string DesignDocumentId => "_design/" + DesignDocumentName;

        public string DesignDocumentName { get; }

        public string IndexId { get; }
    }
}