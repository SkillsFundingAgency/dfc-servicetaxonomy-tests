using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public static class DictionaryHelper
    {
        public static string DictionaryToString(IDictionary<string, string> dict)
        {
            string output = "";
            foreach (var kp in dict)
            {
                output += kp.Key + " - " + kp.Value + "\n";
            }
            return output;
        }

        public static bool AreEqual(IDictionary<string, string> thisItems, IDictionary<string, string> otherItems)
        {
            if (thisItems.Count != otherItems.Count)
            {
                return false;
            }
            var thisKeys = thisItems.Keys;
            foreach (var key in thisKeys)
            {
                if (!(otherItems.TryGetValue(key, out var value) && string.Equals(thisItems[key], value, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
