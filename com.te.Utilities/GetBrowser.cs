using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ADX_Regression.ControlUnit
{
    /// <summary>
    /// <Browser>Chrome, Mozilla and Firefox</Browser>
    /// <Type>Base Class</Type>
    /// </summary>
    public class GetBrowser
    {
        public static IWebDriver driver;
        public static IWebDriver Browser(string browserName)
        {
            if(browserName.Equals("Chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.Proxy = null;
                options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                driver = new ChromeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            else if (browserName.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserName.Equals("IE"))
            {
                driver = new InternetExplorerDriver();
            }
            return driver;
            
        }

    }
}
