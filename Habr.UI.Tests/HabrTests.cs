using Habr.UI.Tests.Pages;
using Habr.UI.Tests.PopUpWindows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
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
        public void ClickButtonUser_Success()
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
        //проверка поисковой строки или поля
        {
            Post page = new Post(Driver);
            page.GoToPostPage();
            page.SeachFieldProcess("Яндекс");

            Assert.IsTrue(page.ElementTabsPublications.Enabled);
        }

        [TestMethod]
        public void LogoMenuQA_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);
            page.LogoMenuClickQA();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.TakeScreenshot();
            Assert.IsTrue(Driver.Url.StartsWith("https://qna.habr.com/"));
        }

        [TestMethod]
        public void LogoMenuOptions()
        //проверка кликабельности подменю
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);
            page.LogoMenuClickQA();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            page.GoHomePage();
            page.LogoMenuClickHabr();
            Thread.Sleep(2000);

            Assert.IsTrue(Driver.Url.Contains("habr.com/"));

        }


        [TestMethod]
        public void ClickUpPanelSectionAuthor()
        //проверка функционала меню стартовой страницы
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);
            page.UpPanelSectionAuthor.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Url.Contains("sandbox/start/"));
            //https://habr.com/ru/sandbox/start/

        }


        [TestMethod]
        public void ClickButtonWritePostFirstElement_Success()//fix
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ButtonWriteTopic.Click();

            SandboxPage page1 = new SandboxPage(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
            page1.ClickButtonWritePostFirstElement();
            Thread.Sleep(2000);

            Assert.IsTrue(Driver.Url.Contains("https://habr.com/ru/sandbox/add/"));


            //bool result = page.ButtonWritePostFirstElement.Displayed;

            //"https://habr.com/ru/sandbox/add/"
            //Assert.IsTrue(page.ButtonWritePostFirstElement.);
            //Assert.IsTrue(page.ButtonWritePostFirstElement.Enabled);

            //page.ButtonGreenUser.Click();

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //bool result = page.ButtonGreenUser.Displayed;
            //Assert.IsTrue(result);

        }



        public void CheckButtonWritePostFirstElementk_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
            SandboxPage page1 = new SandboxPage(Driver);
            page1.ClickButtonWritePostFirstElement();

            Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
            Assert.IsTrue(page1.ButtonWritePostFirstElement.Enabled);

        }

      
        public void WriteTopicProcess_Success()//check
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);

            SandboxPage page1 = new SandboxPage(Driver);
            page1.WriteTopicProcess();

            Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
            page1.ButtonWritePostFirstElement.Click();
            Thread.Sleep(2000);

        }


        public void WriteTopicProcessComplex_Success()//fix
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();
            Thread.Sleep(2000);

            SandboxPage page1 = new SandboxPage(Driver);
            page1.WriteTopicProcess();
            var result = page1.FieldPostList.Text;
            Thread.Sleep(2000);


            Assert.IsNotNull(result);
            Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
            Assert.IsTrue(page1.ButtonWritePostFirstElement.Enabled);

            Thread.Sleep(2000);
            //Assert.AreEqual("https://habr.com/ru/sandbox/start/", page.Title);
        }



        //tests anout posts

        [TestMethod]
        public void PostAddtoFavoriteBySearch_Success()//дополнить проверкой на закладку
        {
            Post page = new Post(Driver);
            page.GoToPostPage();

            var post = "Яндекс отчитался о выручке на фоне";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);

            //bool result = page.ElementTabsPublications.Displayed;
            //Assert.IsTrue(result);

            Assert.IsTrue(page.ButtonBookmarkPost512916.Displayed);

            var counter = page.ButtonBookmarkPost512916Counter.Text.ToString();


            if (counter.Equals("0"))
            {
                page.ButtonBookmarkPost512916.Click();
                Thread.Sleep(2000);

                Assert.IsFalse(counter.Equals("0"));
            }

            Assert.IsTrue(page.ElementPost_512916.Displayed);

            //var result1 = page.ButtonBookmarkPost512916.GetProperty("color");
            //# a3bc49;
            //title = "Удалить из закладок"
            //data - action = "add"
            //remove

        }



        public void PostAddtoFavoriteBySearchDoubleCheck_Success()
        {
            Post page = new Post(Driver);
            page.GoToPostPage();
            page.Login();

            var post = "Яндекс отчитался о выручке на фоне";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);

            page.ButtonLogo.Click();
            Thread.Sleep(2000);

            page.ClickButtonGreenUser();
            //page.ButtonZakladki.Click();
            //page.ButtonBookmarkPost512916.Click();

            bool result = page.ElementTabsPublications.Displayed;
            bool result1 = page.ButtonBookmarkPost512916.Enabled;
            Assert.IsTrue(result);
            Assert.IsTrue(result1);

            //bool result2 = Driver.FindElement(By.XPath("//a[contains(@href,'512916') and @class='post__title_link']")).Displayed;
            //Assert.IsTrue(result2);

            //https://habr.com/ru/company/ruvds/blog/515544/
            //Assert.AreEqual("remove", page.ButtonBookmark.("data-action"));
            //page.ButtonLogo.Click();
            //Thread.Sleep(2000);
            //page.ClickButtonGreenUser();
            //page.ButtonZakladki.Click();


        }


        [TestMethod]
        public void PostRemoveFromFavoritePost512916()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            //var post = "Яндекс отчитался о выручке на фоне";
            //page.PostAddtoFavoriteBySearch(post);
            //Thread.Sleep(2000);

            //ищем в меню наличие закладки
            page.ButtonGreenUser.Click();
            //page.ButtonZakladki.Click();
            Thread.Sleep(2000);

            //remove bookmark from favorites
            Post page1 = new Post(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));

            if (page1.ButtonBookmarkPost512916.Enabled)
            {
                WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
                page1.ButtonBookmarkPost512916.Click();
                Thread.Sleep(2000);

                //check assert

                //Assert.IsFalse(page1.ElementPost_512916.Displayed);
            }

            else
            {
                Driver.Navigate().Back();
                page1.GoToPostPage();
            }

        }


        [TestMethod]
        public void PostAddtoFavoriteByLink_Success()//fix xpaths
        {

            Post page = new Post(Driver);
            page.GoToPostPage();
            Thread.Sleep(2000);

            page.PostAddtoFavoriteByLink512916("512916");
            Thread.Sleep(2000);

            Assert.IsTrue(Driver.Url.Equals("https://habr.com/ru/news/t/512916/"));
            // Assert.AreEqual("remove", page.ButtonBookmarkPost512916.GetAttribute("data-action"));

        }


        //test language Settings

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
        public void SetALLOptionsInterfaceByBtnSettings()
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


        public void SetEnglishContentByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.SetEnglishContentByBtnSettings();
            Thread.Sleep(1000);

            page.ButtonSettings.Click();
            Assert.IsTrue(langSettings.InputContentEnglish.Displayed);
            //Assert.IsTrue(langSettings.InputContentEnglish.Selected);
            Assert.IsTrue(langSettings.InputContentEnglish.Enabled);


        }

        [TestMethod]
        public void SetRussianContentPlusSearch_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);
            page.ButtonSettings.Click();
            Thread.Sleep(2000);

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.SetRussianContentByBtnSettings();
            Thread.Sleep(2000);

            //Assert.IsTrue(langSettings.InputContentRussian.Displayed);
            Assert.IsTrue(langSettings.InputContentRussian.Selected);

            page.SeachFieldProcess("График");
            Driver.TakeScreenshot();
            Thread.Sleep(2000);

        }

        [TestMethod]
        public void SetALLOptionsContentByBtnSettings()//Maybe NegativeTest
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(2000);

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.SetRussianContentByBtnSettings();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();
            langSettings.SetEnglishContentByBtnSettings();
            Thread.Sleep(1000);
            page.ButtonSettings.Click();
            Thread.Sleep(4000);
            Driver.TakeScreenshot().SaveAsFile("ContentView");

            page.SeachFieldProcess("All");
            Thread.Sleep(2000);
            page.SeachFieldProcess("Все");
            Thread.Sleep(2000);


        }


        //test user Profile

        [TestMethod]
        public void ClickButtonExit()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ButtonGreenUser.Click();
            Thread.Sleep(2000);
            page.ButtonLoginOut_UserMenu.Click();

            Driver.Navigate().Refresh();
            Assert.IsTrue(Driver.Url.Contains("https://habr.com/"));
            Assert.IsTrue(page.ButtonLogin.Enabled);


        }


        
        public void ClickProfileMenu()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ButtonGreenUser.Click();
            
          

            Driver.Navigate().Refresh();
            Assert.IsTrue(Driver.Url.Contains("https://habr.com/"));
            Assert.IsTrue(page.ButtonLogin.Enabled);


        }
    }


}

