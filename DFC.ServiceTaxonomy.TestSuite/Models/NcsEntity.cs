using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public interface NcsEntity
    {
        string[] alternativeLabels { get; set; }
        string uri { get; set; }
    }
}
