using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTask.util;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumTask.pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        private readonly int _defaultWaitForElement;
        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _defaultWaitForElement = Int32.Parse(Config.GetValue("defaultWaitForElement"));
        }

        protected void WaitUntilElementClickable(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_defaultWaitForElement));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementClickable(by);
            return _driver.FindElement(by);
        }
        protected ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            WaitUntilElementClickable(by);
            return _driver.FindElements(by);
        }

        protected void Click(By by)
        {
            WaitUntilElementClickable(by);
            _driver.FindElement(by).Click();
        }

        protected void SendKeys(By by, string text)
        {
            WaitUntilElementClickable(by);
            _driver.FindElement(by).SendKeys(text);
        }
    }
}