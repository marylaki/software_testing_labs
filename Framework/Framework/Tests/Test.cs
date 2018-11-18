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
        private DateTime departureDate = DateTime.Now.AddDays(1);
        private DateTime backDepartureDate = DateTime.Now;

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
        public void DepatureTomorrowBackDepartureToday()
        {
            steps.OpenSearchPage();
            steps.ChooseRoundTrip();
            steps.SetFromCityToCity("Минск", "Москва");
            steps.SetDepartureDate(departureDate);
            steps.SetBackDepartureDate(backDepartureDate);
            Assert.AreEqual("", steps.GetBackDepartureDate());
        }
    }
}
