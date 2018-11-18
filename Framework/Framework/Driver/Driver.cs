using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    class Driver
    {
        private static IWebDriver _driver;
        private Driver() { }
        public static IWebDriver GetDriverInstance()
        {
            if(_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }
        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
