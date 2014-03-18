namespace TheDmi.CouchDesignDocuments
{
    using System;
    using System.Linq.Expressions;

    public static class DesignDocumentExtensions
    {
        public static ViewIdentifier CreateQueryViewRequest<TDoc>(this TDoc designDocument, Expression<Func<TDoc, DesignDocumentView>> viewExpression) where TDoc : DesignDocument
        {
            var memberExpression = viewExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Supplied expression does not have a Body of type MemberExpression", "viewExpression");
            }

            var viewName = memberExpression.Member.Name;
            return new ViewIdentifier(designDocument.Name, char.ToLower(viewName[0]) + viewName.Substring(1));
        }
    }
}
