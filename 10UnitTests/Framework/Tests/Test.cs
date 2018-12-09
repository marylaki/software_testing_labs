using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    [TestFixture]
    public class Test
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void DepatureYesterday()
        {
            DateTime yesterdayDate = DateTime.Now.AddDays(-1);

            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Минск", "Париж");
            steps.SetDepartureDate(yesterdayDate);
            Assert.AreEqual("", steps.GetDepartureDate());
        }

        [Test]
        public void DepatureTomorrowBackDepartureToday()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            DateTime backDepartureDate = DateTime.Now;

            steps.OpenSearchPage();
            steps.ChooseRoundTrip();
            steps.SetFromCityToCity("Минск", "Москва");
            steps.SetDepartureDate(departureDate);
            steps.SetBackDepartureDate(backDepartureDate);
            Assert.AreEqual("", steps.GetBackDepartureDate());
        }

        [Test]
        public void BabiesInTrip()
        {
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.OpenPeopleSetting();
            steps.SetAdults(1);
            steps.SetBabies(2);
            Assert.IsTrue(steps.IsPopupShown());
            steps.SetAdults(2);
            steps.SetBabies(2);
            Assert.AreEqual(steps.GetCountOfPeople(),4);
            Assert.IsFalse(steps.IsPopupShown());
            steps.SetBabies(3);
            Assert.IsTrue(steps.IsPopupShown());
        }
        [Test]
        public void FromLondonToLondon()
        {
            DateTime departureDate = DateTime.Now;
            DateTime backDepartureDate = DateTime.Now.AddDays(4);
            steps.OpenSearchPage();
            steps.SetFromCityToCity("Лондон", "Лондон");
            steps.SetDepartureDate(departureDate);
            steps.SetBackDepartureDate(backDepartureDate);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsAllert());
        }
        [Test]
        public void GoodResult()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Лондон", "Париж");
            steps.SetDepartureDate(departureDate);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Лондон","Париж",departureDate));
        }
        [Test]
        public void TestSorting()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Лондон", "Париж");
            steps.SetDepartureDate(departureDate);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Лондон", "Париж", departureDate));
            steps.ChoosePriceSort();
            Assert.IsTrue(steps.CheckPriceSort());
            steps.ChooseRatingSort();
            Assert.IsTrue(steps.CheckRatingSort());
            steps.ChooseTimeSort();
            Assert.IsTrue(steps.CheckTimeSort());
        }
        [Test]
        public void TransferFilter()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Москва", "Владивосток");
            steps.SetDepartureDate(departureDate);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Москва", "Владивосток", departureDate));
            steps.ClickTransfer();
            steps.ChooseTransfer();
            Assert.IsTrue(steps.CheckTransferFilter());
        }
        [Test]
        public void Booking()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Рим", "Афины");
            steps.SetDepartureDate(departureDate);
            steps.OpenPeopleSetting();
            steps.SetAdults(3);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Рим", "Афины", departureDate));
            steps.ChooseFlight();
            Assert.IsTrue(steps.CheckCountPassangers(3));
            steps.SetContacts("mashka"+DateTime.Now.ToLocalTime()+"@mail.ru","0297293366","Лакевич Мария");
            steps.SetPassangerData(1, 'w',"lakevich","maryia","23.08.1998","13.11.2022","kh2286879");
            steps.SetPassangerData(2, 'm', "hlushko","aliaksandr","17.09.1998", "11.07.2022", "kh3584937");
            steps.SetPassangerData(3, 'w',"zhilinskaya","dziyana","21.07.1998", "25.10.2022","kh6864927");
            Assert.IsTrue(steps.CheckPassanger(3));
            steps.ClickBookingButton();
            steps.ClickAcceptAndPayButtons();
            Assert.IsTrue(steps.CheckHeader());
        }
        [Test]
        public void AirportsFilter()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Рига", "Киев");
            steps.SetDepartureDate(departureDate);
            steps.OpenPeopleSetting();
            steps.SetAdults(3);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Рига", "Киев", departureDate));
            steps.ClickAirportFilter();
            steps.ChooseAirport();
            Assert.IsTrue(steps.CheckDeparturePort());
        }
        [Test]
        public void AircompanyFilter()
        {
            DateTime departureDate = DateTime.Now.AddDays(1);
            steps.OpenSearchPage();
            steps.ChooseOneWayTrip();
            steps.SetFromCityToCity("Рига", "Киев");
            steps.SetDepartureDate(departureDate);
            steps.OpenPeopleSetting();
            steps.SetAdults(3);
            steps.ClickSearchButton();
            Assert.IsTrue(steps.IsRightResult("Рига", "Киев", departureDate));
            steps.ClickAircompanyFilter();
            steps.ChooseAircompany();
            Assert.IsTrue(steps.CheckAircompany());
        }
    }
}
