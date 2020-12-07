using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class Post : BasePage
    {
        public Post(IWebDriver driver) : base(driver)
        {

        }

        private const string _defaultPostNumber = "502746";
        internal readonly object ButtonZakladki;

        //Syntax: //tag[starts-with(@attribute, ‘value‘)]

        //Example: //input[starts-with(@id, ‘user’)]
        //Example: *//h3[starts-with(@class, 'tabs-menu')]
        //Example: *//h3[starts-with(@class, 'tabs-menu')]




        //Syntax: //tag[@attribute=’value‘]

        //Example: //input[@id = ‘user-message’]
        //Example: *//span[@title ='Закладки']


        //Syntax: //tag[contains(@attribute, ‘value‘)]

        //Example: //input[contains(@id, ‘er-messa’)]

        public IWebElement ElementTabsPublications
        {
            get
            {
                return Driver.FindElement(By.XPath("*//h3[starts-with(@class, 'tabs-menu')]"));
                //By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[1]/div/a[1]/h3")
            }
        }

        public IWebElement ButtonBookmarkPost512916 => Driver.FindElement(By.XPath("//button[@data-id='512916']//span"));



        //fix
        public IWebElement ButtonBookmarkPost512916Counter => Driver.FindElement(By.XPath("//*[@data-id='512916']//span[@class='bookmark__counter js-favs_count']"));

        //public IWebElement ElementTrackerNotifications => Driver.FindElement(By.XPath("//h1[@class ='page-header__title']"));
        //div[@data-id='512916']//[@id='post_512916']

        //button[@data-id='512916']//span[@class='btn_inner']"
        //button[@data-id='512916' and @data-action='add']"
        //button[@data-id='512916' and @data-action='add']
        //https://habr.com/ru/news/t/512916/
        //title = "Удалить из закладок" onclick = "posts_add_to_favorite(this);" >

        //<span class="bookmark__counter js-favs_count"


        //check
        public IWebElement ElementPost_512916 => Driver.FindElement(By.XPath("//a[contains(@href,'512916') and @class='post__title_link']"));



        public void PostAddtoFavoriteBySearch(string posttext)
        {

            if (!IsLogedIn)
            {
                Login();
            }

            SeachFieldProcess(posttext);

            //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;
            //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", page.CheckBoxSelect);
            //Thread.Sleep(1000);
            //page.TabSelect2Success.Click();
            //Assert.IsTrue(page.TabResultText.Displayed);
            //ButtonBookmarkPost512916.Click();


            if (ButtonBookmarkPost512916Counter.Equals("0")  || !ButtonBookmarkPost512916.Selected)
            {
                ButtonBookmarkPost512916.Click();
            }

            else
            {
                Driver.TakeScreenshot();
                Thread.Sleep(2000);
                // GoToPostPage();
            }

        }

        public void PostAddtoFavoriteByLink512916()
        {
            if (!IsLogedIn)
            {
                Login();
            }

            GoToPostPage("512916");              

            //wait.Until(ButtonBookmarkPost512916.Displayed);
            Thread.Sleep(2000);
            ButtonBookmarkPost512916.Click();
        }

        public void GoToPostPage(string postNumber = _defaultPostNumber)
        {
            Driver.Navigate().GoToUrl($"{MainAddress}post/{postNumber}/");
        }

    }
}
