namespace SeleniumFramework.Data;

public static class TodoListName
{
    public static string GenerateName()
    {
        var name = Guid.NewGuid().ToString();
        Console.WriteLine("Generated todo list name: " + name);
        return name;
    }
}
