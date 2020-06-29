using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Helpers
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CypherLabelAttribute : Attribute
    {
        private string _label;
        public CypherLabelAttribute(string label)
        {
            _label = label;
        }
        public string GetLabel() { return _label; }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CypherIgnoreAttribute : Attribute
    {
    }

    public static class CypherHelper
    {
        public static string GenerateCypher<T>(Object obj, string name = null)
        {
            string dataStatement = "{";
            string seperator;
            PropertyInfo[] properties =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int count = 0;
            foreach (var prop in properties)
            {
                string label = prop.Name;
                CypherIgnoreAttribute attrIgnore = prop.GetCustomAttribute<CypherIgnoreAttribute>();
                CypherLabelAttribute attrLabel = prop.GetCustomAttribute<CypherLabelAttribute>();

                if (attrIgnore == null)
                {
                    if (attrLabel != null)
                        label = attrLabel.GetLabel();

                    seperator = (++count < properties.Count() ? "," : "");
                    dataStatement += $"{label}:'{prop.GetValue(obj, null)}'{seperator}";
                }
            }
            dataStatement += "}";
            return $"CREATE (n:{name??obj.GetType().Name} {dataStatement} )";
        }

        public static string AddRelationship (string referenceLabel, string reference1, string reference2, string type)
        {
            return $"MATCH (a),(b) WHERE a.{referenceLabel} = '{reference1}' AND b.{referenceLabel} = '{reference2}' CREATE(a) -[r: {type}]->(b) RETURN type(r)";
        }
    }
}
