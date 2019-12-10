using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class Occupation : NcsEntity
    {
        public string occupation { get; set; }
        public string[] alternativeLabels { get; set; }
        public string lastModified { get; set; }
        public string uri { get; set; }
    /*SAMPLE RESPONSE
     * "occupation": [
    {
      "occupation": "pharmaceutical quality specialist",
      "alternativeLabels": [
        "pharmaceutical quality technician",
        "pharmaceutical quality control specialist",
        "pharmaceutical quality control technician",
        "specialist of pharmaceutical quality compliance",
        "pharmaceutical quality inspector",
        "specialist of pharmaceutical quality control",
        "pharmaceutical quality manager",
        "pharmaceutical product quality manager",
        "pharmaceutical quality compliance specialist",
        "pharmaceutical quality verifier",
        "specialist of pharmaceutical quality"
      ],
      "lastModified": "2017-01-17T13:15:00Z",
      "uri": "http://data.europa.eu/esco/occupation/0f845e64-de8b-431e-9fe3-1bccf8e1c5b9"
    },*/
    }
}
