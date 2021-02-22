using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnicalChallenge;
using TechnicalChallenge.Src.PageObjects.Pages;

namespace SeleniumBasics
{
    [TestFixture]
    public class GoogleMapsTests
    {
        [Test]
        [Category("Google Maps")]
        [Category("Dublin")]
        public void Google_Maps_Tests_Dublin()
        {
            IWebDriver _driver = new ChromeDriver();// opens new instance of chromedriver
            var mapSearch = "Dublin";// parameter for value we want to pass in to multiple areas of the test

            var homePage = new HomePage();
            PageFactory.InitElements(_driver, homePage);//initialises elements of HomePage page objects
            homePage.OpenApplication(_driver);

            var searchPage = new SearchPage();
            PageFactory.InitElements(_driver, searchPage);
            searchPage.PerformSearch(mapSearch);

            var infoPage = new InfoPage();
            PageFactory.InitElements(_driver, infoPage);
            infoPage.VerifyCorrectHeadlineIsDisplayed(mapSearch);
            infoPage.ClickDirectionsButton();
            infoPage.VerifySearchBoxValue(mapSearch);
            infoPage.CloseApplication(_driver);
        }
    }
}