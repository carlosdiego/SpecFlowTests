using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebAutomation.Spec.Tests.Pages;
using Xunit;
using System.Collections.Generic;

namespace WebAutomation.Spec.Tests.Steps
{
    [Binding]
    public class UserSteps
    {

        private readonly string url = "http://localhost:4200/users";
        private UserPage _page;
        public UserSteps(IWebDriver _webDrive) => _page = new UserPage(_webDrive);

        [Given(@"a user opens the Users page")]
        public void GivenAUserOpensTheUsersPage() => _page.Navigate(url);

        [Given(@"the user enters a new name ""(.*)"" into the registration form")]
        public void GivenTheUserEntersANewNameIntoTheRegistrationForm(string name) => _page.txtName.SendKeys(name);

        [Given(@"the user enters a valid email ""(.*)"" into the registration form")]
        public void GivenTheUserEntersAValidEmailIntoTheRegistrationForm(string email) => _page.txtEmail.SendKeys(email);

        [When(@"the user submits the registration form")]
        public void WhenTheUserSubmitsTheRegistrationForm() => _page.ClickSave();

        [Then(@"the registration should be successful")]
        public void ThenTheRegistrationShouldBeSuccessful() => Assert.True(_page.alertText.Text == "Success");

        [Then(@"a new user must be listed")]
        public void ThenANewUserMustBeListed() => Assert.Contains(_page.tableRows, u => u.NameTxt.Text == _page.txtName.Text && u.EmailTxt.Text == _page.txtEmail.Text);

    }
}
