using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    public enum TeardownOption
    {
        None,
        Sql,
        Graph,
        All
    }
    public class _DataItem
    {
        public string Uri { get; }
        public TeardownOption TearDownOption { get; }
        public bool TearDownSql { get; }
        public bool TearDownGraph { get; }

        public _DataItem(string uri, TeardownOption option)
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
                    break;
                case TeardownOption.Sql:
                    TearDownSql = true;
                    TearDownGraph = false;
                    break;
                case TeardownOption.None:
                    TearDownSql = false;
                    TearDownGraph = false;
                    break;
            }
        }
    }


}
