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


        public IWebElement ButtonLogo => Driver.FindElement(By.ClassName("logo"));
        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("//div[@class='main-navbar']//button[contains(@class,'btn_navbar_user-dropdown')]"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("//*[@id='search-form-btn' and @title='Поиск по сайту']"));

        //By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/button"));
        // <button type = "button" class="btn btn_navbar_search icon-svg_search" id="search-form-btn" title="Поиск по сайту">

        public IWebElement ButtonSettings => Driver.FindElement(By.XPath("//button[contains(@class, 'js-show_lang_settings')]"));

        //Syntax: //tag[contains(@attribute, ‘value‘)]

        //Example: //input[contains(@id, ‘er-messa’)]

        //button type = "button" class="btn btn_medium btn_navbar_lang js-show_lang_settings"> <svg class="icon-svg" width="18" height="18">


        //XPath("//*[@for='hl_langs_ru' and @class='radio__label radio__label_another']"));
        //<label for="hl_langs_ru" class="radio__label radio__label_another">Русский</label>
        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("//a[contains(@href,'/tracker/') and contains(@class, 'btn_navbar_tracker')]"));
        //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]")
        //<a href = "https://habr.com/ru/tracker/" class="btn btn_medium btn_navbar_tracker" title="Трекер">

        public IWebElement ButtonWriteTopic => Driver.FindElement(By.XPath("//*[@title = 'Написать' and @href='https://habr.com/ru/sandbox/start/']"));


        public IWebElement ButtonLogin => Driver.FindElement(By.XPath("//*[@id='login']"));
        public IWebElement ButtonLoginOut_UserMenu => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));

        public IWebElement ButtonZakladki => Driver.FindElement(By.XPath("//a[text()='Закладки']"));

        //Syntax: //tag[text()=’text value‘]
        //label[text()=’Enter message’]
        //Syntax: //tag[XPath Statement-1 and XPath Statement-2]
        //*[@id=’user-message’ and @class=’form-control’]

        public IWebElement SearchFieldForm => Driver.FindElement(By.XPath("//*[@id='search-form-field' and @placeholder='Поиск']"));
        //id="search-form-field" placeholder="Поиск"
        //XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/label/input")


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


        public IWebElement ElementTrackerNotifications
        {
            get
            {
                return Driver.FindElement(By.XPath("//h1[@class ='page-header__title']"));
                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[1]/h1"));
                //a[contains(@href,'/tracker/') and contains(@class, 'btn_navbar_tracker')

            }
        }
        public IWebElement ElementMyPosts//change xpath
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3"));

                ////h3[@class='tabs-menu__item-text']"));
                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");

            }
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
