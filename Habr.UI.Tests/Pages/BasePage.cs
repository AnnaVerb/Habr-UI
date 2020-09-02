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
        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/button"));
        public IWebElement ButtonLogo => Driver.FindElement(By.ClassName("logo"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/button"));
        public IWebElement SearchFieldForm => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/label/input"));
        public IWebElement ButtonLogin => Driver.FindElement(By.XPath("//*[@id='login']"));
        public IWebElement ButtonLoginOut_UserMenu => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));
        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]"));
        public IWebElement ButtonWriteTopic => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[2]"));



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
