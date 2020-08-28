using Habr.UI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests
{
    [TestClass]
    public class HabrTests
    {

        IWebDriver Driver { get; set; }

        [TestInitialize] //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХром вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Driver.Close();
        }

        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;
            string outputDirectory = Path.GetDirectoryName(address);

            return new ChromeDriver(outputDirectory, new ChromeOptions());
        }



        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException), "Login button is not presented on the page.")]
        public void LoginInput_Success()
        {

            PageHome page = new PageHome(Driver);
            page.Login("annystudy@gmail.com", "d!6#AHW3uhq6*kL");

            var button = page.ButtonLogin;

        }

        [TestMethod]
        public void LoginOut_Success()
        {

            PageWithLogin pageLogin = new PageWithLogin(Driver);
            PageHome pageHome = new PageHome(Driver);

            PageWithLogin.Login("annystudy@gmail.com", "d!6#AHW3uhq6*kL");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));


            pageLogin.ClickButtonLoginOut();
            Driver.Navigate().Refresh();

            Assert.IsTrue(pageHome.ButtonLogin.Displayed);


        }


        [TestMethod]
        public void CheckNotifications_Success()
        {
            PageWithLogin page = new PageWithLogin(Driver);
                        

            page.CheckNotifications();
            //Driver.FindElement(By.ClassName("page-header__title");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement firstResult = wait.Until(driver => driver.FindElement(By.Name("Войти")));

            Assert.IsTrue(page.ButtonNotifications.Displayed);
            string ClassName = "page - header title";
            Assert.AreEqual("page - header title", ClassName);
        }
    }
}
