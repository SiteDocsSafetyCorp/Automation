using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SiteDocsAutomationProject.driver;
using SiteDocsAutomationProject.implementation;
using SiteDocsAutomationProject.implementation.webApp;
using SiteDocsAutomationProject.testCredentials;
using SiteDocsAutomationProject.testCredentials.webApp;


/**
 * This is the test class where the QA create Test Cases 
 * All appropriate methods and page objects to run a test should be called in this class
 * @Test annotation system will recognize from where to run a specific test
 * @Order annotation is used to prioritize the test cases
 * @Description annotation is used to descripe what's the test case for 
 * @AllureLink annotation is used to put test case's link from TestRail
 * You can run all tests in View/Test Explorer
 */
namespace SiteDocsAutomationProject.tests.webApp
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("Forms Suite")]
    [Category("Forms")]
    internal class FormsTest : InitializeUserDriver
    {

        // PAGE OBJECTS
        private LoginImpl loginImpl;
        private FormsImpl formsImpl;

        // This is used to setup common steps to prevent duplicated code
        private void CommonSteps()
        {
            loginImpl = new LoginImpl(driver);
            formsImpl = new FormsImpl(driver);
            driver.Navigate().GoToUrl("https://dev-app.sitedocs.com/");
            loginImpl.LoginWithDifferentUsers(LoginInfo.APP_ACCESS_USER, LoginInfo.PASSWORD);
        }

        [Test, Order(1), Description("This test case tests if user can fill all form items and sign it!")]
        public void FillOutAllFormItemsAndSign() 
        {
            CommonSteps();
            formsImpl.SelectLocationAndGoToGivenTab(FormsInfo.LOCATION_NAME, FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.LABEL)
                .PassOrFailOrNoneItem()
                .CheckBoxItem()
                .ShortAnswerItem(FormsInfo.SHORT_ANSWER)
                .LongAnswerItem(FormsInfo.LONG_ANSWER)
                .DropDownOneSelect()
                .DropDownMultipleSelect()
                .YesOrNoOrNoneItem()
                .PassOrFailCounterItem()
                .NumberOnlyItem(FormsInfo.NUMBER)
                .SelectDateItem()
                .SelectTimeItem()
                .SelectOneWorkerItem()
                .SelectMultipleWorkersItem()
                .AddGPSCoordinatesItem()
                .ViewImageItem()
                .ViewPDFItem()
                .InsertPDFItem("1mb.pdf")
                .SignAndSave();
        }

        [Test, Order(2), Description("This test case tests if user can fill out follow up template and sign it!")]
        public void FillOutFollowUpAndSign()
        {
            CommonSteps();
            formsImpl.SelectLocationAndGoToGivenTab(FormsInfo.LOCATION_NAME, FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.LABEL)
                .fillOutFollowUpTemplate(FormsInfo.LABEL, FormsInfo.SHORT_ANSWER, FormsInfo.LONG_ANSWER, FormsInfo.NUMBER, "100kb.pdf")
                .SignAndSave();
        }


    }
}
