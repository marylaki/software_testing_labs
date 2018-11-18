using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject.Pages
{
    class SearchPage
    {
        [FindsBy(How = How.XPath, Using = "//div[.//input[@id='oneway']]//ins")]
        public IWebElement oneWay { get; set; }

        [FindsBy(How = How.Id, Using = "from_name")]
        public IWebElement departure { get; set; }

        [FindsBy(How = How.Id, Using = "to_name")]
        public IWebElement arrival { get; set; }

        [FindsBy(How = How.Id, Using = "departure_date")]
        public IWebElement departureDate { get; set; }
        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement _datePicker  { get; set; }

        [FindsBy(How = How.ClassName, Using = "search_button")]
        public IWebElement searchButton { get; set; }

        public bool PickDate(DateTime date)
        {
            var weeks = _datePicker.FindElements(By.ClassName("day_td"));
            foreach (var el in weeks)
            {
                if (el.GetAttribute("data-month") == (date.Month-1).ToString())
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
    }
}
