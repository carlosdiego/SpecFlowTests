using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WebAutomation.Spec.Tests.Factories
{
    public class DriverFactory
    {
        private string crhomeDriverPath => AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "Drivers\\chrome";
        private string firefoxDriverPath => AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "Drivers\\firefox";
        public IWebDriver CreateDriver()
        {
            string browser =  Environment.GetEnvironmentVariable("BROWSER") ?? "CHROME";


            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver(crhomeDriverPath);
                case "FIREFOX":
                    return new FirefoxDriver(firefoxDriverPath);
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}
