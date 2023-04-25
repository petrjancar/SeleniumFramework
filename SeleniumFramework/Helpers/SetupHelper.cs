using SeleniumFramework.Enums;

namespace SeleniumFramework.Helpers;

public static class SetupHelper
{
    public static Browser Browser { get; set; } = Browser.Chrome;
    public static bool RunInHeadlessMode { get; set; } = true;
    public static bool TakeScreenshotOnFailedTest { get; set; } = true;
    public static string ScreenshotDirectory { get; set; } = "C:\\Screenshots";
    public static string BaseUrl { get; set; } = "https://eviltester.github.io/simpletodolist/";
}
