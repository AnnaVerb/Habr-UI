using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Habr.UI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Habr.UI.Tests
{
    [TestClass]
    public class PageHomeTests
    {

        IWebDriver Driver { get; set; }

        [TestInitialize] //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХром вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();
        }

        //private IWebDriver GetChromeDriver()
        //{
        //    throw new NotImplementedException();
        //}

        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;
            string outputDirectory = Path.GetDirectoryName(address);

            return new ChromeDriver(outputDirectory, new ChromeOptions());
        }


        [TestMethod]
        public void Test_HomePage()
        {

            HomePage page = new HomePage(Driver);
            page.GoHomePage();


        }
    }
}
