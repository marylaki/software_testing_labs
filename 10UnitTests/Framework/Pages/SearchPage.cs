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

        [FindsBy(How = How.ClassName, Using = "preson_quant")]
        private IWebElement people { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "persons_select_popup")]
        private IWebElement peoplePopup { get; set; }

        [FindsBy(How = How.ClassName, Using = "infants-attention-popup")]
        private IWebElement peopleAttentionPopup { get; set; }
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
        public void SetDirectionOneWayTrip()
        {
            directions[0].Click();
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
            Thread.Sleep(20000);
        }
        public String GetDepartureDate()
        {
            return departureDate.Text;
        }
        public void OpenPeopleSettings()
        {
            people.Click();
            Thread.Sleep(2000);
        }
        public void SetAdults(int count)
        {
            if (count < 1)
                return;
            IWebElement adultsPan = peoplePopup.FindElement(By.XPath("//ul[@data-uil='quantity_adults']"));

            IWebElement plus = adultsPan.FindElement(By.ClassName("plus"));
            IWebElement minus = adultsPan.FindElement(By.ClassName("minus"));
            IWebElement countAdults = adultsPan.FindElement(By.ClassName("value"));
            int val;
            Int32.TryParse(countAdults.GetAttribute("value"), out val);
            if (val < count)
            {
                do
                {
                    plus.Click();
                    Thread.Sleep(300);
                    Int32.TryParse(countAdults.GetAttribute("value"), out val);
                } while (val != count);
            }
            if (val > count)
            {
                do
                {
                    minus.Click();
                    Thread.Sleep(300);
                    Int32.TryParse(countAdults.GetAttribute("value"), out val);
                } while (val != count);
            }
        }
        public void SetBabies(int count)
        {
            if (count < 0)
                return;
            IWebElement babiesPan = peoplePopup.FindElement(By.XPath("//ul[@data-uil='quantity_infants']"));

            IWebElement plus = babiesPan.FindElement(By.ClassName("plus"));
            IWebElement minus = babiesPan.FindElement(By.ClassName("minus"));
            IWebElement countBabies = babiesPan.FindElement(By.ClassName("value"));
            int val;
            Int32.TryParse(countBabies.GetAttribute("value"), out val);
            if (val < count)
            {
                for(int i=count-val; i!=0;i--)
                {
                    plus.Click();
                    Thread.Sleep(300);

                };
            }
            if (val > count)
            {
                for (int i = val-count; i != 0; i--)
                {
                    minus.Click();
                    Thread.Sleep(300);

                };
            }
        }
        public bool IsPeopleAttentionShowed()
        {
            return peopleAttentionPopup.GetCssValue("display") == "block";
        }
        public int getCountOfPeople()
        {
            IWebElement countAdults = peoplePopup.FindElement(By.XPath("//ul[@data-uil='quantity_adults']")).FindElement(By.ClassName("value"));
            IWebElement countBabies = peoplePopup.FindElement(By.XPath("//ul[@data-uil='quantity_infants']")).FindElement(By.ClassName("value"));
            IWebElement countChildren = peoplePopup.FindElement(By.XPath("//ul[@data-uil='quantity_children']")).FindElement(By.ClassName("value"));
            int valA,valCh,valB;
            Int32.TryParse(countAdults.GetAttribute("value"), out valA);
            Int32.TryParse(countBabies.GetAttribute("value"), out valB);
            Int32.TryParse(countChildren.GetAttribute("value"), out valCh);
            return valA + valB + valCh;
        }

    }
}
