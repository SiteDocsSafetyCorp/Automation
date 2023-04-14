using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

/**
 * This class serves to open browser and go to Admin Panel
 * @SetUp annotation is used to run some code BEFORE @Test runs
 *    In our case it launches browser and goes to Admin Panel
 * @TearDown annotation is used to run some code AFTER @Test runs
 *    In our case it closes browser after test case is completed
 */
namespace SiteDocsAutomationProject.driver
{
    [AllureNUnit]
    [TestFixture]
    public class InitializeUserDriver
    {

        public IWebDriver driver;


        [SetUp]
        public void Initialize()

        {
            // This is used to initialize driver!
            ChromeOptions capability = new ChromeOptions
            {
                BrowserVersion = "latest"
            };
            capability.AddArgument("--incognito");
            capability.AddAdditionalOption("bstack:options", capability);
            driver = new RemoteWebDriver(
              new Uri("http://localhost:4444/wd/hub/"),
              capability
            );

            // This is used to set driver properties and navigate to homepage!
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://dev-panel.sitedocs.com/");
            Assert.IsTrue(driver.FindElement(By.ClassName("logo-wrapper")).Displayed);
            logs.Logs.StartOfTest();
            logs.Logs.Info("User was successfully navigate to Home Page!");


        }

        [TearDown]
        public void TearDown()

        {
            // This is used to take screenshot after failure test!
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
                var path = "user.dir" + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
            }

            driver.Quit();
            logs.Logs.EndOfTest();
        }
    }
}
