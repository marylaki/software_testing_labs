using Framework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Steps
{
    class Steps
    {
        private IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.Driver.GetDriverInstance();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public void OpenSearchPage()
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.OpenPage();
        }

        public void ChooseRoundTrip()
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetDirectionRoundTrip();
        }
        public void SetFromCityToCity(String departureCity, String arrivalCity)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetDepartureCity(departureCity);
            searchPage.SetArrivalCity(arrivalCity);
        }

        public void SetDepartureDate(DateTime date)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.PickDepartureDate(date);
            Thread.Sleep(1000);
        }
        public void SetBackDepartureDate(DateTime date)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.PickBackDepartureDate(date);
            Thread.Sleep(1000);
        }
        public string GetBackDepartureDate()
        {
            SearchPage searchPage = new SearchPage(driver);
            return searchPage.GetBackDepartureDate();
        }

    }
}
