using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class SpecflowTableExtentions
    {
        public static Dictionary<string,string> SingleColumnToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static Dictionary<string, string> SingleRowToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach ( var col in table.Rows[0])
            {
                dictionary.Add(col.Key, col.Value);
            }
            return dictionary;
        }

    }
}
