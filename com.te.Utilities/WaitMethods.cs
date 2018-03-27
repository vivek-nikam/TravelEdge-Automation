using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using ADX_Regression.Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ADX_Regression.ControlUnit
{
    /// <summary>
    /// <Browser waits>Class for all the wait commands for the app</Browser>
    /// <Methods>Important methods common for all the modules</Methods>
    /// </summary>
    class WaitMethods : GetBrowser
    {
        public WaitMethods()
        {
            PageFactory.InitElements(driver, this);
        }
        //Common wait object of the webdriver wait class
        WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        //Element to wait for when the browser launches and loads the login page
        [FindsBy(How = How.XPath, Using = "html/body/div[1]")]
        public IWebElement Uat_flag { get; set; }

        //string loading = "return document.readyState";
        public Object ExecuteJavaScript(string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public void Login_Wait()
        {
            try
            {
                w.Until(d =>
                {
                    if (Uat_flag.Text == "UAT")
                        return true;
                    return false;
                });
            }
            catch
            {
                return;
            }
        }

        public void Wait(By element)
        {
            try
            {
                w.Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch
            {
                return;
            }

        }

        public void Wait_Invisible(By element, string text)
        {
            try
            {
                w.Until(ExpectedConditions.InvisibilityOfElementWithText(element, text));
            }
            catch
            {
                return;
            }

        }

        public void Typeahead_select()
        {
            try
            {
                w.Until(ExpectedConditions.ElementIsVisible(By.TagName("strong")));
                Actions act = new Actions(driver);
                act.SendKeys(Keys.ArrowDown);
                act.SendKeys(Keys.Enter).Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        public void Typeahead_SelectHotel()
        {
            try
            {
                w.Until(ExpectedConditions.ElementIsVisible(By.TagName("div")));
                Actions act = new Actions(driver);
                act.SendKeys(Keys.ArrowDown);
                act.SendKeys(Keys.Enter).Perform();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        public void Dropdown_Value(IWebElement name, String value)
        {
            SelectElement ele = new SelectElement(name);
            ele.SelectByValue(value);
        }

        public void Dropdown_Text(IWebElement name, String value)
        {
            SelectElement ele = new SelectElement(name);
            ele.SelectByText(value);
        }

        //Method to filter by Airline Name in Matrix
        public void Matrix(string data)
        {
            List<string> matchingLinks = new List<string>();

            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                string text = link.Text;
                if (text == data)
                {
                    matchingLinks.Add(text);
                }

            }
            foreach (string linktext in matchingLinks)
            {
                IWebElement element = driver.FindElement(By.PartialLinkText(linktext));
                Wait(By.XPath("(//a[@class = 'on-matrix-filter'])[3]"));
                element.Click();

            }
        }

        //Method to Navigate through different linktext in Cruise Details page under Deck Plans, to view Fare Codes and to view commission
        public void Links_Method(string data)
        {
            List<string> matchingLinks = new List<string>();

            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                string text = link.Text;
                if (text == data)
                {
                    matchingLinks.Add(text);
                }

            }
            foreach (string linktext in matchingLinks)
            {
                IWebElement element = driver.FindElement(By.PartialLinkText(linktext));
                element.Click();

            }
        }

        //Method to Navigate through the various Checkboxes under Select Fare Codes and Select a Fare Code based on the Value
        public void SelectFareCode(string data)
        {
            //List<string> checkboxes = new List<string>();
            ReadOnlyCollection<IWebElement> boxes = driver.FindElements(By.XPath("//input[@class = 'fare-code']"));

            foreach (IWebElement box in boxes)
            {
                string value = box.GetAttribute("value");
                if(value == data)
                {
                    box.Click();
                }               
            }
            
        }

        //Method to Hover on the available Cabin Category and Price Information
        public void CabinCategory_Hover(string data)
        {
            List<string> cabins = new List<string>();
            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//div[@class = 'sailing-cabin-category-name sailing-cabin-category-results-name']"));

            foreach (IWebElement link in links)
            {
                string text = link.Text;
                if(text == data)
                {
                    cabins.Add(text);
                }

            }
            foreach (string linktext in cabins)
            {
                IWebElement element = driver.FindElement(By.LinkText(linktext));
                Actions act = new Actions(driver);
                act.MoveToElement(element).Perform();

            }
        }

        //Method used for Hotel drag and drop
        public void Hotel_DragAndDrop(IWebElement element, int x, int y)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//a[@class = 'ui-slider-handle ui-state-default ui-corner-all']"));
            int count = elements.Count;
            for (int i = 0; i < count; i++)
            {
                Point point = element.Location;
                int offsetx = point.X;
                if (offsetx != 0)
                {
                    Actions actions = new Actions(driver);
                    actions.ClickAndHold(element);
                    actions.MoveByOffset(x, y).Release().Perform();
                    break;
                }
            }
        }

        //Method to Select the Book button in Cabin category section
        public void Cruise_CabinCategory(int bookCruise)
        {
            ReadOnlyCollection<IWebElement> cruise = driver.FindElements(By.XPath("//button[contains(@class,'btn-add-cabin-category')]"));
            IWebElement book = cruise.ElementAt(bookCruise);
            book.Click();
        }

    }
}





    

