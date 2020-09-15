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

        //Syntax: //tag[text()=’text value‘]

        //Example: .//label[text()=’Enter message’]
        //<label for="hl_langs_en" class="radio__label radio__label_another">English</label>

        public IWebElement InputInterfaceRussian => Driver.FindElement(By.XPath("//fieldset[@data-section='2']/div[1]/span"));
       
        public IWebElement InputInterfaceEnglish => Driver.FindElement(By.XPath("//fieldset[@data-section='2']/div[2]/span"));

        public IWebElement InputContentRussian => Driver.FindElement(By.XPath("//*[@id='lang-settings-form']//fieldset[2]/div[1]"));
        
        //form-field form-field_lang-settings
        //By.XPath("//*[@id='fl_langs_ru']")

        //("//fieldset[@data-section='2']/div[1]/span"));

        public IWebElement InputContentEnglish => Driver.FindElement(By.XPath("//label[@for='fl_langs_en']"));
        //fieldset[@data-section='2']/div[2]/span")
        //XPath("//fieldset[@class='form__fieldset form__fieldset_thin']//input[@value='fl_langs_en']"));
        // <input type = "checkbox" name="fl[]" id="fl_langs_en" class="checkbox__input js-fl_langs" value="en">
        //*[@id="lang-settings-form"]/fieldset[2]/div[2]
        //html/body/div[2]/div/div[2]/form/fieldset[2]/div[2]/span


        public void SetRussianByBtnSettings()
        {
            InputInterfaceRussian.Click();
            Thread.Sleep(2000);
            ButtonSaveSettings.Click();

        }

        public void SetEnglishByButtonSettings()
        {

            InputInterfaceEnglish.Click();
            Thread.Sleep(2000);
            ButtonSaveSettings.Click();

        }

        
        public void SetEnglishContentByBtnSettings()
        {
            InputContentEnglish.Click();
            //Driver.Manage().Timeouts().ImplicitWait.TotalSeconds;
            Thread.Sleep(2000);
            ButtonSaveSettings.Click();

        }

        public void SetRussianContentByBtnSettings()
        {
            InputContentRussian.Click();
            Thread.Sleep(2000);
            ButtonSaveSettings.Click();

        }



    }
}
