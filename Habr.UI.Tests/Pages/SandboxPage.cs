using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class SandboxPage : BasePage
    {

        public SandboxPage(IWebDriver driver) : base(driver)
        {

        }


        //check
        public IWebElement ButtonWritePostFirstElement => Driver.FindElement(By.XPath("//*['Create post']//[@class='nav - links__item - link']"));




        ////*['Create post']//[@class='nav - links__item - link']"));

        //*['Написать пост']//h2[text()='Как всё произойдет']"));
        //"//h2[contains(text()='Как всё произойдет')]"));
        //*['Написать пост']//h2[text()='Как всё произойдет']

        //h2[text()='Как всё произойдет']
        //Example: //input[contains(@id, ‘er-messa’)] ‘value‘)]

        //Example: //input[contains(@id, ‘er-messa’)]
        //a[@href ='/ru/sandbox/add/']//following::h2[1]


        public IWebElement FieldPostList//check
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='posts_list']"));

                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");
            }
        }

        public IWebElement MenuMyPosts => Driver.FindElement(By.XPath("//div[@class='tabs']//a[4]"));

        //public IWebElement ElementMyPosts => return Driver.FindElement(By.XPath("//div[@class='tabs']//a[4]"));

        ////h3[@class='tabs-menu__item-text']"));
        //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");           

        ////h3[@class='tabs-menu__item-text']"));
        //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");



        //methods
        public void ClickButtonWritePostFirstElementOnPage()//Как всё произойдет
        {
            Home page = new Home(Driver);
            page.ClickButtonWriteTopic();

            SandboxPage pagesand = new SandboxPage(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));

            Thread.Sleep(2000);
            
            if (ButtonWritePostFirstElement.Displayed)
            {
                //this one will scroll the element into view for interactions

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", ButtonWritePostFirstElement);

                //ButtonWritePostFirstElement.Click();//new button
                Driver.FindElement(By.XPath("//a[@href ='https://habr.com/en/feed/']")).Click();


                //          Message:
                //              Test method Habr.UI.Tests.HabrTests.ClickButtonWritePostFirstElementOnPage_Success threw exception:
                //              OpenQA.Selenium.ElementClickInterceptedException: element click intercepted: 
                //Element < a href = "/en/sandbox/add/" class="btn btn_medium btn_blue">...</a> is not clickable at point(256, 16).
                //Other element would receive the click: <a href = "https://habr.com/en/feed/" class="nav-links__item-link ">...</a>
                //    
                Thread.Sleep(2000);

            }
            else
            {
                page.GoHomePage();
            }

            //Assert.AreEqual("https://habr.com/ru/sandbox/add/", Driver.Contains("https://habr.com/ru/sandbox/add/"));
            //ButtonWritePostFirstElement.SendKeys("Enter");
            //String tagname = Driver.FindElement(By.XPath("//*['Написать пост']//h2[text()='Как всё произойдет']")).GetAttribute("");
            //Assert.AreEqual("1", tagname);
            //element = driver.FindElement(By.LinkText("Click me using this link text!")); это наш батн
            //this will scroll the element and center it for interaction
            //var js = (IJavaScriptExecutor)Driver;
            //js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);

            ////this one will scroll the element into view for interactions
            //IJavaScriptExecutor je = (IJavaScriptExecutor)Driver;
            //je.ExecuteScript("arguments[0].scrollIntoView(false);", ButtonWritePostFirstElement);
            //wait.Until().ButtonWritePostFirstElement();
            //WebDriverWait wait = new WebDriverWait(driver, timeOut);

        }

        public void WriteTopicProcess()  //https://habr.com/ru/sandbox/start/
        {
            if (IsLogedIn)
            {
                ButtonWriteTopic.Click();
                Thread.Sleep(2000);

                Assert.IsTrue(ButtonWritePostFirstElement.Displayed);
                ButtonWritePostFirstElement.Click();

                //ElementMyPosts.Click();
                //Thread.Sleep(2000);
                //ButtonWritePostFirstElement.Click();
            }

            else
                //Home page = new Home(Driver); 
                Login();
        }



    }
}
