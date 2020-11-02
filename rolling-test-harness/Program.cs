using System;
using System.Threading;

namespace rolling_test_harness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestBase config = new TestBase();

            AccountTest accountTest = new AccountTest(config._config["accounts:url"],
                                                      config._config["accounts:uid"],
                                                      config._config["accounts:pwd"],
                                                      config._config["testRunner:outputDir"]);
                ;

            RunMethodInSeparateThread(accountTest.RunTest);

        }

        private static void RunMethodInSeparateThread(Action action)
        {
            var thread = new Thread(new ThreadStart(action));
            thread.Start();
        }


    }


}

