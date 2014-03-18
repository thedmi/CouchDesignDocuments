namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class DesignDocumentSerializerSettings : JsonSerializerSettings
    {
        public DesignDocumentSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
