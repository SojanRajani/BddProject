﻿using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Bdd.Project.Test.Utilities
{
    [Binding]
    public class ExtentReportsHelper
    {
        public ExtentReports extent { get; set; }
        public ExtentHtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }
        private static string filePath { get; set; }
        private static string ReportName { get; set; }
        
        [BeforeFeature]
        public void Setup(string reportName)
        {
            ReportName = reportName;
            filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            extent = new ExtentReports();
            reporter = new ExtentHtmlReporter(filePath);
            reporter.Config.DocumentTitle = "Automation Testing Report";
            reporter.Config.ReportName = ReportName;
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            extent.AttachReporter(reporter);
            extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        [BeforeScenario]
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        [AfterFeature]
        public void Close()
        {
            extent.Flush();
        }
    }
}
