using OpenQA.Selenium;

namespace SeleniumFramework.Helpers;

public static class DebugHelper
{
    public static void Highlight(IWebDriver driver, IWebElement element, int sec = 3)
    {
        var originalStyle = element.GetAttribute("style");
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        
        js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", 
            element,
            "style", "border: 3px solid red; border-style: dashed;");
        
        Thread.Sleep(sec * 1000);
        
        js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", 
            element, "style", 
            originalStyle);
    }

    public static void ShowNotification(IWebDriver driver, string message, int sec = 3)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        js.ExecuteScript($"alertFun = function () {{ notie.alert({{type: 'info', text: '{message}', time: {sec} }}) }};");

        js.ExecuteScript(@"
            var toastrCss = document.createElement('link'); toastrCss.rel = 'stylesheet';
            toastrCss.type = 'text/css';
            toastrCss.href = 'https://unpkg.com/notie/dist/notie.min.css';
            document.getElementsByTagName('head')[0].appendChild(toastrCss);
            "
        );

        js.ExecuteScript(@"
            var toastrJs = document.createElement('script'); 
            toastrJs.type = 'text/javascript';
            toastrJs.src = 'https://unpkg.com/notie';
            toastrJs.onload = alertFun;
            document.getElementsByTagName('head')[0].appendChild(toastrJs);
            ");

        Thread.Sleep((sec  * 1000) + 1000);
    }
}
