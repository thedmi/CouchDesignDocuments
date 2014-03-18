namespace TheDmi.CouchDesignDocuments
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class DesignDocumentSerializerSettings : JsonSerializerSettings
    {
        public DesignDocumentSerializerSettings()
        {
            ContractResolver = new UnderscorePropertyNamesContractResolver();
        }

        public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.DeCamelCase().ToLower();
            }
        }
    }
}
