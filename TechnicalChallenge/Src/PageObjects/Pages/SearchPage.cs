using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
 
namespace TechnicalChallenge.Src.PageObjects.Pages
{
    public class SearchPage
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@aria-label, 'Search Google Maps')]")]
        public IWebElement SearchBox { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@aria-label, 'Search')]")]
        public IWebElement SearchButton { get; set; }

        public SearchPage ClickSearchButton()
        {
            SearchButton.Click();

            return this;
        }

        public SearchPage EnterSearchBoxValue(string boxValue)
        {
            SearchBox.SendKeys(boxValue);

            return this;
        }

        public SearchPage PerformSearch(string boxValue)
        {
            EnterSearchBoxValue(boxValue);// enters value passed in into search box
            ClickSearchButton();// clicks search

            return this;
        }
    }
}