namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Linq.Expressions;

    public static class DesignDocumentExtensions
    {
        public static ViewIdentifier GetViewIdentifier<TDoc>(this TDoc designDocument, Expression<Func<ViewSpec>> viewExpression) where TDoc : IDesignDocument
        {
            var memberExpression = viewExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Supplied expression does not have a Body of type MemberExpression", "viewExpression");
            }

            var viewName = memberExpression.Member.Name.DeCamelCase().ToLower();
            return new ViewIdentifier(designDocument.Name, char.ToLower(viewName[0]) + viewName.Substring(1));
        }
    }
}
