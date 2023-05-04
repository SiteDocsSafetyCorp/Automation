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


        public void LoginWithDifferentUsers(String username, String password)
        {

            actions.SendInput(usernameHolder, username, 2);
            actions.Click(nextBtn, 10);
            actions.SendInput(passwordHolder, password, 2);
            actions.Click(loginBtn, 10);

            try
            {
                // This will look for an error message showing that the username/password was incorrect
                IWebElement errorMessage = driver.FindElement(By.ClassName("login-input-error"));
                if (errorMessage.Text.Contains("The username and/or password did not match our records."))
                {
                    logs.Logs.Error("User has used wrong username/password and wasn't logged in! ");
                    return;
                }
            }
            catch (NoSuchElementException)
            {
                logs.Logs.Info("Login successful for user " + username);
            }

            if (username == LoginInfo.APP_ACCESS_USER)
            {
                Assert.IsTrue(actions.WaitUntilElementIsDisplayed(accessDeniedPage, 2));
                logs.Logs.Info(username + " is redirected to Denied Access page because it doesn't have permissions!");
                return;
            }

            Assert.IsTrue(actions.WaitUntilElementIsDisplayed(userProfile, 2));
            logs.Logs.Info(username + " has navigated to Admin Panel!");

        }



        // change password is different in stage from dev
        public void ChangePassword()
        {
            actions.Click(userProfile, 2);
            actions.Click(changePasswordBtn, 2);
            actions.WaitUntilElementIsDisplayed(changePasswordModal, 2);
            logs.Logs.Info("Change password modal was successfully opened!");
            actions.SendInput(currentPasswordHolder, LoginInfo.PASSWORD, 2);
            actions.SendInput(newPasswordHolder, LoginInfo.PASSWORD, 2);
            actions.SendInput(confirmPasswordHolder, LoginInfo.PASSWORD, 2);
            actions.Click(confirmChangePasswordBtn, 2);
            actions.WaitUntilElementIsDisplayed(passwordChangedMsg, 2);
            logs.Logs.Info("User has changed password successfully!");

        }

    }
}
