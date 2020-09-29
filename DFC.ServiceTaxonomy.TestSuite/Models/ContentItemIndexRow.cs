using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class ContentItemIndexRow
    {
        public string _key { get; set; }
        public string[] expectedEvents { get; set; }
        public int actionStart { get; set; }
        public int actionEnd { get; set; }
        public string Id { get; set; }
        public string DocumentId { get; set; }
        public string ContentItemId { get; set; }
        public string ContentItemVersionId { get; set; }
        public string Latest { get; set; }
        public string Published { get; set; }
        public string ContentType { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public DateTime PublishedUtc { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string Owner { get; set; }
        public string Author { get; set; }
        public string DisplayText { get; set; }
        
    }
}
