using OpenQA.Selenium;
using SpecFlowExpertLevelCertification.Utils;

namespace SpecFlowExpertLevelCertification.Pages
{
    public class HomePage : BasePage
    {
        By lnkFirstSearchResult = By.CssSelector("div[cel_widget_id = 'MAIN-SEARCH_RESULTS-4'] .s-link-style");
        public IWebElement LnkFirstSearchResult => Driver.FindElement(lnkFirstSearchResult);

        By txtSearchBox = By.Id("twotabsearchtextbox");
        public IWebElement TxtSearchBox => Driver.FindElement(txtSearchBox);

        By btnSearch = By.Id("nav-search-submit-button");
        public IWebElement BtnSearch => Driver.FindElement(btnSearch);

        By lblProductPrice = By.CssSelector("div[cel_widget_id = 'MAIN-SEARCH_RESULTS-4'] .a-price-whole");
        public IWebElement LblProductPrice => Driver.FindElement(lblProductPrice);

        By lblProductName = By.CssSelector("div[cel_widget_id='MAIN-SEARCH_RESULTS-4'] .a-size-medium.a-color-base.a-text-normal");
        public IWebElement LblProductName => Driver.FindElement(lblProductName);

        By btnAddToCart = By.Id("add-to-cart-button");
        public IWebElement BtnAddToCart => Driver.FindElement(btnAddToCart);

        By imgClose = By.Id("attach-close_sideSheet-link");
        public IWebElement ImgClose => Driver.FindElement(imgClose);

        IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Navigate()
        {
            driver.Url = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];
            VerifyPageLoaded();
        }

        public void EnterSearchInput(string searchText)
        {
            TxtSearchBox.Clear();
            TxtSearchBox.SendKeys(searchText);
        }

        public void ClickOnSearchButton()
        {
            BtnSearch.Click();
            VerifyPageLoaded();
        }

        public void ClickOnFirstSearchResult()
        {
            VerifyElementExists(lnkFirstSearchResult);
            LnkFirstSearchResult.ClickUsingScrollIntoView();
            VerifyPageLoaded();
        }

        public void ClickOnAddToCartButton()
        {
            VerifyElementExists(btnAddToCart);
            BtnAddToCart.ClickUsingScrollIntoView();
            ImgClose.Click();
        }

        public bool IsSearchBoxDisplayed
        {
            get
            {
                return TxtSearchBox.Displayed;
            }
        }

        public bool IsSearchButtonDisplayed
        {
            get
            {
                return BtnSearch.Displayed;
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

        public bool IsFirstSearchResultDisplayed
        {
            get
            {
                return LblProductName.Displayed;
            }
        }
    }
}
