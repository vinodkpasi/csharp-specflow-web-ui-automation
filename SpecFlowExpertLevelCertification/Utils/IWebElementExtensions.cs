using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExpertLevelCertification.Utils
{
    public static class IWebElementExtensions
    {
        public static void ScrollIntoView(this IWebElement iwebElement)
        {
            (iwebElement.GetDriver() as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView(true);", iwebElement);
        }

        public static void ClickUsingScrollIntoView(this IWebElement iwebElement)
        {
            (iwebElement.GetDriver() as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView(true);", iwebElement);
            iwebElement.Click();
        }

        public static void JSClick(this IWebElement iwebElement)
        {
            (iwebElement.GetDriver() as IJavaScriptExecutor).ExecuteScript("arguments[0].click();", iwebElement);
        }

        public static IWebDriver GetDriver(this IWebElement iwebElement)
        {
            RemoteWebElement remoteWebElement = iwebElement as RemoteWebElement;
            ////if (remoteWebElement != null)
                return remoteWebElement.WrappedDriver;
            ////return ((IWrapsDriver)(((IWrapsElement)iwebElement).WrappedElement)).WrappedDriver;
        }
    }
}
   
