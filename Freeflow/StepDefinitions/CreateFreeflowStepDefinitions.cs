using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Freeflow.Helpers;
using Freeflow.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace Freeflow.StepDefinitions
{
    [Binding]
    public class CreateFreeflowStepDefinitions : CommonDriver
    {
        // Initializing page object
        FreeflowPage freeflowPageObj = new FreeflowPage();

        [Given(@"create a freeflow entry")]
        public void GivenCreateAFreeflowEntry()
        {
            var htmlReporter = new ExtentHtmlReporter(@"R:\PlayingWithExtentReports\Freeflow\TestReports\extentreport\");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            // Feature
            var feature = extent.CreateTest<Feature>("CreateFreeflow");

            // Scenario
            var scenario = feature.CreateNode<Scenario>("Create freeflow entry");

            // Steps
            scenario.CreateNode<Given>("create a freeflow entry");

            freeflowPageObj.CreateEntry(driver);
            
            // Save log
            extent.Flush();
        }

        [Then(@"the freeflow entry should be created successfully")]
        public void ThenTheFreeflowEntryShouldBeCreatedSuccessfully()
        {
            // Get status message
            string createStatusMessage = freeflowPageObj.GetCreateStatusMessage(driver);

            // Assertion
            Assert.That(createStatusMessage.Contains("has been created"));
        }
    }
}