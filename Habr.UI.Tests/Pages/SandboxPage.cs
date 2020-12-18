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

        public IWebElement ButtonCreatePostFirstElement => Driver.FindElement(By.ClassName("btn.btn_medium btn_blue"));
        ////*['Create post']//[@class='nav - links__item - link']"));
        //btn btn_medium btn_blue

        public IWebElement FieldPostList//check
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='posts_list']"));

                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");
            }
        }
        public IWebElement MenuMyPosts => Driver.FindElement(By.XPath("//div[@class='tabs']//a[4]"));

        //public IWebElement ElementMyPosts => Driver.FindElement(By.XPath("//div[@class='tabs']//a[4]"));

        ////h3[@class='tabs-menu__item-text']"));
        //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");           

        ////h3[@class='tabs-menu__item-text']"));
        //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");



        //methods

        //методы

        

        //public void WriteTopicProcess()  //https://habr.com/ru/sandbox/start/
        //{
        //    if (IsLogedIn)
        //    {
        //        ButtonCreatePost.Click();
        //        Thread.Sleep(2000);

        //        Assert.IsTrue(ButtonWritePostFirstElement.Displayed);
        //        ButtonWritePostFirstElement.Click();

        //        //ElementMyPosts.Click();
        //        //Thread.Sleep(2000);
        //        //ButtonWritePostFirstElement.Click();
        //    }

        //    else
        //        //Home page = new Home(Driver); 
        //        Login();
        //}

    }
}
