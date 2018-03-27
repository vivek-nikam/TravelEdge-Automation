using ADX_Regression.ControlUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace ADX_Regression.CommonObjects
{
    class Login : GetBrowser
    {
        //Login class for Travelex
        public Login()
        {            
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//*[text()='Agent Sign In']")]
        public IWebElement Signin_conf { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement Agentid { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Agentpwd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Sign in']")]
        public IWebElement Signin { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Close']")]
        public IWebElement Close_Exception { get; set; }

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        public void LoginToApp(string username, string password)
        {
            WaitMethods w = new WaitMethods();
            w.ExecuteJavaScript("document.readyState");
            w.Login_Wait();
            Agentid.SendKeys(username);
            Agentpwd.SendKeys(password);
            Actions action = new Actions(driver);
            action.MoveToElement(Signin).Perform();
            Signin.Click();
            w.Wait(By.XPath("(//div[@class = 'dashboard-title-text'])[1]"));
            
        }
        
    }
}
