using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Habr.UI.Tests.Pages
{
    public abstract class BasePage
    {
        protected static bool IsLogedIn { get; set; }
        private const string _defaultLogInEmail = "annystudy@gmail.com";
        private const string _defaultLogInPassword = "d!6#AHW3uhq6*kL";


        protected static readonly string MainAddress = "https://habr.com/ru/";
        protected IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        //used english names for buttons
        //
        public IWebElement ButtonLogo => Driver.FindElement(By.XPath("//a[@class='logo']"));

        public IWebElement UpPanelMenuNavigationLinksMyFeed => Driver.FindElement(By.XPath("//a[text()='My feed']"));

        public IWebElement UpPanelMenuNavigationLinksAllStreams => Driver.FindElement(By.XPath("//a[text()='All streams']"));
        public IWebElement UpPanelMenuNavigationLinksDevelopment => Driver.FindElement(By.XPath("//a[text()='Development']"));

        public IWebElement UpPanelMenuNavigationLinksPopSi => Driver.FindElement(By.XPath("//a[text()='PopSi']"));


        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("//div[@class='main-navbar']//button[contains(@class,'btn_navbar_user-dropdown')]"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("//button[@id='search-form-btn']"));
        //fix and use english words

        //By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/button"));
        // <button type = "button" class="btn btn_navbar_search icon-svg_search" id="search-form-btn" title="Поиск по сайту">



        //fix path
        public IWebElement ButtonSettings => Driver.FindElement(By.XPath("//div[@class='main-navbar__section main-navbar__section_right']//button[1]"));

        //Syntax: //tag[contains(@attribute, ‘value‘)]

        //Example: //input[contains(@id, ‘er-messa’)]

        //button type = "button" class="btn btn_medium btn_navbar_lang js-show_lang_settings"> <svg class="icon-svg" width="18" height="18">


        //XPath("//*[@for='hl_langs_ru' and @class='radio__label radio__label_another']"));
        //<label for="hl_langs_ru" class="radio__label radio__label_another">Русский</label>





        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("//a[contains(@href,'/tracker/') and contains(@class, 'btn_navbar_tracker')]"));
        //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]")
        //<a href = "https://habr.com/ru/tracker/" class="btn btn_medium btn_navbar_tracker" title="Трекер">

        public IWebElement ButtonWriteTopic => Driver.FindElement(By.XPath("//a[@title='Create post']")); //"Написать пост"

        public IWebElement ButtonLogin => Driver.FindElement(By.XPath("//*[@id='login']"));
        public IWebElement ButtonLoginOut_UserMenu => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));
        public IWebElement SearchFieldForm => Driver.FindElement(By.XPath("//*[@id='search-form-field']"));
        // @placeholder='Поиск']"));
        //id="search-form-field" placeholder="Поиск"
        //XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/label/input")




        //methods

        public IWebElement ElementTrackerNotifications => Driver.FindElement(By.XPath("//h1[@class ='page-header__title']"));





        //methods
        public void Login(string email = _defaultLogInEmail, string password = _defaultLogInPassword)
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
        public void ClickButtonWriteTopic()
        {

            if (IsLogedIn)
                ButtonWriteTopic.Click();
            else
                throw new Exception("User isn't loged in");
        }




    }
}
