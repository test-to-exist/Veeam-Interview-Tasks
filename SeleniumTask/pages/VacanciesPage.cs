using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTask
{
    public class VacanciesPage : BasePage
    {
        public VacanciesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetAllDepartmentsComboBox()
        {
            return GetElement(By.XPath("//button[contains(text(),'All departments')]"));
        }

        public void ClickResearchAndDevelopmentDepartmentOption()
        {
            GetElement(By.XPath("//a[contains(text(),'Research & Development')]")).Click();
        }

        public IWebElement GetLanguagesComboBox()
        {
            return GetElement(By.XPath("//button[contains(text(),'All languages')]"));
        }

        public IWebElement GetLanguagesComboBoxWithEnglishPicked()
        {
            return GetElement(By.XPath("//button[contains(text(),'English')]"));
        }
        public void ClickEnglishLanguageOption()
        {
            GetElement(By.XPath("//label[contains(text(),'English')]")).Click();
        }

        public IEnumerable<IWebElement> GetAllOpenedVacancies()
        {
            return GetElements(By.XPath("//a[contains(@href,'/vacancies/development')]"))
            .GroupBy(el => el.GetAttribute("href")).Select(grp => grp.First());
        }
    }
}