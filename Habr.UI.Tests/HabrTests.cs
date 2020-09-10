using Habr.UI.Tests.Pages;
using Habr.UI.Tests.PopUpWindows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Threading;
[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

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
        //[ExpectedException(typeof(NoSuchElementException), "Login button is not presented on the page.")]
        public void LoginIn_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            Assert.IsTrue(page.ButtonGreenUser.Displayed);
        }

        [TestMethod]
        public void LoginOut_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();
            page.LoginOutProcess();

            Assert.IsTrue(page.ButtonLogin.Displayed);

        }

        [TestMethod]
        public void CheckNotifications_Success()//поправить тест
        {
            Home page = new Home(Driver);
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
            Home page = new Home(Driver);
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
            Post page = new Post(Driver);
            page.GoToPostPage();
            page.SeachFieldProcess("Яндекс");

            Assert.IsTrue(page.ElementTabsPublications.Enabled);
        }

        [TestMethod]
        public void WriteTopicProcess_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();
            Thread.Sleep(2000);

            page.WriteTopicProcess();
            var result = page.FieldPostList.Text;
            Thread.Sleep(2000);
            Assert.IsNotNull(result);

            Assert.IsTrue(page.ButtonWritePost.Displayed);
            Assert.IsTrue(page.ButtonWritePost.Enabled);
            Thread.Sleep(2000);
            Assert.AreEqual("https://habr.com/ru/sandbox/start/", page.Title);
        }

        [TestMethod]
        public void PostAddtoFavoriteBySearch_Success()
        {
            Post page = new Post(Driver);
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


        public void PostAddtoFavoriteLink()
        {

            Post page = new Post(Driver);
            page.GoToPostPage("512916");

            Thread.Sleep(5000);
            page.Login();
            page.PostAddtoFavorite("512916");
            page.ButtonBookmark.Click();


            // Assert.AreEqual("remove", page.ButtonBookmark.GetAttribute("data-action"));


        }


        public void PostRemoveFromFavorite(string postNumber)
        {

            Post page = new Post(Driver);
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
        public void SetEnglishByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();
            Thread.Sleep(1000);

            LanguageSettings langSettings = new LanguageSettings(Driver);
            if (!langSettings.InputInterfaceEnglish.Selected)
            {
                langSettings.SetEnglishByButtonSettings();
                Thread.Sleep(2000);
                Assert.AreEqual("https://habr.com/en/", Driver.Url);
            }

            else
            {
                langSettings.ButtonSaveSettings.Click();
                page.GoHomePage();
            }


            //langSettings.InputInterfaceEnglish.Click();
            //Thread.Sleep(2000);
            //langSettings.ButtonSaveSettings.Click();


        }

        [TestMethod]
        public void SetRussianByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);


            if (langSettings.InputInterfaceRussian.Selected)
            {
                langSettings.ButtonSaveSettings.Click();
                page.ButtonLogo.Click();
            }
            else
            {
                langSettings.SetRussianByBtnSettings();
                Thread.Sleep(2000);
                Assert.AreEqual("https://habr.com/ru/", Driver.Url);
            }

            Thread.Sleep(2000);

        }

        ////private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        //{
        //    return driver =>
        //    {
        //        try
        //        {
        //            return element.Displayed;
        //        }
        //        catch (Exception)
        //        {
        //            // If element is null, stale or if it cannot be located
        //            return false;
        //        }
        //    };

        [TestMethod]//Negative test
        public void SetAllButtonsInterfaceByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.InputInterfaceRussian.Click();
            Thread.Sleep(2000);
            langSettings.InputInterfaceEnglish.Click();
            Thread.Sleep(2000);
            langSettings.ButtonSaveSettings.Click();

            //langSettings.InputInterfaceRussian.Click();
            //var valuechecked= langSettings.InputInterfaceEnglish.GetAttribute("checked");

            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(2000);

            // Assert.IsTrue(langSettings.InputInterfaceEnglish.Selected); к кнопке это свойство не подходит
            Assert.IsTrue(langSettings.InputInterfaceEnglish.Displayed);
            Assert.IsTrue(langSettings.InputInterfaceEnglish.Enabled);
            //Assert.AreEqual("true", langSettings.InputInterfaceEnglish.FindElement(By.("checked")));


        }





        [TestMethod]
        public void SetEnglishContentByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.SetEnglishContentByBtnSettings();
            page.ButtonSettings.Click();
            Thread.Sleep(1000);

            Assert.IsTrue(langSettings.InputContentEnglish.Enabled);

            //page.SeachFieldProcess("How Can AI & Data Science Help to Fight the Coronavirus");
            //Assert.IsTrue(page.Title.Contains("How Can AI & Data Science Help to Fight the Coronavirus"));

        }

        [TestMethod]
        public void SetRussianContentByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.InputContentRussian.Click();

            page.ButtonSettings.Click();
            Thread.Sleep(1000);

            Assert.IsTrue(langSettings.InputContentRussian.Displayed);
            Assert.AreEqual("1", langSettings.InputContentRussian.GetAttribute("checked"));

            //page.SeachFieldProcess("How Can AI & Data Science Help to Fight the Coronavirus?");

        }




        public void SetALLOptionsContentByBtnSettings()//Negative Test
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(1000);

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.SetRussianContentByBtnSettings();
            Thread.Sleep(1000);
            langSettings.SetEnglishContentByBtnSettings();

            page.ButtonSettings.Click();
            Thread.Sleep(1000);

            //set check
            if (true)
            {

            }

            //page.SeachFieldProcess("How Can AI & Data Science Help to Fight the Coronavirus?");


            //Assert.AreEqual("How Can AI & Data Science Help to Fight the Coronavirus?", page.Title);

        }




    }


}

