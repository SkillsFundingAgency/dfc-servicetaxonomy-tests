using FluentAssertions.Specialized;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public static class RetryHelper
    {
        public static List<T> RetryOnEmptyList<T>(int times, TimeSpan delay, Func<List<T>> method, params object[] args)// where T : class, new()
        {
            List<T> list = null;
            var attempts = 0;
            do
            {
                attempts++;
                list = (List<T>)method.DynamicInvoke(args);
                if (list.Count > 0)
                    break;
            } while (attempts < times);
            return  list ??  new List<T>();
        }
    }
}
