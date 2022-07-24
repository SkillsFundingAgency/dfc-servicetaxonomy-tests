using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Helpers
{
    public class RandomsGenerator
    {
        private readonly Random _random = new Random();

        public string RandomNumber(int min, int max)
        {
            return _random.Next(min, max).ToString();
        }

        public string RandomAlpha()
        {
            int ascii_index2 = _random.Next(97, 123); //ASCII character codes 97-123
            char myRandomLowerCase = Convert.ToChar(ascii_index2); //produces any char a-z
            return myRandomLowerCase.ToString().ToUpper();
        }
    }
}
