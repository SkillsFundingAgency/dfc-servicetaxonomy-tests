using System;
using System.Threading;

namespace rolling_test_harness
{
    class Program
    {
        static void Main(string[] args)
        {
           /* TODO
            * standardise date / time stamps
            * add csv output
            */
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


        private static void RunMethodInSeparateThread(ITest action)
        {
            var thread = new Thread(new ThreadStart(action.RunTest));
            thread.Start();
        }

    }


}

