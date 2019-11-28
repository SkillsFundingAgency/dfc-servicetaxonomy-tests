﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public static class RestHelper
    {
        public static IRestResponse Get(string url)
        {
            //Thread.Sleep(250);
            Console.WriteLine("Attempt to GET: " + url);
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = null;
                bool retry = true;
                int tries = 0;
                int maxTries = 5;
                while (retry)
                {
                    tries++;
                    response = client.Execute(request);
                    Console.WriteLine("Rest call Attempt (" + tries + ") Returned " + response.StatusCode);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        if (tries <= maxTries)
                        {
                            Console.WriteLine("Sleep and retry");
                            Thread.Sleep(500);
                        }
                        else retry = false;
                    }
                    else retry = false;
                }

                return response;
            }
            catch (Exception e) { throw e; }
        }

    }
}