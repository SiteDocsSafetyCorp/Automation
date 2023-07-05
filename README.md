<!-- ABOUT THE PROJECT -->
## About The Project

Automation selenium project contains all of our automated tests that is stored and constructed as individual and independent modules.

### Built With

* [C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/): is the chosen language that is used to develop the test scripts as well as the core reusable functions for the entire project
* [Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/): is a web automation framework that allows you to execute your tests against different browsers
* [NUnit](https://nunit.org/): is an automation testing framework that is used for all .Net languages.
* [Allure](https://qameta.io/allure-report/): is a flexible, lightweight multi-language test reporting tool.

<!-- GETTING STARTED -->
## Getting Started


### Prerequisites

* [Install Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
* [Install Git](https://git-scm.com/downloads)
* [Install Allure Report](https://docs.qameta.io/allure/)

### Getting Started
* Install Git in your local machine
* Open terminal and type 'git clone https://github.com/lorikSiteDocs/SiteDocsAutomationProject.git' 
* After clone is done you can open project with Visual Studio or click on "SiteDocsAutomationProject.sln" file
* All Tests within the project using annotation [TEST] will be listed in Test Explorer

### Local Setup 
* `runType="local"`
    * Choose between:
      * `local` - This will run your tests in the browser using your local WebDriver
      * `remote` - This will run your tests using the browserstack remote driver
    * Default if not set:  `docker`
* `environment="stage"`
    * Choose between `prod`, `stage`, and `dev` 
    * Default if not set: `stage`
* To run all tests from Developer PowerShell use this command "dotnet test" 
* To run tests with specific category use this command "dotnet test --filter Category=LoginTest"
* After running first test, allure-results folder will be created with test results
* To run allure report from cmd use this command "allure serve bin\Debug\net6.0\allure-results"

### Note for browserstack 
* Update userName and accessKey in browserstack.yml with your credentials
* Remove other OS than Chrome so it won't take to long to run tests locally

<!-- CONTACT -->
## Contact

[Lorik Halili](mailto:lorik@sitedocs.com)
