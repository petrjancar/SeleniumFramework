using SeleniumFramework.Data;
using SeleniumFramework.PageObjects;
using SeleniumFramework.Enums;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TodoTests : BaseTests
{
    [Test]
    [Category(Category.Smoke)]
    public void CreateTodoListTest()
    {
        // Arrange
        var todoListName = TodoListName.GenerateName();

        // Act
        var todoMainPage = new TodoMainPage(Driver);
        todoMainPage.Navigate();
        todoMainPage.ClickManageTodoListsLink();

        var todoListsManagementPage = new TodoListsManagementPage(Driver);
        todoListsManagementPage.CreateNewTodoList(todoListName);

        // Assert
        Assert.That(todoListsManagementPage.TodoListExists(todoListName), Is.True);
    }

    [Test]
    [Category(Category.Smoke)]
    public void H1BackgroundTest()
    {
        // Act
        var todoMainPage = new TodoMainPage(Driver);
        todoMainPage.Navigate();
        todoMainPage.ClickManageTodoListsLink();

        var todoListsManagementPage = new TodoListsManagementPage(Driver);

        // Assert
        Assert.That(Helpers.ColorHelper.FromString(
            todoListsManagementPage.H1BackgroundColor()),
            Is.EqualTo(Helpers.ColorHelper.FromString("#B4B6AA")));
    }
}


// How to run with custom .runsettings
// -----------------------------------
// 1) cd SeleniumFramework/
// 2) dotnet test SeleniumFramework.csproj -s RunSettings/Default.runsettings


// How to run tagged tests (i.e. "Smoke")
// --------------------------------------
// 1) cd SeleniumFramework/
// 2) dotnet test --filter "TestCategory=Smoke"
