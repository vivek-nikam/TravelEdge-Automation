using System;
using System.Collections.ObjectModel;
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
    class Cruise : ExtentReport
    {
        public Cruise()
        {
            PageFactory.InitElements(driver, this);
        }
        //Object of the WaitMethods Class
        WaitMethods w = new WaitMethods();

        //WebElement to click on, to open the Cruise Search tab and also to Assert the text
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Cruise']")]
        public IWebElement Cruise_Click_Val { get; set; }

        //Object to Choose from the Drop down list for Destination (value)
        [FindsBy(How = How.XPath, Using = "//select[@name = 'CruiseDestinationId']")]
        public IWebElement Destination_DropDown { get; set; }

        //Date Picker to Choose the From Date
        [FindsBy(How = How.Id, Using = "cruise-date-from")]
        public IWebElement CruiseFromDate { get; set; }

        //Date Picker to Choose the To Date
        [FindsBy(How = How.Id, Using = "cruise-date-to")]
        public IWebElement CruisetoDate { get; set; }

        //Price Range Drag and Drop from left Source Element at 0%
        [FindsBy(How = How.XPath, Using = "(//div/a[1][contains(@class,'ui-slider-handle ui-state-default ui-corner-all')])[3]")]
        public IWebElement PriceRangeleft_Source { get; set; }
        //a[contains(@class,'ui-slider-handle ui-state-default ui-corner-all')]
        //html/body/div[2]/div[2]/div[3]/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div/div/form/div[2]/div[1]/div[4]/div/div/div/a[1]

        //Price Range Drag and Drop from left to Source Element at 8%
        [FindsBy(How = How.XPath, Using = "//a[@style = 'left: 2%;']")]
        public IWebElement PriceRangeleft_Dest { get; set; }

        //Price Range Drag and Drop from right Source Element at 100%
        [FindsBy(How = How.XPath, Using = "(//div/a[2][contains(@class,'ui-slider-handle ui-state-default ui-corner-all')])[3]")]
        public IWebElement PriceRangeRight_Source { get; set; }

        //Price Range Drag and Drop from right to Source Element at 80%
        [FindsBy(How = How.XPath, Using = "//a[@style = 'left: 80%;']")]
        public IWebElement PriceRangeRight_Dest { get; set; }

        //Object to verify the Price Range after Drag and Drop
        [FindsBy(How = How.Id, Using = "amount")]
        public IWebElement PriceRange_Amount_Val { get; set; }

        //Objects to select the Cruise Lines
        [FindsBy(How = How.XPath, Using = "//input[@value = '937']")]
        public IWebElement Azamara_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '908']")]
        public IWebElement Carnival_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '909']")]
        public IWebElement Celebrity_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '918']")]
        public IWebElement Cunard_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '921']")]
        public IWebElement Disney_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '911']")]
        public IWebElement Holland_Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = '912']")]
        public IWebElement Norwegian_Select { get; set; }

        //Input box to open the drop down for Embarkation Ports
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Search for Embarkation Ports']")]
        public IWebElement EmbarkationPort_Click { get; set; }

        //CheckBox to Select the first Embarkation Port - Generic
        [FindsBy(How = How.XPath, Using = "(//input[@name = 'EmbarkmentPortIds'])[1]")]
        public IWebElement EmbarkationPort_Check { get; set; }

        //The embark, de-embark and ports of call are sticky so click on this after every selection of the same
        [FindsBy(How = How.XPath, Using = "//label[text() = 'Embarkation Ports']")]
        public IWebElement Ports_Click_Random { get; set; }

        //Input box to open the drop down for Debarkation Ports
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Search for Debarkation Ports']")]
        public IWebElement DebarkationPort_Click { get; set; }

        //CheckBox to Select the first Debarkation Port - Generic
        [FindsBy(How = How.XPath, Using = "(//input[@name = 'DebarkmentPortIds'])[1]")]
        public IWebElement DebarkationPort_Check { get; set; }

        //Input box to open the drop down for Ports of Call
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Search for Ports of Call']")]
        public IWebElement PortsOfCall_Click { get; set; }

        //CheckBox to Select the first Port of Call - Generic
        [FindsBy(How = How.XPath, Using = "(//input[@name = 'LocationIds'])[1]")]
        public IWebElement PortOfCall_Check { get; set; }

        //Drop Down to Select the Quote Owner
        [FindsBy(How = How.Id, Using = "AgentId")]
        public IWebElement AgentId_DropDown { get; set; }

        //Drop Down to select the currency
        [FindsBy(How = How.XPath, Using = "//select[@name = 'CurrencyCode']")]
        public IWebElement Currency_DropDown { get; set; }

        //Object to Click on Save for Later button
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-default btn-save-cruise-search']")]
        public IWebElement SaveForLater { get; set; }

        //Object to Assert for to Save the Cruise Search
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Save Cruise Search']")]
        public IWebElement SaveCruiseSearch_Widget { get; set; }

        //Object to input the saved search name
        [FindsBy(How = How.XPath, Using = "//input[@name = 'SavedSearchName']")]
        public IWebElement SavedSearchName { get; set; }

        //Object to cancel the Saved Search
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Cancel']")]
        public IWebElement SavedSearch_Cancel { get; set; }

        //Object to Save the Saved Search
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Save']")]
        public IWebElement SavedSearch_Save { get; set; }

        //Object to reset the search criteria
        [FindsBy(How = How.Id, Using = "cruise-search-widget-reset")]
        public IWebElement Search_Reset { get; set; }

        //Object to click on View Saved and Previous Searches to open the drop down for all the saved and previous searches
        [FindsBy(How = How.XPath, Using = "//a[@class = 'on-view-saved-searches-summary de-link']")]
        public IWebElement ViewSaved_PreviousSearches { get; set; }

        //Object to Assert that Previous/Saved Searches widget is opened
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Previous/Saved Searches']")]
        public IWebElement PreviousSaved_Searches_Assert { get; set; }

        //Link to click on under Saved Searches
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'perform-saved-search'])[1]")]
        public IWebElement SavedSearches_Click { get; set; }

        //Link to click on under Previous Searches
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'perform-saved-search'])[4]")]
        public IWebElement PreviousSearches_Click { get; set; }

        //Object to click on to view all the Saved and Previous Searches
        [FindsBy(How = How.XPath, Using = "//button[text() = 'All Saved & Previous Searches']")]
        public IWebElement AllSearches_Click { get; set; }

        //Object to Assert in the Previous/Saved Searches pop-up window
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-sm-12 col-md-12 saved-search-item-header'])[1]")]
        public IWebElement AutoSave_Assert { get; set; }

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
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'close'])[2]")]
        public IWebElement Close_Savedsearch { get; set; }

        //Object to select for Sailings with Groups or Promotions
        [FindsBy(How = How.Id, Using = "GroupOrPromotionSailingsOnly")]
        public IWebElement Groups_Promotions { get; set; }

        //Button to click on to search
        [FindsBy(How = How.Id, Using = "cruise-search-widget-form-find-cruises")]
        public IWebElement Search { get; set; }

        //Pagination Assert
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'pagination-count'])[1]")]
        public IWebElement Pagination_Count { get; set; }

        //Object to Assert that it is search results page
        [FindsBy(How = How.XPath, Using = "//h1[text() = 'Choose Cruise']")]
        public IWebElement ChooseCruise_Assert { get; set; }

        //Object to Assert whether modify search widget is open or not
        [FindsBy(How = How.XPath, Using = "//b[text() = 'Modify Cruise Quote']")]
        public IWebElement ModifyCruise_Assert { get; set; }

        //Assert by which currency the results are displayed
        [FindsBy(How = How.XPath, Using = "//span[@class = 'cruise-search-results-currencycode']")]
        public IWebElement CurrencyCode { get; set; }

        //Button to click for Modify Search
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Modify Search']")]
        public IWebElement ModifySearch { get; set; }

        //Button to sort by Sailing Date
        [FindsBy(How = How.XPath, Using = "//button[@data-sort-type='1']")]
        public IWebElement SailingDate_Sort { get; set; }

        //Button to sort by Inside Cabin
        [FindsBy(How = How.XPath, Using = "//button[@data-sort-type='2']")]
        public IWebElement Inside_Sort { get; set; }

        //Button to sort by Ocean View Cabin
        [FindsBy(How = How.XPath, Using = "//button[@data-sort-type='3']")]
        public IWebElement Oceanview_Sort { get; set; }

        //Button to sort by Balcony 
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'btn btn-default cruise-search-sort'])[position()=4]")]
        public IWebElement Balcony_Sort { get; set; }

        //Button to sort by Suite
        [FindsBy(How = How.XPath, Using = "//button[@data-sort-type='5']")]
        public IWebElement Suite_Sort { get; set; }

        //Object to go to previous page in search results
        [FindsBy(How = How.XPath, Using = "//a[@class = 'action-item on-prev-page']")]
        public IWebElement PreviousPage { get; set; }

        //Object to go to first page in search results
        [FindsBy(How = How.XPath, Using = "//a[@class = 'action-item on-first-page']")]
        public IWebElement FirstPage { get; set; }

        //Object to go to next page in search results
        [FindsBy(How = How.XPath, Using = "//a[@class = 'action-item on-next-page']")]
        public IWebElement NextPage { get; set; }

        //Object to go to last page in search results
        [FindsBy(How = How.XPath, Using = "//a[@class = 'action-item on-last-page']")]
        public IWebElement LastPage { get; set; }

        //Object to View the different cabins and stateroom
        [FindsBy(How = How.XPath, Using = "(//a[text() = 'VIEW'])[1]")]
        public IWebElement View { get; set; }

        //Object to click on to View Cruise Details Page
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'cruise-search-view-details de-link-small'])[1]")]
        public IWebElement View_Details { get; set; }

        //Object to View the different cabins and stateroom inside view details
        [FindsBy(How = How.XPath, Using = "//a[text() = 'VIEW']")]
        public IWebElement View_InsideCabinDetails { get; set; }

        //Object used for Asserting the Itinerary Cruise Details Page
        [FindsBy(How = How.XPath, Using = "//h1[text() = 'Cruise Details']")]
        public IWebElement CruiseDetailsPage_Val { get; set; }

        //Object used for Asserting the Itinerary selected in Cruise Details Page
        [FindsBy(How = How.XPath, Using = "//h2[@class = 'title2']")]
        public IWebElement CruiseDetailsPage_Title { get; set; }

        //Object used to go back from Cruise Details Page to Cruise Results
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'inter-page-link details-back-link'])[1]")]
        public IWebElement BackToCruiseResults { get; set; }

        //Object used to Assert the Ship Name selected
        [FindsBy(How = How.XPath, Using = "(//dd[@class = 'dd-inline'])[1]")]
        public IWebElement CruiseShip_Val { get; set; }

        //Object used to View the Cabins in Cruise details Page
        [FindsBy(How = How.XPath, Using = "//a[text() = 'VIEW']")]
        public IWebElement View_Cabins { get; set; }

        //Object to view the cabin details
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'action-item on-show-cabin-details'])[1]")]
        public IWebElement CabinDetails { get; set; }

        //Object to Assert when clicked on View Available Cabin details
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'dashboard-title-text'])[1]")]
        public IWebElement AvailableCabins { get; set; }

        //Object to Assert when opened a particular Cabin
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'dashboard-title-text'])[2]")]
        public IWebElement CabinDetails_Cabin { get; set; }

        //Object to GetText of the Cabin opened to view the details
        [FindsBy(How = How.XPath, Using = "//div[@class = 'col-xs-8 col-md-8']")]
        public IWebElement CabinDetails_GetText { get; set; }

        //Object to close the Available Cabins overlay
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'close'])[4]")]
        public IWebElement AvailableCabins_Close { get; set; }

        //Object to close the Cabin Details Overlay
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'close'])[5]")]
        public IWebElement CabinDetails_Close { get; set; }

        //Object to select the Fare codes from the Drop down Menu
        [FindsBy(How = How.XPath, Using = "//select[@class = 'form-control de-form-control on-change-fare-code-selection']")]
        public IWebElement FareCodes_DropDown { get; set; }

        //Object to click on to view the drop down menu for cabins available under the particular Fare Codes
        [FindsBy(How = How.Id, Using = "availableCabinCategories")]
        public IWebElement FareCodes_Cabins_Menu { get; set; }

        //object to select a fare code from the menu
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-10 col-md-10'])[2]")]
        public IWebElement FareCodes_Select { get; set; }

        //Object to click on to find the cabins
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Find Cabins']")]
        public IWebElement FindCabins { get; set; }

        //Object to GetText of Cruise Ship ID
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[9]")]
        public IWebElement CruiseId { get; set; }

        //Object to click on Ship Details in Cruise Details Page
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Ship Details']")]
        public IWebElement ShipDetails { get; set; }

        //Object to click on Staterooms in Cruise Details Page
        [FindsBy(How = How.XPath, Using = "//a[@href = '#staterooms']")]
        public IWebElement Staterooms { get; set; }

        //Object to Select the Cruise Itinerary and open traveler details widget
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Show Cabin Categories']")]
        public IWebElement Select_Cruise { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@title = 'Show Cabin Categories'])[2]")]
        public IWebElement Select_Cruise2 { get; set; }

        //Object to open the drop down for travelers and select it based on the value
        [FindsBy(How = How.XPath, Using = "//select[@class = 'form-control de-form-control num-travelers']")]
        public IWebElement Select_Travelers_DropDown { get; set; }

        //Object to click on to Save Travelers and Select Fare Codes
        [FindsBy(How = How.XPath, Using = "//input[@value = 'Save Travelers and Select Fare Codes']")]
        public IWebElement SaveTravelers_SelectFareCodes { get; set; }

        //Object to shift tab to Quick Quote flow
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Quick Quote']")]
        public IWebElement Quick_Quote { get; set; }

        //Drop Down to select the number of travelers
        [FindsBy(How = How.XPath, Using = "//select[@class = 'form-control de-form-control num-travelers']")]
        public IWebElement Travelers_DropDown { get; set; }

        //Button to click on to Save Fare Codes and Select Cabin Category
        [FindsBy(How = How.XPath, Using = "//input[@class = 'btn btn-primary pull-right btn-save-fare-codes-select-categories']")]
        public IWebElement SaveFareCodes { get; set; }

        //Button to select Balcony under Cabin Category
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Balcony']")]
        public IWebElement Balcony_CabinSelect { get; set; }

        //Button to select Suite under Cabin Category
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Suite']")]
        public IWebElement Suite_CabinSelect { get; set; }

        //Button to select Oceanview under Cabin Category
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Oceanview']")]
        public IWebElement Oceanview_CabinSelect { get; set; }

        //Button to select Inside under Cabin Category
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Inside']")]
        public IWebElement Inside_CabinSelect { get; set; }

        //Button to select All under Cabin Category
        [FindsBy(How = How.XPath, Using = "//a[text() = 'All']")]
        public IWebElement All_CabinSelect { get; set; }

        //Asserting the selected fare code under Cabin Category and mouse hover action to get the text from Tool Tip
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'sailing-cabin-category-header-farecode'])[2]")]
        public IWebElement CabinSelected_Hover { get; set; }

        //Asserting the selected fare code under Cabin Category and mouse hover action to get the text from Tool Tip
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'sailing-cabin-category-header-farecode'])[1]")]
        public IWebElement CabinSelected_Hover1 { get; set; }

        //Element inside price tool tip to retrieve the commission amount
        [FindsBy(How = How.XPath, Using = "//div/i[@class = 'sailing-cabin-category-pricing-details-commission']")]
        public IWebElement CommissionAmountFromPrice_Hover { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'sailing-cabin-category-description']")]
        public IWebElement CabinCategoryDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@href = 'javascript:void(0);'])[2]")]
        public IWebElement CabinCategoryPrice_Hover { get; set; }

        //Button to click on to book the cruise
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn-add-cabin-category')]")]
        public IWebElement Book_Cruise { get; set; }

        [FindsBy(How = How.XPath, Using = "//b[text() = 'New Cruise Search']")]
        public IWebElement Click { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[1]")]
        public IWebElement FareCodes_Assert_BestRate { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class = 'margin5-top bold']")]
        public IWebElement FareCodes_Text { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class = 'inter-page-link back-to-farecodes'])[1]")]
        public IWebElement BackToFareCodes { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[2]")]
        public IWebElement FareCodes_Assert_BVL { get; set; }

        //Fare Codes Text of third Fare Code
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[3]")]
        public IWebElement FareCodes_Assert_3 { get; set; }

        //Fare Codes Text of fourth fare Code
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[4]")]
        public IWebElement FareCodes_Assert_4 { get; set; }

        //Fare Codes Text of fifth Fare Code
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[5]")]
        public IWebElement FareCodes_Assert_5 { get; set; }

        //Fare Codes Text of sixth Fare Code
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[6]")]
        public IWebElement FareCodes_Assert_6 { get; set; }

        //Fare Codes Text of Seventh Fare Code
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'show-farecode-details'])[7]")]
        public IWebElement FareCodes_Assert_7 { get; set; }

        //Edit fare Codes
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Edit Fare Codes']")]
        public IWebElement EditFareCodes { get; set; }

        //Select in Cruise Booking Select Cabin « ADX
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[1]")]
        public IWebElement Select1 { get; set; }

        //Select in Cruise Booking Select Cabin « ADX
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[2]")]
        public IWebElement Select2 { get; set; }

        //Select Seating
        [FindsBy(How = How.XPath, Using = "(//select[contains(@class,'de-form-control')])[1]")]
        public IWebElement Select_Seating { get; set; }

        //Select Table Size
        [FindsBy(How = How.XPath, Using = "(//select[contains(@class,'de-form-control')])[2]")]
        public IWebElement Select_TableSize { get; set; }

        //Select Nationality
        [FindsBy(How = How.XPath, Using = "(//select[contains(@class,'de-form-control')])[3]")]
        public IWebElement Select_Nationality { get; set; }

        //Show Passport Details
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'cruise-booking-pass-details')]")]
        public IWebElement Show_PassportDetails { get; set; }

        //Passport Number
        [FindsBy(How = How.Name, Using = "PassportNumber")]
        public IWebElement PassportNumber { get; set; }

        //View/Select Cruise Line Insurance
        [FindsBy(How = How.XPath, Using = "//h2[contains(@class,'toggle-extended-booking-options')]")]
        public IWebElement ViewOrSelectCruiseLineInsurance { get; set; }

        //Select Cruise Care Insurance
        [FindsBy(How = How.XPath, Using = "(//label/input[@data-insurance-code='CRC'])[1]")]
        public IWebElement CruiseCare1 { get; set; }

        //Select Cruise care Insurance
        [FindsBy(How = How.XPath, Using = "(//label/input[@data-insurance-code='CRC'])[2]")]
        public IWebElement CruiseCare2 { get; set; }

        //Button to Update the Price
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Update Pricing']")]
        public IWebElement UpdatePricing { get; set; }

        //Final Book Cruise
        [FindsBy(How = How.Id, Using = "on-book-cruise")]
        public IWebElement Cruise_Book_Final { get; set; }

        //Final Quote Cruise
        [FindsBy(How = How.Id, Using = "on-quote-cruise")]
        public IWebElement Cruise_Quote_Final { get; set; }

        //back to Trip Services
        [FindsBy(How = How.XPath, Using = "//a[text() = '« Back to Trip Services']")]
        public IWebElement BackToTripServices { get; set; }

        //Cruise Booking Page Dining Together
        [FindsBy(How = How.Name, Using = "dining-together")]
        public IWebElement Dining_Together { get; set; }

        //Insurance Price 
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-3 col-md-3 text-right'])[4]")]
        public IWebElement InsurancePrice { get; set; }

        //Cruise Confirmation Message
        [FindsBy(How = How.XPath, Using = "//p[@class = 'text-center']")]
        public IWebElement CruiseConfirmation { get; set; }

        //View Trip Services Page
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'view-trip-services')]")]
        public IWebElement View_TSP { get; set; }

        //Booked N/$ TSP Validation
        [FindsBy(How = How.XPath, Using = "//span[text() = 'booked N/$']")]
        public IWebElement Booked_Assert { get; set; }

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        ClientSearch_TravelerSelection _TravelerSelection = new ClientSearch_TravelerSelection();

        Exceptions ex = new Exceptions();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


        public void Cruise_Scenario1(String destination, String fromDate, String toDate, String saveSearchName, String fareCodes, ExtentTest test)
        {
            w.Wait(By.XPath("//div[text() = 'Cruise']"));
            Assert.That(Cruise_Click_Val.Text, Is.EqualTo("CRUISE"));
            test.Log(Status.Pass, ("Clicked on Cruise Search Widget"));
            Cruise_Click_Val.Click();
            w.Wait(By.XPath("//label[text() = 'Destination']"));
            test.Log(Status.Info, "Opened Cruise Search Widget to enter Values");
            w.Dropdown_Value(Destination_DropDown, destination);
            CruiseFromDate.SendKeys(fromDate);
            CruisetoDate.Clear();
            CruisetoDate.SendKeys(toDate);
            Azamara_Select.Click();
            SaveForLater.Click();
            w.Wait(By.XPath("//div[text() = 'Save Cruise Search']"));
            string saveSearch = SaveCruiseSearch_Widget.Text;
            Assert.That(saveSearch, Is.EqualTo("SAVE CRUISE SEARCH"));
            SavedSearchName.SendKeys(saveSearchName);
            SavedSearch_Save.Click();
            Thread.Sleep(5000);
            test.Log(Status.Info, "Saving the Cruise Search");
            Search_Reset.Click();
            Thread.Sleep(20000);
            Assert.IsFalse(Azamara_Select.Selected);
            test.Log(Status.Pass, "Performed Reset Successfully");
            Azamara_Select.Click();
            Celebrity_Select.Click();
            Search.Click();
            w.Wait(By.XPath("(//a[@class = 'cruise-search-view-details de-link-small'])[1]"));
            string paginationCountInitial = Pagination_Count.Text;
            string chooseCruise = ChooseCruise_Assert.Text;
            Assert.That(chooseCruise, Is.EqualTo("Choose Cruise"));
            test.Log(Status.Pass, "Successfully Navigated to Search Results Page: " + chooseCruise);
            ModifySearch.Click();
            w.Wait(By.XPath("//b[text() = 'Modify Cruise Quote']"));
            string modifyCruise = ModifyCruise_Assert.Text;
            Assert.That(modifyCruise, Is.EqualTo("MODIFY CRUISE QUOTE"));
            test.Log(Status.Info, "Opened Modify Search Widget: " + modifyCruise);
            ViewSaved_PreviousSearches.Click();
            w.Wait(By.XPath("//label[text() = 'Saved Searches']"));
            AllSearches_Click.Click();
            w.Wait(By.XPath("//div[text() = 'Previous/Saved Searches']"));
            string autosave = AutoSave_Assert.Text;
            if (autosave == "AUTOSAVE")
            {
                Assert.That(autosave, Is.EqualTo("AUTOSAVE"));
                test.Log(Status.Pass, "Successfully Saved the Cruise Search Criteria of Dashboard Page with the name: " + autosave);
                Thread.Sleep(3000);
                Search_Savedsearch_Previoussearches.Click();
                Thread.Sleep(5000);
                Search.Click();
                w.Wait(By.XPath("(//a[@class = 'cruise-search-view-details de-link-small'])[1]"));
                string paginationCount = Pagination_Count.Text;
                Assert.AreEqual(paginationCountInitial, paginationCount);
                w.Wait(By.XPath("(//a[@class = 'cruise-search-view-details de-link-small'])[1]"));
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Fail("The number of search results displayed initially does not match the actual search results obtained after the second search: " + paginationCount, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            else
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Could not find the Saved Name, Closing the Previous/Saved Searches Window: " + autosave, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                w.Wait(By.XPath("(//button[@class = 'close'])[2]"));
                Close_Savedsearch.Click();
                Thread.Sleep(3000);
                Search.Click();
            }
            Thread.Sleep(5000);
            w.Wait(By.XPath("(//a[@class = 'cruise-search-view-details de-link-small'])[1]"));
            View_Details.Click();
            Thread.Sleep(6000);
            //w.Wait(By.XPath("//img[@title = 'Azamara Club Cruises']"));
            try
            {
                //Thread.Sleep(4000);
                w.Wait(By.XPath("//img[@title = 'Azamara Club Cruises']"));
                string cruiseDetails = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Opened the Cruise Details Page: " + cruiseDetails);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Could not navigate to Cruise Details Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            w.Wait(By.XPath("//a[text() = 'VIEW']"));
            View_Cabins.Click();
            w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[2]"));
            try
            {
                string availableCabins = AvailableCabins.Text;
                Assert.That(availableCabins, Is.EqualTo("AVAILABLE CABINS"));
                test.Log(Status.Pass, "Opened the Available Cabins widget: " + availableCabins);
                //string cabinDetails1 = CabinDetails.Text;
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured in opening the Available Cabins Overlay" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            w.Dropdown_Value(FareCodes_DropDown, fareCodes);
            w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[2]"));
            FareCodes_Cabins_Menu.Click();
            FareCodes_Select.Click();
            w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[2]"));
            FindCabins.Click();
            try
            {
                w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[2]"));
            }
            catch
            {
                ex.Wait_Error();
                string businessErrorMsg = js.ExecuteScript("document.getElementsByTagName('dd')[3].innerText;").ToString();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on FindCabins, Please review the error message: " + businessErrorMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                js.ExecuteScript("arguments[0].click();", ex.Close_Exception);
            }
            CabinDetails.Click();
            try
            {
                w.Wait(By.XPath("//div[@class = 'col-xs-8 col-md-8']"));
                string cabinDetails2 = CabinDetails_Cabin.Text;
                string cabinDetails_Summary = CabinDetails_GetText.Text;
                string screenShotPath = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Pass, "Opened the particular cabin details overlay: " + cabinDetails2 + "Details of the Cabin: " + cabinDetails_Summary, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());

            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured in opening the Cabins Overlay" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());

            }
            CabinDetails_Close.Click();
            Thread.Sleep(2000);
            AvailableCabins_Close.Click();
            w.Wait(By.XPath("//a[text() = 'Deck Plans']"));
            Thread.Sleep(3000);
            w.Links_Method("Deck Four");
            w.Links_Method("Deck Seven");
            w.Links_Method("Deck Nine");
            ShipDetails.Click();
            Staterooms.Click();
        }

        public void Cruise_Book(String ClientName, String Title, String Fname, String Mname, String Lname, String Day, String Month, String Year, String Nationality, String companionRelationship,
            String Seating, String TableSize, String Nationality_CruiseBook, ExtentTest test)
        {
            Select_Cruise.Click();
            w.Wait(By.Id("clientSearch"));
            Thread.Sleep(8000);
            _TravelerSelection.ClientSearch.SendKeys(ClientName);
            _TravelerSelection.ClientSearch_button.Click();
            w.Wait(By.XPath("(//button[text() = 'View'])[2]"));
            _TravelerSelection.ClientSelect_button.Click();
            w.Wait(By.XPath("//a[@class = 'on-view-client']"));
            string clientName = _TravelerSelection.ClientName_Val.Text;
            test.Log(Status.Info, "Selected Client is: " + clientName);
            Thread.Sleep(3000);
            _TravelerSelection.Is_Traveling.Click();
            Thread.Sleep(20000);
            w.Wait(By.XPath("//input[@value = 'Roberto']"));
            w.Wait(By.XPath("(//select[@name = 'Title'])[2]"));
            w.Dropdown_Value(_TravelerSelection.Title_Dropdown2, Title);
            _TravelerSelection.FirstName2.SendKeys(Fname);
            _TravelerSelection.MiddleName2.SendKeys(Mname);
            _TravelerSelection.LastName2.SendKeys(Lname);
            w.Dropdown_Value(_TravelerSelection.Day_DropDown2, Day);
            w.Dropdown_Value(_TravelerSelection.Month_DropDown2, Month);
            w.Dropdown_Value(_TravelerSelection.Year_DropDown2, Year);
            w.Dropdown_Value(_TravelerSelection.Nationality_DropDown2, Nationality);
            //w.Wait(By.XPath("(//input[@class = 'save-companion'])[2]"));
            _TravelerSelection.SaveCompanion2.Click();
            w.Wait(By.XPath("(//select[@name = 'CompanionRelationship'])[1]"));
            w.Dropdown_Value(_TravelerSelection.CompanionRelationship2, companionRelationship);
            string screenShotPath = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
            test.Log(Status.Pass, "Assigned client and Travelers Successfully", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            SaveTravelers_SelectFareCodes.Click();
            try
            {
                w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Save Travelers and Select Fare Codes" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            try
            {
                string fareCode3 = FareCodes_Assert_3.Text;
                w.Links_Method(fareCode3);
                w.Wait(By.XPath("(//div[@class = 'col-md-12 col-xs-12'])[20]"));
                test.Log(Status.Pass, "Selected Fare Code is: " + fareCode3);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when viewed the particular Fare Code Details" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            js.ExecuteScript("window.scrollBy(0,-100)");
            BackToFareCodes.Click();
            w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
            try
            {
                string fareCode4 = FareCodes_Assert_4.Text;
                w.Links_Method(fareCode4);
                w.Wait(By.XPath("(//div[@class = 'col-md-12 col-xs-12'])[20]"));
                test.Log(Status.Pass, "Selected Fare Code is: " + fareCode4);
            }
            catch (Exception e)
            {
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when viewed the particular Fare Code Details" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
            }
            js.ExecuteScript("window.scrollBy(0,-100)");
            BackToFareCodes.Click();
            w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
            string bestRate = FareCodes_Assert_BestRate.Text;
            w.SelectFareCode(bestRate);
            string bvl = FareCodes_Assert_BVL.Text;
            w.SelectFareCode(bvl);
            test.Log(Status.Pass, "The Selected Fare Codes are: " + bestRate + "and" + bvl);
            Actions builder = new Actions(driver);
            builder.MoveToElement(FareCodes_Assert_6).Perform();
            SaveFareCodes.Click();
            w.Wait(By.XPath("(//div[@class = 'sailing-cabin-category-header-farecode'])[1]"));
            try
            {
                w.Links_Method("Commission Info");
                Thread.Sleep(5000);
                Suite_CabinSelect.Click();
                string cabinCategory = Suite_CabinSelect.Text;
                test.Log(Status.Info, "Sorted Cabins by: " + cabinCategory);
                w.CabinCategory_Hover("Club Ocean Suite");
                string cabinCategoryDesc = CabinCategoryDescription.Text;
                string screenShotCabin = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Info, "The Cabin Details on Hover: " + cabinCategoryDesc, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotCabin).Build());
                w.CabinCategory_Hover("Club World Owner's Suite");
                Actions act = new Actions(driver);
                act.MoveToElement(CabinCategoryPrice_Hover).Perform();

            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Save Fare Codes" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
                w.Wait(By.XPath("//button[text() = 'Edit Fare Codes']"));
                EditFareCodes.Click();
                w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
                string fareCode3 = FareCodes_Assert_3.Text;
                w.SelectFareCode(fareCode3);
                SaveFareCodes.Click();
            }
            w.Cruise_CabinCategory(2);
            w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[16]"));
            try
            {
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Navigated to : " + title);
                Select1.Click();
                w.Wait(By.XPath("//h2[text() = 'Travelers']"));
                try
                {
                    string title_book = js.ExecuteScript("return document.title;").ToString();
                    test.Log(Status.Pass, "Successfully Selected the Cabin and navigated to Cruise Booking Page: " + title_book);
                    Dining_Together.Click();
                    w.Dropdown_Value(Select_Seating, Seating);
                    w.Dropdown_Value(Select_TableSize, TableSize);
                    w.Dropdown_Value(Select_Nationality, Nationality_CruiseBook);
                    ViewOrSelectCruiseLineInsurance.Click();
                    w.Wait(By.XPath("//label/input[@data-insurance-code='CRC']"));
                    CruiseCare1.Click();
                    UpdatePricing.Click();
                    try
                    {
                        ex.Wait_Error_Business_Cruise();
                        string screenShot8 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                        test.Log(Status.Fail, "Error occured when Selected Insurance for only one Traveler", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot8).Build());
                        IWebElement elem4 = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                        String javascript4 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                        ((IJavaScriptExecutor)driver).ExecuteScript(javascript4, elem4);
                        elem4.Click();
                        Thread.Sleep(3000);
                        CruiseCare2.Click();
                        UpdatePricing.Click();

                    }
                    catch (Exception f)
                    {
                        test.Log(Status.Fail, "UnSuccessful Assertion and Booking Processed" + f);

                    }
                }
                catch (Exception e)
                {
                    ex.Wait_Error();
                    string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured when clicked on Select in Cabin Selection Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                    IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                    elem.Click();
                    js.ExecuteScript("window.history.go(-1);");
                    w.Wait(By.XPath("//a[text() = '« Back to Trip Services']"));
                    BackToTripServices.Click();
                }

            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Book in Cabin Category" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
                Thread.Sleep(3000);
                js.ExecuteScript("window.scrollBy(0,-1000);");
                BackToCruiseResults.Click();
                Thread.Sleep(5000);
                js.ExecuteScript("window.scrollBy(0,100);");
                w.Wait(By.XPath("(//button[@title = 'Show Cabin Categories'])[2]"));
                Select_Cruise2.Click();
                w.Wait(By.Id("clientSearch"));
                Thread.Sleep(8000);
                _TravelerSelection.ClientSearch.SendKeys(ClientName);
                _TravelerSelection.ClientSearch_button.Click();
                w.Wait(By.XPath("(//button[text() = 'View'])[2]"));
                _TravelerSelection.ClientSelect_button.Click();
                w.Wait(By.XPath("//a[@class = 'on-view-client']"));
                string clientName1 = _TravelerSelection.ClientName_Val.Text;
                test.Log(Status.Info, "Selected Client is: " + clientName1);
                Thread.Sleep(3000);
                _TravelerSelection.Is_Traveling.Click();
                Thread.Sleep(20000);
                w.Wait(By.XPath("//input[@value = 'Roberto']"));
                w.Wait(By.XPath("(//select[@name = 'Title'])[2]"));
                w.Dropdown_Value(_TravelerSelection.Title_Dropdown2, Title);
                _TravelerSelection.FirstName2.SendKeys(Fname);
                _TravelerSelection.MiddleName2.SendKeys(Mname);
                _TravelerSelection.LastName2.SendKeys(Lname);
                w.Dropdown_Value(_TravelerSelection.Day_DropDown2, Day);
                w.Dropdown_Value(_TravelerSelection.Month_DropDown2, Month);
                w.Dropdown_Value(_TravelerSelection.Year_DropDown2, Year);
                w.Dropdown_Value(_TravelerSelection.Nationality_DropDown2, Nationality);
                //w.Wait(By.XPath("(//input[@class = 'save-companion'])[2]"));
                //_TravelerSelection.SaveCompanion2_SearchResults.Click();
                //w.Wait(By.XPath("(//select[@name = 'CompanionRelationship'])[3]"));
                //w.Dropdown_Value(_TravelerSelection.CompanionRelationship2_SearchResults, companionRelationship);
                string screenShotPath1 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Pass, "Assigned client and Travelers Successfully", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath1).Build());
                SaveTravelers_SelectFareCodes.Click();
                try
                {
                    w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
                }
                catch (Exception f)
                {
                    ex.Wait_Error();
                    string screenShot2 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured when clicked on Save Travelers and Select Fare Codes" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                    IWebElement elems = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascripts = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascripts, elems);
                    elem.Click();
                }
                try
                {
                    string fareCode3 = FareCodes_Assert_3.Text;
                    w.Links_Method(fareCode3);
                    w.Wait(By.XPath("(//div[@class = 'col-md-12 col-xs-12'])[20]"));
                    test.Log(Status.Pass, "Selected Fare Code is: " + fareCode3);
                }
                catch (Exception f)
                {
                    ex.Wait_Error();
                    string screenShot3 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured when viewed the particular Fare Code Details" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot3).Build());
                    IWebElement elem2 = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript2 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript2, elem2);
                    elem.Click();
                }
                js.ExecuteScript("window.scrollBy(0,-100)");
                BackToFareCodes.Click();
                w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
                try
                {
                    string fareCode4 = FareCodes_Assert_4.Text;
                    w.Links_Method(fareCode4);
                    w.Wait(By.XPath("(//div[@class = 'col-md-12 col-xs-12'])[20]"));
                    test.Log(Status.Pass, "Selected Fare Code is: " + fareCode4);
                }
                catch (Exception f)
                {
                    string screenShot4 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured when viewed the particular Fare Code Details" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot4).Build());
                }
                js.ExecuteScript("window.scrollBy(0,-100)");
                BackToFareCodes.Click();
                w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
                string bestRate1 = FareCodes_Assert_BestRate.Text;
                w.SelectFareCode(bestRate1);
                string bvl1 = FareCodes_Assert_BVL.Text;
                w.SelectFareCode(bvl1);
                test.Log(Status.Pass, "The Selected Fare Codes are: " + bestRate1 + "and" + bvl1);
                Actions builder1 = new Actions(driver);
                builder1.MoveToElement(FareCodes_Assert_6).Perform();
                SaveFareCodes.Click();
                w.Wait(By.XPath("(//div[@class = 'sailing-cabin-category-header-farecode'])[1]"));
                try
                {
                    w.Links_Method("Commission Info");
                    Thread.Sleep(5000);
                    Suite_CabinSelect.Click();
                    string cabinCategory = Suite_CabinSelect.Text;
                    test.Log(Status.Info, "Sorted Cabins by: " + cabinCategory);
                    w.CabinCategory_Hover("Club Ocean Suite");
                    string cabinCategoryDesc = CabinCategoryDescription.Text;
                    string screenShotCabin = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Info, "The Cabin Details on Hover: " + cabinCategoryDesc, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotCabin).Build());
                    w.CabinCategory_Hover("Club World Owner's Suite");
                    Actions act = new Actions(driver);
                    act.MoveToElement(CabinCategoryPrice_Hover).Perform();

                }
                catch (Exception f)
                {
                    ex.Wait_Error();
                    string screenShot5 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured when clicked on Save Fare Codes" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot5).Build());
                    IWebElement elem3 = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript3 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript3, elem3);
                    elem3.Click();
                    w.Wait(By.XPath("//button[text() = 'Edit Fare Codes']"));
                    EditFareCodes.Click();
                    w.Wait(By.XPath("(//a[@class = 'show-farecode-details'])[1]"));
                    string fareCode3 = FareCodes_Assert_3.Text;
                    w.SelectFareCode(fareCode3);
                    SaveFareCodes.Click();
                }
                w.Cruise_CabinCategory(2);
                w.Wait(By.XPath("(//div[@class = 'de-table-col-inner'])[16]"));
                try
                {
                    string title = js.ExecuteScript("return document.title;").ToString();
                    test.Log(Status.Pass, "Successfully Navigated to : " + title);
                    Select2.Click();
                    w.Wait(By.XPath("//h2[text() = 'Travelers']"));
                    try
                    {
                        string title_book = js.ExecuteScript("return document.title;").ToString();
                        test.Log(Status.Pass, "Successfully Selected the Cabin and navigated to Cruise Booking Page: " + title_book);
                        Dining_Together.Click();
                        w.Dropdown_Value(Select_Seating, Seating);
                        w.Dropdown_Value(Select_TableSize, TableSize);
                        w.Dropdown_Value(Select_Nationality, Nationality_CruiseBook);
                        ViewOrSelectCruiseLineInsurance.Click();
                        w.Wait(By.XPath("//label/input[@data-insurance-code='CRC']"));
                        CruiseCare1.Click();
                        UpdatePricing.Click();
                        try
                        {
                            Thread.Sleep(10000);
                            //ex.Wait_Error_Business_Cruise();
                            string screenShot8 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                            test.Log(Status.Fail, "Error occured when Selected Insurance for only one Traveler" , MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot8).Build());
                            IWebElement elem4 = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                            String javascript4 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                            ((IJavaScriptExecutor)driver).ExecuteScript(javascript4, elem4);
                            elem4.Click();
                            Thread.Sleep(3000);
                            CruiseCare2.Click();
                            UpdatePricing.Click();

                        }
                        catch(Exception f)
                        {
                            test.Log(Status.Fail, "UnSuccessful Assertion and Booking Processed" + f);

                        }
                    }
                    catch (Exception f)
                    {
                        ex.Wait_Notification();
                        string screenShot6 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                        test.Log(Status.Fail, "Error occured when clicked on Select in Cabin Selection Page" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot6).Build());
                        IWebElement elem4 = driver.FindElement(By.XPath("//span[@title = 'Close')]"));
                        String javascript4 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                        ((IJavaScriptExecutor)driver).ExecuteScript(javascript4, elem4);
                        elem4.Click();
                        Thread.Sleep(3000);
                        Select2.Click();
                        w.Wait(By.XPath("//h2[text() = 'Travelers']"));
                        //js.ExecuteScript("window.history.go(-1);");
                        //w.Wait(By.XPath("//a[text() = '« Back to Trip Services']"));
                        //BackToTripServices.Click();
                    }
                }
                catch (Exception f)
                {
                    ex.Wait_Error();
                    string screenShot7 = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                    test.Log(Status.Fail, "Error occured again when clicked on Book in Cabin Category" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot7).Build());
                    IWebElement elem5 = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript5 = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript5, elem5);
                    elem5.Click();
                }
            }
            Thread.Sleep(8000);
            Cruise_Book_Final.Click();
            w.Wait(By.XPath("//div[text() = 'Verify Travelers Legal Names']"));
            Thread.Sleep(2000);
            _TravelerSelection.Verified_1.Click();
            _TravelerSelection.Verified_2.Click();
            _TravelerSelection.Continue.Click();
            w.Wait(By.XPath("//p[@class = 'text-center']"));
            try
            {
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                string cruiseConf = CruiseConfirmation.Text;
                string title1 = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Booked the Cruise and Navigated to Cruise Confirmation page: " + title1 + cruiseConf, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
            }
            catch (Exception f)
            {
                ex.Wait_Error();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Save Fare Codes" + f, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
                w.Wait(By.XPath("//a[text() = '« Back to Trip Services']"));
                BackToTripServices.Click();

            }
            View_TSP.Click();
            w.Wait(By.XPath("//span[text() = 'booked N/$']"));
            try
            {
                string booked = Booked_Assert.Text;
                string title = js.ExecuteScript("return document.title;").ToString();
                string screenShot = ScreenShots.Capture(driver, ExtentReport.GetDateTime());
                test.Log(Status.Pass, "Booked the Cruise and Navigated to TSP: " + booked + title, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Error Occured when clicked on View Trip Services Page" + e);
            }


        }

    }
}

