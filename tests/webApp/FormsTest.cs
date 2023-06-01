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
    [Category("FormsSuite")]
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

        [Test, Order(1), Description("This test case tests if user can fill all form items and sign it!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80365")]
        public void FillOutAllFormItemsAndSignForm() 
        {
            CommonSteps();
            formsImpl.SelectLocation(FormsInfo.LOCATION_NAME)
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.SIGNED_FORM_LABEL)
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
                .InsertPDFItem("100kb.pdf")
                .SignAndSave()
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_NAME, FormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(FormsInfo.SIGNED_FORM_LABEL)
                .CheckSignitureContainerExists();
        }

        [Test, Order(2), Description("This test case tests if user can fill out follow up template and sign it!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80366")]
        public void FillOutFollowUpAndSignForm()
        {
            CommonSteps();
            formsImpl.SelectLocation(FormsInfo.LOCATION_NAME)
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.SIGN_FOLLOWUP_LABEL)
                .fillOutFollowUpTemplate(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.SHORT_ANSWER, FormsInfo.LONG_ANSWER, FormsInfo.NUMBER, "100kb.pdf", true)
                .SignAndSave()
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(FormsInfo.SIGN_FOLLOWUP_LABEL)
                .CheckSignitureContainerExists();
                
        }


        [Test, Order(3), Description("This test case tests if user can save follow up template and sign it!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/87266")]
        public void SaveFollowUpAndSignForm()
        {
            CommonSteps();
            formsImpl.SelectLocation(FormsInfo.LOCATION_NAME)
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.SAVE_FOLLOWUP_LABEL)
                .fillOutFollowUpTemplate(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.SHORT_ANSWER, FormsInfo.LONG_ANSWER, FormsInfo.NUMBER, "100kb.pdf", false)
                .SignAndSave()
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_FOLLOWUP_NAME, FormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(FormsInfo.SAVE_FOLLOWUP_LABEL)
                .CheckSignitureContainerExists();
        }

        [Test, Order(4), Description("This test case tests if user can fill all form items and save as draft!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80365")]
        public void FillOutAllFormItemsAndSaveAsDraft()
        {
            CommonSteps();
            formsImpl.SelectLocation(FormsInfo.LOCATION_NAME)
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_NAME, FormsInfo.STATUS_NEW)
                .AddFormLabel(FormsInfo.DRAFT_FORM_LABEL)
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
                .InsertPDFItem("100kb.pdf")
                .SaveAsDraft()
                .GoToGivenTab(FormsInfo.FORMS_TAB)
                .SelectFormAndStatus(FormsInfo.FORM_NAME, FormsInfo.STATUS_IN_PROGRESS)
                .SelectPreviousForm(FormsInfo.DRAFT_FORM_LABEL);
        }


    }
 }
