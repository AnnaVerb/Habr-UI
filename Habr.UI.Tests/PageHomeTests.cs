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

            HomePage page = new HomePage(Driver);
            page.GoHomePage();
        }

        //private IWebDriver GetChromeDriver()
        //{
        //    throw new NotImplementedException();
        //}

        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;

            string outputDirectory = Path.GetDirectoryName(address);
            return new ChromeDriver(outputDirectory);
            //создание нового объекта типа ChromeDriver и вызов конструктора с параметром 
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
            Console.WriteLine("Test2");
            Console.WriteLine("Test3");
            Console.WriteLine("Test3.1");
        }

        [TestMethod]
        public void Test_HomePage()
        {
            //var driver = new ChromeDriver();
            HomePage page = new HomePage(Driver);

            page.GoHomePage();
            Thread.Sleep(2000);
            Assert.AreEqual("Хабр", Driver.Title);

        }

        [TestMethod]
        public void ClickButtonLogo_Success()
        {
            //PageHome pageHome = new PageHome(Driver);
            HomePage page = new HomePage(Driver);
            page.ButtonLogo.Click();

            Assert.AreEqual("Лучшие публикации за сутки", Driver.Title);
        }

    }
}
