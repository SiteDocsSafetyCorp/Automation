using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SiteDocsAutomationProject.utilities;
using Directory = SiteDocsAutomationProject.utilities.Directory;

/**
 * Impl classes are used to setup steps that user has to take in order to complete a test case
 * For every Method that you create that does any action, please add logs to describe that action
 * Import the class and use LogDemo.info() method to describe action.
 */
namespace SiteDocsAutomationProject.implementation.webApp
{
    internal class FormsImpl
    {
        // PAGE OBJECTS
        private readonly IWebDriver driver;
        private readonly UserDriverActions actions;

        // CLASS CONSTRUCTOR
        public FormsImpl(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new UserDriverActions(driver);
        }

        // LOCATORS
        private readonly By locationModal = By.Id("location-modal-paper");
        private readonly By locationOption = By.XPath("//li[@data-id='location-modal-item-name-button']");
        private readonly By profile = By.Id("HOME_MENU");
        private readonly By formsMenu = By.XPath("//h4[text()='Forms']");
        private readonly By formTemplateContainer = By.Id("form-container-ss-form");
        private readonly By formsLabel = By.Id("company-info-label");
        private readonly By commentOnPhotoHolder = By.XPath(".//textarea[@placeholder='Add Photo Comment']");
        private readonly By uploadImageHolder = By.XPath(".//input[@type='file']");
        private readonly By signAndSaveBtn = By.XPath("//button[@data-id='sign-button']");
        private readonly By selectEmployeeModal = By.XPath("//div[@data-id='select-form-item-modal']");
        private readonly By saveSignatureBtn = By.XPath("//button[@data-id='save-signature-button']");
        private readonly By passAndYesBtn = By.XPath(".//button[@data-id='form-item-passfail-pass']");
        private readonly By passAndFailCounterBtn = By.XPath(".//button[@data-id='form-item-passfailcounter-increment-button']");
        private readonly By checkboxBtn = By.XPath(".//button[@data-id='form-item-checkbox-button']");
        private readonly By shortAnswerHolder = By.XPath(".//textarea[@placeholder='Short Answer']");
        private readonly By longAnswerHolder = By.XPath(".//textarea[@placeholder='Long Answer']");
        private readonly By numberHolder = By.XPath(".//textarea[@placeholder='Number']");
        private readonly By selectBtn = By.XPath(".//button[@type='button']");
        private readonly By selectDateModal = By.XPath("//div[@data-id='form-item-date-modal']");
        private readonly By okDateBtn = By.XPath("//span[@data-id='form-item-date-modal-submit-button']");
        private readonly By okTimeBtn = By.XPath("//span[@data-id='form-item-time-modal-submit-button']");
        private readonly By optionOne = By.XPath("//h5[contains(@class, 'webforms-MuiTypography-root webforms-MuiTypography-h5') and contains (.,'option1')]");
        private readonly By optionTwo = By.XPath("//h5[contains(@class, 'webforms-MuiTypography-root webforms-MuiTypography-h5') and contains (.,'option2')]");
        private readonly By doneBtn = By.XPath("//button[@data-id='select-form-item-modal-button']");
        private readonly By addLocationBtn = By.XPath(".//button[@data-id='pdf-form-latlong-button']");
        private readonly By itemImageHolder = By.XPath(".//div[@data-id='form-item-container-image']");
        private readonly By viewPdfBtn = By.XPath(".//button[@data-id='pdf-form-item-button']");
        private readonly By pdfDocument = By.ClassName("react-pdf__Document");
        private readonly By closeBtn = By.XPath("//button[@data-id='close-modal-button']");
        private readonly By uploadPdfHolder = By.XPath("//input[@data-testid='pdf-input-file']");
        private readonly By pdfPageCanvasHolder = By.XPath("//canvas[@class='react-pdf__Page__canvas']");
        private readonly By followUpBtn = By.XPath("//button[@aria-label='Add Flag']");
        private readonly By followUpForm = By.XPath("//span[@data-id='followup-form-item-name-text']");
        private readonly By commentBtn = By.XPath(".//button[@aria-label='Add Comment']");
        private readonly By commentHolder = By.XPath(".//textarea[@id='undefined-comment']");
        private readonly By adminUserSelect = By.XPath("//h5[text()='Automation, Admin']");
        private readonly By appAccessUserSelect = By.XPath("//h5[text()='Automation, AppAccess']");
        private readonly By FormSignedSuccessfullyMsg = By.Id("notistack-snackbar");



        public FormsImpl SelectLocationAndGoToGivenTab(String locationName, String tabName)
        {
            actions.WaitUntilElementIsDisplayed(locationModal);
            IWebElement option = driver.FindElement(locationOption);
            if (option.Text.Equals(locationName))
            {
                option.Click();
                Thread.Sleep(1000);
                logs.Logs.Info("User has selected location - " + locationName);
                actions.WaitUntilElementIsDisplayed(profile);
            }
            else
            {
                Assert.Fail(locationName + " - was not found in the list!");
            }
            actions.ClickElementFromList(By.ClassName("webforms-webforms-42"), By.TagName("a"), tabName);
            logs.Logs.Info("User has successfully navigated to tab - " + tabName);
            return this;
        }

        public FormsImpl SelectFormAndStatus(String formName, String status)
        {
            actions.WaitUntilElementIsDisplayed(formsMenu);
            logs.Logs.Info("Forms menu is visible!");
            actions.ClickElementFromList(By.ClassName("ReactVirtualized__Grid__innerScrollContainer"), By.TagName("span"), formName);
            actions.ClickElementFromList(By.TagName("nav"), By.TagName("a"), status);
            actions.WaitUntilElementIsDisplayed(formTemplateContainer);
            logs.Logs.Info("User has successfully selected form - " + formName + " and selected status - " + status);
            return this;
        }

        public FormsImpl AddFormLabel(String label)
        {
            actions.SendInput(formsLabel, label);
            logs.Logs.Info(label + " label was typed for this form template!");
            return this;
        }

        private IWebElement SelectFormItem(int nr)
        {
            return driver.FindElement(By.XPath($"//div[@data-id='form-item-container-{nr}']"));
        }


        public FormsImpl PassOrFailOrNoneItem() 
        {
            IWebElement item1 = SelectFormItem(2);
            item1.FindElement(passAndYesBtn).Click();

            return this;
        }

        public FormsImpl CheckBoxItem()
        {
            IWebElement section = SelectFormItem(1);
            actions.Click(checkboxBtn);

            return this;
        }

        public FormsImpl ShortAnswerItem(String shortText)
        {
            IWebElement item3 = SelectFormItem(6);
            item3.FindElement(shortAnswerHolder).SendKeys(shortText);

            return this;
        }

        public FormsImpl LongAnswerItem(String text)
        {
            IWebElement section = SelectFormItem(3);
            actions.SendInput(longAnswerHolder, text);

            return this;
        }

        public FormsImpl DropDownOneSelect()
        {
            IWebElement item6 = SelectFormItem(9);
            item6.FindElement(selectBtn).Click();
            actions.Click(optionOne);
            actions.Click(doneBtn);

            return this;
        }

        public FormsImpl DropDownMultipleSelect()
        {
            IWebElement item7 = SelectFormItem(8);
            item7.FindElement(selectBtn).Click();
            actions.Click(optionOne);
            actions.Click(optionTwo);
            actions.Click(doneBtn);

            return this;
        }

        public FormsImpl YesOrNoOrNoneItem()
        {
            IWebElement item8 = SelectFormItem(18);
            item8.FindElement(passAndYesBtn).Click();

            return this;
        }

        public FormsImpl PassOrFailCounterItem()
        {
            IWebElement item9 = SelectFormItem(19);
            item9.FindElements(passAndFailCounterBtn)?.ElementAtOrDefault(0)?.Click();
            item9.FindElements(passAndFailCounterBtn)?.ElementAtOrDefault(1)?.Click();

            return this;
        }

        public FormsImpl NumberOnlyItem(String nr)
        {
            IWebElement item10 = SelectFormItem(16);
            item10.FindElement(numberHolder).SendKeys(nr);

            return this;
        }

        public FormsImpl SelectDateItem()
        {
            IWebElement item11 = SelectFormItem(13);
            item11.FindElement(selectBtn).Click();
            actions.WaitUntilElementIsDisplayed(selectDateModal);
            actions.Click(okDateBtn);

            return this;
        }

        public FormsImpl SelectTimeItem()
        {
            IWebElement item12 = SelectFormItem(14);
            item12.FindElement(selectBtn).Click();
            actions.Click(okTimeBtn);

            return this;
        }

        public FormsImpl SelectOneWorkerItem()
        {
            IWebElement item13 = SelectFormItem(12);
            item13.FindElement(selectBtn).Click();
            actions.Click(adminUserSelect);
            actions.Click(doneBtn);

            return this;
        }

        public FormsImpl SelectMultipleWorkersItem()
        {
            IWebElement item14 = SelectFormItem(20);
            item14.FindElement(selectBtn).Click();
            actions.Click(adminUserSelect);
            actions.Click(appAccessUserSelect);
            actions.Click(doneBtn);

            return this;
        }

        public FormsImpl AddGPSCoordinatesItem()
        {
            IWebElement item15 = SelectFormItem(17);
            item15.FindElement(addLocationBtn).Click();

            return this;
        }

        public FormsImpl ViewImageItem()
        {
            IWebElement item16 = SelectFormItem(22);
            actions.WaitUntilElementIsDisplayed(itemImageHolder);

            return this;
        }

        public FormsImpl ViewPDFItem()
        {
            actions.Click(viewPdfBtn);
            actions.WaitUntilElementIsDisplayed(pdfDocument);
            actions.Click(closeBtn);

            return this;
        }

        public FormsImpl InsertPDFItem(String fileName)
        {
            IWebElement item18 = SelectFormItem(23);
            item18.FindElement(selectBtn).Click();
            actions.UploadImageOrFile(uploadPdfHolder, fileName);
            actions.WaitUntilElementIsDisplayed(pdfPageCanvasHolder);

            return this;
        }

        public FormsImpl ClickAndComment(int nrOfSection, String comment)
        {
            IWebElement section = SelectFormItem(nrOfSection);
            try
            {
                section.FindElement(commentBtn).Click();
                section.FindElement(commentHolder).SendKeys(comment);
                logs.Logs.Info($"text '{comment}' was typed!");
            }
            catch (NotFoundException e) 
            {
                logs.Logs.Info($"An error occurred: {e.Message}, the section user has selected might not have comment button!");
                throw;
            }
            return this;
        }

        public FormsImpl UploadImageAndComment(int nrOfSection, String fileName, String comment)
        {
            IWebElement section = SelectFormItem(nrOfSection);
            try
            {

                UploadImageOnForm(section, fileName);
                section.FindElement(commentOnPhotoHolder).SendKeys(comment);
                logs.Logs.Info($"text '{comment}' was typed on the photo!");
            }
            catch(NotFoundException e) 
            {
                logs.Logs.Info($"An error occurred: {e.Message}, the section user has selected might not have image uploader button!");
                throw;
            }
            return this;
        }

        public FormsImpl fillOutFollowUpTemplate(String followUpLabel, String shortText, String longText, String nr, String fileName)
        {
            actions.Click(followUpBtn);
            actions.Click(followUpForm);
            IWebElement followUpContainer = driver.FindElement(By.Id("form-container-ss-followup-form"));
            followUpContainer.FindElement(formsLabel).SendKeys(followUpLabel);
            IWebElement item11 = SelectFormItem(11);
            item11.FindElement(selectBtn).Click();
            actions.Click(adminUserSelect);
            actions.Click(appAccessUserSelect);
            actions.Click(doneBtn);
            IWebElement item10 = SelectFormItem(10);
            item10.FindElement(selectBtn).Click();
            actions.WaitUntilElementIsDisplayed(selectDateModal);
            actions.Click(okDateBtn);
            PassOrFailOrNoneItem();
            CheckBoxItem();
            ShortAnswerItem(shortText);
            LongAnswerItem(longText);
            DropDownOneSelect();
            DropDownMultipleSelect();
            YesOrNoOrNoneItem();
            PassOrFailCounterItem();
            NumberOnlyItem(nr);
            SelectDateItem();
            SelectTimeItem();
            SelectOneWorkerItem();
            SelectMultipleWorkersItem();
            ViewImageItem();
            AddGPSCoordinatesItem();
            InsertPDFItem(fileName);
            driver.FindElements(signAndSaveBtn)?.ElementAtOrDefault(1)?.Click();
            actions.Click(appAccessUserSelect);
            DrawSigniture();
            actions.WaitUntilElementIsDisplayed(By.XPath("//span[@data-id='signature-item-worker-name']"));
            actions.Click(closeBtn);
            logs.Logs.Info("User has successfully filled out the follow up form and signed it!");
            return this;
        }

        public FormsImpl SignAndSave()
        {
            actions.Click(signAndSaveBtn);
            actions.WaitUntilElementIsDisplayed(selectEmployeeModal);

            logs.Logs.Info("Select Employee modal was opened successfully!");
            actions.Click(appAccessUserSelect);
            DrawSigniture();
            actions.WaitUntilElementIsDisplayed(FormSignedSuccessfullyMsg);
            logs.Logs.Info("Form signed successfully message appeared!");
            return this;
        }

        public void DrawSigniture()
        {
            IWebElement canvas = driver.FindElement(By.Id("signature-canvas"));
            Actions action = new Actions(driver);
            action.MoveToElement(canvas)
                .ClickAndHold()
                .MoveByOffset(50, 20)
                .MoveByOffset(50, 30)
                .MoveByOffset(50, 40)
                .Release()
                .Perform();

            actions.Click(saveSignatureBtn);
        }

        public void UploadImageOnForm(IWebElement section, string fileName)
        {
            IWebElement fileUploadButton = section.FindElement(uploadImageHolder);
            string imagePath = DirectoryPaths.GetPath(Directory.UploadFilesPath) + fileName;
            fileUploadButton.SendKeys(imagePath);
            logs.Logs.Info(fileName + " was uploaded successfully!");

        }


    }
}
