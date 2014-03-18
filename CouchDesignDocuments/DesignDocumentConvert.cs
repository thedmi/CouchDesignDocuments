namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;

    public static class DesignDocumentConvert
    {
        public static string Serialize(IDesignDocument designDocument)
        {
            return JsonConvert.SerializeObject(designDocument, Formatting.Indented, new DesignDocumentSerializerSettings());
        }
    }
}
