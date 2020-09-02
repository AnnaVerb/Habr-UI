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
        public IWebElement ButtonLogin => Driver.FindElement(By.XPath("//*[@id='login']"));
        public IWebElement ButtonGreenUser => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/button"));
        public IWebElement ButtonNotifications => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/a[1]"));
    }
}
