using OpenQA.Selenium;
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


        public void WriteTopicProcess()  //https://habr.com/ru/sandbox/start/
        {
            if (IsLogedIn)
            {
                ButtonWriteTopic.Click();
                Thread.Sleep(2000);
                ElementMyPosts.Click();
                Thread.Sleep(2000);
                ButtonWritePost.Click();
            }

            else
                throw new Exception("User isn't loged in");
        }

        public IWebElement ButtonWritePostFirstElement//check
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[@href ='/ru/sandbox/add/']//ancestor::div[1]]"));
                //a[@href ='/ru/sandbox/add/']//ancestor::div[1]
                ///h3[@class='tabs-menu__item-text']"));
                //a[@href ='sandbox/add/']


            }
        }
        public IWebElement FieldPostList//check
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='posts_list']"));

                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");
            }
        }

    }
}
