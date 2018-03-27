using ADX_Regression.ControlUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ADX_Regression.CommonObjects
{
    /// <summary>
    /// <PageObject>Client/Traveler Selection</PageObject>
    /// </summary>
    class ClientSearch_TravelerSelection : GetBrowser
    {
        public ClientSearch_TravelerSelection()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "clientSearch")]
        public IWebElement ClientSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/button[@class = 'btn btn-default btn-clientsearch']")]
        public IWebElement ClientSearch_button { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[text() = 'View'])[2]")]
        public IWebElement ClientSelect_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'on-view-client']")]
        public IWebElement ClientName_Val { get; set; }

        //Object to click on for client Is Traveling
        [FindsBy(How = How.XPath, Using = "//label[@class = 'label-functional is-traveling-label']")]
        public IWebElement Is_Traveling { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name = 'Title']")]
        public IWebElement Title_Dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name = 'Title'])[2]")]
        public IWebElement Title_Dropdown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'FirstName']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'FirstName'])[2]")]
        public IWebElement FirstName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'MiddleName']")]
        public IWebElement MiddleName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'MiddleName'])[2]")]
        public IWebElement MiddleName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'LastName']")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'LastName'])[2]")]
        public IWebElement LastName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[1][@class= 'day form-control de-form-control']")]
        public IWebElement Day_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[1][@class= 'day form-control de-form-control'])[3]")]
        public IWebElement Day_DropDown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[2][@class= 'month form-control de-form-control']")]
        public IWebElement Month_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[2][@class= 'month form-control de-form-control'])[3]")]
        public IWebElement Month_DropDown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[3][@class= 'year form-control de-form-control']")]
        public IWebElement Year_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[3][@class= 'year form-control de-form-control'])[3]")]
        public IWebElement Year_DropDown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name = 'Nationality']")]
        public IWebElement Nationality_DropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name = 'Nationality'])[2]")]
        public IWebElement Nationality_DropDown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class = 'btn btn-default select-traveler'])[1]")]
        public IWebElement AssignTraveler_First { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class = 'btn btn-default select-traveler'])[2]")]
        public IWebElement AssignTraveler_Second { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Ms. Lucy  Lucy']")]
        public IWebElement SelectTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "((//label[@class = 'de-label'])/input[@name = 'IsCompanion'])[1]")]
        public IWebElement SaveCompanion2 { get; set; }

        [FindsBy(How = How.XPath, Using = "((//label[@class = 'de-label'])/input[@name = 'IsCompanion'])[3]")]
        public IWebElement SaveCompanion2_SearchResults { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name = 'CompanionRelationship'])[1]")]
        public IWebElement CompanionRelationship2 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name = 'CompanionRelationship'])[3]")]
        public IWebElement CompanionRelationship2_SearchResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Save Traveler Changes']")]
        public IWebElement SaveTraveler_TSP { get; set; }

        [FindsBy(How = How.XPath, Using = "//b[text() = 'Client and Air Service Travelers']")]
        public IWebElement AssignTraveler_Page { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text() = 'Verify Travelers Legal Names']")]
        public IWebElement VerifyTraveler_Legalnames { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'Verified'])[1]")]
        public IWebElement Verified_1 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'Verified'])[2]")]
        public IWebElement Verified_2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Continue']")]
        public IWebElement Continue { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Assign Travelers']")]
        public IWebElement AssignTravelers { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text() = 'Roberto  Cavilli']")]
        public IWebElement AssignTravelers_Checkbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Save']")]
        public IWebElement Save_AssignTravelers { get; set; }
    }
}
