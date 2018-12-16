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
    class BookingPage
    {
        private IWebDriver driver;
        
        [FindsBy(How = How.ClassName, Using = "one-passenger-data")]
        private IList<IWebElement> passengers;
        [FindsBy(How = How.ClassName, Using = "js-user-email")]
        private IWebElement emailField;

        [FindsBy(How = How.ClassName, Using = "valid_phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement nameField;
        
        [FindsBy(How = How.ClassName, Using = "js-pre-book-button")]
        private IWebElement bookingButton;
        public BookingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
       public bool CheckCountPassengers( int count)
        {
            return passengers.Count == count;
        }
        public void SetGender(int n,int g)
        {
            passengers[n - 1].FindElements(By.ClassName("iCheck-helper"))[g].Click();
            Thread.Sleep(200);
        }
        public void SetLastName(int n, String name)
        {
            passengers[n - 1].FindElement(By.ClassName("latinName")).SendKeys(name);
            Thread.Sleep(200);
        }
        public void SetName(int n, String name)
        {
            passengers[n - 1].FindElement(By.ClassName("firstnameLength")).SendKeys(name);
            Thread.Sleep(200);
        }
        public void SetBDay(int n, String date)
        {
            string[] dat = date.Split('.');
            passengers[n - 1].FindElement(By.ClassName("js-day")).SendKeys(dat[0]);
            Thread.Sleep(200);
            passengers[n - 1].FindElement(By.ClassName("js-month")).SendKeys(dat[1]);
            Thread.Sleep(200);
            passengers[n - 1].FindElement(By.ClassName("year")).SendKeys(dat[2]);
            Thread.Sleep(200);
        }
        public void SetExpireDate(int n,string date)
        {
            try
            {
                string[] dat = date.Split('.');
                passengers[n - 1].FindElement(By.ClassName("expiration-date-col")).FindElement(By.ClassName("js -day")).SendKeys(dat[0]);
                Thread.Sleep(200);
                passengers[n - 1].FindElement(By.ClassName("expiration-date-col")).FindElement(By.ClassName("js-month")).SendKeys(dat[1]);
                Thread.Sleep(200);
                passengers[n - 1].FindElement(By.ClassName("expiration-date-col")).FindElement(By.ClassName("year")).SendKeys(dat[2]);
                Thread.Sleep(200);
            }
            catch { }
        }
        public void SetPassport(int n, string passport)
        {
            try
            {
                passengers[n - 1].FindElement(By.ClassName("valid_docnum")).SendKeys(passport);
                Thread.Sleep(200);
            }
            catch { }
        }
        public void SetContackt(string email,string phone,string name)
        {
            try
            {
                emailField.SendKeys(email);
                Thread.Sleep(200);
                phoneField.SendKeys(phone);
                Thread.Sleep(200);
                nameField.SendKeys(name);
            }
            catch { }
        }
        public void ClickBooking()
        {
            bookingButton.Click();
            Thread.Sleep(30000);
        }
    }
}
