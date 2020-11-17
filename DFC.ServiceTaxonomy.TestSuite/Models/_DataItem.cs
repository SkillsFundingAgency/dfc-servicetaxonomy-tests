using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{

    public class _DataItem
    {
        public List<_LinkedItem> linkedItems = new List<_LinkedItem>();
        public string Uri { get; }
        public TeardownOption TearDownOption { get; }
        public bool TearDownSql { get; } = false;
        public bool TearDownGraph { get; } = false;
        public bool TearDownInUI { get; } = false;
        public object model { get; set; }
        public string TypeName { get; set; }
        public string Tag { get; set; }
        public string UICleardownPage { get; set; }
        public string UICleardownAction { get; set; }
        public _DataItem(string uri, string tag, string type, object m, TeardownOption option)
        {
            Uri = uri;
            switch (option)
            {
                case TeardownOption.All:
                    TearDownSql = true;
                    TearDownGraph = true;
                    break;
                case TeardownOption.Graph:
                    TearDownSql = false;
                    TearDownGraph = true;
                    TearDownInUI = false;
                    break;
                case TeardownOption.Sql:
                    TearDownSql = true;
                    TearDownGraph = false;
                    TearDownInUI = false;
                    break;
                case TeardownOption.UI:
                    TearDownSql = false;
                    TearDownGraph = false;
                    TearDownInUI = true;
                    break;
                case TeardownOption.None:
                    TearDownSql = false;
                    TearDownGraph = false;
                    TearDownInUI = false;
                    break;
            }
            model = m;
            TypeName = type;
            Tag = tag;
        }
    }


}
