using OpenQA.Selenium;

namespace Framework._Task_1.Helpers
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(path + ".png");
        }
    }

}
