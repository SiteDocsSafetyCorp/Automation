using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SiteDocsAutomationProject.driver;
using SiteDocsAutomationProject.implementation;
using SiteDocsAutomationProject.implementation.webPanel;
using SiteDocsAutomationProject.testCredentials;
using SiteDocsAutomationProject.testCredentials.webPanel;

namespace SiteDocsAutomationProject.tests.webPanel
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("Contractor Suite")]
    [Category("ContractorSuite")]
    public class ContractorsTest : InitializeUserDriver
    {

        //PAGE OBJECTS
        private LoginImpl loginImpl;
        private ContractorsImpl contractorsImpl;

        // This is used to setup common steps to prevent duplicated code
        private void CommonSteps()
        {
            loginImpl = new LoginImpl(driver);
            contractorsImpl = new ContractorsImpl(driver);
            loginImpl.LoginWithDifferentUsers(ILoginInfo.SUPER_ADMIN, ILoginInfo.PASSWORD);
        }

        [Test, Order(1), Description("This test case tests if user can create CompanyType!")]
        public void createCompanyType()
        {
            CommonSteps();
            contractorsImpl.GoToGivenTabWebPanel(IContractorsInfo.SETUP_TAB)
                .GoToGivenSubmenuWebPanel(IContractorsInfo.COMPANY_TYPE_SUBMENU)
                .CreateCompanyType(IContractorsInfo.COMPANY_TYPE_NAME);
        }

        [Test, Order(2), Description("This test case tests if user can create Contractor Company!")]
        public void createContractorCompany()
        {
            CommonSteps();
            contractorsImpl.GoToGivenTabWebPanel(IContractorsInfo.COMPANIES_TAB)
                .GoToGivenSubmenuWebPanel(IContractorsInfo.ALL_COMPANIES_SUBMENU)
                .CreateCompanies(IContractorsInfo.COMPANY_NAME, IContractorsInfo.COMPANY_TYPE_NAME);
        }
    }
}
