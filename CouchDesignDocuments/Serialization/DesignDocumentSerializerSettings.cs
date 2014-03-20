namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class DesignDocumentSerializerSettings : JsonSerializerSettings
    {
        public DesignDocumentSerializerSettings()
        {
            ContractResolver = new DesignDocumentContractResolver();
        }

        public class DesignDocumentContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.DeCamelCase().ToLower();
            }

            public override JsonContract ResolveContract(Type type)
            {
                var contract = base.ResolveContract(type);

                if (type == typeof(FunctionSpec))
                {
                    contract.Converter = new FunctionSpecConverter();
                }

                if (type.ImplementsInterface(typeof(IDesignDocument)))
                {
                    contract.Converter = new DesignDocumentConverter();
                }

                return contract;
            }
        }
    }
}
