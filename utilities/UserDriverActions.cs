using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

/**
 * This class contains methods that the user has to use frequently.
 * Example: You want to wait for an element to be displayed in page.
 */
namespace SiteDocsAutomationProject.utilities
{
    public class UserDriverActions
    {
        // PAGE OBJECTS
        private readonly IWebDriver driver;

        // CLASS CONSTRUCTOR
        public UserDriverActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        // This method is used to input text and wait for given time for element to be displayed!
        public void SendInput(By locator, string text, int timeout)
        {


            try
            {

                WaitUntilElementIsDisplayed(locator, timeout);
                driver.FindElement(locator).SendKeys(text);
                logs.Logs.Info(text + " --  text was successfully send!");

            }
            catch (Exception e)
            {
                logs.Logs.Error(
                        "It failed to send text! " + "\r\n\r\n" +
                                e + "\r\n\r\n"
                );
                // Retry to send again input if it fails for the first time!
                ReattemptSendInput(locator, text, 2, timeout);

            }
        }

        // This method is used to click an element and wait for given time to be displayed!
        public void Click(By locator, int timeout)
        {
            try
            {
                WaitUntilElementIsDisplayed(locator, timeout);
                driver.FindElement(locator).Click();
                logs.Logs.Info("User has successfully clicked the button!");

            }
            catch (ElementNotInteractableException e)
            {
                logs.Logs.Error(
                        "It failed to click button! " + "\r\n\r\n" +
                                e + "\r\n\r\n)");

            }
        }

        // This method is used to wait for an element until is displayed for given time!
        public bool WaitUntilElementIsDisplayed(By locator, int timeout)
        {
            try
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(drv => drv.FindElement(locator).Displayed);
            }
            catch (NoSuchElementException e)
            {

                logs.Logs.Error(
                        "It failed to click button! " + "\r\n\r\n" +
                                e + "\r\n\r\n");
                return false;
            }
        }

        // This method is used to reattempt to send input for given times!
        public void ReattemptSendInput(By locator, String text, int nrOfRetries, int timeout)
        {

            driver.FindElement(locator).Clear();
           
            for (int i = 0; i < nrOfRetries; i++)
            {
                try
                {
                    driver.FindElement(locator).SendKeys(text);
                    break;
                }
                catch (Exception e)
                {
                    logs.Logs.Error("Attempt " + (i + 1) + " to send input failed: " + "\r\n\r\n" +
                                e + "\r\n\r\n");
                }
            }
        }

        //This method is used to open a new tab!
        public void OpenNewTab()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        // This method is used to handle open tabs and switch to desired tab! 
        public void SwitchToTab(int selectedTab)
        {
            List<string> browserTabs = new List<string>(driver.WindowHandles);
            try
            {
                Console.WriteLine("Switching to tab " + selectedTab + "...");
                driver.SwitchTo().Window(browserTabs[selectedTab]);
            }
            catch (Exception e)
            {
                logs.Logs.Error("Unable to switch to the desired tab, you currently have " + browserTabs.Count + " tabs on this browser window!");
            }
        }
    }
}
