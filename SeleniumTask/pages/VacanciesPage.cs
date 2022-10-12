using System.Linq;
using OpenQA.Selenium;

namespace SeleniumTask.pages
{
    public class VacanciesPage : BasePage
    {
        private readonly By _departmentsComboBox = By.XPath("//button[contains(text(),'All departments')]");
        private readonly By _languagesComboBox = By.XPath("//button[contains(text(),'All languages')]");
        private readonly By _languagesWithEnglishComboBox = By.XPath("//button[contains(text(),'English')]");

        public VacanciesPage(IWebDriver driver) : base(driver)
        {
        }
        private By GetDepartmentOptionSelector(string option)
        {
            return By.XPath($"//a[contains(text(),'{option}')]");
        }

        private By GetLanguageOptionSelector(string option)
        {
            return By.XPath($"//label[contains(text(),'{option}')]");
        }

        private By GetVacanciesListSelector(string href = "/vacancies/development")
        {
            return By.XPath($"//a[contains(@href,'{href}')]");
        }

        public void ClickAllDepartmentsComboBox()
        {
            Click(_departmentsComboBox);
        }

        public void ChooseDepartmentOption(string option)
        {
            Click(GetDepartmentOptionSelector(option));
        }

        public void ClickLanguagesComboBox()
        {
            Click(_languagesComboBox);
        }

        public void ClickLanguagesComboBoxWithEnglishPicked()
        {
            Click(_languagesWithEnglishComboBox);
        }

        public void ChooseLanguageOption(string option)
        {
            Click(GetLanguageOptionSelector(option));
        }

        public int CountAllOpenedVacancies(string href = "/vacancies/development")
        {
            return GetElements(GetVacanciesListSelector(href))
            .GroupBy(el => el.GetAttribute("href")).Select(grp => grp.First()).Count();
        }
    }
}