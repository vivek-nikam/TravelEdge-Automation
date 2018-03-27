using ADX_Regression.ControlUnit;
using ADX_Regression.Objects;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace ADX_Regression.com.te.testcases
{
    /// <summary>
    /// <TestCase>TE_Air</TestCase>
    /// <Author>Vivek Nikam</Author>
    /// </summary>

    [TestFixture]
    class WVT_Air : ExtentReport
    {
        Air air;
        string path;
        ExcelPath excelfile = new ExcelPath();
        ExcelOps file = new ExcelOps();
        ExtentTest parentTest;

        //Initiate the Browser
        [OneTimeSetUp]
        public void Beforeclass()
        {
            Browser("IE");
        }
        
        //Agent Sign into the application
        [Test]
        public void AgentSignin()
        {
            path = excelfile.ExcelFile();
            file.PopulateInCollection(path, "Login");
            parentTest = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name).AssignCategory("Air Regression").AssignAuthor("Vivek Nikam");
            Navigate(file.ReadData(1, "URL"), childTest);
            Logintoapp(file.ReadData(1, "UserName"), file.ReadData(1, "Password"), childTest);

        }

        //Air Quote,Reprice, Book and Ticket
        [Test]
        public void Air_RoundTrip()
        {
            path = excelfile.ExcelFile();
            file.PopulateInCollection(path, "Air");
            air = new Air();
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            air.Roundtrip_Scenario1(file.ReadData(1, "From"), file.ReadData(1, "To"), file.ReadData(1, "Depart"), file.ReadData(1, "Return")
                , file.ReadData(1, "Currency"), file.ReadData(1, "Adult"), file.ReadData(1, "Gds"), file.ReadData(1, "ClientName"), childTest);
            air.Reprice_Flow(file.ReadData(1, "Title"), file.ReadData(1, "FirstName"), file.ReadData(1, "MiddleName")
                , file.ReadData(1, "LastName"), file.ReadData(1, "Day"), file.ReadData(1, "Month"), file.ReadData(1, "Year"), file.ReadData(1, "Nationality") , childTest);
            air.Book_Flow(childTest);
            file.PopulateInCollection(path, "Payment");
            air.PayFlow_Split(file.ReadData(1, "Name1"), file.ReadData(1, "Name2"), file.ReadData(1, "CreditCard"), file.ReadData(1, "ExpiryMonth"), file.ReadData(1, "ExpiryYear"),
                file.ReadData(1, "CVV"), file.ReadData(2, "Name1"), file.ReadData(2, "Name2"), file.ReadData(2, "CreditCard"), file.ReadData(2, "ExpiryMonth"), 
                file.ReadData(2, "ExpiryYear"),file.ReadData(2, "CVV"), childTest);
            
        }

        //Close the browser instance
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
        }
    }


}

