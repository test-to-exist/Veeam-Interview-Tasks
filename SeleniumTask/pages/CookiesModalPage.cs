using OpenQA.Selenium;

namespace SeleniumTask.pages
{
    public class CookiesModalPage : BasePage
    {
        private readonly By _rejectCookies = By.Id("cookiescript_reject");

        public CookiesModalPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickRejectCookies()
        {
            Click(_rejectCookies);
        }
    }
}