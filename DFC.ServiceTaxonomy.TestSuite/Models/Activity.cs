using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    class Activity : NcsEntity
    {
        public string activity { get; set; }
        public string[] alternativeLabels { get; set; }
        public string uri { get; set; }
    }
}

