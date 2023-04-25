# Selenium Framework

Minimalist .NET framework for running *Selenium WebDriver* tests using NUnit + example.

## Features:
- Page Object Pattern
- Automatic driver management (via [WebDriverManager](https://www.nuget.org/packages/WebDriverManager))
- Cross-browser support
- Parallel test execution
- Screenshot on test failure
- Configuration using a `.runsettings` file
- Suitable for CI/CD (e.g. with [Jenkins](https://www.jenkins.io/))
- Easily extendable

## NuGet dependencies:
- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver)
- [Selenium.Support](https://www.nuget.org/packages/Selenium.Support)
- [DotNetSeleniumExtras.WaitHelpers](https://www.nuget.org/packages/DotNetSeleniumExtras.WaitHelpers)
- [WebDriverManager](https://www.nuget.org/packages/WebDriverManager)
