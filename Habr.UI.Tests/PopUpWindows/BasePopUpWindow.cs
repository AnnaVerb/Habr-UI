using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.PopUpWindows
{
    public abstract class BasePopUpWindow
    {
        protected IWebDriver Driver { get; set; }
        public BasePopUpWindow(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
