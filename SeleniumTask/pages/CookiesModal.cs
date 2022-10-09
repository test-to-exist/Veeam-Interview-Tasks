using OpenQA.Selenium;

public class CookiesModalPage {

    private readonly IWebDriver _driver;

    public CookiesModalPage(IWebDriver driver) {
        _driver = driver;
    }

    public void RejectCookies() {
        _driver.FindElement(By.Id("cookiescript_reject")).Click();
    }
}