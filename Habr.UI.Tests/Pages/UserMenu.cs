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

        public IWebElement ButtonBookmarks => Driver.FindElement(By.XPath("//a[text()='Bookmarks']"));
        public IWebElement ButtonPublications => Driver.FindElement(By.XPath("//a[text()='Publications' and @class='n-dropdown-menu__item-link']"));
        public IWebElement ButtonUserProfile => Driver.FindElement(By.XPath("//a[@class='dropdown__user-info user-info']"));

        //кнопка настройки профиля юзера
        public IWebElement ButtonProfileSettings => Driver.FindElement(By.XPath("//*['Profile settings']//div[@class='user-info__buttons']"));
        //поле Actual name 
        public IWebElement FieldName => Driver.FindElement(By.XPath("//input[@class='h-form-input__control' and @maxlength='40']"));
        // <input type = "text" maxlength="40" class="h-form-input__control">

        //dropdown__user-info user-info
        //Syntax: //tag[text()=’text value‘]
        //label[text()=’Enter message’]
        //Syntax: //tag[XPath Statement-1 and XPath Statement-2]
        //*[@id=’user-message’ and @class=’form-control’]

        public IWebElement ButtonSaveChanges => Driver.FindElement(By.XPath("//span[@class='tm-button__text']"));
        //Driver.FindElement(By.XPath("//span[@class='tm-button__text']")).Click();
        /////html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/form/div[3]/button")).Click();
        //span[@class = 'tm-button__text']






        //methods



        public void ClickButtonUserProfile()
        {
            UserMenu page = new UserMenu(Driver);
            //page.ButtonGreenUser.Click();
            page.ButtonUserProfile.Click();
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();

        }

        public void ClickSaveChangesAfterInput()
        {
            UserMenu page = new UserMenu(Driver);
            page.ButtonUserProfile.Click();

            page.ButtonProfileSettings.Click();
            page.FieldName.Clear();
            Thread.Sleep(2000);
            page.FieldName.Click();
            page.FieldName.SendKeys("_Anna");
            Thread.Sleep(2000);
            page.ButtonSaveChanges.Click();
          
        }

    }
}
