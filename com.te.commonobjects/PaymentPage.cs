using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADX_Regression.ControlUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ADX_Regression.CommonObjects
{
    class PaymentPage : GetBrowser
    {
        public PaymentPage()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Ticket Flight']")]
        public IWebElement TicketFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Pay All']")]
        public IWebElement PayAll { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[text() = 'Itinerary Payment']")]
        public IWebElement PaymentPage_Val { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@role = 'tab'])[2]")]
        public IWebElement AddCreditCard { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class = 'btn btn-default partial-btn active']")]
        public IWebElement PartialPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@class = 'assign-traveler'])[2]")]
        public IWebElement Uncheck_Split_Check { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class = 'payableAmount']")]
        public IWebElement PayableAmount { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div/div[2]/input[@id = 'firstName'])[2]")]
        public IWebElement FirstName1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'LastName']")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'LastName'])[2]")]
        public IWebElement LastName1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'CreditCardNumber']")]
        public IWebElement CreditCardNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'CreditCardNumber'])[2]")]
        public IWebElement CreditCardNumber1 { get; set; }

        [FindsBy(How = How.Id, Using = "month")]
        public IWebElement Month_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@id = 'month'])[2]")]
        public IWebElement Month_DropDown1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name = 'Year']")]
        public IWebElement Year_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name = 'Year'])[2]")]
        public IWebElement Year_DropDown1 { get; set; }

        [FindsBy(How = How.Id, Using = "verificationCode")]
        public IWebElement Cvv { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@id = 'verificationCode'])[2]")]
        public IWebElement Cvv1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'check-billing-address']")]
        public IWebElement Check_BillingAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@class = 'check-billing-address'])[2]")]
        public IWebElement Check_BillingAddress1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'accept-toc-checkbox']")]
        public IWebElement Check_Terms_Conditions { get; set; }

        [FindsBy(How = How.Id, Using = "payAndTicket")]
        public IWebElement Payment_Button { get; set; }

        [FindsBy(How = How.Id, Using = "pay")]
        public IWebElement ProcessTransaction { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = '« Back to Trip Services']")]
        public IWebElement Back_TSP { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text() = 'travel-ready']")]
        public IWebElement Tsp_Status { get; set; }
    }

    
}
