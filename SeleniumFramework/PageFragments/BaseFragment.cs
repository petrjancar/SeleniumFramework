using OpenQA.Selenium;

namespace SeleniumFramework.PageFragments;

public abstract class BaseFragment
{
    protected IWebDriver Driver;     

    protected BaseFragment(IWebDriver driver)
    {
        Driver = driver;
    }
}

