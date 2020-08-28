using Habr.UI.Tests.Pages;
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
        public PageWithLogin(IWebDriver driver)
        {
            Driver = driver;


        }
        private IWebDriver Driver { get; set; }


        public IWebElement ButtonGreen
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
                return Driver.FindElement(By.ClassName("btn btn medium btn navbar tracker"));
            }
        }
        public IWebElement ButtonLoginOut_UserMenu
        {
            get
            {
                //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a")
                //By.CssSelector("body > div.layout > div.layout__row.layout__row_navbar > div > div > div.main - navbar__section.main - navbar__section_right > div > div > ul > li:nth - child(7) > a"));
                return Driver.FindElement(By.Name("Выйти"));
            }
        }
        public IWebElement ButtonLogin
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='login']"));
            }
        }


        public void ClickButtonLoginOut()
        {
            PageWithLogin pageLogin = new PageWithLogin(Driver);

            pageLogin.ButtonGreen.Click();

            ////scroll bar down

            ////System.setProperty("webdriver.chrome.driver", "G://chromedriver.exe");
            ////driver = new ChromeDriver();
            ////JavascriptExecutor js = (JavascriptExecutor)driver;
            ////Find element by link text and store in variable "Element"        		
            ////WebElement Element = driver.findElement(By.linkText("Linux"));

            ////This will scroll the page till the element is found		
            ////js.executeScript("arguments[0].scrollIntoView();", Element); 2: 

            //                       //To scroll down the web page by the visibility of the element.

            //JavascriptExecutor js = (JavascriptExecutor)Driver;
            //js.executeScript("arguments[0].scrollIntoView();", ButtonLoginOut_UserMenu);


            //pageLogin.ButtonLoginOut_UserMenu.Click();

            if (pageLogin.ButtonLoginOut_UserMenu.Displayed)
            {
                pageLogin.ButtonLoginOut_UserMenu.Click();
            }
            else
            {
                Driver.Close();
            }


            Driver.Navigate().Refresh();

        }

        public void CheckNotifications()
        {
            PageWithLogin pageLogin = new PageWithLogin(Driver);

            pageLogin.ButtonNotifications.Click();
            //Driver.FindElement(By.ClassName("page-header__title");

        }




    }



    internal class JavascriptExecutor
    {
    }
}

