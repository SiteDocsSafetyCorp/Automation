using OpenQA.Selenium;
using SiteDocsAutomationProject.testCredentials;
using SiteDocsAutomationProject.utilities;

/**
 * Impl classes are used to setup steps that user has to take in order to complete a test case
 * For every Method that you create that does any action, please add logs to describe that action
 * Import the class and use LogDemo.info() method to describe action.
 */
namespace SiteDocsAutomationProject.implementation
{
    public class LoginImpl
    {

        // PAGE OBJECTS
        private readonly IWebDriver driver;
        private readonly UserDriverActions userActions;


        // CLASS CONSTRUCTOR
        public LoginImpl(IWebDriver driver)
        {
            this.driver = driver;
            userActions = new UserDriverActions();
        }

        // LOCATORS 
        private readonly By usernameHolder = By.Id("Username");
        private readonly By passwordHolder = By.Id("Password");
        private readonly By loginButton = By.CssSelector(".btn.btn-primary.btn-lg.btn-block");
        private readonly By nextButton = By.CssSelector(".btn.btn-primary.btn-lg.btn-block");
        private readonly By accessDeniedPage = By.Id("error-message");
        private readonly By panelAdminLeftNavMenu = By.XPath("//nav[contains(@class, 'jss11')]");

        public void LoginWithDifferentUsers(String username, String password)
        {

            userActions.SendInput(driver, usernameHolder, username);
            userActions.ClickElement(driver, nextButton);
            userActions.SendInput(driver, passwordHolder, password);
            userActions.ClickElement(driver, loginButton);

            if (username == LoginInfo.APP_ACCESS_USER)
            { 
                // this will fail for jenkins demo
                Assert.IsTrue(userActions.WaitUntilElementIsDisplayed(driver, accessDeniedPage));
                logs.Logs.Info(username + " is redirected to Denied Access page because it doesn't have permissions!");
                return;
            }

            Assert.IsTrue(userActions.WaitUntilElementIsDisplayed(driver, panelAdminLeftNavMenu));
            logs.Logs.Info(username + " has navigated to Admin Panel!");

        }

    }
}
