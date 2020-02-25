using System;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework;
using Selenious;
using Selenious.AllureIntegration;
using Selenious.Logevents;
using static Selenious.Condition;
using static Selenious.Selenious;

namespace nunit_selenious_example
{
    [AllureNUnit]
    [TestFixture]
    public class Tests
    {

        private static Logger Log = LogManager.GetCurrentClassLogger();
        
        [SetUp]
        public void Setup()
        {
            Log.Debug("Starting Test!");
            SeleniousLogger.AddLogger("Allure", new AllureSelenious()
                .ScreenShots(true)
                .PageSource(true));
            Configuration.Timeout = TimeSpan.FromMilliseconds(5000);
            Configuration.BaseUrl = "http://google.com";
        }

        [TearDown]
        public void TearDown()
        {
            Log.Debug("Test is finished!");
        }
        
        
        [Test]
        public void Test1()
        {
            var searchPage = new SearchPage().Open()
                .Search("Hello World!");
            searchPage.TestField.ShouldNotBe(Visible);
        }
        
        [Test]
        public void Test2()
        {
            new SearchPage().Open()
                .Search("Hello World!");
            Element("test").ShouldBe(Visible);
        }
    }
}