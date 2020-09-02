using OpenQA.Selenium;

namespace Habr.UI.Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public IWebElement ButtonLogo => Driver.FindElement(By.ClassName("logo"));
        public IWebElement ButtonSearch => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/button"));
        public IWebElement SearchFieldForm
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/form/label/input"));
            }
        }
      
    }
}
