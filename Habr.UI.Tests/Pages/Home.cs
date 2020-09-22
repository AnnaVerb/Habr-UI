using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Habr.UI.Tests.Pages
{
    public class Home : BasePage
    {
        internal readonly object ButtonWritePost;

        public string Title => Driver.Title;

        public Home(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement LogoMenuElement => Driver.FindElement(By.XPath("//span[@id='dropdown-control']"));

        public IWebElement DownMenuElementHabr => Driver.FindElement(By.XPath("//a[@class='service' and @href='/']"));
        public IWebElement DownMenuElementQA => Driver.FindElement(By.XPath("//h4[@class='service-title']"));
        //[contains(@id, ‘er - messa’)]

        // Syntax: //tag[starts-with(@attribute, ‘value‘)]

        //Example: //input[starts-with(@id, ‘user’)]

        //public IWebElement DownMenuElementHabr => Driver.FindElement(By.XPath(""));



        public void GoHomePage()
        {
            Driver.Navigate().GoToUrl(MainAddress);
        }

        public void LogoMenuClickQA()
        {
            Home page = new Home(Driver);
            GoHomePage();
            LogoMenuElement.Click();
            Thread.Sleep(2000);
            DownMenuElementQA.Click();
            Thread.Sleep(2000);

        }
    }
}




////scroll bar down

////System.setProperty("webdriver.chrome.driver", "G://chromedriver.exe");
////driver = new ChromeDriver();
////JavascriptExecutor js = (JavascriptExecutor)driver;
////Find element by link text and store in variable "Element"        		
////WebElement Element = driver.findElement(By.linkText("Linux"));

////This will scroll the page till the element is found		
////js.executeScript("arguments[0].scrollIntoView();", Element); 2: 

//To scroll down the web page by the visibility of the element.

//JavascriptExecutor js = (JavascriptExecutor)Driver;
//js.executeScript("arguments[0].scrollIntoView();", ButtonLoginOut_UserMenu);







