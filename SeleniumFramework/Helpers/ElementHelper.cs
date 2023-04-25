using OpenQA.Selenium;

namespace SeleniumFramework.Helpers;

public static class ElementHelper
{
    public static bool HasClass(IWebElement element, string classStr)
    {
        string classes = element.GetAttribute("class");
        foreach (string c in classes.Split(" "))
        {
            if (c.Equals(classStr))
            {
                return true;
            }
        }
        return false;
    }
}
