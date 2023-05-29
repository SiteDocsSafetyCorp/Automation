using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        public void SendInput(By locator, string text)
        {
            try
            {

                WaitUntilElementIsDisplayed(locator);
                driver.FindElement(locator).SendKeys(text);
                logs.Logs.Info(text + " --  text was successfully send!");

            }
            catch (Exception e)
            {
                Assert.Fail(
                        "It failed to send text! " + "\r\n\r\n" +
                                e + "\r\n\r\n"
                );
                // Retry to send again input if it fails for the first time!
                ReattemptSendInput(locator, text, 1);

            }
        }

        // This method is used to click an element and wait for given time to be displayed!
        public void Click(By locator)
        {
            try
            {
                WaitUntilElementIsDisplayed(locator);
                driver.FindElement(locator).Click();
                logs.Logs.Info("User has successfully clicked the button!");

            }
            catch (ElementNotInteractableException e)
            {
                Assert.Fail(
                        "It failed to click button! " + "\r\n\r\n" +
                                e + "\r\n\r\n)");

            }
        }

        // This method is used to wait for an element until is displayed
        public bool WaitUntilElementIsDisplayed(By locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
                wait.PollingInterval = TimeSpan.FromSeconds(1);

                return wait.Until(drv => drv.FindElement(locator).Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                Assert.Fail("Element didn't display! " + "\r\n\r\n" + e + "\r\n\r\n");
                return false;
            }
        }

        // This method is used to reattempt to send input for given time!
        public void ReattemptSendInput(By locator, String text, int nrOfRetries)
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
                    Assert.Fail("Attempt " + (i + 1) + " to send input failed: " + "\r\n\r\n" +
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
                driver.SwitchTo().Window(browserTabs[selectedTab]);
            }
            catch (Exception e)
            {
                Assert.Fail("Unable to switch to the desired tab, you currently have " + browserTabs.Count + " tabs on this browser window!");
            }
        }

        // This method is used to get all elements on the list and click desired locator by name 
        public void ClickElementFromList(By listID, By locatorID, String name)
        {
            IWebElement list = driver.FindElement(listID);
            List<IWebElement> locators = list.FindElements(locatorID).ToList();

            foreach (WebElement locator in locators)
            {
                if (locator.Text.ToUpper().Equals(name.ToUpper()))
                {
                    locator.Click();
                    logs.Logs.Info("User has successfully clicked to " + name + " element!");
                    return;
                }
            }
            Assert.Fail(name + " - element's name doesn't exist!");
        }

        // This method is used to upload desired file/image from uploadFiles folder 
        public void UploadImageOrFile(By locator, string fileName)
        {
            IWebElement fileUploadButton = driver.FindElement(locator);    
            string imagePath = DirectoryPaths.GetPath(Directory.UploadFilesPath) + fileName;
            fileUploadButton.SendKeys(imagePath);
            logs.Logs.Info(fileName + " was uploaded successfully!");

        }

    }
}
