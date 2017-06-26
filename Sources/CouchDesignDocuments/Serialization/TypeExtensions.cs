namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type source, Type interfaceType)
        {
            return source.GetTypeInfo().GetInterfaces().Any(i => i == interfaceType);        
        }
    }
}
