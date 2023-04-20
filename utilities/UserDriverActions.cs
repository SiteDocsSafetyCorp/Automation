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
        

    public void SendInput(IWebDriver driver, By element, string text)
    {


        try
        {

                WaitUntilElementIsDisplayed(driver, element);
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

    public void ClickElement(IWebDriver driver, By element)
    {
        try
        {

            WaitUntilElementIsDisplayed(driver, element);
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

    public bool WaitUntilElementIsDisplayed(IWebDriver driver, By locator)
    {
        try
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
