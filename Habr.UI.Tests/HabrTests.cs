using Habr.UI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests
{
    [TestClass]
    public class HabrTests
    {

        IWebDriver Driver { get; set; }

        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;
            string outputDirectory = Path.GetDirectoryName(address);

            return new ChromeDriver(outputDirectory, new ChromeOptions());
        }


        [TestInitialize] //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХром вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Driver.Close();
        }


        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException), "Login button is not presented on the page.")]
        public void LoginIn_Success()
        {
            PageHome page = new PageHome(Driver);
            page.GoHomePage();
            page.Login();
            var button = page.ButtonLogin;

        }

        [TestMethod]
        public void LoginOut_Success()
        {
            PageHome page = new PageHome(Driver);
            page.GoHomePage();
            page.Login();
            page.LoginOutProcess();

            Assert.IsTrue(page.ButtonLogin.Displayed);

        }

        [TestMethod]
        public void CheckNotifications_Success()//поправить тест
        {
            PageHome page = new PageHome(Driver);
            page.GoHomePage();
            page.Login();
            page.ClickNotifications();

            //IWebElement result = Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]"));
            Thread.Sleep(5000);

            Assert.IsTrue(page.ElementTrackerNotifications.Displayed);

        }

        [TestMethod]
        public void CheckButtonUser_Success()
        {
            PageHome page = new PageHome(Driver);
            page.GoHomePage();
            page.Login();
            page.ButtonGreenUser.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            bool result = page.ButtonGreenUser.Displayed;
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void SeachFieldProcess_Success()
        {
            PostPage page = new PostPage(Driver);
            page.GoToPostPage();
            page.SeachFieldProcess("Яндекс");

            Assert.IsTrue(page.ElementTabsPublications.Enabled);
        }

        [TestMethod]
        public void PostAddtoFavoriteBySearch_Success()
        {
            PostPage page = new PostPage(Driver);
            
            var post = "Как заставить код выполняться за одинаковое время? Способы от Яндекс.Контеста";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(5000);
            page.ButtonBookmark.Click();


            ////Assert.AreEqual("remove", page.ButtonBookmark.Text);
            ////Driver.Navigate().GoToUrl("https://habr.com/ru/company/yandex/blog/515544/");
            //page.SeachFieldProcess(post);



        }

        [TestMethod]
        public void PostAddtoFavorite(string postNumber)
        {

            PostPage page = new PostPage(Driver);
            page.GoToPostPage("515544");
            Thread.Sleep(5000);
            page.Login();


            //string link = "https://habr.com/ru/company/yandex/blog/515544/";

            //page.PostAddtoFavoriteByLink(link);

            //Assert.AreEqual("remove", page.ButtonBookmark.Text);

            //page.ButtonBookmark.Click();
        }

    }
}
