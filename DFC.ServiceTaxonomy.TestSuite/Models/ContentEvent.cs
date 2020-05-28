using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class ContentEvent
    {
        public ContentEvent()
        {
            data = new ContentEventData();
        }

        public string id { get; set; }
        public string subject { get; set; }
        public ContentEventData data { get; set; }
        public string eventType { get; set; }
        public string eventTime { get; set; }
        public string dataVersion { get; set; }
        public string metadataVersion { get; set; }
        public string topic { get; set; }
    }
}
