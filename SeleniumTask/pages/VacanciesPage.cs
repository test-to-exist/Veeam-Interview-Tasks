using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTask
{
    public class VacanciesPage
    {
        private readonly IWebDriver _driver;
        public VacanciesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetAllDepartmentsComboBox()
        {
            return _driver.FindElement(By.XPath("//button[contains(text(),'All departments')]"));
        }

        public void ClickResearchAndDevelopmentDepartmentOption()
        {
            _driver.FindElement(By.XPath("//a[contains(text(),'Research & Development')]")).Click();
        }

        public IWebElement GetLanguagesComboBox()
        {
            return _driver.FindElement(By.XPath("//button[contains(text(),'All languages')]"));
        }

        public IWebElement GetLanguagesComboBoxWithEnglishPicked()
        {
            return _driver.FindElement(By.XPath("//button[contains(text(),'English')]"));
        }
        public void ClickEnglishLanguageOption()
        {
            _driver.FindElement(By.XPath("//label[contains(text(),'English')]")).Click();
        }

        public IEnumerable<IWebElement> GetAllOpenedVacancies()
        {
            return _driver.FindElements(By.XPath("//a[contains(@href,'/vacancies/development')]"))
            .GroupBy(el => el.GetAttribute("href")).Select(grp => grp.First());
        }
    }
}