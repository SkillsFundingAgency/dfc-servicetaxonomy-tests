using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public class EscoDataItem
    {
        public string className { get; set; }
        public string classId { get; set; }
        public string uri { get; set; }
        public string title { get; set; }
        public string[] hasSkillType { get; set; }
    }
}
