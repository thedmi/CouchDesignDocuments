namespace TheDmi.CouchDesignDocuments.Serialization
{
    using System;
    using System.Linq;

    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type source, Type interfaceType)
        {
            return source.GetInterfaces().Any(i => i == interfaceType);        
        }
    }
}
