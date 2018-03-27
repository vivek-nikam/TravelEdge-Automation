using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ADX_Regression.CommonObjects;
using ADX_Regression.Objects;
using OpenQA.Selenium;
using System.Threading;

namespace ADX_Regression.ControlUnit
{
    /// <summary>
    /// <Report>Extent Html Report</Report>
    /// <Version>3.0</Version>
    /// </summary>
    [TestFixture]
    public class ExtentReport : GetBrowser
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;
        public static ExtentTest childTest;
        Login login;
        

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Reports\\" + GetDateTime() + "TravelEdge.html";
            htmlReporter = new ExtentHtmlReporter(@reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("OS", "Windows 10");
            extent.AddSystemInfo("Host Name", "ADX");
            extent.AddSystemInfo("Environment", "UAT");
            extent.AddSystemInfo("User Name", "Vivek Nikam");
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;
            htmlReporter.Configuration().DocumentTitle = "ADX Automation";
            htmlReporter.Configuration().ReportName = "ADX Report";
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().CSS = "css-string";
            htmlReporter.Configuration().JS = "js-string";

            var parentTest = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        }

        //Generic Test Case to Validate the URL and Sign In Page
        public void Navigate(String url, ExtentTest test)
        {
            login = new Login();
            driver.Url = url;
            test.Log(Status.Info, "Launched the application successfully");
            try
            {
                Assert.That(login.Signin_conf.Text, Is.EqualTo("Agent Sign In"));
                test.Log(Status.Pass, "Sign-in Page");
            }
            catch
            {
                test.Log(Status.Fail, "Signed into a different application");
            }
        }

        //Generic Test Case to validate the HomePage
        public void Logintoapp(String username, String password, ExtentTest test)
        {
            Exceptions _exceptions = new Exceptions();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            login.LoginToApp(username, password);
            test.Log(Status.Info, "Entered username and password");
            try
            {
                String currentUrl = driver.Url;
                Assert.That(currentUrl, Is.EqualTo("http://adx.uat.te.tld/"));
                test.Log(Status.Pass, "UAT DashboardPage");
            }
            catch
            {
                _exceptions.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Unhandled Exception occured when logged into the application", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                _exceptions.Close_Exception.Click();
                js.ExecuteScript("arguments[0].click();", _exceptions.Close_Exception);
            }
            test.Log(Status.Pass, "Successfully logged into the application");

        }
        
        public static String GetDateTime()
        {

            // Create object of SimpleDateFormat class and decide the format
            String dateFormat = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            String currentDate = dateFormat.Replace(':', '_');

            return currentDate;

        }

        public void Extent(string categoryName, string authorName)
        {
            var parentTest = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name).AssignCategory(categoryName).AssignAuthor(authorName);
        }
        [TearDown]
        public void GetResult()
        {
            TestStatus s = TestContext.CurrentContext.Result.Outcome.Status;

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            switch (status)
            {
                case TestStatus.Failed:
                    childTest.Log(Status.Fail, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test case FAILED please review:", ExtentColor.Red));
                    childTest.Fail(TestContext.CurrentContext.Result.Message);
                    string screenShotPath = ScreenShots.Capture(GetBrowser.driver, GetDateTime());
                    childTest.Log(Status.Fail, stackTrace + errorMessage);
                    childTest.Log(Status.Fail, "ScreenShot below: " + childTest.AddScreenCaptureFromPath(screenShotPath));
                    break;

                case TestStatus.Passed:
                    childTest.Log(Status.Pass, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test Case PASSED", ExtentColor.Green));
                    break;

                case TestStatus.Skipped:
                    childTest.Log(Status.Skip, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test Case SKIPPED", ExtentColor.Orange));
                    childTest.Skip(TestContext.CurrentContext.Test.FullName);
                    break;
            }
        }
        [OneTimeTearDown]
        public void EndReport()
        {
            //Flush all status into Report
            extent.Flush();

        }

    }

}

