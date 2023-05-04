using OpenQA.Selenium;

namespace SeleniumFramework.PageObjects;

public abstract class BasePage
{
    protected IWebDriver Driver;
    public string? Url = null;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
    
    public void Navigate()
    {
        if (Url == null)
        {
            throw new NullReferenceException("Url was null.");
        }
        
        Driver.Navigate().GoToUrl(Url);
    }      
}
