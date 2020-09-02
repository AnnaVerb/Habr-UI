using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Habr.UI.Tests.Pages
{
    public class PageHome : BasePage
    {
        private static readonly string MainAddress = "https://habr.com/ru/";
        public string Title
        {
            get
            {
                return Driver.Title;
            }
        }

        public IWebElement SearchFieldForm
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/label/input"));
            }
        }
        public IWebElement ElementTabsPublications
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[1]/div/a[1]/h3"));
            }
        }
        public IWebElement ButtonBookmark
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button"));
                //By.TagName("onclick"));
                //Xpath.("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button")
            }
        }
        public IWebElement ElementPost
        {
            get
            {

                return Driver.FindElement(By.Id("post_515544"));
            }
        }
        public IWebElement ElementTrackerNotifications
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[1]/h1"));
            }
        }
        public IWebElement ButtonLoginOut_UserMenu
        {
            get
            {
                //By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a")
                //By.CssSelector("body > div.layout > div.layout__row.layout__row_navbar > div > div > div.main - navbar__section.main - navbar__section_right > div > div > ul > li:nth - child(7) > a"));
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div/ul/li[7]/a"));
            }
        }
        public PageHome(IWebDriver driver) : base(driver)
        {            
        }
        public void GoHomePage()
        {
            Driver.Navigate().GoToUrl(MainAddress);
        }
        public void Login(string email, string password)
        {
            GoHomePage();
            ButtonLogin.Click();

            LoginPopUpPage page = new LoginPopUpPage(Driver);

            page.InputEmail.SendKeys(email);
            page.InputPassword.SendKeys(password);
            page.ClickButtonLoginPopupPage();

        }

        public void LoginOutProcess()
        {
            PageHome page = new PageHome(Driver);

            page.ButtonGreenUser.Click();

            //pageLogin.ButtonLoginOut_UserMenu.Click();

            if (ButtonLoginOut_UserMenu.Displayed)
            {
                ButtonLoginOut_UserMenu.Click();
            }
            else
            {
                Driver.Close();
            }

        }

        public void SeachFieldProcess(string text)
        {
            GoHomePage();
            PageHome page = new PageHome(Driver);

            page.ButtonSearch.Click();
            page.SearchFieldForm.SendKeys(text);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            page.SearchFieldForm.SendKeys(Keys.Enter);
            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            //Actions builder = new Actions(Driver);
            //builder.SendKeys(Keys.Enter);



        }

        public void PostsAddtoFavoriteProcess(string posttext)
        {
            PageHome page = new PageHome(Driver);

            SeachFieldProcess(posttext);
            ButtonBookmark.Click();


            //posts_add_to_favorite(this);

        }

        public void ClickNotifications()
        {
            PageHome page = new PageHome(Driver);
            GoHomePage();

            if (ButtonNotifications.Displayed)
            {
                ButtonNotifications.Click();
            }
            else
            {
                Login("annystudy@gmail.com", "d!6#AHW3uhq6*kL");
                ButtonNotifications.Click();
            }



        }

        public void ClickButtonGreenUser()
        {
            PageHome page = new PageHome(Driver);
            GoHomePage();
            ButtonGreenUser.Click();

        }



    }






    ////scroll bar down

    ////System.setProperty("webdriver.chrome.driver", "G://chromedriver.exe");
    ////driver = new ChromeDriver();
    ////JavascriptExecutor js = (JavascriptExecutor)driver;
    ////Find element by link text and store in variable "Element"        		
    ////WebElement Element = driver.findElement(By.linkText("Linux"));

    ////This will scroll the page till the element is found		
    ////js.executeScript("arguments[0].scrollIntoView();", Element); 2: 

    //To scroll down the web page by the visibility of the element.

    //JavascriptExecutor js = (JavascriptExecutor)Driver;
    //js.executeScript("arguments[0].scrollIntoView();", ButtonLoginOut_UserMenu);






}
