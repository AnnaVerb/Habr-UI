using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class UserMenu : BasePage
    {               
        public string Title => Driver.Title;

        public UserMenu(IWebDriver driver) : base(driver)
            {
            }

        public IWebElement ButtonZakladki => Driver.FindElement(By.XPath("//a[text()='Закладки']"));

        public IWebElement ButtonPublications => Driver.FindElement(By.XPath("//a[text()='Публикации' and @class='n-dropdown-menu__item-link']"));

        public IWebElement ButtonUserProfile => Driver.FindElement(By.XPath("//a[@class='dropdown__user-info user-info']"));

        public IWebElement ButtonProfileSettings => Driver.FindElement(By.XPath("//*['Profile settings']//div[@class='user-info__buttons']"));


        //dropdown__user-info user-info
        //Syntax: //tag[text()=’text value‘]
        //label[text()=’Enter message’]
        //Syntax: //tag[XPath Statement-1 and XPath Statement-2]
        //*[@id=’user-message’ and @class=’form-control’]

        public void ClickButtonUserProfile()
        {
            UserMenu page = new UserMenu(Driver);
            //page.ButtonGreenUser.Click();
            page.ButtonUserProfile.Click();
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();
    
        }


    }
}
