using System;
using OpenQA.Selenium;

namespace ADX_Regression.ControlUnit
{
    public class ScreenShots
    {
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + ".png";
            string projectPath = new Uri(actualPath).LocalPath;
            screenshot.SaveAsFile(projectPath, ScreenshotImageFormat.Png);
            return projectPath;
        }
    }
}
