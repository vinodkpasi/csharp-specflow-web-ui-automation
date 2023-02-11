using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using SpecFlowExpertLevelCertification.Utils;
using System;
namespace SpecFlowExpertLevelCertification.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer container;

        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            try
            {
                ChromeDriver driver = new ChromeDriver();
                container.RegisterInstanceAs<IWebDriver>(driver);
            }
            catch (Exception ex)
            {
                Util.Log.Error(ex.StackTrace);
            }
        }

        [AfterScenario(Order = 2)]
        public void DestroyWebDriver()
        {
            try
            {
                var driver = container.Resolve<IWebDriver>();
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Error(ex.StackTrace);
            }
        }
    }
}
