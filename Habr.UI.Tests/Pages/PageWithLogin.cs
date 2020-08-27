using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests
{
    public class PageWithLogin
    {
        private IWebDriver Driver { get; set; }

        public IWebElement ButtonGreen_UserMenu
        {
            get
            {
                //y.XPath("//*[@id='email_field']")); 
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/button"));
            }
        }
        public IWebElement ButtonNotifications
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]"));
            }
        }

        public IWebElement ProfileMenu_ButtonLoginOut
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));
            }
        }


    }
}
