using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.PageObjects;

public class TodoMainPage : BasePage
{
    private By ManageTodoListsLinkBy = By.Id("accesstodolists");

    public TodoMainPage(IWebDriver driver) : base(driver)
    {
        Url = SetupHelper.BaseUrl;
    }

    public void ClickManageTodoListsLink()
    {
        var link = WaitHelper.WaitForClickable(Driver, ManageTodoListsLinkBy, TimeoutHelper.MidTimeout);
        link.Click();
    }
}
