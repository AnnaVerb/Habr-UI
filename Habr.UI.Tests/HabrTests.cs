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
            page.GoToPostPage();
            Thread.Sleep(2000);

            page.Login();
            var post = "Яндекс отчитался о выручке на фоне";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);


            page.ClickButtonGreenUser();
            page.ButtonZakladki.Click();

            bool result = Driver.FindElement(By.XPath("//a[contains(@href,'512916') and @class='post__title_link']")).Displayed;
            //https://habr.com/ru/company/ruvds/blog/515544/


            Assert.IsTrue(result);

            //Assert.AreEqual("remove", page.ButtonBookmark.("data-action"));


        }

        [TestMethod]
        public void PostAddtoFavoriteLink()
        {

            PostPage page = new PostPage(Driver);
            page.GoToPostPage("512916");

            Thread.Sleep(5000);
            page.Login();
            page.PostAddtoFavorite("512916");
            page.ButtonBookmark.Click();


            // Assert.AreEqual("remove", page.ButtonBookmark.GetAttribute("data-action"));


        }

        [TestMethod]
        public void PostRemoveFromFavorite(string postNumber)
        {

            PostPage page = new PostPage(Driver);
            page.GoToPostPage();

            Thread.Sleep(5000);
            page.Login();
            page.PostAddtoFavorite("512916");
            page.ButtonBookmark.Click();
            Assert.AreNotEqual("Add", page.ButtonBookmark.Text);

            page.ButtonBookmark.Click();//remove from bookmark
            page.ButtonGreenUser.Click();
            page.ButtonZakladki.Click();
            Assert.IsFalse(page.ElementPost.Displayed);



            //string link = "https://habr.com/ru/company/yandex/blog/515544/";



        }

        [TestMethod]
        public void ChangeLanguageByButtonSettings()
        {
            PageHome page = new PageHome(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.SetEnglishByButtonSettings();

            Assert.AreEqual("https://habr.com/en/", Driver.Url);

            //https://habr.com/en/
            //Assert.IsFalse(page.ElementPost.Displayed);



        }


    }
}
