using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace TechnicalChallenge.Src.PageObjects.Pages
{
    class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//iframe[@class='widget-consent-frame']")]
        public IWebElement InitialFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'RveJvd snByac') and text()='I agree']")]
        public IWebElement IAgree { get; set; }

        public HomePage OpenApplication(IWebDriver myDriver)
        {
            myDriver.Url = "https://www.google.com/maps";
            myDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            try
            {
                myDriver.SwitchTo().Frame(InitialFrame);// switch to 'I agree' iframe
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            ClickIAgree();
            myDriver.SwitchTo().ParentFrame();//switch back to parent frame

            return this;
        }

        public HomePage ClickIAgree()
        {
            IAgree.Click();

            return this;
        }
    }
}