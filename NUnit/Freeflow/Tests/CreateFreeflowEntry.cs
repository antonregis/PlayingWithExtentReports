using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Freeflow.Helpers;
using Freeflow.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using static Freeflow.Helpers.CommonMethods;

namespace Freeflow.NUnitTests
{
    [TestFixture]
    public class FreeflowFeature : CommonDriver
    {
        private static ExtentTest test;
        private static ExtentReports extent;

        // Initializing page object
        FreeflowPage freeflowPageObj = new FreeflowPage();


        [OneTimeSetUp]
        public void Start()
        {
            // Open chrome browser, no login required for this test
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConstantUtils.Url);

            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [Test] 
        public void T01_CreateFreeflowEntry()
        {
            try
            {
                // Create Extentreport test
                test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry(driver);

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
                test.AddScreenCaptureFromPath(img);

                // Get status message
                string createStatusMessage = freeflowPageObj.GetCreateStatusMessage(driver);

                // Assertion
                Assert.That(createStatusMessage.Contains("has been created"));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Create Freeflow entry successfull");
            }
            catch (Exception)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Create Freeflow entry unsuccessfull");
            }
        }


        [Test]
        public void T02_CreateFreeflowEntry()
        {
            try
            {
                // Create Extentreport test
                test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry(driver);

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
                test.AddScreenCaptureFromPath(img);

                // Get status message
                string createStatusMessage = freeflowPageObj.GetCreateStatusMessage(driver);

                // Assertion
                Assert.That(createStatusMessage.Contains("should fail"));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Create Freeflow entry successfull");
            }
            catch (Exception)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Create Freeflow entry unsuccessfull");
            }
        }


        [OneTimeTearDown]
        public void CloseTestRun()
        {
            // Close the browser
            driver.Quit();

            // Save Extentereport html file
            extent.Flush();
        }
    }
}