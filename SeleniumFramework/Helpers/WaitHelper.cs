using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.Helpers;

public static class WaitHelper
{
    public static IWebElement WaitForExistence(IWebDriver driver, By elementBy, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.ElementExists(elementBy));
    }

    public static IWebElement WaitForVisible(IWebDriver driver, By elementBy, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.ElementIsVisible(elementBy));
    }
    
    public static ReadOnlyCollection<IWebElement> WaitForVisibleElements(IWebDriver driver, By elementsBy, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementsBy));
    }
    
    public static IWebElement WaitForClickable(IWebDriver driver, By elementBy, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.ElementToBeClickable(elementBy));
    }
    
    public static IWebElement WaitForClickable(IWebDriver driver, IWebElement element, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public static bool WaitForInvisible(IWebDriver driver, By elementBy, int sec)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.InvisibilityOfElementLocated(elementBy));
    }

    public static bool WaitForTextToBePresent(IWebDriver driver, By elementBy, int sec, string text)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(ExpectedConditions.TextToBePresentInElementLocated(elementBy, text));
    }
    
    public static bool WaitForFileToBePresent(IWebDriver driver, int sec, string path)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until((d) => File.Exists(path));
    }
}
