using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.PageObjects;

public class TodoListsManagementPage : BasePage
{
    private By NewTodoListInputBy = By.ClassName("new-todo-list");
    private By H1By = By.TagName("h1");

    private class TodoListsTableRowFragment
    {
        private IWebDriver Driver;
        private int NthList;
        private string? ListName = null;
        public bool Exists => TableRow != null;
        private By TableBy = By.CssSelector(".todo-list-list");
        private By TableRowBy = By.CssSelector(".todo-list-list li");
        private By UseButtonBy => By.CssSelector(".view a");
        private IWebElement? TableRow => ListName != null ? Driver.FindElements(TableRowBy).
            FirstOrDefault(p => p.FindElement(By.CssSelector(".view label")).Text == ListName) : 
            Driver.FindElements(TableRowBy)[NthList];
        private IWebElement? UseButton => TableRow?.FindElement(UseButtonBy);

        public TodoListsTableRowFragment(IWebDriver driver, int nthList)
        {
            Driver = driver;
            NthList = nthList;
            WaitHelper.WaitForVisible(Driver, TableBy, TimeoutHelper.MidTimeout);
        }

        public TodoListsTableRowFragment(IWebDriver driver, string listName)
        {
            Driver = driver;
            ListName = listName;
            WaitHelper.WaitForVisible(Driver, TableBy, TimeoutHelper.MidTimeout);
        }

        public void ClickUseButton()
        {
            var button = WaitHelper.WaitForClickable(Driver, UseButton, TimeoutHelper.MidTimeout);
            button.Click();
        }
    }

    public TodoListsManagementPage(IWebDriver driver) : base(driver)
    {
        Url = SetupHelper.BaseUrl + "todolists.html/";
    }

    public void CreateNewTodoList(string todoListName)
    {
        var input = WaitHelper.WaitForClickable(Driver, NewTodoListInputBy, TimeoutHelper.MidTimeout);
        input.SendKeys(todoListName);
        input.SendKeys(Keys.Enter);
    }

    public bool TodoListExists(string todoListName)
    {
        var tableRowFragment = new TodoListsTableRowFragment(Driver, todoListName);
        return tableRowFragment.Exists;
    }

    public void UseTodoList(string todoListName)
    {
        var tableRowFragment = new TodoListsTableRowFragment(Driver, todoListName);
        tableRowFragment.ClickUseButton();
    }
    
    public string H1BackgroundColor()
    {
        var h1 = WaitHelper.WaitForVisible(Driver, H1By, TimeoutHelper.MidTimeout);
        return h1.GetCssValue("background-color");
    }
}
