using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite
{
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
        public const string requestParam = "requestParam";
        public const string requestVariables = "requestVariables";
        public const string contentItemIndexes = "contentItemIndexes";
        public const string contentIdCount = "contentIdCount";
        public const string contentIds = "contentIds";
        public const string recordIdCount = "recordIdCount";
        public const string recordIds = "recordIds";
        public const string cypherQuery = "cypherQuery";
        public const string prefix = "prefix";
        public const string prefixField = "prefixField";
        public const string ContentType = "contentType";
        public const string Title = "Title";
        public const string FieldName = "FieldName";



        //cypher query template
        public const string cypher_ClearDownItemsWithPrefix = @"match (i) where i.@FIELDNAME@ STARTS WITH '@PREFIX@' detach delete i";
        public const string cypher_ClearDownItemsWithUri = @"match (i) where i.uri = '@URI@' detach delete i";

        public const string sql_ClearDownAllContentItemsOfType =
                                                               @"begin transaction t1
                                                                select DocumentId
                                                                into #tmpdocids
                                                                from [dbo].[ContentItemIndex]
                                                                where @WHERECLAUSE@;
                                                                delete from [dbo].[ContentItemIndex] where DocumentId in ( select DocumentId from #tmpdocids ) ;
                                                                delete from [dbo].Document where id in ( select DocumentId from #tmpdocids );
                                                                drop table #tmpdocids
                                                                commit transaction t1";
    }
}
