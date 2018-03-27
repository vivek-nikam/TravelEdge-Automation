using System;
using System.Threading;
using ADX_Regression.CommonObjects;
using ADX_Regression.ControlUnit;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ADX_Regression.Common;

namespace ADX_Regression.Objects
{
    /// <summary>
    /// <Package>com.te.Objects</Package>
    /// <PageObjects>Hotel</PageObjects>
    /// <Author>Vivek Nikam</Author>
    /// </summary>
    class Hotel : ExtentReport
    {
        //Constructor to Initialise all the properties and methods to the driver declared in GetBrowser Class
        public Hotel()
        {
            PageFactory.InitElements(driver, this);
        }

        #region "All the WebElements for Hotel excluding Payment Screen"

        //WebElement to click on to open the Hotel Search Tab
        [FindsBy(How = How.XPath, Using = "//b[text() = 'Hotel']")]
        public IWebElement HotelSearch { get; set; }

        //WebElement to Assert on the hotel Search Tab
        [FindsBy(How = How.XPath, Using = "//b[text() = 'New Hotel Search']")]
        public IWebElement NewHotelSearch_Assert { get; set; }

        //WebElement to Assert on the hotel Search Tab in Price Summary Page
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Hotel Search']")]
        public IWebElement HotelSearch_Assert { get; set; }

        //WebElement to Search By Destination
        [FindsBy(How = How.Name, Using = "DestinationCode")]
        public IWebElement Destination_Search { get; set; }

        //DatePicker Check-in Date
        [FindsBy(How = How.Name, Using = "CheckInDate")]
        public IWebElement CheckInDate { get; set; }

        //DatePicker Check out Date
        [FindsBy(How = How.Name, Using = "CheckOutDate")]
        public IWebElement CheckOutDate { get; set; }

        //Drop down to select the number of nights
        [FindsBy(How = How.Name, Using = "NumberOfNights")]
        public IWebElement NumberOfNights_DropDown { get; set; }

        //Button to Select the rooms and pax
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-default']")]
        public IWebElement Rooms_Button { get; set; }

        //Drop down to select the number of Adults for the first room
        [FindsBy(How = How.Name, Using = "room-adult-1")]
        public IWebElement Rooms_Adult_1 { get; set; }

        //Drop down to select the number of Children for the first room
        [FindsBy(How = How.Name, Using = "room-children-1")]
        public IWebElement Rooms_Children_1 { get; set; }

        //Drop down to select the Age of the child for the first room
        [FindsBy(How = How.Name, Using = "room-child1-1")]
        public IWebElement Rooms_Children_Age_1 { get; set; }

        //Button to Add another room
        [FindsBy(How = How.XPath, Using = "//a[@class = 'btn btn-default add-hotel-guests']")]
        public IWebElement AddRoom { get; set; }

        //Button to finish the room selection 
        [FindsBy(How = How.Id, Using = "editRoomSubmit")]
        public IWebElement Done { get; set; }

        //Drop down to select the number of Adults for the second room
        [FindsBy(How = How.Name, Using = "room-adult-2")]
        public IWebElement Rooms_Adult_2 { get; set; }

        //Drop down to select the number of Children for the second room
        [FindsBy(How = How.Name, Using = "room-children-2")]
        public IWebElement Rooms_Children_2 { get; set; }

        //Link to remove the rooms
        [FindsBy(How = How.XPath, Using = "(//span[text() = 'Remove'])[2]")]
        public IWebElement Remove { get; set; }

        //Input box to filter by hotel chains
        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder, 'Enter hotel chain name or code')]")]
        public IWebElement HotelChains { get; set; }

        //Radio button to include the Hotel Chains
        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'include')]")]
        public IWebElement HotelChains_Include { get; set; }

        //Radio button to exclude the hotel chains
        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'exclude')]")]
        public IWebElement HotelChains_Exclude { get; set; }

        //Link to open the drop down menu of Advanced Search
        [FindsBy(How = How.XPath, Using = "//a[@class = 'de-link advanced-search']")]
        public IWebElement Advanced_Search { get; set; }

        //Button to Search for the Hotel
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-primary btn-search-hotelfare']")]
        public IWebElement Search { get; set; }

        //Random click
        [FindsBy(How = How.XPath, Using = "//label[text() = 'HOTEL CHAINS']")]
        public IWebElement HotelChains_Click { get; set; }

        //Advanced Search options - Parking
        [FindsBy(How = How.XPath, Using = "(//input[@value = '1'])[4]")]
        public IWebElement Parking_Click { get; set; }

        //Advanced Search options - High Speed Internet
        [FindsBy(How = How.XPath, Using = "//input[@value = '9']")]
        public IWebElement Internet_Click { get; set; }

        //Drag and Drop in search tab by Min Rating
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'rating-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement MinRating { get; set; }

        //Header text of drag and drop to assert the Rating
        [FindsBy(How = How.XPath, Using = "//span[@class = 'any-rating']")]
        public IWebElement Rating_Assert { get; set; }

        //WebElements of Hotel Search Results Page
        //Radio Button select Map view
        [FindsBy(How = How.XPath, Using = "//label/input[@value = 'map-view']")]
        public IWebElement MapView { get; set; }

        //Radio button to select ListView
        [FindsBy(How = How.XPath, Using = "//label/input[@value = 'list-view']")]
        public IWebElement ListView { get; set; }

        //Search Results Page pagination count
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'pagination-count'])[1]")]
        public IWebElement SearchResults_Val { get; set; }

        //Pagination drop down in search results Page
        [FindsBy(How = How.XPath, Using = "(//select[@class = 'per-page on-per-page form-control'])[1]")]
        public IWebElement Pagination { get; set; }

        //Price/Night Filter in Search Results Page
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[1]")]
        public IWebElement Price_Night { get; set; }

        //Under Price/Night drop down menu sort by price (First Ascending and then Descending)
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'price']")]
        public IWebElement SortByPrice { get; set; }

        //Gets the Price of the First hotel in the search results for Assertion
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'hotel-price'])[1]")]
        public IWebElement Price_Val { get; set; }

        //Gets the price range text under Price/Night for the search criteria
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-12 col-xs-12'])[5]")]
        public IWebElement PriceRange_SearchResults { get; set; }

        //Slider for Price range by left
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'price-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement PriceRange_Slider_Left { get; set; }

        //Slider for Price range by right
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'price-range-slider')]//a[2]")]
        public IWebElement PriceRange_Slider_Right { get; set; }

        //Property Name filter drop down menu in search results page
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[2]")]
        public IWebElement PropertyName { get; set; }

        //Sort by property name in Property Name drop down menu
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'name']")]
        public IWebElement SortByPropertyName { get; set; }

        //Input box to sort by property name 
        [FindsBy(How = How.XPath, Using = "//input[@class = 'form-control de-form-control property-name-filter-text']")]
        public IWebElement PropertyName_SendKeys { get; set; }

        //Search button in the property name menu to sort by the property name
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-primary property-name-filter-btn']")]
        public IWebElement PropertyName_Searchbtn { get; set; }

        //Gets the Property Name of the first hotel in the search results
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-3 col-md-3 property-name-col'])[1]")]
        public IWebElement PropertyName_Assert { get; set; }

        //Rating filter drop down menu in search results page
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[3]")]
        public IWebElement Rating { get; set; }

        //Rating slider left
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'rating-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement Rating_SlideLeft { get; set; }

        //Rating Slider right
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'rating-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[2]")]
        public IWebElement Rating_SlideRight { get; set; }

        //Sort By rating
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'rating']")]
        public IWebElement SortByRating { get; set; }

        //Distance filter drop down menu in search results page
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[4]")]
        public IWebElement Distance { get; set; }

        //Sort by Distance
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'distance']")]
        public IWebElement Distance_Sort { get; set; }

        //Distance Slider left
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'distance-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement Distance_SlideLeft { get; set; }

        //Distance slider right
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'distance-range-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[2]")]
        public IWebElement Distance_SlideRight { get; set; }

        //To find the first distance of the hotel once the page loads
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'distance-col')])[2]")]
        public IWebElement Distance_First_Assert { get; set; }

        //Gets the text of the Distance dragged and dropped
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-12 col-xs-12'])[11]")]
        public IWebElement Distance_DragAndDrop_Text { get; set; }

        //Gets the drag and drop text from the filter in the filters section
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'filter-name'])[3]")]
        public IWebElement Distance_Filter_Text { get; set; }

        //Clear All the Filters selected
        [FindsBy(How = How.XPath, Using = "//button[@class = 'btn btn-primary reset-selected-filters']")]
        public IWebElement Clear_Filters { get; set; }

        //To Shortlist the first hotel in the search results page
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[1]")]
        public IWebElement Shortlist1 { get; set; }

        //WebElement which gets the name of the Hotel shortlisted for shortlist1 element above
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'tab-hotelname'])[2]")]
        public IWebElement Shortlist1_HotelName { get; set; }

        //WebElement which gets the header text i.e. hotel name in property details page
        [FindsBy(How = How.XPath, Using = "(//h2[@class = 'title2'])[1]")]
        public IWebElement Shortlist1_HotelName_PropertyDetailsPage { get; set; }

        //To Shortlist the fourth hotel in the search results page
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[4]")]
        public IWebElement Shortlist2 { get; set; }

        //To Shortlist the seventh hotel in the search results page
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[7]")]
        public IWebElement Shortlist3 { get; set; }

        //To remove the Filters individually, just increase the position to locate for other filters
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'fa fa-close remove-filter'])[2]")]
        public IWebElement RemoveFilter { get; set; }

        //Element to add another tab to search
        [FindsBy(How = How.XPath, Using = "//i[@class = 'fa fa-plus']")]
        public IWebElement AddTab { get; set; }

        //Element to wait for once clicked on add tab, also used to assert the tab
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Hotel Search']")]
        public IWebElement AddTab_Assert { get; set; }

        //To remove the hotel chains filter
        [FindsBy(How = How.XPath, Using = "//i[@class = 'fa icon fa-times']")]
        public IWebElement Remove_HotelChain { get; set; }

        //To Navigate to first tab
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'tab-hotelname'])[1]")]
        public IWebElement FirstTab { get; set; }

        //WebElement to remove the second tab
        [FindsBy(How = How.XPath, Using = "(//i[contains(@class,'hotel-search-close-tab')])[2]")]
        public IWebElement RemoveTab_2 { get; set; }

        //WebElement to Assert the selected rating under rating drop down menu
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-12 col-xs-12'])[9]")]
        public IWebElement RatingSelected_Assert { get; set; }

        //WebElement to get the filter text for rating
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'filter-name'])[2]")]
        public IWebElement Rating_FilterName { get; set; }

        //WebElement to open the third caret in search results page
        [FindsBy(How = How.XPath, Using = "(//i[@class = 'fa fa-chevron-down'])[3]")]
        public IWebElement Caret_SearchResultsPage { get; set; }

        //WebElement to select the Hotels
        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'select-hotel')])[3]")]
        public IWebElement Select_Hotel { get; set; }

        //To open photos in Property Details Page
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Photos']")]
        public IWebElement Hotel_Photos { get; set; }

        //To open the facilities
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Facilities']")]
        public IWebElement Hotel_Facilities { get; set; }

        //To open the Map
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Map']")]
        public IWebElement Hotel_Map { get; set; }

        //Map View Assert In Property Details Page
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'hotel-map-marker-label'])[1]")]
        public IWebElement Hotel_Map_val { get; set; }

        //To Toggle the map to full screen
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Toggle fullscreen view']")]
        public IWebElement Map_FullScreen { get; set; }

        //To Zoom in
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Zoom in']")]
        public IWebElement Map_Zoomin { get; set; }

        //To Zoom out
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Zoom out']")]
        public IWebElement Map_Zoomout { get; set; }

        //To open the Nearby attractions
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Nearby attractions']")]
        public IWebElement Hotel_NearbyAttractions { get; set; }

        //To open the Contact Details & Directions
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Contact Details & Directions']")]
        public IWebElement Hotel_ContactDetails { get; set; }

        //To go to next image
        [FindsBy(How = How.XPath, Using = "//*[@id='vfmviewer_vfmMedia']/a[2]/div")]
        public IWebElement Photos_Next { get; set; }

        //To get Photo Caption
        [FindsBy(How = How.Id, Using = "vfmviewer_vfmCaption")]
        public IWebElement Photos_Caption { get; set; }

        //To get the Rate Name
        [FindsBy(How = How.XPath, Using = "//table/tbody[1]/tr[2]/td[4]")]
        public IWebElement RateName { get; set; }

        //Average Rate/Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[6]")]
        public IWebElement AvgRateperNight { get; set; }

        //To Get the Price after each sort
        [FindsBy(How = How.XPath, Using = "//table/tbody[1]/tr[2]/td[1]")]
        public IWebElement AvgRateperNight_Price { get; set; }

        //Sort by Average Price per Night
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'daily-rate']")]
        public IWebElement AvgRateperNight_Sort { get; set; }

        //Slider for Average Rate/Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'daily-rate-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement AvgRateperNight_SliderLeft { get; set; }

        //Slider for Average Rate/Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'daily-rate-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement AvgRateperNight_SliderReft { get; set; }

        //To get the text from the filter shown under Filters section
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'filter-name'])[1]")]
        public IWebElement AvgRateperNight_FilterText { get; set; }

        //Average Rate/Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[7]")]
        public IWebElement TotalPrice { get; set; }

        //Sort by Total Price per Night
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'total-price']")]
        public IWebElement TotalPrice_Sort { get; set; }

        //To get the price after total price sort
        [FindsBy(How = How.XPath, Using = "//table/tbody[1]/tr[2]/td[2]")]
        public IWebElement TotalPrice_Price { get; set; }

        //Slider for Total Price per Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'total-price-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement TotalPrice_SliderLeft { get; set; }

        //Slider for Total Price per Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "((//div[contains(@class,'total-price-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[2]")]
        public IWebElement TotalPrice_SliderReft { get; set; }

        //To get the text from the filter shown under Filters section
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'filter-name'])[2]")]
        public IWebElement TotalPrice_FilterText { get; set; }

        //Commission Drop down Menu
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'commission-filter-title')]")]
        public IWebElement Commission { get; set; }

        //Sort by Commission
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'commission']")]
        public IWebElement Commission_Sort { get; set; }

        //Commission Slider Left
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'commission-slider')])//a[@class = 'ui-slider-handle ui-state-default ui-corner-all'])[1]")]
        public IWebElement Commission_SliderLeft { get; set; }

        //Average Rate/Night Drop down Menu
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'search-results-filter-title'])[8]")]
        public IWebElement RateNameDropdown { get; set; }

        //Sort by Rate Name
        [FindsBy(How = How.XPath, Using = "//a[@data-sort-by = 'rate-name']")]
        public IWebElement RateName_Sort { get; set; }

        //Input box to enter the rate name
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'rate-name-filter-text')]")]
        public IWebElement RateName_Input { get; set; }

        //Search the Rate Name
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'input-group-btn'])[4]")]
        public IWebElement RateName_Search { get; set; }

        //Narrow room description by keyword
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'rate-description-filter-text')]")]
        public IWebElement RoomDescription { get; set; }

        //Search the Room Description
        [FindsBy(How = How.XPath, Using = "(//span[@class = 'input-group-btn'])[3]")]
        public IWebElement RoomDesc_Search { get; set; }

        //Show Details HyperLink 1
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'on-rate-details'])[1]")]
        public IWebElement ShowDetails_1 { get; set; }

        //Show Details Hyperlink 1's price
        [FindsBy(How = How.XPath, Using = "(//td[contains(@class,'sum')])[3]")]
        public IWebElement ShowDetails_Price { get; set; }

        //Show Details HyperLink 1
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'on-rate-details'])[2]")]
        public IWebElement ShowDetails_2 { get; set; }

        //Show Details HyperLink 4
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'on-rate-details'])[4]")]
        public IWebElement ShowDetails_4 { get; set; }

        //Show Details HyperLink 6
        [FindsBy(How = How.XPath, Using = "(//a[@class = 'on-rate-details'])[6]")]
        public IWebElement ShowDetails_6 { get; set; }

        //Shortlist Rate Name 1
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[1]")]
        public IWebElement ShortList_1 { get; set; }

        //Shortlist Rate Name 1
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[2]")]
        public IWebElement ShortList_2 { get; set; }

        //Shortlist Rate Name 1
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[4]")]
        public IWebElement ShortList_4 { get; set; }

        //Shortlist Rate Name 1
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Shortlist'])[6]")]
        public IWebElement ShortList_6 { get; set; }

        //Select the Particular Rate
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[1]")]
        public IWebElement Select_1 { get; set; }

        //Get the Price of the First Hotel
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/div[8]/div/ul/li[1]/a/span")]
        public IWebElement Price_FirstHotel { get; set; }

        //Get the Price of the First Hotel
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/div[8]/div/ul/li[2]/a/span")]
        public IWebElement Price_SecondHotel { get; set; }

        //Select the Particular Rate
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[2]")]
        public IWebElement Select_2 { get; set; }

        //Select the Particular Rate
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[4]")]
        public IWebElement Select_4 { get; set; }

        //Select the Particular Rate
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[6]")]
        public IWebElement Select_6 { get; set; }

        //Get the Cancellation Policy in 4.3 Page
        [FindsBy(How = How.XPath, Using = "//div[@class = 'te-notification te-sm-notification alert-warning']")]
        public IWebElement CancellationPolicy_PriceSummaryPage { get; set; }

        //Quote All in 4.2 Page
        [FindsBy(How = How.XPath, Using = "(//button[@title = 'QuoteAll'])[2]")]
        public IWebElement QuoteAll { get; set; }

        //Quote in 4.2 Page
        [FindsBy(How = How.XPath, Using = "(//button[@title = 'Quote'])[2]")]
        public IWebElement Quote { get; set; }

        //TSP Quote status Assertion
        [FindsBy(How = How.XPath, Using = "//span[text() = 'quote']")]
        public IWebElement QuoteStatus { get; set; }

        //TSP First tab
        [FindsBy(How = How.XPath, Using = "(//a[@data-toggle = 'tab'])[2]")]
        public IWebElement FirstTab_TSP { get; set; }

        //TSP second tab
        [FindsBy(How = How.XPath, Using = "(//a[@data-toggle = 'tab'])[3]")]
        public IWebElement SecondTab { get; set; }

        //Book second hotel in TSP through normal flow
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Book'])[2]")]
        public IWebElement Book_SecondHotel { get; set; }

        //Reprice Notification in 4.2
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'te-notification te-sm-notification te-reprice-notification')]")]
        public IWebElement Reprice_Notification { get; set; }

        //Book in 4.2 Page
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Book']")]
        public IWebElement Book_PriceSummaryPage { get; set; }

        //Book in 4.3 Page
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Book with Deposit']")]
        public IWebElement BookWithDeposit { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Book With Gurantee']")]
        public IWebElement BookWithGurantee { get; set; }

        //Pay all in TSP
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Pay All']")]
        public IWebElement PayAll { get; set; }

        //Travel Ready Assertion
        [FindsBy(How = How.XPath, Using = "//span[text() = 'travel-ready']")]
        public IWebElement TravelReady { get; set; }

        //Modify Booking
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn-change-room')]")]
        public IWebElement ModifyBooking { get; set; }

        //Modify Booking Assert
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Modify Hotel Booking']")]
        public IWebElement ModifyBooking_Assert { get; set; }

        //Get the Initial Room Rate Code
        [FindsBy(How = How.XPath, Using = "//strong[@class = 'room-rate-code']")]
        public IWebElement ModifyBooking_RoomRateCode { get; set; }

        //Close Modify Widget
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'close'])[2]")]
        public IWebElement ModifyBooking_Close { get; set; }

        //Change Room Rate 
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Change Room Rate']")]
        public IWebElement ChangeRoomRateCode_Btn { get; set; }

        //Change room Rate Widget Get Rate Code first one
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-2 col-xs-2'])[3]")]
        public IWebElement ChangeRoomRateCode_Rate1 { get; set; }

        //Close Change room rate widget
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'close'])[3]")]
        public IWebElement ChangeRoomRateCode_Close { get; set; }

        //Select the first Rate Code
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[1]")]
        public IWebElement Select_Btn1 { get; set; }

        //Change room Rate Widget Get Rate Code fifth one
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-md-2 col-xs-2'])[11]")]
        public IWebElement ChangeRoomRateCode_Rate5 { get; set; }

        //Select the first Rate Code
        [FindsBy(How = How.XPath, Using = "(//button[text() = 'Select'])[5]")]
        public IWebElement Select_Btn5 { get; set; }

        //Cancel Hotel
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn-cancel-hotel')]")]
        public IWebElement CancelBooking { get; set; }

        //Cancel Hotel Remarks
        [FindsBy(How = How.Name, Using = "Remarks")]
        public IWebElement CancelBooking_Remarks { get; set; }

        //Cancel PNR Asert in hotel cancellation widget
        [FindsBy(How = How.XPath, Using = "//div[text() = 'Cancel PNR']")]
        public IWebElement CancelPNR_Assert { get; set; }

        //Continue Cancellation
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Continue']")]
        public IWebElement CancelPNR_Continue { get; set; }

        //rate Code in TSP Assert
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-4 col-md-4'])[1]")]
        public IWebElement RateCode_TSP { get; set; }

        //room rate in TSP Assert
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'col-xs-4 col-md-4'])[2]")]
        public IWebElement RoomRate_TSP { get; set; }

        //Cancellation Message From TSP
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'te-page-notification-message-main text16'])[3]")]
        public IWebElement TSP_CancellationMsg { get; set; }

        //Ok on the cancellation green message
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Ok']")]
        public IWebElement TSP_CancellationMsg_Ok { get; set; }

        //Cancelled Assert
        [FindsBy(How = How.XPath, Using = "//span[text() = 'canceled']")]
        public IWebElement CancelledItin { get; set; }

        //Cancellation Deadline Assert and button
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Send cancellation request']")]
        public IWebElement Cancellation_Deadline_SendRequest { get; set; }

        //ADX to perform Context Click
        [FindsBy(How = How.XPath, Using = "//img[@title = 'Back to Dashboard']")]
        public IWebElement SwitchTab { get; set; }

        #endregion

        #region "Objects of the classes commonly used in the application"
        //Object of the WaitMethods Class
        WaitMethods wait = new WaitMethods();

        //Object of the Actions Class
        Actions act = new Actions(driver);

        //Object of JavaScriptExecutor
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //Object of the Exceptions Class
        Exceptions ex = new Exceptions();

        //Object of the ClientSearch_TravelerSelection Class
        ClientSearch_TravelerSelection client = new ClientSearch_TravelerSelection();

        //Object of the PaymentPage class
        PaymentPage pay = new PaymentPage();
        #endregion

        #region "Search By Destination"
        /// <summary>
        /// Method to Search for a Hotel By Destination
        /// </summary>
        /// <param name="destination">Search for hotel, landmark, address, city or airport</param>
        /// <param name="checkInDate">format mm/dd/yyyy</param>
        /// <param name="checkOutDate">format mm/dd/yyyy</param>
        /// <param name="Adults">Max 4 per room</param>
        /// <param name="child">Max 2 per room</param>
        /// <param name="ChildAge">0-12 years</param>
        /// <param name="hotelChains">Enter hotel chain name or code</param>
        /// <param name="test">ExtentTest</param>
        public void Hotel_Search(String destination, String checkInDate, String checkOutDate, String Adults, String child, String ChildAge, String hotelChains, ExtentTest test)
        {
            wait.Wait(By.XPath("//b[text() = 'Hotel']"));
            HotelSearch.Click();
            string newHotelSearch = NewHotelSearch_Assert.Text;
            Assert.That(newHotelSearch, Is.EqualTo("NEW HOTEL SEARCH"));
            test.Log(Status.Info, "Clicked on Hotel Tab: " + newHotelSearch);
            Destination_Search.SendKeys(destination);
            Thread.Sleep(3000);
            act.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
            CheckInDate.Clear();
            CheckInDate.SendKeys(checkInDate);
            CheckOutDate.Clear();
            CheckOutDate.SendKeys(checkOutDate);
            Rooms_Button.Click();
            wait.Dropdown_Value(Rooms_Adult_1, Adults);
            wait.Dropdown_Value(Rooms_Children_1, child);
            wait.Dropdown_Value(Rooms_Children_Age_1, ChildAge);
            Done.Click();
            wait.Hotel_DragAndDrop(MinRating, -150, 0);
            string Selectedrating = Rating_Assert.Text;
            test.Log(Status.Pass, "Filtered star rating : " + Selectedrating);
            HotelChains.SendKeys(hotelChains);
            wait.Typeahead_SelectHotel();
            HotelChains_Click.Click();
            Advanced_Search.Click();
            Thread.Sleep(3000);
            Parking_Click.Click();
            Internet_Click.Click();
            string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
            test.Log(Status.Info, "Entered the Search Criteria", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            Search.Click();
            wait.Wait(By.XPath("(//div[@class = 'col-xs-3 col-md-3 property-name-col'])[1]"));
            try
            {
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully searched for the hotel and navigated to search results page: " + title);
            }
            catch (Exception e)
            {
                string screenShot = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Search in Dashboard Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShot).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
        }
        #endregion

        #region "Filters in Search Results Page"
        /// <summary>
        /// <Method>SearchPage Price filter</Method>
        /// <Method>Property Name Filter</Method>
        /// <Method>Rating Filter</Method>
        /// <Method>Distance Filter</Method>
        /// </summary>
        /// <param name="test">ExtentTest</param>

        //Method which performs all the assertions on the Price/Night Filters
        public void SearchPagePriceFilter(ExtentTest test)
        {
            string searchResults = SearchResults_Val.Text;
            test.Log(Status.Info, "The number of search results retrieved: " + searchResults);
            Price_Night.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'price']"));
            string priceRange = PriceRange_SearchResults.Text;
            test.Log(Status.Info, "The Price Range of the obtained Search Results is: " + priceRange);
            string priceBeforeSort = Price_Val.Text;
            //Sorting by Ascending Order
            SortByPrice.Click();
            Price_Night.Click();
            Thread.Sleep(5000);
            try
            {
                string firstSort = Price_Val.Text;
                Assert.AreNotEqual(priceBeforeSort, firstSort);
                test.Log(Status.Pass, "Sorted the Prices in Ascending Order Successfully: " + firstSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Price Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            //Sorting by Descending Order
            string priceAfterFirstSort = Price_Val.Text;
            Price_Night.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'price']"));
            SortByPrice.Click();
            Price_Night.Click();
            Thread.Sleep(5000);
            try
            {
                string secondSort = Price_Val.Text;
                Assert.AreNotEqual(priceAfterFirstSort, secondSort);
                test.Log(Status.Pass, "Sorted Prices in Descending Order Successfully: " + secondSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Price Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());

            }
            //Actions to perform drag and drop
            Price_Night.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'price']"));
            Actions action = new Actions(driver);
            action.ClickAndHold(PriceRange_Slider_Left);
            action.MoveByOffset(30, 0).Release().Perform();
            Price_Night.Click();

            Thread.Sleep(TestHelper.SLEEP_TIME);
        }

        //Method which performs all the assertions on the Property Name Filters
        public void PropertyNameFilter(ExtentTest test)
        {
            string propertyName = PropertyName_Assert.Text;
            PropertyName.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'name']"));
            SortByPropertyName.Click();
            PropertyName.Click();
            Thread.Sleep(3000);
            try
            {
                string propertyNameonFirstSort = PropertyName_Assert.Text;
                test.Log(Status.Pass, "Successfully sorted by Property Name(First Sort): " + propertyNameonFirstSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, string.Format(TestHelper.ERROR_PROPERTYNAME, "Sort") + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            PropertyName.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'name']"));
            SortByPropertyName.Click();
            PropertyName.Click();
            Thread.Sleep(3000);
            try
            {
                string propertyNameonSecondSort = PropertyName_Assert.Text;
                test.Log(Status.Pass, "Successfully sorted by Property Name(Second Sort): " + propertyNameonSecondSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Property Name Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            PropertyName.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'name']"));
            PropertyName_SendKeys.SendKeys(propertyName);
            PropertyName_Searchbtn.Click();
            PropertyName.Click();
            Thread.Sleep(3000);
            try
            {
                string PropertyName_Search = PropertyName_Assert.Text;
                test.Log(Status.Pass, "Successfully searched by property name: " + PropertyName_Search);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Property Name Search" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            RemoveFilter.Click();
            Thread.Sleep(3000);
        }

        //Method which performs assertion on all the Rating Filters
        public void RatingFilter(ExtentTest test)
        {
            Rating.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'rating']"));
            SortByRating.Click();
            Rating.Click();
            Thread.Sleep(3000);
            try
            {
                test.Log(Status.Pass, "Successfully performed sort by Rating");
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort by Rating" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            Rating.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'rating']"));
            SortByRating.Click();
            Rating.Click();
            Thread.Sleep(3000);
            try
            {
                test.Log(Status.Pass, "Successfully performed sort by Rating");
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort by Rating" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            Rating.Click();
            wait.Hotel_DragAndDrop(Rating_SlideRight, -50, 0);
            string rating_Selected = "Rating: " + RatingSelected_Assert.Text;
            Rating.Click();
            Thread.Sleep(3000);
            try
            {
                string rating = Rating_FilterName.Text;
                Assert.AreEqual(rating_Selected, rating);
                test.Log(Status.Pass, "Successfully filtered by the following rating: " + rating);

            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Filtering by Rating" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
        }

        //Method which performs all the assertions on the Distance Filters
        public void DistanceFilter(ExtentTest test)
        {
            string distance = Distance_First_Assert.Text;
            Distance.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'distance']"));
            Distance_Sort.Click();
            Distance.Click();
            Thread.Sleep(3000);
            //string distance = Distance_First_Assert.Text;
            try
            {
                string distance1 = Distance_First_Assert.Text;
                Assert.That(distance, Is.EqualTo(distance1));
                test.Log(Status.Pass, "Sorted Distance by Ascending Order: " + distance1);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sorting by Distance" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            Distance.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'distance']"));
            Distance_Sort.Click();
            Distance.Click();
            Thread.Sleep(3000);
            try
            {
                string distance2 = Distance_First_Assert.Text;
                Assert.AreNotEqual(distance, distance2);
                test.Log(Status.Pass, "Sorted Distance by Descending Order: " + distance2);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sorting by Distance" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            Distance.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'distance']"));
            wait.Hotel_DragAndDrop(Distance_SlideRight, -50, 0);
            string sortedDistance = "Distance: " + Distance_DragAndDrop_Text.Text;
            Distance.Click();
            Thread.Sleep(3000);
            try
            {
                string distanceFilter = Distance_Filter_Text.Text;
                Assert.AreEqual(sortedDistance, distanceFilter);
                test.Log(Status.Pass, "Sorted the hotels by distance with the following range: " + distanceFilter);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Drag and Drop by Distance" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
        }
        #endregion

        #region "Shortlist the Hotels"
        /// <summary>
        /// <Method>Shortlist Hotel</Method>
        /// </summary>
        /// <param name="test"></param>
        //Method to Shortlist the Hotels
        public void ShortlistHotel(ExtentTest test)
        {
            Shortlist1.Click();
            Thread.Sleep(2000);
            //string shortlistedHotel = Shortlist1_HotelName.Text;
            Shortlist1_HotelName.Click();
            wait.Wait(By.XPath("(//h2[@class = 'title2'])[1]"));
            try
            {
                string hotelName_PropertyDetails = Shortlist1_HotelName_PropertyDetailsPage.Text;
                //Assert.AreSame(shortlistedHotel, hotelName_PropertyDetails);
                test.Log(Status.Pass, "Successfully Shortlisted the Hotel: " + hotelName_PropertyDetails);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Shortlisting the Hotel" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            FirstTab.Click();
            RemoveTab_2.Click();
        }
        #endregion

        #region "Select Hotel (Right now its hard coded to select the first hotel in the search results page)"
        //Method to select the hotel
        public void SelectHotel(ExtentTest test)
        {
            Caret_SearchResultsPage.Click();
            Select_Hotel.Click();
            wait.Wait(By.XPath("(//tr[@class = 'hotel-rate-description-row'])[1]"));
            try
            {
                string hotelName = Shortlist1_HotelName_PropertyDetailsPage.Text;
                test.Log(Status.Pass, "Successfully selected the Hotel and navigated to Property Details Page" + hotelName);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Selecting the Hotel" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();

            }
        }
        #endregion

        #region "Property details Page initial assertion except for filters"
        //Method to Assert in Property Details Page
        public void PropertyDetailsPage(ExtentTest test)
        {
            Hotel_Photos.Click();
            Thread.Sleep(6000);
            //wait.Wait(By.XPath("//*[@id='vfmviewer_vfmMedia']/a[2]/div"));
            try
            {
                test.Log(Status.Pass, "Opened the particular Hotel Photos");
            }
            catch
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "No Photos Available for the particular Property", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }

            Hotel_Facilities.Click();
            Thread.Sleep(2000);
            Hotel_Map.Click();
            wait.Wait(By.XPath("(//div[@class = 'hotel-map-marker-label'])[1]"));
            try
            {
                string mapPrice = Hotel_Map_val.Text;
                test.Log(Status.Pass, "Opened the Map View of the Property: " + mapPrice);
            }
            catch
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "No Map Available for the particular Property", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            Map_FullScreen.Click();
            Thread.Sleep(5000);
            Map_Zoomin.Click();
            Thread.Sleep(3000);
            Map_Zoomout.Click();
            Thread.Sleep(3000);
            Map_FullScreen.Click();
            wait.Wait(By.XPath("//a[text() = 'Facilities']"));
            Hotel_NearbyAttractions.Click();
            Thread.Sleep(2000);
            Hotel_ContactDetails.Click();
            Thread.Sleep(2000);
        }
        #endregion

        #region"Property Details Page Filters"
        /// <summary>
        /// <Method>Average Rate Per Night Filter</Method>
        /// <Method>Total Price Filter</Method>
        /// <Method>Rate Name drop down Filter</Method>
        /// </summary>
        /// <param name="test">ExtentTest</param>
        //Method to Assert all the scenarios for Average Rate/Night drop down Filter
        public void AvgRatePerNight(ExtentTest test)
        {
            //js.ExecuteScript("window.scrollBy(0,900)");
            string priceBeforeSort = AvgRateperNight_Price.Text;
            AvgRateperNight.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'daily-rate']"));
            AvgRateperNight_Sort.Click();
            AvgRateperNight.Click();
            Thread.Sleep(3000);
            try
            {
                string priceAfterFirstSort = AvgRateperNight_Price.Text;
                //Assert.AreEqual(priceBeforeSort, priceAfterFirstSort);
                test.Log(Status.Pass, "Successfully sorted Average Rate/Night filter in Ascending order: " + priceAfterFirstSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            AvgRateperNight.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'daily-rate']"));
            AvgRateperNight_Sort.Click();
            AvgRateperNight.Click();
            Thread.Sleep(3000);
            try
            {
                string priceAfterSecondSort = AvgRateperNight_Price.Text;
                //Assert.AreEqual(priceBeforeSort, priceAfterSecondSort);
                test.Log(Status.Pass, "Successfully sorted Average Rate/Night filter in Descending order: " + priceAfterSecondSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            AvgRateperNight.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'daily-rate']"));
            wait.Hotel_DragAndDrop(AvgRateperNight_SliderLeft, 50, 0);
            AvgRateperNight.Click();
            Thread.Sleep(3000);
            try
            {
                string priceAfterDragAndDrop = AvgRateperNight_Price.Text;
                Assert.AreNotEqual(priceBeforeSort, priceAfterDragAndDrop);
                string filterText = AvgRateperNight_FilterText.Text;
                test.Log(Status.Pass, "Applied the drag and drop price range successfully: " + filterText);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort " + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }


        }

        //Method to Assert all the scenarios for Total Price drop down Filter
        public void TotalPriceFilter(ExtentTest test)
        {
            string priceBeforeSort = TotalPrice_Price.Text;
            TotalPrice.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'total-price']"));
            TotalPrice_Sort.Click();
            TotalPrice.Click();
            Thread.Sleep(3000);
            try
            {
                string priceAfterFirstSort = TotalPrice_Price.Text;
                //Assert.AreEqual(priceBeforeSort, priceAfterFirstSort);
                test.Log(Status.Pass, "Successfully sorted Total Price filter in Ascending order: " + priceAfterFirstSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            TotalPrice.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'total-price']"));
            TotalPrice_Sort.Click();
            TotalPrice.Click();
            Thread.Sleep(3000);
            try
            {
                string priceAfterSecondSort = TotalPrice_Price.Text;
                //Assert.AreEqual(priceBeforeSort, priceAfterSecondSort);
                test.Log(Status.Pass, "Successfully sorted Total Price filter in Descending order: " + priceAfterSecondSort);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }
            TotalPrice.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'total-price']"));
            wait.Hotel_DragAndDrop(TotalPrice_SliderLeft, 50, 0);
            TotalPrice.Click();
            Thread.Sleep(3000);
            try
            {
                //string priceAfterDragAndDrop = TotalPrice_Price.Text;
                //Assert.AreNotEqual(priceBeforeSort, priceAfterDragAndDrop);
                string filterText = TotalPrice_FilterText.Text;
                test.Log(Status.Pass, "Applied the drag and drop price range successfully: " + filterText);
            }
            catch (Exception e)
            {
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error in Sort" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            }


        }

        //Method to Assert all the scenarios for Average Rate/Night drop down Filter
        public void RateNameDropDown(ExtentTest test)
        {
            RateNameDropdown.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'rate-name']"));
            RateName_Sort.Click();
            RateNameDropdown.Click();
            Thread.Sleep(3000);
            RateNameDropdown.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'rate-name']"));
            RateName_Sort.Click();
            RateNameDropdown.Click();
            Thread.Sleep(3000);
            string rateName = RateName.Text;
            RateNameDropdown.Click();
            wait.Wait(By.XPath("//a[@data-sort-by = 'rate-name']"));
            RateName_Input.SendKeys(rateName);
            RateName_Search.Click();
            Thread.Sleep(3000);

        }
        #endregion

        #region"Select Rate in Property Details Page(Hard Coded to select the first Rate)"
        //Method to select the particular Rate
        public void Select_Rate(ExtentTest test)
        {
            ShowDetails_1.Click();
            wait.Wait(By.XPath("//strong[text() = 'Cancellation Policy']"));
            try
            {
                string totalPrice = ShowDetails_Price.Text;
                test.Log(Status.Pass, "Clicked on Show Details of the particular Rate with the Total Price: " + totalPrice);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Show Details" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            Select_1.Click();
            Thread.Sleep(8000);
            try
            {
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Navigated to 4.2 Page: " + title);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Select button in Property Details Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            //string cancellationPolicy = CancellationPolicy_PriceSummaryPage.Text;
            //return cancellationPolicy;
        }
        #endregion

        #region"Adds another hotel in the Price Summary Page and searches by destination"
        /// <summary>
        /// This method can be used anywhere in the Hotel module to add another search
        /// </summary>
        /// <param name="destination1">Search for hotel, landmark, address, city or airport</param>
        /// <param name="Nights1">Max 10</param>
        /// <param name="Adults1">Max 4 per room</param>
        /// <param name="test">ExtentTest</param>
        //Method to Add Another Hotel
        public void AddHotel(String destination1, String Nights1, String Adults1, ExtentTest test)
        {
            //
            js.ExecuteScript("window.scrollBy(0,-800);");
            AddTab.Click();
            wait.Wait(By.XPath("//div[text() = 'Hotel Search']"));
            string newHotelSearch = HotelSearch_Assert.Text;
            Assert.That(newHotelSearch, Is.EqualTo("HOTEL SEARCH"));
            test.Log(Status.Info, "Clicked on New Hotel Tab: " + newHotelSearch);
            Destination_Search.Clear();
            Destination_Search.SendKeys(destination1);
            Thread.Sleep(3000);

            //
            act.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
            wait.Dropdown_Value(NumberOfNights_DropDown, Nights1);
            Rooms_Button.Click();
            wait.Dropdown_Value(Rooms_Adult_1, Adults1);
            Thread.Sleep(2000);
            Done.Click();
            wait.Hotel_DragAndDrop(MinRating, 50, 0);
            Remove_HotelChain.Click();

            //
            string Selectedrating = Rating_Assert.Text;
            test.Log(Status.Pass, "Filtered star rating : " + Selectedrating);
            string screenShotPath = ScreenShots.Capture(driver, GetDateTime());

            test.Log(Status.Info, "Entered the Search Criteria", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
            Search.Click();
            wait.Wait(By.XPath("(//div[@class = 'col-xs-3 col-md-3 property-name-col'])[1]"));
            SelectHotel(test);
            Select_Rate(test);
            QuoteAll.Click();
            wait.Wait(By.XPath("//span[text() = 'quote']"));
            string tsp_Status = QuoteStatus.Text;
            try
            {
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Navigated to TSP: " + title + " with the itinerary status: " + tsp_Status);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath1 = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Select button in Property Details Page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath1).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            wait.Wait(By.Id("clientSearch"));

        }
        #endregion

        #region"Add client in TSP using webelements from the class ClientSearch_TravelerSelection"
        /// <summary>
        /// Method to add client name in TSP or Assign Client/Traveler selection Page
        /// </summary>
        /// <param name="ClientName">Roberto Cavalli</param>
        /// <param name="test">ExtentTest</param>
        //Method to Add Client in TSP
        public void AddClient(String ClientName, ExtentTest test)
        {
            Thread.Sleep(4000);
            client.ClientSearch.SendKeys(ClientName);
            client.ClientSearch_button.Click();
            wait.Wait(By.XPath("(//button[text() = 'View'])[2]"));
            client.ClientSelect_button.Click();
            client.Is_Traveling.Click();
            wait.Wait(By.XPath("//input[@value = 'Roberto']"));
            client.SaveTraveler_TSP.Click();
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,-900);");
            SecondTab.Click();
            wait.Wait(By.XPath("//button[text() = 'Assign Travelers']"));
            client.AssignTravelers.Click();
            wait.Wait(By.XPath("//div[text() = 'Assign Travelers']"));
            Thread.Sleep(2000);
            client.AssignTravelers_Checkbox.Click();
            client.Save_AssignTravelers.Click();
            wait.Wait(By.XPath("//div[contains(@class,'service-traveler-info')]"));
            Thread.Sleep(3000);
        }
        #endregion

        #region "Book 2 hotels from TSP"
        /// <summary>
        /// Pay all for both the hotels
        /// </summary>
        /// <param name="Fname"></param>
        /// <param name="Lname"></param>
        /// <param name="CCno"></param>
        /// <param name="month"></param>
        /// <param name="Year"></param>
        /// <param name="cvv"></param>
        /// <param name="test"></param>
        public void Book_Hotel_2(String Fname, String Lname, String CCno, String month, String Year, String cvv, ExtentTest test)
        {

            PayAll.Click();
            wait.Wait(By.XPath("//strong[text() = 'Planning and Service Fees']"));
            Thread.Sleep(5000);
            try
            {
                string title = js.ExecuteScript("return document.title;").ToString();
                test.Log(Status.Pass, "Successfully Navigated to Payment Page: " + title);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath1 = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Pay All in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath1).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();

            }

            pay.FirstName.SendKeys(Fname);
            pay.LastName.SendKeys(Lname);
            pay.CreditCardNumber.SendKeys(CCno);
            wait.Dropdown_Value(pay.Month_DropDown, month);
            wait.Dropdown_Value(pay.Year_DropDown, Year);
            pay.Cvv.SendKeys(cvv);
            pay.Check_BillingAddress.Click();
            pay.Check_Terms_Conditions.Click();
            pay.ProcessTransaction.Click();
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            w.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'travel-ready']")));
            try
            {
                string travelReady = TravelReady.Text;
                Assert.That(travelReady, Is.EqualTo("TRAVEL-READY"));
                test.Log(Status.Pass, "Successfully paid for the hotels and navigated to TSP page with the status: " + travelReady);

            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Payment in payment page" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            FirstTab_TSP.Click();
            wait.Wait(By.XPath("//button[contains(@class,'btn-change-room')]"));
            string RoomRateInitial = RoomRate_TSP.Text;
            ModifyBooking.Click();
            wait.Wait(By.XPath("//div[text() = 'Modify Hotel Booking']"));
            try
            {
                string modifyWidget = ModifyBooking_Assert.Text;
                Assert.That(modifyWidget, Is.EqualTo("MODIFY HOTEL BOOKING"));
                test.Log(Status.Pass, "Opened the modification widget: " + modifyWidget);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Modify Booking in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            string rateCodeInitial = ModifyBooking_RoomRateCode.Text;
            ChangeRoomRateCode_Btn.Click();
            wait.Wait(By.XPath("(//div[@class = 'col-md-2 col-xs-2'])[3]"));
            if (ChangeRoomRateCode_Rate1.Displayed)
            {
                string rateCodeToBeSelected = ChangeRoomRateCode_Rate1.Text;
                test.Log(Status.Info, "Going to select the following Rate Code: " + rateCodeToBeSelected);
                Select_Btn1.Click();
                Thread.Sleep(30000);
                FirstTab_TSP.Click();
                wait.Wait(By.XPath("(//div[@class = 'col-xs-4 col-md-4'])[1]"));
                try
                {
                    string rateCodeAfterModify = RateCode_TSP.Text;
                    Assert.AreNotEqual(rateCodeInitial, rateCodeAfterModify);
                    test.Log(Status.Pass, "Modified the Room Rate Successfully");
                }
                catch (Exception e)
                {
                    ex.Wait_Error();
                    string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                    test.Log(Status.Fail, "Error occured when modified the hotel rate code in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                    IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                    elem.Click();
                }

            }
            wait.Wait(By.XPath("(//a[@data-toggle = 'tab'])[3]"));
            SecondTab.Click();
            CancelBooking.Click();
            wait.Wait(By.XPath("//div[text() = 'Cancel PNR']"));
            try
            {
                string cancel = CancelPNR_Assert.Text;
                Assert.That(cancel, Is.EqualTo("CANCEL PNR"));
                test.Log(Status.Pass, "Successfully opened the cancellation widget: " + cancel);
            }
            catch (Exception e)
            {
                ex.Wait_Error();
                string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Fail, "Error occured when clicked on Cancel Hotel button in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                elem.Click();
            }
            if (!Cancellation_Deadline_SendRequest.Displayed)
            {
                CancelBooking_Remarks.SendKeys("Auto Cancel(Test), Please Avoid");
                CancelPNR_Continue.Click();
                wait.Wait(By.XPath("(//div[@class = 'te-page-notification-message-main text16'])[3]"));
                try
                {
                    string cancelMsg = TSP_CancellationMsg.Text;
                    string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                    test.Log(Status.Pass, "Successfully processed the cancellation: " + cancelMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
                catch (Exception e)
                {
                    ex.Wait_Error();
                    string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                    test.Log(Status.Fail, "Error occured when clicked on Cancel Hotel in cancellation widget in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                    IWebElement elem = driver.FindElement(By.XPath("//button[contains(@class,'btn-close-support-form pull-right')]"));
                    String javascript = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(javascript, elem);
                    elem.Click();
                }
                TSP_CancellationMsg_Ok.Click();
                wait.Wait(By.XPath("//span[text() = 'canceled']"));
                string cancelItin = CancelledItin.Text;
                string screenShotPath2 = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Pass, "Cancelled the itinerary successfully: " + cancelItin, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath2).Build());
            }
            else if (Cancellation_Deadline_SendRequest.Displayed)
            {
                Cancellation_Deadline_SendRequest.Click();
                CancelBooking_Remarks.SendKeys("Auto Cancel(Test), Please Avoid");
                CancelPNR_Continue.Click();
                WebDriverWait wait_cancel = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                wait_cancel.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class = 'te-page-notification-message-main text16'])[3]")));
                try
                {
                    string cancelMsg = TSP_CancellationMsg.Text;
                    string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                    test.Log(Status.Pass, "Successfully processed the cancellation: " + cancelMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
                catch (Exception e)
                {
                    ex.Wait_Error();
                    string screenShotPath = ScreenShots.Capture(driver, GetDateTime());
                    test.Log(Status.Fail, "Error occured when clicked on Cancel Hotel in cancellation widget in TSP" + e, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                    js.ExecuteScript("arguments[0].click();", ex.Close_Exception);
                }
                wait.Wait(By.XPath("//button[text() = 'Ok']"));
                TSP_CancellationMsg_Ok.Click();
                Thread.Sleep(5000);
                wait.Wait(By.XPath("//span[text() = 'canceled']"));
                string cancelItin = CancelledItin.Text;
                string screenShotPath2 = ScreenShots.Capture(driver, GetDateTime());
                test.Log(Status.Pass, "Cancelled the itinerary successfully: " + cancelItin, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath2).Build());
                //string TSP_URL = driver.Url;
                ////Actions context = new Actions(driver);
                ////context.SendKeys(Keys.Control).Click(SwitchTab);
                //Actions action = new Actions(driver);
                //action.KeyDown(Keys.Control).MoveToElement(SwitchTab).Click().KeyUp(Keys.Control).Perform();
                //string newWindowHandle = driver.WindowHandles[1];
                //var newWindow = driver.SwitchTo().Window(newWindowHandle);

            }

        }
        #endregion
    }
}




