using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Helpers
{
    class RandomStringGenerator
    {
        public static string RandomString()
        {
            int randomStringLength = 8;
            
            using (var crypto = new RNGCryptoServiceProvider())
            {
                var bits = (randomStringLength * 6);
                var byte_size = ((bits + 7) / 8);
                var bytesarray = new byte[byte_size];
                crypto.GetBytes(bytesarray);

                return Convert.ToBase64String(bytesarray);
            }
        }
    }
}
