using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SiteDocsAutomationProject.utilities;

namespace SiteDocsAutomationProject.implementation.webPanel
{
    public class ContractorsImpl
    {

        // PAGE OBJECTS
        private readonly IWebDriver driver;
        private readonly UserDriverActions actions;
        private string randomOptionText;


        // CLASS CONSTRUCTOR
        public ContractorsImpl(IWebDriver driver)
        {
            this.driver = driver;
            actions = new UserDriverActions(driver);
        }

        // LOCATORS

        private readonly By leftMenu = By.XPath("//nav[@class='jss11']");
        private readonly By leftSubmenu = By.XPath("//div[@class='jss18']");
        // --- Company Type ---
        private readonly By companyTypeTitle = By.XPath("//h4[text()='Company Types']");
        private readonly By createCompanyTypeBtn = By.Id("new_company_type");
        private readonly By companyTypeNameHolder = By.CssSelector(".MuiInputBase-input-818.MuiInput-input-806");
        private readonly By createBtn = By.XPath("//span[contains(@class, 'MuiButton-label-828') and contains (.,'Create')]");
        // --- Companies ---
        private readonly By companiesTitle = By.XPath("//h4[text()='Companies']");
        private readonly By createCompanyBtn = By.Id("new_company");
        private readonly By companyNameHolder = By.Id("new-contractor-company-name-input");
        private readonly By createBtn2 = By.XPath("//span[text()='Create']");
        private readonly By addLocationBtn = By.XPath("//svg[@data-id='worker-add-location']");
        private readonly By assignLocationModal = By.XPath("//svg[@data-id='alert-dialog-container']");
        private readonly By locationsTitle = By.XPath("//h4[text()='Locations']");



        public ContractorsImpl GoToGivenTabWebPanel(string tabName)
        {
            actions.WaitUntilElementIsDisplayed(leftMenu);
            actions.ClickElementFromList(leftMenu, By.TagName("a"), tabName);
            Thread.Sleep(2000);
            logs.Logs.Info($"'{tabName}' menu item was successfully found on the left menu!");
            return this;
        }

        public ContractorsImpl GoToGivenSubmenuWebPanel(string submenuTab)
        {
            actions.WaitUntilElementIsDisplayed(leftSubmenu);
            actions.ClickElementFromList(leftSubmenu, By.TagName("a"), submenuTab);
            logs.Logs.Info($"'{submenuTab}' submenu item was successfully found on the left submenu!");
            return this;
        }


        public ContractorsImpl CreateCompanyType(string companyTypeName)
        {
            actions.WaitUntilElementIsDisplayed(companyTypeTitle);
            actions.Click(createCompanyTypeBtn);
            actions.SendInput(companyTypeNameHolder, companyTypeName);
            actions.Click(createBtn);
            Thread.Sleep(1000);
            actions.IsElementDisplayedInList(By.TagName("tbody"), By.TagName("tr"), companyTypeName);
            logs.Logs.Info($"'{companyTypeName}' company type was successfully created and found on the list!");
            return this;
        }

        public ContractorsImpl CreateCompanies(string companyName, string companyTypeName)
        {
            actions.WaitUntilElementIsDisplayed(companiesTitle);
            actions.Click(createCompanyBtn);
            actions.SendInput(companyNameHolder, companyName);
            IWebElement element = driver.FindElement(By.XPath("//label[text()='Company Type']"));
            Actions action = new Actions(driver);
            action.Click(element).Perform();

            try
            {
                IWebElement dropdownElement = driver.FindElement(By.XPath($"//ul/li[text()='{companyTypeName}']"));
                action.Click(dropdownElement).Perform();
                logs.Logs.Info($"Selected the option '{companyTypeName}'.");
            }
            catch (NoSuchElementException)
            {
                actions.SelectRandomOption(driver.FindElements(By.XPath("//ul/li")));
            }

            actions.Click(createBtn2);
            Thread.Sleep(1000);
            actions.IsElementDisplayedInList(By.TagName("tbody"), By.TagName("tr"), companyTypeName);
            logs.Logs.Info($"'{companyName}' company was successfully created and found on the list!");
            return this;
        }

        public ContractorsImpl AssignLocationToCompany(string companyName) 
        {
            string locationName = "ContractorTest";
            actions.WaitUntilElementIsDisplayed(companiesTitle);
            try
            {
                IWebElement company = driver.FindElement(By.XPath($"//tbody/tr[text()='{companyName}']"));
                company.FindElement(addLocationBtn);
            }
            catch (NoSuchElementException)
            {
                actions.SelectRandomOption(driver.FindElements(addLocationBtn));
            }
           
            actions.WaitUntilElementIsDisplayed(assignLocationModal);
            actions.ClickElementFromList(By.TagName("tr"), By.TagName("td"), locationName);
            Thread.Sleep(10000);

            return this;
        }


    }
}
