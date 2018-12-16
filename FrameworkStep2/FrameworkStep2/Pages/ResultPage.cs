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
    class ResultPage
    {
        private IWebDriver driver;
        
        [FindsBy(How = How.ClassName, Using = "segment-block__item")]
        private IList<IWebElement> OfferList;
        
        [FindsBy(How = How.ClassName, Using = "item-block")]
        private IList<IWebElement> PriceList;

        [FindsBy(How = How.XPath, Using = "//a[@data-uil='sort-price']")]
        private IWebElement priceSortButton;

        [FindsBy(How = How.XPath, Using = "//a[@data-uil='sort-rating']")]
        private IWebElement ratingSortButton;

        [FindsBy(How = How.XPath, Using = "//a[@data-uil='sort-duration']")]
        private IWebElement timeSortButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='#tabs-1']")]
        private IWebElement transfer;
        
        [FindsBy(How = How.ClassName, Using = "filters-item")]
        private IWebElement transferPanel;

        [FindsBy(How = How.XPath, Using = "//a[@href='#tabs-3']")]
        private IWebElement airport;
        
        [FindsBy(How = How.ClassName, Using = "filters-item_3")]
        private IWebElement airportPanel;
        [FindsBy(How = How.XPath, Using = "//a[@href='#tabs-4']")]
        private IWebElement aircompany;

        [FindsBy(How = How.ClassName, Using = "filters-item_4")]
        private IWebElement aircompanyPanel;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public bool CheckDepertureCity(string departureCity)
        {
            
            foreach(IWebElement offer in OfferList)
            {
                IWebElement info = offer.FindElements(By.ClassName("col-m-4"))[0];
                IWebElement data = info.FindElements(By.TagName("li"))[2];
                string city = data.Text;
                if (!city.Contains(departureCity))
                    return false;
            }
            return true;
        }
        public bool ChecktoCity(string toCity)
        {

            foreach (IWebElement offer in OfferList)
            {
                IWebElement info = offer.FindElements(By.ClassName("col-m-4"))[2];
                IWebElement data = info.FindElements(By.TagName("li"))[2];
                string city = data.Text;
                if (!city.Contains(toCity))
                    return false;
            }
            return true;
        }
        public bool CheckArrivalDate(DateTime date)
        {

            foreach (IWebElement offer in OfferList)
            {
                IWebElement info = offer.FindElements(By.ClassName("col-m-4"))[0];
                IWebElement data = info.FindElements(By.TagName("li"))[1];
                string arDate = data.Text;
                if (!arDate.Contains(date.ToLongDateString().Substring(0, date.ToLongDateString().Length - 3)))
                    return false;
            }
            return true;
        }
        public void ClickPriceSort()
        {
            priceSortButton.Click();
            Thread.Sleep(1000);
        }
        public void ClickRatingSort()
        {
            ratingSortButton.Click();
            Thread.Sleep(3000);
        }
        public void ClickTimeSort()
        {
            timeSortButton.Click();
            Thread.Sleep(1000);
        }
        public bool CheckPriceSort()
        {
            List<int> pricesBYN = new List<int>();
            foreach (IWebElement offer in PriceList)
            {
                IWebElement price = offer.FindElement(By.ClassName("BYN"));
                string priceval = price.Text.Substring(0, price.Text.Length-4);
                int value;
                if (Int32.TryParse(priceval, out value))
                {
                    try { offer.FindElement(By.ClassName("label-corner")); }
                    catch {
                        pricesBYN.Add(value);
                    }
                    
                        
                }
            }
            List<int> sortedprices = pricesBYN.OrderBy(p=>p).ToList();

            return sortedprices.SequenceEqual(pricesBYN);
        }
        public bool CheckRatingSort()
        {
            List<Double> ratings = new List<Double>();
            foreach (IWebElement offer in PriceList)
            {
                IWebElement rating = offer.FindElement(By.ClassName("ac_raiting")).FindElement(By.TagName("span"));
                string ratingval = rating.GetAttribute("style").Substring(7, rating.GetAttribute("style").Length - 9).Replace('.',',');
                Double value;
                if (Double.TryParse(ratingval, out value))
                {
                    try { offer.FindElement(By.ClassName("label-corner")); }
                    catch
                    {
                        ratings.Add(value);
                    }
                }
            }
            List<Double> sortedpratings = ratings.OrderByDescending(p => p).ToList();

            return sortedpratings.SequenceEqual(ratings);
        }
        public bool CheckTimeSort()
        {
            foreach (IWebElement offer in PriceList)
            {
                List<int> minetsFying = new List<int>();
                IList<IWebElement> times = offer.FindElements(By.ClassName("flight-time"));
                foreach(IWebElement time in times )
                {
                    string[] timeParts = time.Text.Split(' ');
                    int hours, min;
                    Int32.TryParse(timeParts[0], out hours);
                    Int32.TryParse(timeParts[2], out min);
                    minetsFying.Add(hours * 60 + min);
                }
                List<int> sortedminetsFying = minetsFying.OrderBy(p => p).ToList();

                if(!sortedminetsFying.SequenceEqual(minetsFying))
                    return false;
            }
            return true;
        }
        public void ClickTransfer()
        {
            transfer.Click();
            Thread.Sleep(300);
        }
        public void Choose1Transfer()
        {
            transferPanel.FindElements(By.ClassName("iCheck-helper"))[2].Click();
            Thread.Sleep(2000);
        }
        public bool CheckTransfer()
        {
            foreach (IWebElement offer in OfferList)
            {                
                if (!offer.FindElement(By.ClassName("rtl-text")).Text.Contains("1 пересадка"))
                    return false;
            }
            return true;
        }
        public void ChooseFlight()
        {
            PriceList[0].FindElement(By.ClassName("rec_submit")).Click();
            Thread.Sleep(20000);
        }
        public void ClickAirport()
        {
            airport.Click();
            Thread.Sleep(300);
        }
        public void ChoseDeparturePort()
        {
            airportPanel.FindElements(By.ClassName("col-4"))[1].FindElements(By.TagName("ins"))[1].Click();
            Thread.Sleep(3000);
        }
        public bool CheckDeparturePort()
        {
            string airprt=airportPanel.FindElements(By.ClassName("col-4"))[1].FindElement(By.ClassName("checked")).FindElement(By.TagName("input")).GetAttribute("value");
            foreach (IWebElement offer in OfferList)
            {
                IWebElement info = offer.FindElements(By.ClassName("col-m-4"))[2];
                IWebElement data = info.FindElements(By.TagName("li"))[2].FindElement(By.ClassName("tooltip-link"));
                string port = data.Text;
                if (port!=airprt)
                    return false;
            }
            return true;

        }
        public void ClickAircompany()
        {
            aircompany.Click();
            Thread.Sleep(300);
        }
        public void ChoseAircompany()
        {
            aircompanyPanel.FindElements(By.TagName("ins"))[1].Click();
            Thread.Sleep(4000);
        }
        public bool CheckAircompany()
        {
            string airprt = aircompanyPanel.FindElements(By.ClassName("col-12"))[1].FindElement(By.ClassName("checked")).FindElement(By.TagName("input")).GetAttribute("value");
            foreach (IWebElement offer in OfferList)
            {
                IWebElement info = offer.FindElement(By.ClassName("col-m-12"));
                IWebElement data = info.FindElement(By.TagName("strong"));
                string port = data.Text;
                if (!port.Contains(airprt))
                    return false;
            }
            return true;

        }
    }
}
