using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public static class constants
    {
        public const string cypher_ClearDownItemsWithPrefix = @"match (i) where i.@FIELDNAME@ STARTS WITH '@PREFIX@' delete i";

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
