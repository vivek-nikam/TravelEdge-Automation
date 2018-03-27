using ADX_Regression.ControlUnit;
using ADX_Regression.Objects;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace ADX_Regression.Showdown
{
    /// <summary>
    /// <TestCase>TE_Cruise</TestCase>
    /// <Author>Vivek Nikam</Author>
    /// </summary>

    [TestFixture]
    class WVT_Cruise : ExtentReport
    {
        Cruise cruise;
        ExtentTest parentTest;
        string path;
        ExcelPath excelfile = new ExcelPath();
        ExcelOps file = new ExcelOps();

        //Initiate the browser
        [OneTimeSetUp]
        public void Beforeclass()
        {

            Browser("Chrome");

        }
        
        //Test Case to Sign into the Application
        [Test]
        public void AgentSignin()
        {
            path = excelfile.ExcelFile();
            file.PopulateInCollection(path, "Login");
            parentTest = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name).AssignCategory("Cruise Regression").AssignAuthor("Vivek Nikam");
            Navigate(file.ReadData(1, "URL"), childTest);
            Logintoapp(file.ReadData(1, "UserName"), file.ReadData(1, "Password"), childTest);

        }
        
        //Test Case to Enter the Search Criteria and Select the Cruise and validate View Details Page of Cruise
        [Test]
        public void Cruise_Search()
        {
            cruise = new Cruise();
            path = excelfile.ExcelFile();
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            file.PopulateInCollection(path, "Cruise");
            string keyword = file.ReadData(1, "CruiseKey");
            string exe = file.ReadData(1, "CruiseExe");
            if (keyword.Equals("Cruise_Scenario1") && exe.Equals("Yes"))
            {
                cruise.Cruise_Scenario1(file.ReadData(1, "Destination"), file.ReadData(1, "SailingFrom"), file.ReadData(1, "SailingTo"), file.ReadData(1, "SaveSearch"), file.ReadData(3, "FareCodes"), childTest);
            }
            else
            {
                return;
            }
        }
        
        //Test Case to book Cruise
        [Test]
        public void Cruise_TSP()
        {
            path = excelfile.ExcelFile();
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string keyword = file.ReadData(2, "CruiseKey");
            string exe = file.ReadData(2, "CruiseExe");
            if (keyword.Equals("Cruise_Book") && exe.Equals("Yes"))
            {
                cruise.Cruise_Book(file.ReadData(1, "ClientName"), file.ReadData(2, "Title"), file.ReadData(2, "FirstName"), file.ReadData(2, "MiddleName"), file.ReadData(2, "LastName"),
                file.ReadData(2, "Day"), file.ReadData(2, "Month"), file.ReadData(2, "Year"), file.ReadData(2, "Nationality"), file.ReadData(1, "CompanionRelationship"),
                file.ReadData(1, "Seating"), file.ReadData(1, "TableSize"), file.ReadData(1, "NationalityBook"), childTest);

            }
            else
            {
                return;
            }
        }

        //Close the Browser Instance
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}

