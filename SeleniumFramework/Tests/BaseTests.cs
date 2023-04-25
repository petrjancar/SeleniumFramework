using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumFramework.Enums;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public abstract class BaseTests
{
    protected IWebDriver Driver;

    [SetUp]
    public void SetUp()
    {
        RunSettingsSetup();
        Driver = DriverHelper.GetWebDriver();
    }

    [TearDown]
    public void TearDown()
    {
        if (SetupHelper.TakeScreenshotOnFailedTest)
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("Taking screenshot after failed test is turned on...");
                string? fileName = ScreenshotHelper.TakeScreenshot(Driver);
                if (fileName != null)
                {
                    Console.WriteLine("Screenshot was saved as: " + fileName);
                }
            }
        }

        Driver.Quit();
    }
    
    private static void RunSettingsSetup()
    {
        string? browser = TestContext.Parameters["Browser"];
        string? headless = TestContext.Parameters["Headless"];
        string? screenshotOnFailed = TestContext.Parameters["ScreenshotOnFail"];
        string? screenshotDirectory = TestContext.Parameters["ScreenshotDir"];
        string? baseUrl = TestContext.Parameters["BaseUrl"];

        if (browser != null)
        {
            switch (browser)
            {
                case "chrome":
                    SetupHelper.Browser = Browser.Chrome;
                    break;
                case "firefox":
                    SetupHelper.Browser = Browser.Firefox;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (headless != null)
        {
            switch (headless)
            {
                case "true":
                    SetupHelper.RunInHeadlessMode = true;
                    break;
                case "false":
                    SetupHelper.RunInHeadlessMode = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (screenshotOnFailed != null)
        {
            switch (screenshotOnFailed)
            {
                case "true":
                    SetupHelper.TakeScreenshotOnFailedTest = true;
                    break;
                case "false":
                    SetupHelper.TakeScreenshotOnFailedTest = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (screenshotDirectory != null)
        {
            SetupHelper.ScreenshotDirectory = screenshotDirectory;
        }

        if (baseUrl != null)
        {
            SetupHelper.BaseUrl = baseUrl;
        }
    }
}

