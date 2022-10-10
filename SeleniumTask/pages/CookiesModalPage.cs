using OpenQA.Selenium;

namespace SeleniumTask
{
    public class CookiesModalPage : BasePage
    {

        public CookiesModalPage(IWebDriver driver) : base(driver)
        {
        }

        public void RejectCookies()
        {
            GetElement(By.Id("cookiescript_reject")).Click();
        }
    }
}