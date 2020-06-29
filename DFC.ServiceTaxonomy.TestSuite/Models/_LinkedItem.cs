using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class _LinkedItem
    {
        public _LinkedItem(string title, string relType, _DataItem item)
        {
            Title = title;
            RelatedItem = item;
            RelationshipType = relType;
        }
        public string Title { get; }
        public string RelationshipType { get; }
        public _DataItem RelatedItem;
    }
}
