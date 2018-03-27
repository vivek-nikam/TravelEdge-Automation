using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADX_Regression.ControlUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ADX_Regression.CommonObjects
{
    /// <summary>
    /// <Package>com.te.commonobjects</Package>
    /// <PageObjects>Exception Handling</PageObjects>
    /// <Author>Vivek Nikam</Author>
    /// </summary>
    class Exceptions:GetBrowser
    {
        public Exceptions()
        {
            PageFactory.InitElements(driver, this);
        }
        //Exception Handling UI Elements for all the errors in the application
        [FindsBy(How = How.XPath, Using = "//div/textarea[@name = 'IssueDescription']")]
        public IWebElement IssueDescription { get; set; }

        //Error message title
        [FindsBy(How = How.XPath, Using = "//div[text() = 'An error has occurred']")]
        public IWebElement ErrorMessage_title { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class = 'text11 error-guid']")]
        public IWebElement ErrorCode { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div/div[2]/div/div/div[2]/dl/dd[2]")]
        public IWebElement ErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Send Support Request']")]
        public IWebElement SendSupportRequest { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[2]/strong")]
        public IWebElement SupportTicketNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Close')]")]
        public IWebElement Close_Exception { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@title = 'Close')]")]
        public IWebElement Close_Notification { get; set; }

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //Method to wait for a red Exception
        public void Wait_Error()
        {
            try
            {
                wait.Until(d =>
                {
                    string error = js.ExecuteScript("return document.getElementsByClassName('dashboard-title-text')[0].textContent;").ToString().ToUpper();
                    if (error == "AN ERROR HAS OCCURRED")
                    {
                        return true;
                    }
                    return false;

                });
               
            }
            catch
            {
                return;
            }

        }

        //Method to wait for a business exception
        public void Wait_Error_Business()
        {
            try
            {
                wait.Until(d =>
                {
                    string businessErrorTitle = js.ExecuteScript("document.getElementsByClassName('dashboard-title-text')[0].innerText;").ToString().ToUpper();
                    if (businessErrorTitle == "IMPORTANT INFORMATION")
                    {
                        return true;
                    }
                    return false;

                });

            }
            catch
            {
                return;
            }

        }

        //Method to wait for a business exception for insurance in Cruise Booking Page
        public void Wait_Error_Business_Cruise()
        {
            try
            {
                wait.Until(d =>
                {
                    string businessErrorTitle = js.ExecuteScript("document.getElementsByClassName('dashboard-title-text')[0].innerText;").ToString().ToUpper();
                    if (businessErrorTitle == "SAME INSURANCE COVERAGE OPTION")
                    {
                        return true;
                    }
                    return false;

                });

            }
            catch
            {
                return;
            }

        }

        //Method to Handle Notification
        public void Wait_Notification()
        {
            try
            {
                wait.Until(d =>
                {
                    string error = js.ExecuteScript("return document.getElementsByClassName('ui-pnotify-title')[0].innerText;").ToString().ToUpper();
                    if (error == "IMPORTANT INFORMATION")
                    {
                        return true;
                    }
                    return false;

                });

            }
            catch
            {
                return;
            }

        }
    }
}
