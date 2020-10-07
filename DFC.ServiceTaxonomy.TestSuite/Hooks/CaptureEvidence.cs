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
            if (_scenarioContext.GetEnv().pipelineRun)
            {
                TakeScreenshot();
            }
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEvidenceFolder()
        {
            if (_scenarioContext.GetEnv().pipelineRun)
            {
                scenarioDirectory = $"{baseDirectory}\\{DateTime.Now:HH-mm-ss}_{_scenarioContext.ScenarioInfo.Title}";
                Directory.CreateDirectory(scenarioDirectory);
            }
        }

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
    }
}
