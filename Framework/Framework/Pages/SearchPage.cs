using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class SearchPage
    {
        private const string BASE_URL = "http://bilet.aviakassa.by/";

        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "iradio_minimal")]
        private IList<IWebElement> directions;

        [FindsBy(How = How.Id, Using = "from_name")]
        private IWebElement departure { get; set; }

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement arrival { get; set; }

        [FindsBy(How = How.Id, Using = "departure_date")]
        private IWebElement departureDate { get; set; }

        [FindsBy(How = How.Id, Using = "departure_date_1")]
        private IWebElement backDepartureDate { get; set; }

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement _datePicker { get; set; }

        [FindsBy(How = How.ClassName, Using = "search_button")]
        private IWebElement searchButton { get; set; }

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void SetDirectionRoundTrip()
        {
            directions[1].Click();
        }

        public void SetDepartureCity(String City)
        {
            departure.Clear();
            departure.SendKeys(City);
            Thread.Sleep(1500);
            departure.SendKeys(Keys.Enter);
            Thread.Sleep(1500);
        }

        public void SetArrivalCity(String City)
        {
            arrival.Clear();
            arrival.SendKeys(City);
            Thread.Sleep(1500);
            arrival.SendKeys(Keys.Enter);
            Thread.Sleep(1500);
        }

        public bool PickDepartureDate(DateTime date)
        {
            departureDate.Click();
            Thread.Sleep(1000);
            var weeks = _datePicker.FindElements(By.ClassName("day_td"));
            foreach (var el in weeks)
            {
                if (el.GetAttribute("data-month") == (date.Month - 1).ToString())
                {
                    var link = el.FindElement(By.ClassName("ui-state-default"));
                    if (link.Text == date.Day.ToString())
                    {
                        link.Click();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PickBackDepartureDate(DateTime date)
        {
            try
            {
                backDepartureDate.Click();
                Thread.Sleep(1000);
                var weeks = _datePicker.FindElements(By.ClassName("day_td"));
                foreach (var el in weeks)
                {
                    if (el.GetAttribute("data-month") == (date.Month - 1).ToString())
                    {
                        var link = el.FindElement(By.ClassName("ui-state-default"));
                        if (link.Text == date.Day.ToString())
                        {
                            link.Click();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch { return false; }
        }
        public String GetBackDepartureDate()
        {
            return backDepartureDate.Text;
        }
        public void SearchButtonClick()
        {
            searchButton.Click();
            Thread.Sleep(100);
        }
    }
}
