using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowExpertLevelCertification.Pages;
using SpecFlowExpertLevelCertification.Utils;

namespace SpecFlowExpertLevelCertification.StepDefinitions
{
    [Binding]
    public class CartSteps:TechTalk.SpecFlow.Steps
    {
        private readonly IWebDriver driver;
        private readonly CartPage cartPage;

        public CartSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.cartPage = new CartPage(driver);
        }

        [Then(@"Verify cart icon is displayed")]
        public void ThenVerifyCartIconIsDisplayed()
        {
            Util.Log.Info("Verify cart icon is displayed");
            Assert.IsTrue(cartPage.IsCartDisplayed,"Cart icon is not displayed");
        }

        [Then(@"Verify initially cart is displayed with (.*) items added")]
        [Then(@"Verify cart is displayed with (.*) items added")]
        public void ThenVerifyInitiallyCartIsDisplayedWithItemsAdded(int count)
        {
            Util.Log.Info($"Verify cart is displayed with {count} items added");
            int cartCount = cartPage.CartItemsCount;
            Assert.IsTrue(cartCount == count, "Cart count is not matched");
        }
        
        [Given(@"User open the cart")]
        [When(@"User open the cart")]
        public void WhenUserOpenTheCart()
        {
            Util.Log.Info("User open the cart");
            cartPage.OpenCart();
        }

        [Then(@"Cart header is displayed as ""([^""]*)""")]
        public void ThenCartHeaderIsDisplayedAs(string meassage)
        {
            Util.Log.Info($"Cart header is displayed as {meassage}");
            Assert.IsTrue(cartPage.HeaderText == meassage, "Cart header text is not matched");
        }
    }
}
