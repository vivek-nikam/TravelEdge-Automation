using ADX_Regression.ControlUnit;
using ADX_Regression.Objects;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace ADX_Regression.com.te.testcases
{
    /// <summary>
    /// <TestCase>TE_Hotel</TestCase>
    /// <Author>Vivek Nikam</Author>
    /// </summary>
    [TestFixture]
    class WVT_Hotel : ExtentReport
    {
        Hotel hotel;
        string path;
        ExcelPath excelfile = new ExcelPath();
        ExcelOps file = new ExcelOps();
        ExtentTest parentTest;

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
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name).AssignCategory("Hotel Regression").AssignAuthor("Vivek Nikam");
            Navigate(file.ReadData(1, "URL"), childTest);
            Logintoapp(file.ReadData(1, "UserName"), file.ReadData(1, "Password"), childTest);
        }

        //Test Case to Search for a hotel by Destination
        [Test]
        public void HotelSearch()
        {
            hotel = new Hotel();
            path = excelfile.ExcelFile();
            file.PopulateInCollection(path, "Hotel");
            //Creating a Node under the Class Name in Extent Report
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string keyword = file.ReadData(1, "KeyWords");
            string exe = file.ReadData(1, "Execution");
            //Performs the Test Case only if the keywords exist in the Excel Sheet and Execution Status is Yes else it closes the browser
            if(keyword.Equals("Hotel_Search") && exe.Equals("Yes"))
            {
                hotel.Hotel_Search(file.ReadData(1, "Destination"), file.ReadData(1, "Checkin"), file.ReadData(1, "CheckOut"), file.ReadData(1, "Adults"), 
                    file.ReadData(1, "Child"),file.ReadData(1,"ChildAge"), file.ReadData(1, "HotelChains"), childTest);
            }
            else
            {
                driver.Close();
            }
        }

        //Test Case to Validate the Search results Page
        [Test]
        public void HotelSearchPage()
        {
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string keyword = file.ReadData(2, "KeyWords");
            string exe = file.ReadData(2, "Execution");
            if(keyword.Equals("SearchPagePriceFilter") && exe.Equals("Yes"))
            {
                hotel.SearchPagePriceFilter(childTest);
            }
            else
            {
                return;
            }
            string keyword_prop = file.ReadData(3, "KeyWords");
            string exe_prop = file.ReadData(3, "Execution");
            if (keyword_prop.Equals("PropertyNameFilter") && exe_prop.Equals("Yes"))
            {
                hotel.PropertyNameFilter(childTest);
            }
            else
            {
                return;
            }
            string rating = file.ReadData(4, "KeyWords");
            string exe_rating = file.ReadData(4, "Execution");
            if (rating.Equals("RatingFilter") && exe_rating.Equals("Yes"))
            {
                hotel.RatingFilter(childTest);
            }
            else
            {
                return;
            }
            string distance_Filter = file.ReadData(5, "KeyWords");
            string exe_Distance = file.ReadData(5, "Execution");
            if (distance_Filter.Equals("DistanceFilter") && exe_Distance.Equals("Yes"))
            {
                hotel.DistanceFilter(childTest);
            }
            else
            {
                return;
            }
        }

        //Test Case to Shortlist the Hotels
        [Test]
        public void HotelShortList()
        {
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string shortlist = file.ReadData(6, "KeyWords");
            string exe_shortlist = file.ReadData(6, "Execution");
            if (shortlist.Equals("ShortlistHotel") && exe_shortlist.Equals("Yes"))
            {
                hotel.ShortlistHotel(childTest);
            }
            else
            {
                return;
            }
        }

        //Test Case to Assert on the Property Details Page
        [Test]
        public void PropertyDetailsPage()
        {
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string select_Hotel = file.ReadData(7, "KeyWords");
            string exe_SelectHotel = file.ReadData(7, "Execution");
            if (select_Hotel.Equals("SelectHotel") && exe_SelectHotel.Equals("Yes"))
            {
                hotel.SelectHotel(childTest);
            }
            else
            {
                return;
            }
            string propertyDetails = file.ReadData(8, "KeyWords");
            string exe_propertyDetails = file.ReadData(8, "Execution");
            if(propertyDetails.Equals("PropertyDetailsPage") && exe_propertyDetails.Equals("Yes"))
            {
                hotel.PropertyDetailsPage(childTest);
            }
            else
            {
                return;
            }
            string avgRatePerNight = file.ReadData(9, "KeyWords");
            string exe_avgRatePerNight = file.ReadData(9, "Execution");
            if (avgRatePerNight.Equals("AvgRatePerNight") && exe_avgRatePerNight.Equals("Yes"))
            {
                hotel.AvgRatePerNight(childTest);
            }
            else
            {
                return;
            }
            string totalPriceFilter = file.ReadData(10, "KeyWords");
            string exe_totalPriceFilter = file.ReadData(10, "Execution");
            if (totalPriceFilter.Equals("TotalPriceFilter") && exe_totalPriceFilter.Equals("Yes"))
            {
                hotel.TotalPriceFilter(childTest);
            }
            else
            {
                return;
            }
            string RateNameDropDown = file.ReadData(11, "KeyWords");
            string exe_RateNameDropDown = file.ReadData(11, "Execution");
            if (RateNameDropDown.Equals("RateNameDropDown") && exe_RateNameDropDown.Equals("Yes"))
            {
                hotel.RateNameDropDown(childTest);
            }
            else
            {
                return;
            }
            string Select_Rate = file.ReadData(12, "KeyWords");
            string exe_Select_Rate = file.ReadData(12, "Execution");
            if (Select_Rate.Equals("Select_Rate") && exe_Select_Rate.Equals("Yes"))
            {
                hotel.Select_Rate(childTest);
            }
            else
            {
                return;
            }
        }

        //Test Case to add another Hotel to the Same flow and Quote All in 4.2
        [Test]
        public void QuoteAll()
        {
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string AddHotel = file.ReadData(13, "KeyWords");
            string exe_AddHotel = file.ReadData(13, "Execution");
            if (AddHotel.Equals("AddHotel") && exe_AddHotel.Equals("Yes"))
            {
                hotel.AddHotel(file.ReadData(2, "Destination"), file.ReadData(1, "Nights"), file.ReadData(2, "Adults"),childTest);
            }
            else
            {
                return;
            }
        }

        //Test CAse to assign client/Traveler in TSP
        [Test]
        public void TSP()
        {
            childTest = parentTest.CreateNode(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string AddClient = file.ReadData(14, "KeyWords");
            string exe_AddClient = file.ReadData(14, "Execution");
            if (AddClient.Equals("AddClient") && exe_AddClient.Equals("Yes"))
            {
                hotel.AddClient(file.ReadData(1,"ClientName"),childTest);
            }
            else
            {
                return;
            }
            string Book_Hotel_2 = file.ReadData(15, "KeyWords");
            string exe_Book_Hotel_2 = file.ReadData(15, "Execution");
            if (Book_Hotel_2.Equals("Book_Hotel_2") && exe_Book_Hotel_2.Equals("Yes"))
            {
                file.PopulateInCollection(path, "Payment");
                hotel.Book_Hotel_2(file.ReadData(1, "Name1"), file.ReadData(1, "Name2"), file.ReadData(1, "CreditCard"), file.ReadData(1, "ExpiryMonth"), 
                    file.ReadData(1, "ExpiryYear"), file.ReadData(1, "CVV"), childTest);
            }
            else
            {
                return;
            }
        }

        //Browser and ChromeDriver Instance Close
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            //driver.Close();
            driver.Dispose();
        }

    }


       
}
