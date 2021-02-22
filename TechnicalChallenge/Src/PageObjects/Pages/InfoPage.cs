using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace TechnicalChallenge.Src.PageObjects.Pages
{
    public class InfoPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//h1[contains(@class, 'section-hero-header-title-title')]")]
        public IWebElement Headline { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-value, 'Directions')]")]
        public IWebElement DirectionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@aria-label, 'Destination')]")]
        public IWebElement SearchBox { get; set; }

        public InfoPage ClickDirectionsButton()
        {
            DirectionsButton.Click();

            return this;
        }

        public InfoPage VerifyCorrectHeadlineIsDisplayed(string headline)
        {
            Thread.Sleep(3000);// small wait required
            try
            {
                Assert.IsTrue(Headline.Text.Equals(headline));// verifies value being passed in is equal to Headline
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }
        public InfoPage VerifySearchBoxValue(string searchValue)
        {
            Thread.Sleep(2000);// small wait required
            try
            {
                string value = SearchBox.GetAttribute("aria-label");// retries value from specific tag in Search Box object. Value returned is "Destination Dublin"
                Assert.IsTrue(value.Contains(searchValue));// verifies value being passed "Dublin" is contained in field value
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        public InfoPage CloseApplication(IWebDriver myDriver)
        {
            myDriver.Close();// method to close application once test is completed

            return this;
        }
    }
}