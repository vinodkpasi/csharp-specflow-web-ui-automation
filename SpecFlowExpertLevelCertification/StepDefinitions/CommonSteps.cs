using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowExpertLevelCertification.Pages;
using SpecFlowExpertLevelCertification.Utils;

namespace SpecFlowExpertLevelCertification.StepDefinitions
{
    [Binding]
    public class CommonSteps:TechTalk.SpecFlow.Steps
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;

        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver);
        }

        [Given(@"User Navigate to the application url")]
        public void GivenUserNavigateToTheApplicationUrl()
        {
            Util.Log.Info("User Navigate to the application url");
            homePage.Navigate();
        }

        [Then(@"Verify that page title should be ""([^""]*)""")]
        public void ThenVerifyThatPageTitleShouldBe(string title)
        {
            Util.Log.Info($"Verify that page title should be {title}");
            Assert.IsTrue(driver.Title == title);
        }
    }
}
