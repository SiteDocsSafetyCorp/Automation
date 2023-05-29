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

            actions.SendInput(usernameHolder, username);
            actions.Click(nextBtn);
            actions.SendInput(passwordHolder, password);
            actions.Click(loginBtn);

            try
            {
                // This will look for an error message showing that the username/password was incorrect
                IWebElement errorMessage = driver.FindElement(By.ClassName("login-input-error"));
                if (errorMessage.Text.Contains("The username and/or password did not match our records."))
                {
                    logs.Logs.Info("User has used wrong username/password and wasn't logged in! ");
                    return;
                }
            }
            catch (NoSuchElementException)
            {
                logs.Logs.Info("Login successful for user " + username);
            }

            if(username == LoginInfo.APP_ACCESS_USER) 
            {
                logs.Logs.Info(username + " was redirected to Web App");
            }
               else
            {
                Assert.IsTrue(actions.WaitUntilElementIsDisplayed(userProfile));
                logs.Logs.Info(username + " has navigated to Admin Panel!");
            }
            

        }



        // change password is different in stage from dev
        public void ChangePassword()
        {
            actions.Click(userProfile);
            actions.Click(changePasswordBtn);
            actions.WaitUntilElementIsDisplayed(changePasswordModal);
            logs.Logs.Info("Change password modal was successfully opened!");
            actions.SendInput(currentPasswordHolder, LoginInfo.PASSWORD);
            actions.SendInput(newPasswordHolder, LoginInfo.PASSWORD);
            actions.SendInput(confirmPasswordHolder, LoginInfo.PASSWORD);
            actions.Click(confirmChangePasswordBtn);
            actions.WaitUntilElementIsDisplayed(passwordChangedMsg);
            logs.Logs.Info("User has changed password successfully!");

        }

    }
}
