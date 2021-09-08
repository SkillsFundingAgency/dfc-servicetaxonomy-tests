using System;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using NUnit.Framework;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

using OpenQA.Selenium;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class CaptureEvidence
    {
        private ScenarioContext _scenarioContext;
        private string baseDirectory;
        private string scenarioDirectory;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public CaptureEvidence(ScenarioContext context)
        {
            _scenarioContext = context;
            baseDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\evidence";
            Directory.CreateDirectory(baseDirectory);
        }

        [AfterStep(Order = 1)]
        public void CaputureEvidence()
        {
            if (_scenarioContext.GetEnv().PipelineRun && _scenarioContext.GetEnv().CaptureScreenshots)
            {
                TakeScreenshot();
            }
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEvidenceFolder()
        {
            if (_scenarioContext.GetEnv().PipelineRun && _scenarioContext.GetEnv().CaptureScreenshots)
            {
                scenarioDirectory = $"{baseDirectory}\\{DateTime.Now:HH-mm-ss}_{_scenarioContext.ScenarioInfo.Title}";
                Directory.CreateDirectory(scenarioDirectory);
            }
        }

        //[AfterScenario(Order = 1)]
        //public void CheckResult()
        //{
        //    if (_scenarioContext.GetEnv().pipelineRun)
        //    {
        //        if (_scenarioContext.TestError == null)
        //        {
        //            DeleteDirectory(scenarioDirectory);
        //        }
        //    }
        //}

        public void TakeScreenshot()
        {
            try
            {
                var screenshotName = $"{DateTime.Now:HH-mm-ss}_{_scenarioContext.StepContext.StepInfo.Text}.png".Replace("/", string.Empty)
                                                                                                                .Replace("\"","'") ;
                ITakesScreenshot screenshotHandler = _scenarioContext.GetWebDriver() as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                var screenshotPath = Path.Combine(scenarioDirectory, screenshotName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(screenshotPath, screenshotName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to capture screenshot: {e.Message}");
            }
        }


        private void DeleteDirectory(string dirName)
        {
            try
            {
                Directory.Delete(dirName, true);
            }
            catch { }
        }

        //private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        //{
        //    // Get the subdirectories for the specified directory.
        //    DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        //    if (!dir.Exists)
        //    {
        //        throw new DirectoryNotFoundException(
        //            "Source directory does not exist or could not be found: "
        //            + sourceDirName);
        //    }

        //    DirectoryInfo[] dirs = dir.GetDirectories();

        //    // If the destination directory doesn't exist, create it.       
        //    Directory.CreateDirectory(destDirName);

        //    // Get the files in the directory and copy them to the new location.
        //    FileInfo[] files = dir.GetFiles();
        //    foreach (FileInfo file in files)
        //    {
        //        string tempPath = Path.Combine(destDirName, file.Name);
        //        file.CopyTo(tempPath, false);
        //    }

        //    // If copying subdirectories, copy them and their contents to new location.
        //    if (copySubDirs)
        //    {
        //        foreach (DirectoryInfo subdir in dirs)
        //        {
        //            string tempPath = Path.Combine(destDirName, subdir.Name);
        //            DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
        //        }
        //    }
        //}
    }
}
