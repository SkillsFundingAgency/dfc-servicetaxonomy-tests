using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Interfaces
{
    public interface NcsEntity
    {
        string[] alternativeLabels { get; set; }
        string uri { get; set; }
    }
}
