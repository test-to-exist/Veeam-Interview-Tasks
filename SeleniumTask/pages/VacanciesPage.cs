using System.Linq;
using OpenQA.Selenium;

namespace SeleniumTask.pages
{
    public class VacanciesPage : BasePage
    {
        private readonly By _departmentsComboBox = By.XPath("//button[contains(text(),'All departments')]");
        private readonly By _researchAndDevelopmentOption = By.XPath("//a[contains(text(),'Research & Development')]");
        private readonly By _languagesComboBox = By.XPath("//button[contains(text(),'All languages')]");
        private readonly By _englishLanguageOption = By.XPath("//label[contains(text(),'English')]");
        private readonly By _languagesWithEnglishComboBox = By.XPath("//button[contains(text(),'English')]");
        private readonly By _vacanciesList = By.XPath("//a[contains(@href,'/vacancies/development')]");

        public VacanciesPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAllDepartmentsComboBox()
        {
            Click(_departmentsComboBox);
        }

        public void ClickResearchAndDevelopmentDepartmentOption()
        {
            Click(_researchAndDevelopmentOption);
        }

        public void ClickLanguagesComboBox()
        {
            Click(_languagesComboBox);
        }

        public void ClickLanguagesComboBoxWithEnglishPicked()
        {
            Click(_languagesWithEnglishComboBox);
        }
        public void ClickEnglishLanguageOption()
        {
            Click(_englishLanguageOption);
        }

        public int CountAllOpenedVacancies()
        {
            return GetElements(_vacanciesList)
            .GroupBy(el => el.GetAttribute("href")).Select(grp => grp.First()).Count();
        }
    }
}