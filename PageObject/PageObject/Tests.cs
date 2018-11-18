using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Threading;
using PageObject.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Test
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
           
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void YesterdayDepartureDate()
        {
            driver.Url = "http://bilet.aviakassa.by/";
            SearchPage searchPage = new SearchPage();
            PageFactory.InitElements(driver, searchPage);

            searchPage.oneWay.Click();
            Thread.Sleep(1000);
            
            searchPage.departure.Clear();
            searchPage.departure.SendKeys("Лондон");
            Thread.Sleep(1000);
            searchPage.departure.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            searchPage.arrival.Clear();
            searchPage.arrival.SendKeys("Москва");
            Thread.Sleep(1000);
            searchPage.arrival.SendKeys(Keys.Enter);

            searchPage.departureDate.Click();
            Thread.Sleep(1000);

            Assert.AreEqual(false,searchPage.PickDate(DateTime.Now.AddDays(-1)));
            
        }
    }
}