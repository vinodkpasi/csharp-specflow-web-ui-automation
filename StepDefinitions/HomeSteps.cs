using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowExpertLevelCertification.Pages;
using SpecFlowExpertLevelCertification.Utils;

namespace SpecFlowExpertLevelCertification.StepDefinitions
{
    [Binding]
    public class HomeSteps:TechTalk.SpecFlow.Steps
    {
        private readonly HomePage homePage;
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private readonly CartPage cartPage;

        public HomeSteps(IWebDriver driver,ScenarioContext scenarioContext)
        {
            this.homePage = new HomePage(driver);
            this.cartPage = new CartPage(driver);
            this.scenarioContext = scenarioContext;
            this.driver = driver;
        }

        [Then(@"search box and search button is displayed")]
        public void ThenSearchBoxAndSearchButtonIsDisplayed()
        {
            Util.Log.Info("Verify search box and search button is displayed");
            Assert.IsTrue(homePage.IsSearchBoxDisplayed, "Search box is not displayed");
            Assert.IsTrue(homePage.IsSearchButtonDisplayed, "Search button is not displayed");
        }

        [Given(@"User enter ""([^""]*)"" in the search box")]
        public void GivenUserEnterInTheSearchBox(string searchText)
        {
            Util.Log.Info($"User enter {searchText} in the search box");
            homePage.EnterSearchInput(searchText);
        }

        [Given(@"User click on the search button")]
        public void GivenUserClickOnTheSearchButton()
        {
            Util.Log.Info("User click on the search button");
            homePage.ClickOnSearchButton();
        }

        [Then(@"Search result should be displayed")]
        public void ThenSearchResultShouldBeDisplayed()
        {
            Util.Log.Info("Verify search result should be displayed");
            Assert.IsTrue(homePage.IsFirstSearchResultDisplayed, "Search result is not displayed");
        }

        [Given(@"User search the ""([^""]*)""")]
        public void GivenUserSearchTheProduct(string searchText)
        {
            Util.Log.Info($"User search the {searchText}");
            homePage.EnterSearchInput(searchText);
            homePage.ClickOnSearchButton();
            ThenSearchResultShouldBeDisplayed();
        }

        [Given(@"User open the first search result")]
        public void ThenUserOpenTheFirstSearchResult()
        {
            Util.Log.Info("User open the first search result");
            scenarioContext.Add("ProductName", homePage.LblProductName.Text);
            scenarioContext.Add("ProductPrice", homePage.LblProductPrice.Text);
            homePage.ClickOnFirstSearchResult();
        }

        [When(@"User click on the add to the cart button")]
        public void ThenUserClickOnTheAddToTheCartButton()
        {
            Util.Log.Info("User click on the add to the cart button");
            homePage.ClickOnAddToCartButton();
        }

        [Then(@"Verify the product name and price")]
        public void ThenVerifyTheProductNameAndPrice()
        {
            Util.Log.Info("Verify the product name and price");
            Assert.IsTrue(cartPage.ProductName == scenarioContext.Get<string>("ProductName"),"Product name does not match");
            Assert.IsTrue(cartPage.ProductPrice == scenarioContext.Get<string>("ProductPrice"), "Product price does not match");
        }

        [Given(@"User search the ""([^""]*)"" and add the first result to the cart")]
        public void GivenUserSearchTheAndAddTheFirstResultToTheCart(string searchText)
        {
            GivenUserSearchTheProduct(searchText);
            ThenUserOpenTheFirstSearchResult();
            ThenUserClickOnTheAddToTheCartButton();
            CartSteps cartSteps = new CartSteps(driver);
            cartSteps.ThenVerifyInitiallyCartIsDisplayedWithItemsAdded(1);
        }
    }
}
