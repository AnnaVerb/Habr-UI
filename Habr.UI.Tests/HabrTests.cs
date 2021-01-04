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
[assembly: Parallelize(Workers = 5, Scope = ExecutionScope.MethodLevel)]

namespace Habr.UI.Tests
{
    [TestClass]
    public class HabrTests
    {
        //private readonly string email;
        //private readonly string password;

        private IWebDriver Driver { get; set; }
        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;
            string outputDirectory = Path.GetDirectoryName(address);

            return new ChromeDriver(outputDirectory, new ChromeOptions());
        }
        IWebElement BtnFollowTwitterPage => Driver.FindElement(By.XPath("//*[text()='Follow']"));
        IWebElement BtnLoginTwitterPage => Driver.FindElement(By.XPath("//*[@href ='/login']"));

        [TestInitialize]
        //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХром вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Home page = new Home(Driver);
            page.GoHomePage();
            //SetEnglishByBtnSettings();
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Driver.Close();
        }


        //Log In and Login OUT Tests

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


        //проверка панелей меню

        [TestMethod]
        public void ClickUpPanelMenuNavigationLinksAllStream_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            page.UpPanelMenuNavigationLinksAllStreams.Click();
            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
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

        [TestMethod]
        public void ClickUpPanelMenuNavigationLinksMyFeed_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.UpPanelMenuNavigationLinksMyFeed.Click();
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            bool result = Driver.Url.Contains("habr.com/en/feed");
            Assert.IsTrue(result);
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
            Assert.IsTrue(Driver.Url.Contains("qna.habr.com"));
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
            Assert.IsTrue(Driver.Url.Contains("https://habr.com/ru/"));

            Driver.Navigate().Back();
            page.LogoMenuClickQA();
            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            Assert.IsTrue(Driver.Url.Contains("qna.habr.com"));

        }



        //проверка кнопок и элементов

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
        [TestMethod]
        public void ClickBtnCreatePost_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();
            Thread.Sleep(2000);
            page.ClickButtonCreateTopic();

            Assert.IsTrue(Driver.Url.Equals("https://habr.com/en/sandbox/start/"));

        }

        //cliclk button create post near how to
        //Driver.FindElement(By.Name("Create post")).Click();
        //Thread.Sleep(3000);

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


        //tests about posts

        [TestMethod]
        public void PostYandexAddBySearch()
        {
            Home page = new Home(Driver);
            page.Login();

            Post page1 = new Post(Driver);
            page1.GoToPostPage();
            var post = "Яндекс отчитался о выручке на фоне";
            page1.PostAddtoFavoriteBySearch(post);
            Thread.Sleep(2000);

            bool result = page1.ElementTabsPublications.Displayed;
            Assert.IsTrue(result);

            //проверка элементов
            Assert.IsTrue(page1.ButtonBookmarkPost.Enabled);

            //if (page1.ButtonBookmarkPost.GetAttribute("data - action").Contains("remove"))

            page1.ButtonBookmarkPost.Click();
            //check bookmark

            var text = page1.ButtonBookmarkPost.Text;
            if (text.Equals("0"))
            {
                page1.ButtonBookmarkPost.Click();
                Thread.Sleep(2000);
                var text2 = page1.ButtonBookmarkPost.Text;

                Assert.AreEqual("1", text2);
            }
            Assert.IsTrue(page1.ElementPost.Displayed);

        }

        [TestMethod]
        [Obsolete]
        public void ClickButtonCreatePost_FirstElementOnPage()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.Login();

            page.ButtonCreatePost.Click();

            SandboxPage page2 = new SandboxPage(Driver);

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            //wait.Until(IWebDriver driver, page2.ButtonCreatePostFirstElement.Displayed);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5000));
            _ = wait.Until(ExpectedConditions.ElementToBeClickable(page2.ButtonCreatePostFirstElement));

            //check button. It should be on sandbox page, click on it
            page2.ButtonCreatePostFirstElement.Click();

            Assert.IsTrue(Driver.Url.Contains("sandbox/add/")); //"https://habr.com/ru/sandbox/add/");

        }
        [TestMethod]
        public void PostAddByLink()
        //добавить проверку счетчика 
        {

            //string postlink = "https://habr.com/en/news/t/512916/";

            Post pagepost = new Post(Driver);
            Driver.Navigate().GoToUrl("https://habr.com/en/news/t/512916/");
            //pagepost.GoToPostPage("512916");
            Thread.Sleep(2000);
            pagepost.Login();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            //Assert.IsTrue(Driver.Url.Contains("512916"));

            pagepost.ButtonBookmarkPost.Click();
            Thread.Sleep(2000);
            Driver.TakeScreenshot();

            //check bookmark

            var text = pagepost.ButtonBookmarkPost.Text;
            if (text.Equals("0"))
            {
                pagepost.ButtonBookmarkPost.Click();
                Thread.Sleep(2000);
                var text2 = pagepost.ButtonBookmarkPost.Text;

                Assert.AreEqual("1", text2);
            }

            //var a = pagepost.ButtonBookmarkPost.GetAttribute("data-action");      

        }



        //test language settings

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
                Assert.IsTrue(Driver.Url.Contains("https://habr.com/en/"));
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
                //page.ButtonLogo.Click();
            }
            else
            {
                langSettings.SetRussianByBtnSettings();
                Thread.Sleep(2000);
                Assert.IsTrue(Driver.Url.Contains("https://habr.com/ru/"));
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
        //Negative test, should be selected one button
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

            Assert.IsFalse(langSettings.InputInterfaceRussian.Selected);
            //Assert.IsTrue(langSettings.InputInterfaceEnglish.Selected);
            Assert.AreEqual(null, langSettings.InputInterfaceEnglish.GetAttribute("checked"));

            langSettings.ButtonSaveSettings.Click();

            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(2000);
            Driver.TakeScreenshot();

            //checked attribute for radio btn  
            //var check = langSettings.InputInterfaceEnglish.GetCssValue("checked");

            //var RussianOption = langSettings.InputInterfaceRussian.FindElement(By.Name("checked"));
            //var EnglishOption = langSettings.InputInterfaceEnglish.GetAttribute("checked");

            // CSS selector, for all checkboxes which are checked
            //input: checked[type='checkbox']
            //Assert.IsFalse(RussianOption.Equals(EnglishOption));
            //Assert.IsTrue(langSettings.InputInterfaceRussian.Selected || langSettings.InputInterfaceEnglish.Selected);
            //Assert.AreEqual("true", langSettings.InputInterfaceEnglish.FindElement(By.("checked")));
        }



        //content settings

        [TestMethod]
        public void SetEnglishContentByBtnSettings()
        {
            Home page = new Home(Driver);
            page.ButtonLogo.Click();
            page.ButtonSettings.Click();

            LanguageSettings langSettings = new LanguageSettings(Driver);
            Thread.Sleep(2000);
            langSettings.InputContentEnglish.Click();

            //проверка чекбокса
            Thread.Sleep(2000);
            if (langSettings.InputContentEnglish.Selected)
            {
                langSettings.ButtonSaveSettings.Click();
            }

            else
            {
                langSettings.InputContentEnglish.Click();
                Thread.Sleep(2000);
                langSettings.ButtonSaveSettings.Click();
            }

        }

        [TestMethod]
        [Obsolete]
        //[Obsolete]
        public void SetRussianContentPlusSearch_Success()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            page.ButtonSettings.Click();
            Thread.Sleep(2000);

            LanguageSettings langSettings = new LanguageSettings(Driver);

            langSettings.InputContentEnglish.Click();
            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4000));
            _ = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@for='fl_langs_ru']")));

            langSettings.InputContentRussian.Click();
            Thread.Sleep(2000);

            Assert.IsTrue(langSettings.InputContentRussian.Enabled);


            langSettings.ButtonSaveSettings.Click();

            CheckLanguagebySearch("График");

            var a = Driver.FindElement(By.XPath("//*[contains(text(),'График')]"));
            a.ToString();
            Assert.IsNotNull(a);

            ////fix with waits
            //WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(4000));
            ////IWebElement element1 = wait1.Until(IWebDriver, langSettings.InputContentRussian.Selected);
            //wait2.Until(ExpectedConditions.ElementToBeSelected(langSettings.InputContentRussian));
            //можно выбрать разные свойства                     
            //*[@id="fl_langs_ru"]));
            //WebDriverWait wait = new WebDriverWait(driver, 120);
            //ElementToBeClickable);            

        }
        public void CheckLanguagebySearch(string text)
        {

            //проверка языка
            Home page2 = new Home(Driver);
            page2.GoHomePage();
            page2.SeachFieldProcess(text);

            Driver.TakeScreenshot();
            Thread.Sleep(2000);


            //private Func<IWebDriver, IWebElement> ElementToBeClickable()
            //{
            //    throw new NotImplementedException();
            //}
            ////проверка поиска по языкам

            //////var a = Driver.FindElement(By.Name("All")).ToString();
            ////var a = Driver.FindElement(By.XPath("//*[contains(text(),'All Все')]"));
            ////a.ToString();
            ////Assert.IsNotNull(a);

        }


        [TestMethod]
        public void SetALLOptionsContent()
        {
            Home page = new Home(Driver);
            page.GoHomePage();
            //English is selected by default in english version

            page.ButtonSettings.Click();
            LanguageSettings langSettings = new LanguageSettings(Driver);
            Thread.Sleep(4000);

            //clear checkbox
            langSettings.InputContentEnglish.Click();
            Thread.Sleep(2000);
            langSettings.InputContentEnglish.Click();
            Thread.Sleep(2000);

            langSettings.InputContentRussian.Click();
            Thread.Sleep(2000);
            langSettings.ButtonSaveSettings.Click();
            Thread.Sleep(4000);

            Home page2 = new Home(Driver);
            //page2.ButtonSearch.Click();

            CheckLanguagebySearch("All все");

            var a = Driver.FindElements(By.XPath("//*[contains(text(),'All все')]"));
            a.ToString();
            Assert.IsNotNull(a);
            //Assert.IsNotNull(Driver);
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
            //page.GoHomePage();
            page.Login();

            page.ButtonGreenUser.Click();
            UserMenu page2 = new UserMenu(Driver);
            page2.ClickButtonUserProfile();

            //если не проставить чекбоксы то они очистятся и тест не пройдет, возможный баг или сбой настроек
            Assert.IsFalse(page2.ButtonUserProfile.Displayed);
            Assert.IsTrue(page2.ButtonProfileSettings.Displayed);
        }

        [TestMethod]
        //проверка изменений поля Actual name
        public void CheckSaveChangesAfterInput_Success()
        {
            Home page = new Home(Driver);
            page.ButtonLogo.Click();
            page.Login();

            //Base page1 = new Base(Driver);            
            page.ButtonGreenUser.Click();

            UserMenu page1 = new UserMenu(Driver);
            page1.ClickSaveChangesAfterInput();
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();

            //check changes

            Home page2 = new Home(Driver);
            page2.ButtonLogo.Click();
            page2.ButtonGreenUser.Click();

            UserMenu page3 = new UserMenu(Driver);
            page3.ButtonUserProfile.Click();

            //page3.ButtonProfileSettings.Click();
            //y.XPath("//*['Profile settings']

            Thread.Sleep(2000);
            var text = Driver.FindElement(By.XPath("//h1[@class='user-info__name']")).Text;
            Assert.IsTrue(text.Contains("_Anna"));

            //page3.ButtonSaveChanges.Click();

        }



        //tests for footer checking buttons

        [TestMethod]
        [Obsolete]
        public void ClickLinkSupportFooter()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            //adding waits to scroll 

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4000));
            _ = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Support']")));

            page.LinkSupportFooter.Click();
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();

            Assert.IsTrue(Driver.Url.Contains("habr.com/en/feedback/"));
        }
        [TestMethod]
        public void ClickBtnLoginInAccountFooter()
        {
            Home page = new Home(Driver);
            page.GoHomePage();


            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Driver.FindElement(By.XPath("//a[@class='footer-menu__item-link'][text()='Log in']")).Click();
            // class="footer-menu__item-link">Log in</a>

            Thread.Sleep(4000);

            LoginPopUp pagelogin = new LoginPopUp(Driver);
            Thread.Sleep(2000);

            Assert.IsTrue(pagelogin.ButtonLoginPopupPage.Displayed);
        }
        [TestMethod]
        [Obsolete]
        public void ClickPostsSectionsFooter()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            //adding waits to scroll 
            //this will scroll the element and center it for interaction
            // Javascript executor
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4000));
            _ = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Posts']")));

            Driver.FindElement(By.XPath("//*[text()='Posts']")).Click();
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();

            Assert.IsTrue(Driver.Url.Contains("habr.com/en/all/"));
        }
        [TestMethod]
        public void ClickHubsSectionsFooter()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            page.FooterSections.FindElement(By.XPath("//*[text()='Hubs']")).Click();
            Thread.Sleep(2000);

            Assert.IsTrue(Driver.Url.Equals("https://habr.com/en/hubs/"));
        }
        [TestMethod]
        public void ClickTwitterLinkFooter()
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

            page.FooterSections.FindElement(By.XPath("//*[@href='https://twitter.com/habr_eng']")).Click();
            Thread.Sleep(2000);

            var results = Driver.FindElements(By.XPath("//*[text()='Habr.com']")).ToString();
            Assert.IsNotNull(results);

        }
                
        
        

    }

}

