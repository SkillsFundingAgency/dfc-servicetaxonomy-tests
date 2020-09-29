using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class SpecflowTableExtentions
    {
        public static Dictionary<string,string> SingleColumnToDictionary(this Table table, ScenarioContext context = null)
        {
            int count = 1;
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add($"item{count++}", (context == null ? row[0] : context.ReplaceTokensInString(row[0])));
            }
            return dictionary;
        }

        public static Dictionary<string, string> SingleRowToDictionary(this Table table, ScenarioContext context = null)
        {
            var dictionary = new Dictionary<string, string>();
            foreach ( var col in table.Rows[0])
            {
                dictionary.Add(col.Key, (context == null ? col.Value : context.ReplaceTokensInString(col.Value)) );
            }
            return dictionary;
        }

    }
}
