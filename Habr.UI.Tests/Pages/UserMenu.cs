using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class UserMenu : BasePage
    {

       
            public string Title => Driver.Title;

            public UserMenu(IWebDriver driver) : base(driver)
            {
            }






        }
    }
