using System;
using System.IO;
using System.Reflection;
using Habr.UI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Habr.UI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
            Console.WriteLine("Test2");
            Console.WriteLine("Test3");
            Console.WriteLine("Test3.1");
        }

        IWebDriver Driver { get; set; }

        [TestInitialize] //запускается перед каждым тестом 
        public void OpenBrowser()
        {
            Driver = GetChromeDriver();// метод ГетХромДр вернет нам созданный браузер в свойство
            Driver.Manage().Window.Maximize();

            HomePage page = new HomePage(Driver);
            page.GoHomePage();
        }


        private IWebDriver GetChromeDriver()
        {

            string address = Assembly.GetExecutingAssembly().Location;

            string outputDirectory = Path.GetDirectoryName(address);
            return new ChromeDriver(outputDirectory);
            //создание нового объекта типа ChromeDriver и вызов конструктора с параметром 
        }


        [TestMethod]
        public void TestMethod_HomePageLogo()
        {
            var driver = new ChromeDriver();
            

        }

    }
}
