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

        // This method is used to input text and wait for given time for By locator to be displayed!
        public void SendInput(By locator, string text)
        {
            try
            {

                WaitUntilElementIsDisplayed(locator);
                driver.FindElement(locator).SendKeys(text);
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

        // This method is used to click By locator and wait for given time to be displayed!
        public void Click(By locator)
        {
            try
            {
                WaitUntilElementIsDisplayed(locator);
                driver.FindElement(locator).Click();
            }
            catch (ElementNotInteractableException e)
            {
                throw new Exception($"Failed to click the {locator.ToString} element!", e);

            }
        }

        // This method is used to click By locator using JavaScript
        public void JSclick(By locator)
        {
            try
            {
                WaitUntilElementIsDisplayed(locator);
                IWebElement element = driver.FindElement(locator);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
            catch (ElementNotInteractableException e)
            {
                throw new Exception($"Failed to click the {locator.ToString} element!", e);
            }
        }

        // This method is used to wait for an By locator until is displayed
        public bool WaitUntilElementIsDisplayed(By locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.PollingInterval = TimeSpan.FromSeconds(1);

                return wait.Until(drv => drv.FindElement(locator).Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new Exception($"{locator.ToString} was not visible!", e);
                
            }
        }

        // This method is used to check if element is displayed
        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception($"{locator} was not visible!", e);
            }
        }

        // This method is used to check if element is displayed and reattempt 3 times 
        public bool ReattemptAndRefreshIsElementDisplayed(By locator)
        {
            const int maxAttempts = 3;  // Maximum number of attempts to check element display

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    if (element.Displayed)
                        return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(5000);
                    driver.Navigate().Refresh();
                }
            }

            return false;
        }

        // This method is used to wait for an IWebElement locator until is displayed
        public bool WaitUntilElementIsDisplayed(IWebElement locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromSeconds(1);

                return wait.Until(drv => locator.Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new Exception($"{locator} was not visible!", e);
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
                    throw new NoSuchElementException("Attempt " + (i) + " to send input failed: " + "\r\n\r\n" +
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
            catch (ElementNotInteractableException)
            {
                throw new Exception("Unable to switch to the desired tab, you currently have " + browserTabs.Count + " tabs on this browser window!");
            }
        }

        // This method is used to get all elements on the list and click desired locator
        public void ClickElementFromList(By listID, By locatorID, String name)
        {
            WaitUntilElementIsDisplayed(listID);
            IWebElement list = driver.FindElement(listID);
            List<IWebElement> locators = list.FindElements(locatorID).ToList();

            foreach (WebElement locator in locators)
            {
                if (locator.Text.ToUpper().Equals(name.ToUpper()))
                {
                    locator.Click();
                    return;
                }
            }
            throw new NoSuchElementException(name + " - element's name doesn't exist!");
        }

        // This method is used to get all elements on the list and check if element is displyed
        public bool IsElementDisplayedInList(By listID, By locatorID, string name)
        {
            WaitUntilElementIsDisplayed(listID);
            IWebElement list = driver.FindElement(listID);
            List<IWebElement> locators = list.FindElements(locatorID).ToList();

            foreach (IWebElement locator in locators)
            {
                if (locator.Displayed && locator.Text.ToUpper().Equals(name.ToUpper()))
                {
                    return true;
                }
            }

            return false;
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
