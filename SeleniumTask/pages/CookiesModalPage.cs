using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
            (new Actions(_driver)).MoveToElement(GetElement(_rejectCookies)).Perform();
            Click(_rejectCookies);
        }
    }
}