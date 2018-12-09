using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class SearchingPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "allert-block")]
        private IWebElement Message;
        public SearchingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public String GetAllertMessage()
        {
            return Message.FindElement(By.TagName("p")).Text;
        }
    }
}
