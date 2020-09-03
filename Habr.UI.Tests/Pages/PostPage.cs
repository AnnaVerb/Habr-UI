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
    public class PostPage : BasePage
    {
        public PostPage(IWebDriver driver) : base(driver)
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
        public IWebElement ButtonBookmark
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button"));
                   
                //(By.XPath("//button[@title ='Удалить из закладок' and @data-action = 'remove']"));
                //data - action = "remove" title = "Удалить из закладок" onclick = "posts_add_to_favorite(this);" >
                //Xpath.("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button")
            }
        }
        public IWebElement ElementPost
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
            ButtonBookmark.Click();

            //if (page.ButtonBookmark.Displayed)
            //{
            //    page.ButtonBookmark.Click();
            //}
            //posts_add_to_favorite(this);

            //page.ButtonSearch.Click();
            //page.SearchFieldForm.SendKeys(text);
        }
        public void PostAddtoFavorite(string postNumber = _defaultPostNumber)
        {
            GoToPostPage(postNumber);

            if (!IsLogedIn)
            {
                Login();
            }

            ButtonBookmark.Click();
        }

        public void GoToPostPage(string postNumber = _defaultPostNumber)
        {
            Driver.Navigate().GoToUrl($"{MainAddress}post/{postNumber}/");
        }

    }
}
