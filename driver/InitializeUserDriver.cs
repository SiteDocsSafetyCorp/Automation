using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

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

        // Default env is Stage Panel
        private const string environment = "stagePanel";
        // Default runType is Remote
        private const string runType = "local";

        [SetUp]
        public void Initialize()

        {
            // This is used to retrieve data from json file!
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: false)
                .Build();

            if (runType.Equals("remote"))
            {
                // This is used to initialize BrowserStack driver!
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
            }
            else if (runType.Equals("local"))
            {

                Dictionary<string, object> profile = new Dictionary<string, object>();

                // 0 - Default, 1 - Allow, 2 - Block
                profile.Add("profile.default_content_setting_values.geolocation", 1);

                Dictionary<string, object> chromeOptions = new Dictionary<string, object>();

                chromeOptions.Add("prefs", profile);

                ChromeOptions options = new ChromeOptions();
                
                options.AddArgument("--start-maximized");
                options.AddArgument("--test-type");
                options.AddArgument("--enable-strict-powerful-feature-restrictions");
                options.AddArgument("--disable-notifications");
                options.AddArgument("--enable-features=Geolocation");
                options.AddArgument("--disable-popup-blocking");
                options.AddArgument("--delete-cookies");


                // Set the desired geolocation coordinates
                options.AddArgument("--geolocation=42.662914,21.165503");
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                driver = new ChromeDriver(options);
                      
            }
            else
            {
                throw new InvalidOperationException("RunType not specified!");
            }

            // This is used to set driver properties and navigate to SiteDocs homepage!
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl(configuration.GetSection(environment).Value);
            logs.Logs.StartOfTest();
            logs.Logs.Info(environment.ToUpper() + " environment was selected!");
            Assert.IsTrue(driver.FindElement(By.ClassName("logo-wrapper")).Displayed);
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
