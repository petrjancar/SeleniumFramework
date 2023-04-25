using SeleniumFramework.Data;
using SeleniumFramework.PageObjects;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TodoTests : BaseTests
{
    [Test]
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
}

// How to run with custom .runsettings
// -----------------------------------
// 1) cd SeleniumFramework/
// 2) dotnet test SeleniumFramework.csproj -s RunSettings/Default.runsettings