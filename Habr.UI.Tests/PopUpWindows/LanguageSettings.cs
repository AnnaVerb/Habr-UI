using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests.PopUpWindows
{
    public class LanguageSettings : BasePopUpWindow
    {
        public LanguageSettings(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement ButtonSaveSettings => Driver.FindElement(By.XPath("//form[@id='lang-settings-form']/div/button"));
        //<button type = "submit" class="btn btn_blue btn_huge btn_full-width js-popup_save_btn">Save settings</button>
        public IWebElement InputInterfaceEnglish => Driver.FindElement(By.XPath("//fieldset[@data-section='2']/div[2]/span"));

        //Syntax: //tag[text()=’text value‘]

        //Example: .//label[text()=’Enter message’]
        //<label for="hl_langs_en" class="radio__label radio__label_another">English</label>

        public IWebElement InputInterfaceRussian => Driver.FindElement(By.XPath("//fieldset[@data-section='2']/div[1]/span"));

        public void SetEnglishByButtonSettings()
        {
            InputInterfaceEnglish.Click();
            Thread.Sleep(2000);
            ButtonSaveSettings.Click();
            
        }
    }
}
