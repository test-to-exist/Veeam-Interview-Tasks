using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTask.pages;
using SeleniumTask.util;

namespace SeleniumTask.tests
{
    [TestFixture]
    public class VacanciesPageTest
    {
        private WebDriver _driver;

        [SetUp]
        public void Setup()
        {
            string[] driverOptions = Config.DriverOptions;
            ChromeOptions options = new ChromeOptions();
            foreach(var option in driverOptions) 
            {
                options.AddArgument(option);
            }
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl($"{Config.BaseUrl}/vacancies");
        }

        [Test]
        public void ShouldHave_ExpectedCountOfJobOnCareersPage()
        {
            CookiesModalPage cookiesModal = new CookiesModalPage(_driver);
            cookiesModal.ClickRejectCookies();
            VacanciesPage vacanciesPage = new VacanciesPage(_driver);
            vacanciesPage.ClickAllDepartmentsComboBox();
            vacanciesPage.ClickResearchAndDevelopmentDepartmentOption();
            vacanciesPage.ClickLanguagesComboBox();
            vacanciesPage.ClickEnglishLanguageOption();
            vacanciesPage.ClickLanguagesComboBoxWithEnglishPicked();
            int expectedVacanciesCount = 12; // This could be a param
            Assert.That(vacanciesPage.CountAllOpenedVacancies() == expectedVacanciesCount);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}