using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpecFlowExpertLevelCertification.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            this.Driver.Manage().Window.Maximize();
        }

        protected void VerifyPageLoaded(uint time = 60)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            string pageLoadStatus = (string)js.ExecuteScript("return document.readyState");
            wait.Until(p => pageLoadStatus == "complete");
        }

        protected void VerifyElementIsVisible(By by, uint time = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        protected void VerifyElementExists(By by, uint time = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
