using Freeflow.Helpers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using static Freeflow.Helpers.CommonMethods;
using AventStack.ExtentReports;

namespace Freeflow.Utils
{
    [Binding]
    public class Start : CommonDriver
    {
        private static ExtentReports extent;

        [BeforeScenario]
        public void Setup()
        {
            // Open chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tademo.codifyme.co.nz/freeflow");
        }

        [AfterScenario]
        public void TearDown()
        {
            // Taking a screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            var extent = new ExtentReports();
            var test = extent.CreateTest("ReportScreenshot");
            test.Log(Status.Info, "Snapshot below: " + test.AddScreenCaptureFromPath(img));

            // Close the browser
            driver.Quit();
        }
    }
}