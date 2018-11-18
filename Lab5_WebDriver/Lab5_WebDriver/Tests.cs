using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_WebDriver
{
    [TestFixture]
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void fromLondon_toLondon()
        {
            driver.Url = "http://bilet.aviakassa.by/";
            
            IWebElement searchForm = driver.FindElement(By.ClassName("inner-search"));
            var rb = searchForm.FindElements(By.ClassName("iradio_minimal"));
            foreach (var i in rb){
                try
                {
                    i.FindElement(By.Id("oneway"));
                    i.Click();
                    break;
                }
                catch { }
            }
            searchForm = driver.FindElement(By.ClassName("new_search_form"));
            IWebElement departure = searchForm.FindElement(By.Id("from_name"));
            departure.Clear();
            departure.SendKeys("Лондон");
            Thread.Sleep(1000);
            departure.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement arrival = searchForm.FindElement(By.Id("to_name"));
            arrival.Clear();
            arrival.SendKeys("Лондон");
            Thread.Sleep(1000);
            arrival.SendKeys(Keys.Enter);

            searchForm.FindElement(By.Id("departure_date")).Click() ;
            Thread.Sleep(2000);
            var weeks = driver.FindElements(By.ClassName("day_td"));
            foreach (var el in weeks)
            {
                if (el.GetAttribute("data-month") == (DateTime.Now.Month-1).ToString())
                {
                    var link = el.FindElement(By.ClassName("ui-state-default"));
                    if (link.Text == DateTime.Now.Day.ToString())
                    {
                        link.Click();
                        break;
                    }
                }
            }
            searchForm.FindElement(By.ClassName("search_button")).Click();
            Thread.Sleep(3000);
            Assert.AreNotEqual(null, driver.FindElement(By.ClassName("allert-block")));
            

        }
    }
}
