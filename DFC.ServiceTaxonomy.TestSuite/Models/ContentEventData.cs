using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class ContentEventData
    {
        public string api { get; set; }
        public string itemId { get; set; }
        public string versionId { get; set; }
        public string workflowCorrelationId { get; set; }
        public string displayText { get; set; }
        public string author { get; set; }
    }
}
