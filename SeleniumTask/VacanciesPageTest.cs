using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTask
{
    public class Tests
    {

        private WebDriver _driver;
        private string _url;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _url = "https://cz.careers.veeam.com/vacancies";
        }

        [Test]
        public void ShouldHave_ExpectedCountOfJobOnCareersPage()
        {
            _driver.Navigate().GoToUrl(_url);
            CookiesModalPage cookiesModal = new CookiesModalPage(_driver);
            cookiesModal.RejectCookies();
            VacanciesPage vacanciesPage = new VacanciesPage(_driver);
            vacanciesPage.GetAllDepartmentsComboBox().Click();
            vacanciesPage.ClickResearchAndDevelopmentDepartmentOption();
            vacanciesPage.GetLanguagesComboBox().Click();
            vacanciesPage.ClickEnglishLanguageOption();
            vacanciesPage.GetLanguagesComboBoxWithEnglishPicked().Click();
            int openedVacanciesCount = vacanciesPage.GetAllOpenedVacancies().Count();
            int expectedVacanciesCount = 12; // This could be a param
            Assert.That(openedVacanciesCount == expectedVacanciesCount);   
        }
    }
}