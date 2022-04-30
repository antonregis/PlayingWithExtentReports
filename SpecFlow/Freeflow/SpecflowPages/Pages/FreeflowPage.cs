using OpenQA.Selenium;


namespace Freeflow.Pages
{
    internal class FreeflowPage
    {
        public void CreateEntry(IWebDriver driver)
        {
            // Click create button
            IWebElement createButton = driver.FindElement(By.XPath("//a[contains(text(),'Create')]"));
            createButton.Click();

            // Enter random text textbox
            IWebElement randomTextTextbox = driver.FindElement(By.XPath("//input[@id='edit-field-freeflow-random-text-0-value']"));
            randomTextTextbox.SendKeys("Ten");

            // Select random planet
            IWebElement randomPlanetOption = driver.FindElement(By.XPath("//option[contains(text(),'earth')]"));
            randomPlanetOption.Click();

            // Click save button
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@id='edit-submit']"));
            saveButton.Click();
        }
        public string GetCreateStatusMessage(IWebDriver driver)
        {
            IWebElement createStatusMessage = driver.FindElement(By.ClassName("messages--status"));
            return createStatusMessage.Text;
        }
    }
}