using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class ContentItemIndexRow
    {
        public string Id { get; set; }
        public string DocumentId { get; set; }
        public string ContentItemId { get; set; }
        public string ContentItemVersionId { get; set; }
        public string Latest { get; set; }
        public string Published { get; set; }
        public string ContentType { get; set; }
        public string ModifiedUtc { get; set; }
        public string PublishedUtc { get; set; }
        public string CreatedUtc { get; set; }
        public string Owner { get; set; }
        public string Author { get; set; }
        public string DisplayText { get; set; }
    }
}
