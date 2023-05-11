using OpenQA.Selenium;
using NUnit.Framework;
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
        private readonly UserDriverActions actions;


        // CLASS CONSTRUCTOR
        public LoginImpl(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new UserDriverActions(driver);
        }

        // LOCATORS 
        private readonly By usernameHolder = By.Id("Username");
        private readonly By passwordHolder = By.Id("Password");
        private readonly By loginBtn = By.CssSelector(".btn.btn-primary.btn-lg.btn-block");
        private readonly By nextBtn = By.CssSelector(".btn.btn-primary.btn-lg.btn-block");
        private readonly By accessDeniedPage = By.Id("error-message");
        private readonly By userProfile = By.Id("bottom-menu-profile");
        private readonly By changePasswordBtn = By.XPath("//div[text()='Change Password']");
        private readonly By changeEmailBtn = By.XPath("//div[text()='Change Email']");
        private readonly By changePasswordModal = By.XPath("//div[@data-id='alert-dialog-container']");
        private readonly By currentPasswordHolder = By.Id("password");
        private readonly By newPasswordHolder = By.Id("new-password");
        private readonly By confirmPasswordHolder = By.Id("confirm-password");
        private readonly By confirmChangePasswordBtn = By.XPath("//span[text()='Change Password']");
        private readonly By passwordChangedMsg = By.XPath("//span[text()='Password changed successfully']");
        private readonly By wrongCredentialsError = By.XPath("//div[@class='login-input-error']");


        public void LoginWithDifferentUsers(String username, String password)
        {

            actions.SendInput(usernameHolder, username, 5);
            actions.Click(nextBtn, 5);
            actions.SendInput(passwordHolder, password, 5);
            actions.Click(loginBtn, 5);

            if (username == LoginInfo.APP_ACCESS_USER)
            {
                Assert.IsTrue(actions.WaitUntilElementIsDisplayed(accessDeniedPage, 5));
                logs.Logs.Info(username + " is redirected to Denied Access page because it doesn't have permissions!");
                return;
            }
            else if (username == LoginInfo.WRONG_USERNAME || password == LoginInfo.WRONG_PASSWORD)
            {
                Assert.IsTrue(actions.WaitUntilElementIsDisplayed(wrongCredentialsError, 5));
                logs.Logs.Error("User has used wrong username/password and wasn't logged in! ");
                return;
            }

            Assert.IsTrue(actions.WaitUntilElementIsDisplayed(userProfile, 5));
            logs.Logs.Info(username + " has navigated to Admin Panel!");

        }



        // change password is different in stage from dev
        public void ChangePassword()
        {
            actions.Click(userProfile, 5);
            actions.Click(changePasswordBtn, 5);
            actions.WaitUntilElementIsDisplayed(changePasswordModal, 5);
            logs.Logs.Info("Change password modal was successfully opened!");
            actions.SendInput(currentPasswordHolder, LoginInfo.PASSWORD, 5);
            actions.SendInput(newPasswordHolder, LoginInfo.PASSWORD, 5);
            actions.SendInput(confirmPasswordHolder, LoginInfo.PASSWORD, 5);
            actions.Click(confirmChangePasswordBtn, 5);
            actions.WaitUntilElementIsDisplayed(passwordChangedMsg, 5);
            logs.Logs.Info("User has changed password successfully!");

        }

    }
}
