namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Linq.Expressions;

    public static class DesignDocumentExtensions
    {
        public static ViewIdentifier GetViewIdentifier<TDoc>(this TDoc designDocument, Expression<Func<ViewSpec>> viewExpression) where TDoc : IDesignDocument
        {
            if (!(viewExpression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("Supplied expression does not have a Body of type MemberExpression", nameof(viewExpression));
            }

            var viewName = GetFunctionName(memberExpression);

            return new ViewIdentifier(designDocument.Name, viewName);
        }

        public static IndexIdentifier GetIndexIdentifier<TDoc>(this TDoc designDocument, Expression<Func<IndexSpec>> indexExpression) where TDoc : IDesignDocument
        {
            if (!(indexExpression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("Supplied expression does not have a Body of type MemberExpression", nameof(indexExpression));
            }

            var indexName = GetFunctionName(memberExpression);

            return new IndexIdentifier(designDocument.Name, indexName);
        }

        private static string GetFunctionName(MemberExpression memberExpression)
        {
            var name = memberExpression.Member.Name.DeCamelCase().ToLower();
            return char.ToLower(name[0]) + name.Substring(1);
        }
    }
}
