using Freeflow.Helpers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace Freeflow.Utils
{
    [Binding]
    public class Start : CommonDriver
    {
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
            //Close the browser
            driver.Quit();
        }
    }
}