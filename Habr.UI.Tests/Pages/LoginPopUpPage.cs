using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class LoginPopUpPage
    {
        private IWebDriver Driver { get; set; }

        public IWebElement InputEmail
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='email_field']"));
            }
        }
        public IWebElement InputPassword
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='password_field']"));
            }
        }
        public IWebElement ButtonLoginPopupPage
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='login_form']/fieldset/div[4]/button"));
            }
        }

        public LoginPopUpPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void ClickButtonLoginPopupPage()
        {
            LoginPopUpPage page = new LoginPopUpPage(Driver);
            page.ButtonLoginPopupPage.Click();

        }


    }
}
