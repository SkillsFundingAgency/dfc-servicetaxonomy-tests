using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string str)
        {
            //First to lower case
            str = str.ToLowerInvariant();

            //Remove all accents
            //var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(str);
            //str = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            str = Regex.Replace(str, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            str = str.Trim('-', '_');

            //Replace double occurences of - or _
            str = Regex.Replace(str, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return str;
        }
    }
}
