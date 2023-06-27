using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SiteDocsAutomationProject.driver;
using SiteDocsAutomationProject.implementation;
using SiteDocsAutomationProject.testCredentials;

/**
 * This is the test class where the QA create Test Cases 
 * All appropriate methods and page objects to run a test should be called in this class
 * @Test annotation system will recognize from where to run a specific test
 * @Order annotation is used to prioritize the test cases
 * @Description annotation is used to descripe what's the test case for 
 * @AllureLink annotation is used to put test case's link from TestRail
 * You can run all tests in View/Test Explorer
 */
namespace SiteDocsAutomationProject.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("Login Suite")]
    [Category("LoginSuite")]

    public class LoginTest : InitializeUserDriver

    {

        // PAGE OBJECTS
        private LoginImpl loginImpl;

        // This is used to setup common steps to prevent duplicated code
        private void CommonSteps(String user, String password)
        {
            loginImpl = new LoginImpl(driver);
            loginImpl.LoginWithDifferentUsers(user, password);
        }


        [Test, Order(1), Description("This test case tests if Only App Access user can log in to Admin Panel!")]
        public void AapAccessUserToAdminPanel()

        {
            CommonSteps(LoginInfo.APP_ACCESS_USER, LoginInfo.PASSWORD);

        }


        [Test, Order(2), Description("This test case tests if Admin user can log in to Admin Panel!")]
        public void AdminUserToAdminPanel()

        {
            CommonSteps(LoginInfo.ADMIN, LoginInfo.PASSWORD);

        }


        [Test, Order(3), Description("This test case tests if Super Admin user can log in to Admin Panel!")]
        public void SuperAdminUserToAdminPanel()

        {
            CommonSteps(LoginInfo.SUPER_ADMIN, LoginInfo.PASSWORD);

        }

        [Test, Order(4), Description("This test case tests if user can login with wrong username!")]
        public void loginWithWrongUsername()
        {
            CommonSteps(LoginInfo.WRONG_USERNAME, LoginInfo.PASSWORD);
        }
        
        [Test, Order(5), Description("This test case tests if user can login with wrong password!")]
        public void loginWithWrongPassword()
        {
            CommonSteps(LoginInfo.WRONG_USERNAME, LoginInfo.WRONG_PASSWORD);
        }

        [Test, Order(6), Description("This test case tests if Super Admin user can change password!")]
        public void ChangePassword()
        {
            CommonSteps(LoginInfo.SUPER_ADMIN, LoginInfo.PASSWORD);
            loginImpl.ChangePassword();

        }
    }
}
