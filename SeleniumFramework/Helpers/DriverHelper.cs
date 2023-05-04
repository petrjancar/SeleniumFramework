using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumFramework.Enums;

namespace SeleniumFramework.Helpers;

public static class DriverHelper
{
    public static IWebDriver GetWebDriver()
    {
        switch (SetupHelper.Browser)
        {
            case Browser.Chrome:
                return SetupChromeDriver();
            case Browser.Firefox:
                return SetupFirefoxDriver();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static ChromeDriver SetupChromeDriver()
    {
        ChromeOptions options = new();
        options.AddAdditionalOption(CapabilityType.AcceptInsecureCertificates, true);
        if (SetupHelper.RunInHeadlessMode)
        {
            options.AddArguments("--window-size=1920, 1080");
            options.AddArguments("--start-maximized");
            options.AddArgument("--headless=new");
        }
        var driver = new ChromeDriver(options);
        if (!SetupHelper.RunInHeadlessMode)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }

    private static FirefoxDriver SetupFirefoxDriver()
    {
        FirefoxOptions options = new();
        options.AddAdditionalOption(CapabilityType.AcceptInsecureCertificates, true);
        if (SetupHelper.RunInHeadlessMode)
        {
            options.AddArguments("--window-size=1920, 1080");
            options.AddArguments("--start-maximized");
            options.AddArguments("--headless");
        }
        var driver = new FirefoxDriver(options);
        if (!SetupHelper.RunInHeadlessMode)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }
}
