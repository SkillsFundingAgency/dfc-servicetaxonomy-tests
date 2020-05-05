using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    class SeleniumInfo : Attribute
    {

        // Private fields 
        private string method;
        private string locator;

        // Parameterised Constructor 
        public SeleniumInfo(string m, string l)
        {
            method = m;
            locator = l;
        }
        
        public static string GetAttribute( Type classType, string property, string attribute)
        {
            MethodInfo method = classType.GetMethod(property);
            object[] attributesArray = method.GetCustomAttributes(true);

            foreach (Attribute item in attributesArray)
            {
                if (item is SeleniumInfo)
                {

                    // Display the fields of the NewAttribute 
                    SeleniumInfo attributeObject = (SeleniumInfo)item;
                    switch ( attribute)
                    {
                        case "method":
                            return attributeObject.method;
                        case "locator":
                            return attributeObject.locator;
                        default:
                            break;

                    }
                }
            }
            return string.Empty;
        }

     }

    class DayToDayTask
    {
        
        public string Uri { get; set; }

        [SeleniumInfo("Id", "TitlePart_Title")]
        public string Title { get; set; }


        [SeleniumInfo("ClassName", "/html/body/div[2]/div[3]/form/div[2]/div/div[2]/div[2]/div/div[2]/p")]
        public string Description { get; set; }
    }
}
