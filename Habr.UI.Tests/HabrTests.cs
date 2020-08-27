using Habr.UI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

            HomePage page = new HomePage(Driver);
            page.Login("annystudy@gmail.com", "d!6#AHW3uhq6*kL");

            var button = page.ButtonLogin;

        }

        [TestMethod]
        public void LoginOut_Success()
        {
            //before Test use Login(string email, string password)

            HomePage page = new HomePage(Driver);
            //page.Login("annystudy@gmail.com", "d!6#AHW3uhq6*kL");
            //var button = page.ButtonLogin;
            page.


        }

    }
}
