using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Freeflow.Helpers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using static Freeflow.Helpers.CommonMethods;


namespace Freeflow.Utils
{
    [Binding]
    public class Start : CommonDriver
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;


        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"R:\PlayingWithExtentReports\Freeflow\TestReports\extentreport\");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            // ExtentReport: Create test or the Feature
            featureName = extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);  
        }

        [AfterStep]
        public void AfterEachStep(ScenarioContext scenariocontext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenariocontext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            
            if (scenariocontext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
            }
        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            // Open chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tademo.codifyme.co.nz/freeflow");

            // ExtentReport: Create node or the Scenario
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TearDown()
        {
            // Takes a screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
            
            // Attaching screenshot to report
            scenario.AddScreenCaptureFromPath(img);
            
            // some experimental codes
            // scenario.Log(Status.Info, "Test description");
            // var test = extent.CreateTest(featurecontext.FeatureInfo.Title);

            //Close the browser
            driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}