using OpenQA.Selenium;

namespace SeleniumFramework.Helpers;

public static class ScreenshotHelper
{
    public static string? TakeScreenshot(IWebDriver driver, string? prefix = null)
    {
        Console.WriteLine("Taking screenshot...");
        string? fileName = null;

        try
        {
            Directory.CreateDirectory(SetupHelper.ScreenshotDirectory);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            if (prefix != null)
            {
                fileName = SetupHelper.ScreenshotDirectory + @"/" + prefix + "_" + TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".png";
            }
            else
            {
                fileName = SetupHelper.ScreenshotDirectory + @"/" + TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".png";
            }
            fileName = fileName.Replace("\"", "");
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot successful!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Screenshot unsuccessful!: " + e.Message);
        }

        return fileName;
    }
}
