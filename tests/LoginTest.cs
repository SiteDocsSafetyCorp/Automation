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
    [Category("Login")]

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


        [Test, Order(1), Description("This test case tests if Only App Access user can log in to Admin Panel!"),
            AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/4667&group_by=cases:section_id&group_order=asc&display_deleted_cases=0&group_id=371")]
        public void appAccessUserToAdminPanel()

        {
            CommonSteps(LoginInfo.APP_ACCESS_USER);

        }


        [Test, Order(2), Description("This test case tests if Admin user can log in to Admin Panel!")]
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
