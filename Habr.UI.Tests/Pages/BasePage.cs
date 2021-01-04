using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Configuration;

namespace Habr.UI.Tests.Pages
{
    public abstract class BasePage
    {
        protected static bool IsLogedIn { get; set; }
        private readonly string _defaultLogInEmail;
        private readonly string _defaultLogInPassword;
        protected static readonly string MainAddress = "https://habr.com/en/top/";
        protected IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            var appSettings = ConfigurationManager.AppSettings;
            _defaultLogInEmail = appSettings["login"];
            _defaultLogInPassword = appSettings["password"];
        }


        //use english names for buttons
        //use xpath 

        public IWebElement ButtonLogo => Driver.FindElement(By.XPath("//a[@class='logo']"));
        public IWebElement ButtonLogin => Driver.FindElement(By.XPath("//*[@id='login']"));
        public IWebElement ButtonLoginOut_UserMenu => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));
        public IWebElement SearchFieldForm => Driver.FindElement(By.XPath("//*[@id='search-form-field']"));
        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("//div[@class='main-navbar']//button[contains(@class,'btn_navbar_user-dropdown')]"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("//button[@id='search-form-btn']"));
        //fix and use english words
        //button" class="btn btn_navbar_search icon-svg_search" id="search-form-btn" title="Поиск по сайту">

        public IWebElement ButtonSettings => Driver.FindElement(By.XPath("//div[@class='main-navbar__section main-navbar__section_right']//button[1]"));
        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("//a[contains(@href,'/tracker/') and contains(@class, 'btn_navbar_tracker')]"));
        //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]")
        //<a href = "https://habr.com/ru/tracker/" class="btn btn_medium btn_navbar_tracker" title="Трекер">
        public IWebElement ButtonCreatePost => Driver.FindElement(By.XPath("//a[@title='Create post']")); //"Написать пост"
        public IWebElement ElementTrackerNotifications => Driver.FindElement(By.XPath("//h1[@class ='page-header__title']"));

        public IWebElement FooterAccount => Driver.FindElement(By.XPath("//h3[text()='Your account']"));
        public IWebElement FooterSections => Driver.FindElement(By.XPath("//h3[text()='Sections']"));
        public IWebElement FooterInfo => Driver.FindElement(By.XPath("//h3[text()='Info']"));

        public IWebElement LinkSupportFooter => Driver.FindElement(By.XPath("//a[@href='https://habr.com/en/feedback/' and text()='Support']"));



        //menu
        public IWebElement UpPanelMenuNavigationLinksMyFeed => Driver.FindElement(By.XPath("//a[text()='My feed']"));
        public IWebElement UpPanelMenuNavigationLinksAllStreams => Driver.FindElement(By.XPath("//a[text()='All streams']"));
        public IWebElement UpPanelMenuNavigationLinksDevelopment => Driver.FindElement(By.XPath("//a[text()='Development']"));
        public IWebElement UpPanelMenuNavigationLinksPopSi => Driver.FindElement(By.XPath("//a[text()='PopSi']"));

        //internal void ButtonLogo()
        //{
        //    throw new NotImplementedException();
        //}



        //methods

        public void Login() => Login(_defaultLogInEmail, _defaultLogInPassword);


        //methods
        public void Login(string email, string password)
        {
            ButtonLogin.Click();
            Thread.Sleep(2000);
            LoginPopUp page = new LoginPopUp(Driver);
            page.InputEmail.SendKeys(email);
            page.InputPassword.SendKeys(password);
            page.ClickButtonLoginPopupPage();

            IsLogedIn = true;
        }
        public void LoginOutProcess()
        {
            ButtonGreenUser.Click();
            ButtonLoginOut_UserMenu.Click();
            IsLogedIn = false;
        }

        public void SeachFieldProcess(string text)
        {
            Home page = new Home(Driver);
            page.GoHomePage();

            page.ButtonSearch.Click();
            page.SearchFieldForm.SendKeys(text);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            page.SearchFieldForm.SendKeys(Keys.Enter);
            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            //Actions builder = new Actions(Driver);
            //builder.SendKeys(Keys.Enter);
        }

        public void ClickNotifications()
        {
            if (IsLogedIn)
                ButtonNotifications.Click();
            else
                throw new Exception("User isn't loged in");
        }
        public void ClickButtonGreenUser()
        {
            if (IsLogedIn)
                ButtonGreenUser.Click();
            else
                throw new Exception("User isn't loged in");
        }
        public void ClickButtonCreateTopic()
        {
            if (IsLogedIn)
                ButtonCreatePost.Click();
            else
                throw new Exception("User isn't loged in");
        }

    }
}
