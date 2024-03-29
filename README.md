# Selenium Framework

Minimalist .NET framework for running *Selenium WebDriver* tests using NUnit + example.

## Features:
- Page Object Pattern
- Automatic driver management (via ~~WebDriverManager~~ Selenium Manager)
- Cross-browser support
- Parallel test execution
- Screenshot on a test failure
- Configuration using a `.runsettings` file
- Suitable for a CI/CD (e.g. with [Jenkins](https://www.jenkins.io/))
- Debugging support class that allows to highlight a web element or show a notification
- Easily extendable

## NuGet dependencies:
- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver)
- [Selenium.Support](https://www.nuget.org/packages/Selenium.Support)
- [DotNetSeleniumExtras.WaitHelpers](https://www.nuget.org/packages/DotNetSeleniumExtras.WaitHelpers)
