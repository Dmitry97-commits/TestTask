using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Data;

namespace Task.Tests
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        protected static void GoToTasks()
        {
           Browser browser = AqualityServices.Browser;
           browser.GoTo(ConfigsData.mainUrl);
           browser.WaitForPageToLoad();
           browser.Maximize();
        }

        [TearDown]
        protected static void Quit()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
