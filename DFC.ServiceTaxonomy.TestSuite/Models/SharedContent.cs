using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using DFC.ServiceTaxonomy.TestSuite.Helpers;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor)]
    public class Stereotype: System.Attribute {  
    public string TheStereotypeName = "General";
    public string TheDescription = "Method Info";
    public Stereotype() { }
    public Stereotype(string aStereotype, string aDescription)
    {
        TheStereotypeName = aStereotype;
        TheDescription = aDescription;
    }
}

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IdentifierAttribute : Attribute
    {
        private string thingVal;
        public IdentifierAttribute(string thing)
        {
            thingVal = thing;
        }
    }

    class SharedContent// : GenericContent
    {  
        [CypherLabel("skos__prefLabel")]
        public string Title { get; set; }
  
        public string Content { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ");
        public string ModifiedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ");
        public string uri { get; set; }

    }

    public class TestClass<T>
    {
        public void GetIDForPassedInObject(T obj)
        {
            PropertyInfo[] properties =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo IdProperty = properties.Where(p => p.GetCustomAttributes(typeof(IdentifierAttribute), true).Length > 0)
                                                .FirstOrDefault();

            if (null == IdProperty)
                throw new ArgumentException("obj does not have Identifier.");

            Object propValue = IdProperty.GetValue(obj);
        }
    }
}

