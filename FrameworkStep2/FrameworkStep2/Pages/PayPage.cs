using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class PayPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "oplata_steps")]
        private IWebElement header;
        public PayPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public bool GetHeaderMessage()
        {
            return header.FindElement(By.TagName("strong")).Text.Contains("ОПЛАТА ЗАКАЗА");
        }
    }
}
