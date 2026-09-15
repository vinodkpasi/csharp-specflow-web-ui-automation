using OpenQA.Selenium;

namespace SpecFlowExpertLevelCertification.Pages
{
    public class CartPage : BasePage
    {
        By lblProductPrice = By.CssSelector("div[data-name='Active Items'] .sc-product-price");
        public IWebElement LblProductPrice => Driver.FindElement(lblProductPrice);

        By lblProductName = By.CssSelector("div[data-name='Active Items'] .sc-product-title");
        public IWebElement LblProductName => Driver.FindElement(lblProductName);

        By imgCart = By.Id("nav-cart");
        public IWebElement ImgCart => Driver.FindElement(imgCart);

        By lblCartCount = By.Id("nav-cart-count");
        public IWebElement LblCartCount => Driver.FindElement(lblCartCount);

        By lblEmptyHeader = By.CssSelector(".sc-your-amazon-cart-is-empty>h2");
        public IWebElement LblEmptyHeader => Driver.FindElement(lblEmptyHeader);

        public CartPage(IWebDriver driver) : base(driver)
        {

        }

        public void OpenCart()
        {
            ImgCart.Click();
            VerifyPageLoaded();
        }

        public string HeaderText
        {
            get
            {
                return LblEmptyHeader.Text;
            }
        }

        public int CartItemsCount
        {
            get
            {
                return int.Parse(LblCartCount.Text);
            }
        }

        public bool IsCartDisplayed
        {
            get
            {
                return ImgCart.Displayed;
            }
        }

        public string ProductPrice
        {
            get
            {
                return LblProductPrice.Text;
            }
        }

        public string ProductName
        {
            get
            {
                return LblProductName.Text;
            }
        }
    }
}
