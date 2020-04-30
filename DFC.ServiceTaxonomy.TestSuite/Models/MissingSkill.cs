using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    class MissingSkill
    {
        public string uri { get; set; }
        public string[] alternativeLabels { get; set; }
        public string lastModified { get; set; }
        public string skill { get; set; }
        public string skillType { get; set; }
        public string skillReusability { get; set; }
        public string relationshipType { get; set; }


        /* Sample response */
         
        // {
        //    missingPrimaryOccupationSkills: [
        //                        {
        //                            uri: http://data.europa.eu/esco/skill/68698869-c13c-4563-adc7-118b7644f45d,
        //                            skill: "identify customer's needs",
        //                            skillType: "knowledge | competency",
        //                            alternativeLabels: [ "alt 1", "alt 2", "alt 3" ],
        //                            skillReusability: "Transversal | Cross-sectoral | Sector-specific | Occupation-specific",
        //                            lastModified: ISO8601 - UTC time,
        //                            relationshipType: "essential | optional",
        //                        },  
        //                        {
        //                            uri: http://data.europa.eu/esco/skill/4e09e2d2-e317-47d2-bf5e-1d6c66be3efc,
        //                            skillType: "energy performance of buildings",
        //                            type: "knowledge | competency",
        //                            alternativeLabels: [ "alt 1", "alt 2", "alt 3" ]
        //                            skillReusability: "Transversal | Cross-sectoral | Sector-specific | Occupation-specific",
        //                            lastModified: ISO8601 - UTC time
        //                            relationshipType: "essential | optional",
        //                        }
        //                    ]
        
        }
        

    }
