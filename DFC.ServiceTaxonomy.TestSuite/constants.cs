using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public enum TeardownOption
    {
        None,
        Sql,
        Graph,
        All
    }
    public static class constants
    {

        // scenario context storage tags
        public const string tokens = "tokens";
        public const string dataItems = "dataItems";
        public const string securityHeader = "securityHeader";
        public const string responseStatus = "responseStatus";
        public const string responseContent = "responseContent";
        //public const string responseBody = "responseBody";
        public const string responseType = "responseType";
        public const string responseScope = "responseScope";
        public const string resultSummary = "resultSummary";
        public const string resultSingle = "resultSingle";

        public const string requestParam = "requestParam";
        public const string requestVariables = "requestVariables";
        public const string requestVariablesUpdated = "requestVariablesUpdated";
        public const string contentItemIndexes = "contentItemIndexes";
        public const string contentIdCount = "contentIdCount";
        public const string contentIds = "contentIds";
        public const string recordIdCount = "recordIdCount";
        public const string recordIds = "recordIds";
        public const string cypherQuery = "cypherQuery";
        public const string prefix = "prefix";
        public const string prefixField = "prefixField";
        public const string ContentType = "contentType";
        public const string published = "published";
        public const string publish = "publish";
        public const string draft = "draft";
        public const string preview = "preview";
        public const string Title = "Title";
        public const string FieldName = "FieldName";
        public const string NotifiableFailure = "NotifiableFailure";

        //cypher query template
        public const string cypher_ClearDownItemsWithPrefix = @"match (i) where i.@FIELDNAME@ STARTS WITH '@PREFIX@' detach delete i";
        public const string cypher_ClearDownItemsWithUri = @"match (i) where i.uri = '@URI@' detach delete i";

    }
}
