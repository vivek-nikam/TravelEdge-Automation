using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ADX_Regression.CommonObjects;
using ADX_Regression.ControlUnit;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ADX_Regression.Objects
{
    class Air : ExtentReport //Extending Browser class
    {
        //COntstructor to Initialise the elements
        public Air()
        {
            PageFactory.InitElements(driver, this);
        }
        //Common Object of WaitMethods Class
        WaitMethods w = new WaitMethods();

        //WebElement to Click on Air Tab In Dashboard Page
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'dashboard-title-text'])[1]")]
        public IWebElement Air_val_click { get; set; }

        //Button to select round trip flight
        [FindsBy(How = How.XPath, Using = "//label[@class = 'btn btn-default label-normal round-trip-label']")]
        public IWebElement Roundtrip { get; set; }

        //Button to select one way flight
        [FindsBy(How = How.XPath, Using = "//label[@class = 'btn btn-default label-normal one-way-label']")]
        public IWebElement Oneway { get; set; }

        //Button to select multi city flight
        [FindsBy(How = How.XPath, Using = "btn btn-default label-normal multi-city-label")]
        public IWebElement Multicity { get; set; }

        //Button to open traveler selection drop down
        [FindsBy(How = How.XPath, Using = "(//*[@type = 'button'])[2]")]
        public IWebElement Traveler_selection { get; set; }

        //Drop down to select Adults
        [FindsBy(How = How.XPath, Using = "//*[@name = 'adult-count']")]
        public IWebElement Adults_count { get; set; }

        //Drop down to select children
        [FindsBy(How = How.XPath, Using = "//*[@name = 'child-count']")]
        public IWebElement Child_count { get; set; }

        //Drop down to select Infant
        [FindsBy(How = How.XPath, Using = "//*[@name = 'infant-count']")]
        public IWebElement Infant_count { get; set; }

        //Drop down to select Lap Infant
        [FindsBy(How = How.XPath, Using = "//*[@name = 'lap-infant-count']")]
        public IWebElement Lapinfant_count { get; set; }

        //Object to select From destination
        [FindsBy(How = How.Id, Using = "airport-from-1")]
        public IWebElement From_dest { get; set; }

        //Object to select To destination
        [FindsBy(How = How.Name, Using = "airport-to-1")]
        public IWebElement To_dest { get; set; }

        //Object to Include NearBy Airports for From destination
        [FindsBy(How = How.XPath, Using = "//*[@name = 'include-nearby-from-airports']")]
        public IWebElement From_nearbyairports { get; set; }

        //Object to Include NearBy Airports for To destination
        [FindsBy(How = How.XPath, Using = "//*[@name = 'include-nearby-to-airports']")]
        public IWebElement To_nearbyairports { get; set; }

        //Date Picker for Departure
        [FindsBy(How = How.XPath, Using = "//*[@name = 'date-1']")]
        public IWebElement Depart_date { get; set; }

        //Date Picker for Arrival
        [FindsBy(How = How.XPath, Using = "//*[@name = 'date-2']")]
        public IWebElement Return_date { get; set; }

        //Drop down to select the cabin for From destination
        [FindsBy(How = How.XPath, Using = "//*[@name = 'cabin-1']")]
        public IWebElement Cabin_1 { get; set; }

        //Drop down to select the cabin for To destination
        [FindsBy(How = How.XPath, Using = "//*[@name = 'cabin-2']")]
        public IWebElement Cabin_2 { get; set; }

        //Object to add the route via for From destination
        [FindsBy(How = How.Name, Using = "via-route-1")]
        public IWebElement Routevia_1 { get; set; }

        //Object to add the route via for To destination
        [FindsBy(How = How.Name, Using = "via-route-2")]
        public IWebElement Routevia_2 { get; set; }

        //Object to add the Airlines and Alliances
        [FindsBy(How = How.XPath, Using = "//*[@class = 'form-control de-form-control airline-typeahead tt-input']")]
        public IWebElement Airlines_alliances { get; set; }

        //Radio button to Include Airlines and Alliances
        [FindsBy(How = How.XPath, Using = "(//*[@type = 'radio'])[@value = 'include']")]
        public IWebElement Airlines_alliances_include { get; set; }

        //Radio button to Exclude Airlines and Alliances
        [FindsBy(How = How.XPath, Using = "(//*[@type = 'radio'])[@value = 'exclude']")]
        public IWebElement Airlines_alliances_exclude { get; set; }

        //Hyperlink to See Preferred List
        [FindsBy(How = How.XPath, Using = "//*[text() = 'See preferred list']")]
        public IWebElement See_preferred_list { get; set; }

        //Drop down to select Fare options
        [FindsBy(How = How.Name, Using = "air-fare-type")]
        public IWebElement Fare_options { get; set; }

        //Drop down to select the stops
        [FindsBy(How = How.Name, Using = "air-stops-count")]
        public IWebElement Stops { get; set; }

        //Drop down to select the inventory source
        [FindsBy(How = How.Name, Using = "inventory-source")]
        public IWebElement Inventory_source { get; set; }

        //Drop down to select the quote owner
        [FindsBy(How = How.Name, Using = "air-quote-owner")]
        public IWebElement Quote_owner { get; set; }

        //Drop down to select the currency
        [FindsBy(How = How.Name, Using = "air-currency-type")]
        public IWebElement Currency { get; set; }

        //Button to Save Search
        [FindsBy(How = How.XPath, Using = "//*[@class = 'btn btn-default btn-save-air-search']")]
        public IWebElement Save_search { get; set; }

        //Hyperlink to open saved searches
        [FindsBy(How = How.XPath, Using = "//*[@class = 'on-view-saved-searches-summary de-link']")]
        public IWebElement View_savedsearch { get; set; }

        //Object to select from Saved Searches under the drop down "View Saved and Previous Searches"
        [FindsBy(How = How.XPath, Using = "(//*[@class = 'perform-saved-search'])[1]")]
        public IWebElement Select_savedsearch { get; set; }

        //Object to open all the Saved Searches
        [FindsBy(How = How.Name, Using = "//*[@class = 'btn btn-default btn-all-saved-searches']")]
        public IWebElement Open_allsavedsearch { get; set; }

        //Object to click on the tab saved Searches in the "Previous/Saved Searches" widget
        [FindsBy(How = How.XPath, Using = "//a[@href = '#savedSearchesTab']")]
        public IWebElement Savedsearches { get; set; }

        //Button to click on and is common for Saved Searches and Previous Searches
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'btn btn-primary btn-perform-saved-search'])[1]")]
        public IWebElement Search_Savedsearch_Previoussearches { get; set; }

        //Object to delete the Saved Search
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'fa fa-trash-o delete-saved-search'])[1]")]
        public IWebElement Delete_Savedsearch { get; set; }

        //Object to click on to view then Previous Searches
        [FindsBy(How = How.XPath, Using = "//a[@href = '#previousSearchesTab']")]
        public IWebElement Previoussearches { get; set; }

        //Object to close saved search
        [FindsBy(How = How.XPath, Using = "//button[@class = 'close']")]
        public IWebElement Close_Savedsearch { get; set; }

        //Button to Search for flights
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-primary btn-search-airfare']")]
        public IWebElement Search { get; set; }

        //Title of Search Results Page used for validation
        [FindsBy(How = How.XPath, Using = "//div/h1[text() = 'Flight Search Results']")]
        public IWebElement Search_Results_val { get; set; }

        //Object to select the pagination
        [FindsBy(How = How.XPath, Using = "//select[@class = 'per-page on-per-page form-control']")]
        public IWebElement Pagination_Select { get; set; }

        //Object to filter based on Airline Names
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[2]")]
        public IWebElement Airline_filter { get; set; }

        //Checkbox inside Airline Filter to Select all
        [FindsBy(How = How.XPath, Using = "//input[@class = 'select-all-airlines']")]
        public IWebElement Select_all { get; set; }

        //Checkbox to select or deselect the particular Airline - Update the Value to choose a different flight
        [FindsBy(How = How.XPath, Using = "//input[@value = 'AA']")]
        public IWebElement Flight_select { get; set; }

        //Assert the Airline filter
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-1 col-md-1 air-column air-airline-column air-airline-column-inner'])[1]")]
        public IWebElement Airline_Assert { get; set; }

        //To Add the Outbound Flights
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Add'])[1]")]
        public IWebElement Airline_add { get; set; }

        //Object to Assert the Outbound flight- It is generic
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-1'])[1]")]
        public IWebElement Outbound_Air { get; set; }

        //Object to Assert the Price Summary Page title
        [FindsBy(How = How.XPath, Using = "//h1[text() = 'Selected Flights']")]
        public IWebElement PriceSummaryPage { get; set; }

        //Object to GetText and Assert the Airline Price before Reprice
        [FindsBy(How = How.XPath, Using = "//span[@class = 'airSearchTabTitle']")]
        public IWebElement PriceofAirline { get; set; }

        //Button to cancel in price summary page
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Cancel']")]
        public IWebElement Cancel_PriceSummaryPage { get; set; }

        //Button to Quote in Price Summary Page
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Quote']")]
        public IWebElement Quote_PriceSummaryPage { get; set; }

        //Button to book in Price Summary Page
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Book']")]
        public IWebElement Book_PriceSummaryPage { get; set; }

        //Object to GetText of the commission and Reprice
        [FindsBy(How = How.XPath, Using = "//span[@class = 'air-commission-wrapper']")]
        public IWebElement PriceSummaryPage_Comm { get; set; }

        //Button to Quote the itinerary in TSP
        [FindsBy(How = How.XPath, Using = "//span[text() = 'quote']")]
        public IWebElement TSP_Quote { get; set; }

        //Button to Book the itinerary in TSP
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Book']")]
        public IWebElement Book_TSP { get; set; }

        //Text to Validate upon Reprice in Price Summary Page
        [FindsBy(How = How.XPath, Using = "//div[@class = 'te-notification te-sm-notification alert-success']")]
        public IWebElement Reprice_Msg { get; set; }

        //Button to book the flights in 4.3 Page
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Book Only']")]
        public IWebElement BookOnly { get; set; }

        //Button to Ticket Flight in 4.3 page
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Ticket Flight']")]
        public IWebElement TicketFlight { get; set; }

        //Object to Assert the itinerary status after booking
        [FindsBy(How = How.XPath, Using = "//span[text() = 'booked N/$']")]
        public IWebElement BookedFlight_Val { get; set; }

        //Object of the class that contains all the UI elements for Exceptions
        Exceptions _exceptions = new Exceptions();

        //Object of the class that contains all the UI elements to select client and assign travelers
        ClientSearch_TravelerSelection clientSearch_Traveler = new ClientSearch_TravelerSelection();

        //Object of the class that contains all the UI elements to enter details in Payment Page
        PaymentPage pay = new PaymentPage();
        ClientSearch_TravelerSelection client_val;
        Exceptions exception = new Exceptions();

        [FindsBy(How = How.XPath, Using = "//div[@class = 'modal-dialog error-notification-modal error']")]
        public IWebElement Exception { get; set; }

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //Method to Run the Scenario 1 for Round trip flights until TSP
        public void Roundtrip_Scenario1(String from,String to,String departdate,String returndate,String currency,String no_adults,String gds, String clientSearch,ExtentTest test)
        {
            Air_val_click.Click();
            test.Log(Status.Info, "Opened Air Search Widget");
            From_dest.SendKeys(from);
            w.Typeahead_select();
            To_dest.SendKeys(to);
            w.Typeahead_select();
            Traveler_selection.Click();
            w.Dropdown_Value(Adults_count, no_adults);
            Depart_date.SendKeys(departdate);
            Return_date.SendKeys(returndate);
            w.Dropdown_Value(Inventory_source, gds);
            w.Dropdown_Value(Currency, currency);
            Search.Click();
            w.Wait(By.XPath("(//a[@class = 'on-matrix-filter'])[3]"));
            try
            {
                Assert.That(Search_Results_val.Text, Is.EqualTo("Flight Search Results"));
                test.Log(Status.Pass, "Successfully entered data,clicked on Air Search button and navigated to search results page");
                w.Matrix("AMERICAN AIRLINES");
                w.Wait(By.XPath("(//div[@class = 'col-xs-1 col-md-1 air-column air-airline-column air-airline-column-inner'])[1]"));
                Thread.Sleep(2000);
                Assert.That(Airline_Assert.Text, Is.EqualTo("AA"));
                test.Log(Status.Pass, "Filtered results by American Airlines");
            }
            catch(Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "No such airline name" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            Thread.Sleep(7000);
            Airline_add.Click();
            try
            {
                w.Wait(By.XPath("(//div[@class = 'col-md-1'])[1]"));
                Assert.That(Outbound_Air.Text, Is.EqualTo("AA"));
                test.Log(Status.Pass, "Selected American Airlines as Outbound Flight");
                
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "No such airline name" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            Thread.Sleep(7000);
            Airline_add.Click();
            try
            {
                w.Wait(By.XPath("//span[@class = 'airSearchTabTitle']"));
                string airlinePrice = PriceofAirline.Text;
                string commissionPriceSummaryPage = PriceSummaryPage_Comm.Text;
                Assert.That(PriceSummaryPage.Text, Is.EqualTo("Selected Flights"));
                test.Log(Status.Pass, "Successfully navigated to 4.2 page");
                test.Log(Status.Info, "Total Price for the flight(s): " + airlinePrice);
                test.Log(Status.Info, "Commission Before Reprice: " + commissionPriceSummaryPage);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured please view the screenshot" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            Thread.Sleep(3000);
            Quote_PriceSummaryPage.Click();
            WebDriverWait quote_Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            quote_Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'quote']")));
            Thread.Sleep(3000);
            try
            {
                String currentUrl = driver.Url;
                Assert.That(TSP_Quote.Text, Is.EqualTo("QUOTE"));
                test.Log(Status.Pass, "Quoted Successfully and navigated to TSP: " + currentUrl);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured in the quote flow" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            w.Wait(By.Id("clientSearch"));
            clientSearch_Traveler.ClientSearch.SendKeys(clientSearch);
            clientSearch_Traveler.ClientSearch_button.Click();
            w.Wait(By.XPath("(//button[text() = 'View'])[2]"));
            clientSearch_Traveler.ClientSelect_button.Click();
           
            try
            {
                client_val = new ClientSearch_TravelerSelection();
                w.Wait(By.XPath("//label[@class = 'label-functional is-traveling-label']"));
                string clientSelected = client_val.ClientName_Val.Text;
                Assert.That(clientSelected, Is.EqualTo("Roberto Cavilli"));
                test.Log(Status.Pass, "Selected Client is: " + clientSelected);

            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Could not find the specified client" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
        }
       
        //Method to Reprice the flights from TSP after assigning Travelers in TSP
        public void Reprice_Flow(String title, String fName, String mName, String lName, String day, String month, String year, String nationality, ExtentTest test)
        {
            w.Dropdown_Value(clientSearch_Traveler.Title_Dropdown, title);
            clientSearch_Traveler.FirstName.SendKeys(fName);
            clientSearch_Traveler.MiddleName.SendKeys(mName);
            clientSearch_Traveler.LastName.SendKeys(lName);
            w.Dropdown_Value(clientSearch_Traveler.Day_DropDown, day);
            w.Dropdown_Value(clientSearch_Traveler.Month_DropDown, month);
            w.Dropdown_Value(clientSearch_Traveler.Year_DropDown, year);
            w.Dropdown_Value(clientSearch_Traveler.Nationality_DropDown, nationality);
            clientSearch_Traveler.AssignTraveler_Second.Click();
            w.Wait(By.XPath("//div[text() = 'Select Companion']"));
            clientSearch_Traveler.SelectTraveler.Click();
            w.Wait(By.XPath("//input[@value = 'Lucy']"));
            clientSearch_Traveler.SaveTraveler_TSP.Click();
            Thread.Sleep(4000);
            Book_TSP.Click();
            WebDriverWait Book_TSP_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            Book_TSP_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'te-notification te-sm-notification alert-success']")));
            try
            {
                test.Log(Status.Info, "Assigned Travelers in TSP");
                string repricemsg = Reprice_Msg.Text;
                Assert.That(repricemsg, Is.EqualTo("Your flight is still available at the same price."));
                test.Log(Status.Pass, "Repriced Successfully: " + repricemsg);
                string airlinePrice = PriceofAirline.Text;
                string commissionPriceSummaryPage = PriceSummaryPage_Comm.Text;
                test.Log(Status.Info, "Total Price for the flight(s) after reprice: " + airlinePrice);
                test.Log(Status.Info, "Commission After Reprice: " + commissionPriceSummaryPage);
            }
            catch(Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                w.Wait(By.XPath("//div[@class = 'te-notification te-sm-notification alert-success']"));
                test.Log(Status.Fail, "Error occured in the reprice flow" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
        }
        
        //Method to book the flights from Price summary after Reprice
        public void Book_Flow(ExtentTest test)
        {
            Book_PriceSummaryPage.Click();
            w.Wait(By.XPath("//button[text() = 'Book Only']"));
            try
            {
                
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Navigated to 4.3 Page: " + title);
            }
            catch(Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail,"Could not navigate to 4.3 page, error occured"+e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            BookOnly.Click();
            WebDriverWait book_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            book_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Verify Travelers Legal Names']")));
            clientSearch_Traveler.Verified_1.Click();
            clientSearch_Traveler.Verified_2.Click();
            clientSearch_Traveler.Continue.Click();
            try
            {
                test.Log(Status.Info, "Booking the flight");
                w.Wait(By.XPath("//span[text() = 'booked N/$']"));
                string driverUrl = driver.Url;
                string jsUrl = js.ExecuteScript("return document.URL;").ToString();
                Assert.AreEqual(driverUrl, jsUrl);
                string bookedFlight = BookedFlight_Val.Text;
                Assert.That(bookedFlight, Is.EqualTo("BOOKED N/$"));
                test.Log(Status.Pass, "Successfully Booked the flight and navigated to TSP: " + jsUrl + " with the itinerary status: "+bookedFlight);
                //test.Log(Status.Pass, "Successfully Booked the flight and Navigated to TSP with the itinerary status: " + bookedFlight);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on 'Book Only' in 4.3 Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
        }

        //Method for Split Payment of 2 Travelers and validate TSP
        public void PayFlow_Split(String firstname,String lastname,String cc, String month, String year, String cvv, String firstname1, String lastname1, String cc1, String month1, String year1, String cvv1, ExtentTest test)
        {
            w.Wait(By.XPath("//b[text() = 'Trip Overview']"));
            pay.TicketFlight.Click();
            w.Wait(By.XPath("//span[@class = 'payableAmount']"));
            pay.Uncheck_Split_Check.Click();
            try
            {
                w.Wait(By.XPath("//h1[text() = 'Itinerary Payment']"));
                string currentUrl = driver.Url;
                string paymentPage = pay.PaymentPage_Val.Text;
                Assert.That(paymentPage, Is.EqualTo("Itinerary Payment"));
                test.Log(Status.Info, "Payment Screen: " + paymentPage);
                test.Log(Status.Pass, "Successfully Navigated to Payment Page with URL: " + currentUrl);
                string split = pay.PartialPayment.Text;
                Assert.That(split, Is.EqualTo("Partial"));
                test.Log(Status.Pass, "Selected Partial Payment: " + split);
                string amount = pay.PayableAmount.Text;
                test.Log(Status.Info, "Amount to be paid by each traveler: " + amount);
                test.Log(Status.Info, "Entered Traveler/Credit Card Details and clicked on Make Payment");

            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured and could not navigate to Payment Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            pay.FirstName.SendKeys(firstname);
            pay.LastName.SendKeys(lastname);
            pay.CreditCardNumber.SendKeys(cc);
            w.Dropdown_Value(pay.Month_DropDown, month);
            w.Dropdown_Value(pay.Year_DropDown, year);
            pay.Cvv.SendKeys(cvv);
            pay.Check_BillingAddress.Click();
            js.ExecuteScript("window.scrollBy(0,-100)");
            Thread.Sleep(3000);
            pay.AddCreditCard.Click();
            pay.Uncheck_Split_Check.Click();
            pay.FirstName1.SendKeys(firstname1);
            pay.LastName1.SendKeys(lastname1);
            pay.CreditCardNumber1.SendKeys(cc1);
            w.Dropdown_Value(pay.Month_DropDown1, month1);
            w.Dropdown_Value(pay.Year_DropDown1, year1);
            pay.Cvv1.SendKeys(cvv1);
            pay.Check_BillingAddress1.Click();
            pay.Check_Terms_Conditions.Click();
            pay.Payment_Button.Click();
            WebDriverWait pay_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            pay_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'travel-ready']")));
            try
            {
                string itineraryStatus = pay.Tsp_Status.Text;
                Assert.That(itineraryStatus, Is.EqualTo("TRAVEL-READY"));
                test.Log(Status.Pass, "Payment was successful and navigated to TSP with the status :" + itineraryStatus);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Payment Failed" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
        }


    }
}
