﻿using System;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DFC.ServiceTaxonomy.TestSuite
{
    class EnvironmentSettingsConfigurationBuilder
    {
        string AppName;

        public EnvironmentSettingsConfigurationBuilder(string appName)
        {
            AppName = appName;
        }

        public bool IsRunningInTfsPipeline { get; } = GetIsRunningInTfsPipeline();

        public IConfiguration BuildConfiguration()
        {

            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory());

            if (File.Exists(@"appsettings.local.json"))
            {
                configurationBuilder
                    .AddJsonFile("appsettings.local.json", false, true);
            }
            else
            {
                configurationBuilder
                   .AddJsonFile("appsettings.json", false, true);
            }

            return configurationBuilder.Build();

        }

        //public IConfiguration BuildConfiguration()
        //{

        //    var configurationBuilder = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory());

        //    Console.WriteLine("------------- Configuring Runtime Params--------------");
        //    if (IsRunningInTfsPipeline)
        //    {
        //        Console.WriteLine("Pipeline run detected - Loading tokenised app settings");
        //        configurationBuilder
        //            .AddJsonFile("appsettings.json", false, true);
        //    }
        //    else
        //    {
        //        var homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
        //                        Environment.OSVersion.Platform == PlatformID.MacOSX)
        //                        ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        //        var customAppSettingsPath =
        //            Environment.ExpandEnvironmentVariables(homePath + $@"\Automation\dfc-servicetaxonomy-tests\DFC.ServiceTaxonomy.TestSuite\appsettings.local.json");
        //        Console.WriteLine("Loading local app settings: " + customAppSettingsPath);

        //        configurationBuilder
        //            .AddJsonFile(customAppSettingsPath, false, true);
        //    }

        //    Console.WriteLine("-----------------------------------------------------");


        //    return configurationBuilder.Build();

        //}

        private static bool GetIsRunningInTfsPipeline() => Environment.GetEnvironmentVariables()
            .Cast<DictionaryEntry>()
            .Any(x => (string.Equals(x.Key?.ToString(), "SYSTEM_HOSTTYPE", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(x.Key?.ToString(), "SYSTEM", StringComparison.OrdinalIgnoreCase)) &&
                      string.Equals(x.Value?.ToString(), "release", StringComparison.OrdinalIgnoreCase));

    }
}
