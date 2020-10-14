using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;
using WebAutomation.Spec.Tests.Utils;
using EC = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace WebAutomation.Spec.Tests.Pages
{
    public class UserPage : PageObject
    {
        public IWebDriver _webDriver { get; }
        public UserPage(IWebDriver webDriver) : base(webDriver) => _webDriver = webDriver;
        public IWebElement txtName => _webDriver.Wait(EC.ElementExists(By.Id("name")));
        public IWebElement txtEmail => _webDriver.Wait(EC.ElementExists(By.Id("email")));
        public IWebElement btnSave => _webDriver.Wait(EC.ElementExists(By.Id("save")));
        public IWebElement alertText => _webDriver.Wait(EC.ElementExists(By.Id("alertText")));
        public IList<UserGridRow> tableRows
        {
            get
            {
                var rt = new List<UserGridRow>();

                foreach (var e in _webDriver.Wait(u=> u.FindElements(By.TagName("clr-dg-row"))))
                {
                    rt.Add(new UserGridRow(e));
                }
                return rt;
            }
        }

        public void ClickSave() => btnSave.Click();
    }

    public class UserGridRow
    {
        public UserGridRow(IWebElement clrRowElem) => _clrRowElem = clrRowElem;
        private IWebElement _clrRowElem { get; }
        public IWebElement NameTxt => _clrRowElem.FindElement(By.ClassName("userName"));
        public IWebElement EmailTxt => _clrRowElem.FindElement(By.ClassName("userEmail"));
    }
}
