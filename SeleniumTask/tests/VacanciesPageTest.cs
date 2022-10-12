using System.Collections.Generic;
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
        private Dictionary<string, string> _testData;

        [SetUp]
        public void Setup()
        {
            _testData = TestDataReadHelpers.GetGenericCsvRecords("VacanciesPageTest.csv");
            string[] driverOptions = Config.DriverOptions;
            ChromeOptions options = new ChromeOptions();
            foreach (var option in driverOptions)
            {
                options.AddArgument(option);
            }
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl($"{Config.BaseUrl}/{_testData["VacanciesPageRoute"]}");
        }

        [Test]
        public void ShouldHave_ExpectedCountOfJobOnCareersPage()
        {
            CookiesModalPage cookiesModal = new CookiesModalPage(_driver);
            cookiesModal.ClickRejectCookies();
            VacanciesPage vacanciesPage = new VacanciesPage(_driver);
            vacanciesPage.ClickAllDepartmentsComboBox();
            vacanciesPage.ChooseDepartmentOption(_testData["DepartmentsOptionText"]);
            vacanciesPage.ClickLanguagesComboBox();
            vacanciesPage.ChooseLanguageOption(_testData["LanguagesOptionText"]);
            vacanciesPage.ClickLanguagesComboBoxWithEnglishPicked();
            int expectedVacanciesCount = int.Parse(_testData["expectedVacanciesCount"]);
            Assert.That(vacanciesPage.CountAllOpenedVacancies() == expectedVacanciesCount);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}