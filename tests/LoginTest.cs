using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
    [AllureSuite("LoginTest")]
    [Category("LoginTest")]

    public class LoginTest : InitializeUserDriver

    {

        // PAGE OBJECTS
        private LoginImpl loginImpl;

        // This is used to setup common steps to prevent duplicated code
        private void CommonSteps(String user)
        {
            loginImpl = new LoginImpl(driver);
            loginImpl.LoginWithDifferentUsers(user, LoginInfo.PASSWORD);
        }


        [Test, Order(1), Category("Failed"), Description("This test case tests if Only App Access user can log in to Admin Panel!")]
        public void appAccessUserToAdminPanel()

        {
            CommonSteps(LoginInfo.APP_ACCESS_USER);

        }


        [Test, Order(2), Category("One"), Description("This test case tests if Admin user can log in to Admin Panel!")]
        public void adminUserToAdminPanel()

        {
            CommonSteps(LoginInfo.ADMIN);

        }


        [Test, Order(3), Description("This test case tests if Super Admin user can log in to Admin Panel!")]
        public void superAdminUserToAdminPanel()

        {
            CommonSteps(LoginInfo.SUPER_ADMIN);

        }

    }
}
