using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class Skill : NcsEntity
    {
        public string skillType { get; set; }
        public string skill { get; set; }
        public string[] alternativeLabels { get; set; }
        public string uri { get; set; }

        /* Sample response 
         * 
         * {
				"skillType": "competency",
				"skill": "collect biological data",
				"alternativeLabels": [
					"biological data analysing",
					"analysing biological records",
					"collect biological records",
					"collecting biological records",
					"analyse biological records",
					"analysing biological data",
					"analyse biological data",
					"biological data collecting",
					"collecting biological data"
				],
				"uri": "http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281"
			}
        */
         
    }
}
