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
        private IWebDriver Driver { get; set; }
        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;
            string outputDirectory = Path.GetDirectoryName(address);

            return new ChromeDriver(outputDirectory, new ChromeOptions());
        }


        [TestInitialize] 
        //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХром вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Home page = new Home(Driver);
            SetEnglishByBtnSettings();
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


        public void ClickUpPanelMenuNavigationLinksMyFeed_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            //SetEnglishByBtnSettings();

            page.UpPanelMenuNavigationLinksMyFeed.Click();
            Thread.Sleep(2000);
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            bool result = Driver.Url.Contains("habr.com/en/feed");
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ClickUpPanelMenuNavigationLinksAllStream_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            page.UpPanelMenuNavigationLinksAllStreams.Click();
            Thread.Sleep(2000);

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //bool result = Driver.Url.Contains("habr.com/en/top/");
            var resultword = Driver.FindElement(By.XPath("//*[text()='All streams']")).Text;

            Assert.AreEqual("All streams", resultword);


        }
        [TestMethod]
        public void ClickUpPanelMenuNavigationLinksDevelopment_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            page.UpPanelMenuNavigationLinksDevelopment.Click();
            Thread.Sleep(2000);

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            bool result = Driver.Url.Contains("/flows/develop/");
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CheckNotifications_Success()
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

        public void ClickBtnWriteTopic()//поправить тест
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ClickButtonWriteTopic();

            ////IWebElement result = Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]"));
            Thread.Sleep(5000);

            //Assert.IsTrue(page..Displayed);
            Assert.IsTrue(page.Title.Contains("Sandbox"));

        }


        [TestMethod]
        //проверка поисковой строки или поля
        public void SeachFieldProcess_Success()
        {
            Post page = new Post(Driver);
            page.GoToPostPage();
            page.SeachFieldProcess("Яндекс");
            Thread.Sleep(2000);
            Driver.TakeScreenshot();
            Assert.IsTrue(page.ElementTabsPublications.Enabled);
        }

        [TestMethod]
        public void LogoMenuQA_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            SetRussianByBtnSettings();
            page.LogoMenuElement.Click();

            Thread.Sleep(2000);
            page.LogoMenuClickQA();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.TakeScreenshot();
            Assert.IsTrue(Driver.Url.StartsWith("https://qna.habr.com/"));
        }

        [TestMethod]
        //проверка кликабельности подменю
        public void LogoMenuOptions()

        {
            Home page = new Home(Driver);
            page.GoHomePage();

            SetRussianByBtnSettings();
            Thread.Sleep(2000);
            page.LogoMenuElement.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            page.LogoMenuClickHabr();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Url.Contains("habr.com/ru/"));

            Driver.Navigate().Back();
            page.LogoMenuClickQA();
            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            Assert.IsTrue(Driver.Url.Contains("qna.habr.com"));

        }


        [TestMethod]
        //проверка функционала меню стартовой страницы
        public void ClickUpPanelSectionAuthor()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);
            page.UpPanelSectionAuthor.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Url.Contains("sandbox/start/"));
            //https://habr.com/ru/sandbox/start/

        }


        //[TestMethod]
        //дополнить тест

        //public void ButtonWritePostFirstElement()
        //{
        //    Home page = new Home(Driver);
        //    page.GoHomePage();
        //    page.Login();

        //    page.ButtonWriteTopic.Click();
        //    Thread.Sleep(2000);
        //    SandboxPage page1 = new SandboxPage(Driver);
        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));

        //    //page1.ClickButtonWritePostFirstElement();


        //    Assert.IsTrue(Driver.Url.Contains("https://habr.com/ru/sandbox/add/"));


        //    //bool result = page.ButtonWritePostFirstElement.Displayed;

        //    //"https://habr.com/ru/sandbox/add/"
        //    //Assert.IsTrue(page.ButtonWritePostFirstElement.);
        //    //Assert.IsTrue(page.ButtonWritePostFirstElement.Enabled);

        //    //page.ButtonGreenUser.Click();

        //    //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        //    //bool result = page.ButtonGreenUser.Displayed;
        //    //Assert.IsTrue(result);

        //}


        //[TestMethod]
        //add waits for visible btn
        //check xpaths
        public void ClickButtonWritePostFirstElementOnPage_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            SandboxPage page2 = new SandboxPage(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            page2.ClickButtonWritePostFirstElementOnPage();

            //check button. It should be on sandbox page
            var a = page2.ButtonWritePostFirstElement.Enabled;

            Assert.IsTrue(a);
            Assert.IsTrue(page2.ButtonWritePostFirstElement.Displayed);
            Assert.IsTrue(Driver.Url.Contains("sandbox/add/"));

            //"https://habr.com/ru/sandbox/add/");

        }


        public void WriteTopicProcess_Success()//check
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            Thread.Sleep(2000);

            SandboxPage page1 = new SandboxPage(Driver);
            //page1.WriteTopicProcess();

            Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
            page1.ButtonWritePostFirstElement.Click();
            Thread.Sleep(2000);

        }



        ////public void WriteTopicProcessComplex_Success()//fix
        //{
        //    Home page = new Home(Driver);
        //    page.GoHomePage();
        //    page.Login();
        //    Thread.Sleep(2000);

        //    SandboxPage page1 = new SandboxPage(Driver);
        //    page1.WriteTopicProcess();
        //    var result = page1.FieldPostList.Text;
        //    Thread.Sleep(2000);


        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
        //    Assert.IsTrue(page1.ButtonWritePostFirstElement.Enabled);

        //    Thread.Sleep(2000);
        //    //Assert.AreEqual("https://habr.com/ru/sandbox/start/", page.Title);
        //}



        //tests about posts

        [TestMethod]
        public void PostAddtoFavoriteBySearch()
        {
            Post page = new Post(Driver);
            page.GoToPostPage();

            var post = "Яндекс отчитался о выручке на фоне";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);

            bool result = page.ElementTabsPublications.Displayed;
            Assert.IsTrue(result);

            Assert.IsTrue(page.ButtonBookmarkPost512916.Enabled);
            Assert.IsTrue(page.ElementPost_512916.Displayed);


        }

        public void CheckAddedPostByUserMenu_Success()
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

        public void PostAddandRemoveFromFav512916()
        {
            Post page = new Post(Driver);
            page.GoToPostPage();
            page.Login();

            SetALLOptionsContentByBtnSettings();
            //language Settings should be russian and english

            var post = "Яндекс отчитался о выручке на фоне";
            page.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);

            //remove post from favs
            string a = page.ButtonBookmarkPost512916.GetAttribute("data-action");

            if (page.ButtonBookmarkPost512916.Displayed && a == "remove")
            {
                page.ButtonBookmarkPost512916.Click();

                Assert.AreNotEqual("remove", a);
                Assert.AreEqual("add", a);

            }

            else
            {
                //post is not added
                page.GoToPostPage();
            }

        }

        public void CheckBookmarkCounter()

        {
            //var newcounter = page.ButtonBookm arkPost512916Counter.Text;
            //Assert.AreNotEqual(counterbeforeremove, newcounter);
            //другой вариант проверки
            ////check that bookmark is removed => ищем post
            //UserMenu page1 = new UserMenu(Driver);
            //page.ButtonGreenUser.Click();
            //page1.ButtonZakladki.Click();
            //Thread.Sleep(2000);

            //if (!page.ElementPost_512916.Displayed)
            //{
            //    WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //    Assert.IsFalse(page.ElementPost_512916.Displayed);
            //}

            //else
            //{
            //    //post is not removed
            //    //CodeThrowExceptionStatement()
            //    page.GoToPostPage();

            //}
            //var counter = page.ButtonBookmarkPost512916Counter.Text.ToString();

            //if (!counter.Equals("0"))
            //{
            //    page.ButtonBookmarkPost512916.Click();
            //    Thread.Sleep(2000);

            //    //Assert.IsFalse(counter.Equals("0"));
            //}

            //var counterbeforeremove = page.ButtonBookmarkPost512916Counter.Text;

            //page.ButtonBookmarkPost512916.Click();
            //Thread.Sleep(2000);
            //Assert.AreNotEqual("add", a);
            //page.ButtonBookmarkPost512916.Click();
            //Assert.AreEqual("add", a);
        }


        [TestMethod]
        public void PostAddtoFavoriteByLink512916()//убрать номер, вынести в константу
        //добавить проверку счетчика
        {
            Post page = new Post(Driver);

            //string postlink = "https://habr.com/ru/news/t/512916/";
            page.GoToPostPage("512916");
            page.Login();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            page.ButtonBookmarkPost512916.Click();
            Thread.Sleep(2000);
            Driver.TakeScreenshot();

            Assert.IsTrue(Driver.Url.EndsWith("/512916/"));
            Assert.IsTrue(page.ButtonBookmarkPost512916.Enabled);

            //CheckforBookmark();

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

        [TestMethod]
        //Negative test
        public void SetALLOptionsInterfaceByBtnSettings()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            langSettings.InputInterfaceRussian.Click();
            Thread.Sleep(1000);
            langSettings.InputInterfaceEnglish.Click();
            Thread.Sleep(1000);
            langSettings.ButtonSaveSettings.Click();

            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(2000);
            Driver.TakeScreenshot();

            //checked attribute for radio btn  
            var check = langSettings.InputInterfaceEnglish.GetCssValue("checked");


            //var RussianOption = langSettings.InputInterfaceRussian.FindElement(By.Name("checked"));
            //var EnglishOption = langSettings.InputInterfaceEnglish.GetAttribute("checked");


            // CSS selector, for all checkboxes which are checked


            //input: checked[type='checkbox']




            //Assert.IsFalse(RussianOption.Equals(EnglishOption));

            //Assert.IsTrue(langSettings.InputInterfaceRussian.Selected || langSettings.InputInterfaceEnglish.Selected);
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

        public void SetALLOptionsContentByBtnSettings()
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



        //tests for UserProfile

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

        [TestMethod]
        //Проверка иконки профиля юзера
        public void ClickProfileMenu()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ButtonGreenUser.Click();
            UserMenu page2 = new UserMenu(Driver);
            page2.ClickButtonUserProfile();

            //Assert.IsFalse(page2.ButtonUserProfile.Displayed);
            Assert.IsTrue(page2.ButtonProfileSettings.Displayed);
            Assert.AreEqual("AnnyV - Пользователь on Habr", Driver.Title);

        }

    }

}

