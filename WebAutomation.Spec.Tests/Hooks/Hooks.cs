using System;
using System.IO;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebAutomation.Spec.Tests.Factories;

namespace WebAutomation.Spec.Tests.Hooks
{

    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _webDrive;
        private static DriverFactory _driverFactory;

        public Hooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _driverFactory = new DriverFactory();
            Directory.CreateDirectory(Path.Combine("..", "..", "TestResults"));
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            _webDrive = _driverFactory.CreateDriver();
            _webDrive.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDrive.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_webDrive);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (_webDrive != null)
            {
                _webDrive.Quit();
            }

        }
    }
}
