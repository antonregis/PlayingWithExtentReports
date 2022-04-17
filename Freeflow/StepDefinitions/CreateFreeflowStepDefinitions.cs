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
            
            freeflowPageObj.CreateEntry(driver);
        }

        [Then(@"the freeflow entry should be created successfully")]
        public void ThenTheFreeflowEntryShouldBeCreatedSuccessfully()
        {
            // Get status message
            string statusMessage = freeflowPageObj.GetCreateStatusMessage(driver);

            // Assertion
            Assert.That(statusMessage.Contains("has been created"));
        }
    }
}
