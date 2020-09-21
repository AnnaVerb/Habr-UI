using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class Post : BasePage
    {
        public Post(IWebDriver driver) : base(driver)
        {

        }


        private const string _defaultPostNumber = "502746";


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


        public IWebElement ButtonBookmarkPost512916//fix
        {
            get
            {

                return Driver.FindElement(By.XPath("//button[@title ='Удалить из закладок']"));

                //https://habr.com/ru/news/t/512916/
                //title = "Удалить из закладок" onclick = "posts_add_to_favorite(this);" >
                //(By.XPath("//button[@title ='Удалить из закладок' and @data-action = 'remove']"));
                //data - action = "remove" title = "Удалить из закладок" onclick = "posts_add_to_favorite(this);" >
                //Xpath.("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button")
            }
        }
        public IWebElement ElementPost_512916//check
        {
            get
            {

                return Driver.FindElement(By.XPath("//a[contains(@href,'512916') and @class='post__title_link']"));
                //
            }
        }


        public void PostAddtoFavoriteBySearch(string posttext)
         {
            SeachFieldProcess(posttext);
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;

            //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", page.CheckBoxSelect);
            //Thread.Sleep(1000);
            //page.TabSelect2Success.Click();
            
            //Assert.IsTrue(page.TabResultText.Displayed);
            ButtonBookmarkPost512916.Click();

            if (ButtonBookmarkPost512916.Displayed)
            {
                ButtonBookmarkPost512916.Click();
            }
            
            //posts_add_to_favorite(this);

            ButtonSearch.Click();
            //page.SearchFieldForm.SendKeys(text);
        }
        public void PostAddtoFavorite(string postNumber = _defaultPostNumber)
        {
            GoToPostPage(postNumber);

            if (!IsLogedIn)
            {
                Login();
            }

            ButtonBookmarkPost512916.Click();
        }


        public void GoToPostPage(string postNumber = _defaultPostNumber)
        {
            Driver.Navigate().GoToUrl($"{MainAddress}post/{postNumber}/");
        }

    }
}
