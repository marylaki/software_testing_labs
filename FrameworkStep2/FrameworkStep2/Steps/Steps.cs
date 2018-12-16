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
        public void ChooseOneWayTrip()
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetDirectionOneWayTrip();
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
        public string GetDepartureDate()
        {
            SearchPage searchPage = new SearchPage(driver);
            return searchPage.GetDepartureDate();
        }
        public void OpenPeopleSetting()
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.OpenPeopleSettings();
        }
        public void SetAdults(int count)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetAdults(count);
        }
        public void SetBabies(int count)
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetBabies(count);
        }
        public bool IsPopupShown(){
            SearchPage searchPage = new SearchPage(driver);
            return searchPage.IsPeopleAttentionShowed();
        }
        public int GetCountOfPeople()
        {
            SearchPage searchPage = new SearchPage(driver);
            return searchPage.getCountOfPeople();
        }
        public void ClickSearchButton()
        {
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SearchButtonClick();
        }
        public bool IsAllert()
        {
            SearchingPage searchingPage = new SearchingPage(driver);
            return searchingPage.GetAllertMessage()!="";
        }
        public bool IsRightResult(string fromCity,string toCity,DateTime departureDate)
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckDepertureCity(fromCity) && resultPage.ChecktoCity(toCity) && resultPage.CheckArrivalDate(departureDate);
        }
        public bool CheckPriceSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckPriceSort();
        }
        public void ChoosePriceSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickPriceSort();
        }
        public void ChooseRatingSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickRatingSort();
        }
        public bool CheckRatingSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckRatingSort();
        }
        public void ChooseTimeSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickTimeSort();
        }
        public bool CheckTimeSort()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckTimeSort();
        }
        public void ClickTransfer()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickTransfer();
        }
        public void ChooseTransfer()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.Choose1Transfer();
        }
        public bool CheckTransferFilter()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckTransfer();
        }
        public void ChooseFlight()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ChooseFlight();
        }
        public bool CheckCountPassangers(int count)
        {
            BookingPage bookingPage = new BookingPage(driver);
            return bookingPage.CheckCountPassengers(count);
        }
        public void SetPassangerData(int num,char gender,string lastName,string name,string date,string expdate,string passport)
        {
            BookingPage bookingPage = new BookingPage(driver);
            bookingPage.SetGender(num, (gender == 'm') ? 0 : 1);
            bookingPage.SetLastName(num, lastName);
            bookingPage.SetName(num, name);
            bookingPage.SetBDay(num, date);
            bookingPage.SetExpireDate(num, expdate);
            bookingPage.SetPassport(num, passport);
        }
        public void SetContacts(string email, string phone, string name)
        {
            BookingPage bookingPage = new BookingPage(driver);
            bookingPage.SetContackt(email, phone, name);
        }
        public void ClickBookingButton()
        {
            BookingPage bookingPage = new BookingPage(driver);
            bookingPage.ClickBooking();
        }
        public bool CheckPassanger(int count)
        {
            BookedResultPage bookedPage = new BookedResultPage(driver);
            return bookedPage.CheckPassanger(count);
        }
        public void ClickAcceptAndPayButtons()
        {
            BookedResultPage bookedPage = new BookedResultPage(driver);
            bookedPage.ClickAccept();
            bookedPage.ClickPay();
        }
        public bool CheckHeader()
        {
            PayPage payPage = new PayPage(driver);
            return payPage.GetHeaderMessage();
        }
        public void ClickAirportFilter()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickAirport();
        }
        public void ChooseAirport()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ChoseDeparturePort();
        }
        public bool CheckDeparturePort()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckDeparturePort();
        }
        public void ClickAircompanyFilter()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ClickAircompany();
        }
        public void ChooseAircompany()
        {
            ResultPage resultPage = new ResultPage(driver);
            resultPage.ChoseAircompany();
        }
        public bool CheckAircompany()
        {
            ResultPage resultPage = new ResultPage(driver);
            return resultPage.CheckAircompany();
        }
    }
}
