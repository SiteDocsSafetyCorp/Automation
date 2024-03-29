﻿using NUnit.Allure.Attributes;
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
    public class FormsTest : InitializeUserDriver
    {

        // PAGE OBJECTS
        private LoginImpl loginImpl;
        private FormsImpl formsImpl;

        // This is used to setup common steps to prevent duplicated code
        private void CommonSteps()
        {
            loginImpl = new LoginImpl(driver);
            formsImpl = new FormsImpl(driver);
            loginImpl.LoginWithDifferentUsers(ILoginInfo.APP_ACCESS_USER, ILoginInfo.PASSWORD);
        }

        [Test, Order(1), Description("This test case tests if user can sign a form by filling all form items!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80365")]
        public void SignFormByFillingAllFormItems() 
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.SIGN_FORM_LABEL)
                .FillOutAllItems(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf")
                .SignAndSave()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_NAME, IFormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(IFormsInfo.SIGN_FORM_LABEL)
                .PrettyPrint(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER);


        }

        [Test, Order(2), Description("This test case tests if user can sign a form with signed followup and filling out all followup items!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/90221")]
        public void SignFormWithFollowupSignedByFillingAllFollowupItems()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.SIGN_FOLLOWUP_LABEL_1)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", true)
                .SignAndSave()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(IFormsInfo.SIGN_FOLLOWUP_LABEL_1)
                .PrettyPrint(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER);

        }


        [Test, Order(3), Description("This test case tests if user can sign a form with saved followup and filling out all followup items!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/90220")]
        public void SignFormWithFollowupSavedByFillingAllFollowupItems()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.SAVE_FOLLOWUP_LABEL)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", false)
                .SignAndSave()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(IFormsInfo.SAVE_FOLLOWUP_LABEL)
                .PrettyPrint(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER);
        }

        [Test, Order(4), Description("This test case tests if user can fill all form items and save as draft!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/89671")]
        public void SaveDraftFormByFillingAllFormItems()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.DRAFT_FORM_LABEL)
                .FillOutAllItems(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf")
                .SaveAsDraft()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_NAME, IFormsInfo.STATUS_IN_PROGRESS)
                .SelectPreviousForm(IFormsInfo.DRAFT_FORM_LABEL);
        }


        [Test, Order(5), Description("This test case tests if user can add signed followup on previously signed form!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/90223")]
        public void AddSignedFollowupOnPreviouslySignedForm()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.SIGN_FOLLOWUP_LABEL_2)
                .SignAndSave()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(IFormsInfo.SIGN_FOLLOWUP_LABEL_2)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", true)
                .PrettyPrint(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER);
        }

        [Test, Order(6), Description("This test case tests if user can add saved followup on previously signed form!"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/90222")]
        public void AddSavedFollowupOnPreviouslySignedForm()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.SAVE_FOLLOWUP_LABEL_2)
                .SignAndSave()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_PREVIOUSLY_SIGNED)
                .SelectPreviousForm(IFormsInfo.SAVE_FOLLOWUP_LABEL_2)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", false)
                .PrettyPrint(IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER);
        }

        [Test, Order(7), Description("This test case tests if user can save draft form with signed followup by filling all form items"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80377")]
        public void SaveDraftFormWithSignedFollowup()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.DRAFT_FORM_LABEL_2)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", true)
                .SaveAsDraft()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_IN_PROGRESS)
                .SelectPreviousForm(IFormsInfo.DRAFT_FORM_LABEL_2);
        }

        [Test, Order(8), Description("This test case tests if user can save draft form with saved followup by filling all form items"), AllureLink("https://sitedocs.testrail.io/index.php?/cases/view/80376")]
        public void SaveDraftFormWithSavedsFollowup()
        {
            CommonSteps();
            formsImpl.SelectLocation(IFormsInfo.LOCATION_NAME)
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_NEW)
                .AddFormLabel(IFormsInfo.DRAFT_FORM_LABEL_3)
                .FillOutFollowUpTemplate(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.SHORT_ANSWER, IFormsInfo.LONG_ANSWER, IFormsInfo.NUMBER, "100kb.pdf", false)
                .SaveAsDraft()
                .GoToGivenTabWebWebApp(IFormsInfo.FORMS_TAB)
                .SelectFormAndStatus(IFormsInfo.FORM_FOLLOWUP_NAME, IFormsInfo.STATUS_IN_PROGRESS)
                .SelectPreviousForm(IFormsInfo.DRAFT_FORM_LABEL_3);
        }
    }
 }
