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
    class BookedResultPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "confirm-btn_wrapper")]
        private IWebElement acceptButton;
        [FindsBy(How = How.ClassName, Using = "js-book-button")]
        private IWebElement payButton;
        [FindsBy(How = How.ClassName, Using = "one-passenger-data")]
        private IList<IWebElement> bookedTicket;
        public BookedResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public void ClickAccept()
        {
            acceptButton.Click();
            Thread.Sleep(300);
        } 
        public void ClickPay()
        {
            payButton.Click();
            Thread.Sleep(30000);
        }
        public bool CheckPassanger(int count)
        {
            return bookedTicket.Count() == count;
        }
    }
}
