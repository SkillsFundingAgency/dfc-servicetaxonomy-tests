using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Context;

namespace DFC.ServiceTaxonomy.TestSuite.MessingAbout
{
    abstract class BaseClass : EditorContext
    {
        public string thing;
        public BaseClass() 
        {
            thing = "1";
        }
        public virtual string thingone => "123";
        public abstract string thingtwo { get; }
        public string thingthree = "456";
    }

    class ClassOne : BaseClass
    {
        public override string thingtwo => "789";
        public ClassOne thisIsMe() => this;
        public ClassTwo makeFreind() => new ClassTwo( thing);
    }

    class ClassTwo : BaseClass
    {
         public ClassTwo(string th) : base()
        {
            thing = th;
         }

        public override string thingtwo => "890";
        public override string thingone => "abc";
    }



}
