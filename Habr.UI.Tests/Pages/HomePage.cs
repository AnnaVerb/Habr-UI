using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class HomePage
    {
        private IWebDriver Driver { get; set; }
        private static readonly string MainAddress = "https://habr.com/ru/";
        public string Title
        {
            get
            {
                return Driver.Title;
            }
        }

        public IWebElement ButtonLogo
        {
            get
            {
                return Driver.FindElement(By.ClassName("logo"));
            }
        }

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoHomePage()
        {
            Driver.Navigate().GoToUrl(MainAddress);            
        }
    }
}
