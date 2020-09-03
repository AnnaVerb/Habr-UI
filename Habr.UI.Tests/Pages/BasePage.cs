using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Habr.UI.Tests.Pages
{
    public class BasePage
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
        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/button"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("//*[@id='search-form-btn' and @title='Поиск по сайту']"));

        //By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/button"));
        // <button type = "button" class="btn btn_navbar_search icon-svg_search" id="search-form-btn" title="Поиск по сайту">

        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("//*[@href = 'https://habr.com/ru/tracker/'and @title='Трекер']"));
        //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]")
        //<a href = "https://habr.com/ru/tracker/" class="btn btn_medium btn_navbar_tracker" title="Трекер">

        public IWebElement ButtonWriteTopic => Driver.FindElement(By.XPath("//*[@title = 'Написать' and @href='https://habr.com/ru/sandbox/start/']"));

        //<a title = "Написать" href="https://habr.com/ru/sandbox/start/" class="btn btn_medium btn_navbar_write-topic">


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

            LoginPopUpPage page = new LoginPopUpPage(Driver);
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

            BasePage page = new BasePage(Driver);
            //GoHomePage();
            Driver.Navigate().GoToUrl("https://habr.com/ru/");

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
