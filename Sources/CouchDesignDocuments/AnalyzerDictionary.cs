namespace TheDmi.CouchDesignDocuments
{
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    // The default JSON serialization configured for use in CouchDesignDocuments converts keys to snake_case,
    // but certain keys in analyzer dictionaries correspond to user-defined index names (i.e. the keys in the
    // "fields" dictionary used in conjunction with the "perfield" analyzer) and can therefore have
    // any type of capitalization, which must be preserved upon JSON serialization. To ensure this preservation,
    // this custom dictionary implementation is defined, so that the default key serialization won't be applied
    // to the dictionary defining the analyzer configuration.
    //
    // Note: overriding the default serialization via a C# attribute defined for the `Analyzer` value doesn't
    // appear to be possible:
    // * the use of `ContractResolver.ResolvePropertyName` in the custom contract resolver in
    //     `DesignDocumentSerializerSettings` overrides the `JsonPropertyAttribute` property name
    //     see https://github.com/JamesNK/Newtonsoft.Json/issues/1463
    // * replacing the `ResolvePropertyName` with a `NamingStrategy` as suggested in the issue above doesn't
    //     solve the problem in a satisfactory manner either, due not being applied to the nested dictionaries
    //     present in an analyzer configuration value (the "fields" sub-dictionary in the "perfield" analyzer
    //     case)
    //     see https://github.com/JamesNK/Newtonsoft.Json/issues/2201
    [JsonDictionary(NamingStrategyType = typeof(DefaultNamingStrategy))]
    public class AnalyzerDictionary : Dictionary<string, object>
    {
    }
}