using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Habr.UI.Tests.Pages
{
    public class Home : BasePage
    {
        internal readonly object ButtonWritePostFirstElement;

        //internal readonly object ButtonPost;

        public string Title => Driver.Title;

        public Home(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement LogoMenuElement => Driver.FindElement(By.XPath("//span[@id='dropdown-control']"));

        public IWebElement DownMenuElementHabr => Driver.FindElement(By.XPath("//a[@class='service' and @href='/']"));
        public IWebElement DownMenuElementQA => Driver.FindElement(By.XPath("//h4[@class='service-title']"));

        public IWebElement UpPanelSectionAuthor => Driver.FindElement(By.XPath("//a[@class='bmenu__conversion']"));

        //href="/ru/sandbox/add/"


        public void GoHomePage()
        {
            Driver.Navigate().GoToUrl(MainAddress);
        }

        public void LogoMenuClickQA()
        {
            //Home page = new Home(Driver);
            GoHomePage();
            LogoMenuElement.Click();
            
            DownMenuElementQA.Click();
            Thread.Sleep(2000);
        }

        public void LogoMenuClickHabr()
        {
            Home page = new Home(Driver);
            GoHomePage();
            LogoMenuElement.Click();
            DownMenuElementHabr.Click();
            Thread.Sleep(2000);

        }

        ////internal void ClickButtonWritePostFirstElement()
        //{
        //    throw new NotImplementedException();
        //}
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







