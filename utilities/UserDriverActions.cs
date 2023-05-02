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
        

    // This method is used to input text and wait for given time for element to be displayed!
    public void SendInput(IWebDriver driver, By element, string text, int timeout)
    {


        try
        {

                WaitUntilElementIsDisplayed(driver, element, timeout);
                driver.FindElement(element).SendKeys(text);
            logs.Logs.Info(text + " --  text was successfully send!");

        }
        catch (Exception e)
        {
            logs.Logs.Error(
                    "It failed to send keys! " + "\r\n\r\n" +
                            e + "\r\n\r\n"
            );


        }
    }

    // This method is used to click an element and wait for given time to be displayed!
    public void ClickElement(IWebDriver driver, By element, int timeout)
    {
        try
        {

            WaitUntilElementIsDisplayed(driver, element, timeout);
                driver.FindElement(element).Click();
            logs.Logs.Info("User has successfully clicked the button!");

        }
        catch (Exception e)
        {
            logs.Logs.Error(
                    "It failed to click button! " + "\r\n\r\n" +
                            e + "\r\n\r\n)");


        }
    }

    // This method is used to wait for an element until is displayed for given time!
    public bool WaitUntilElementIsDisplayed(IWebDriver driver, By locator, int timeout)
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

    }
}
