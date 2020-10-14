using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAutomation.Spec.Tests.Utils
{
    public static class IWebDriverGenericExtensions
    {
        public static TResult Wait<TResult>(this IWebDriver self, Func<IWebDriver, TResult> ec, int timeoutSecs = 20)
        {
            var wait = new WebDriverWait(self, TimeSpan.FromSeconds(timeoutSecs));
            return wait.Until(ec);
        }
    }
}
