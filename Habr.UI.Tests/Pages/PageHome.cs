using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Habr.UI.Tests.Pages
{
    public class PageHome : BasePage
    {
        public string Title => Driver.Title;
      
        public PageHome(IWebDriver driver) : base(driver)
        {
        }
                  

        public void GoHomePage()
        {
            Driver.Navigate().GoToUrl(MainAddress);
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







