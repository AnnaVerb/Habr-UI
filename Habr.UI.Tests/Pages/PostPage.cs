using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class PostPage : BasePage
    {
        public PostPage(IWebDriver driver): base(driver)
        {

        }

        void test() {
            
            
        }



        public IWebElement ElementTabsPublications
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[1]/div/a[1]/h3"));
            }
        }
        public IWebElement ButtonBookmark
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button"));
                //By.TagName("onclick"));
                //Xpath.("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button")
            }
        }
        public IWebElement ElementPost
        {
            get
            {

                return Driver.FindElement(By.Id("post_515544"));
            }
        }

        public void PostsAddtoFavoriteProcess(string posttext)
        {
            PageHome page = new PageHome(Driver);

            SeachFieldProcess(posttext);
            ButtonBookmark.Click();


            //posts_add_to_favorite(this);

        }


    }
}   
