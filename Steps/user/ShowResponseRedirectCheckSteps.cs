using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.user
{
    [Binding]
    public class ShowResponseRedirectCheckSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        Stopwatch Sw;
        DateTime start;
        DateTime end;
        private MainUserPage mainUsP = new MainUserPage(WebDriver);
        
        public ShowResponseRedirectCheckSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"user go to main page")]
        public void WhenUserGoToMainPage()
        {
            WebDriver.Navigate().GoToUrl(MainUserPageURL);

            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Navigate().Refresh();
        }
        
        [When(@"user click on Enter now")]
        public void WhenUserClickOnEnterNow()
        {
            //Sw = new Stopwatch();
            //Sw.Start();
            start = DateTime.Now;
            mainUsP.ClickFirstEnterNow();
            end = DateTime.Now;
            //Sw.Stop();
        }
        
        [When(@"display time from last clicking")]
        public void WhenDisplayTimeFromLastClicking()
        {
            long totalTimeTaken = end.Millisecond-start.Millisecond;
            Console.WriteLine("miliseconds: " + totalTimeTaken);
        }
        
        [When(@"user click on Find out more")]
        public void WhenUserClickOnFindOutMore()
        {
            //Sw.Start();
            start = DateTime.Now;
            mainUsP.ClickFirstFindOutMore();
            end = DateTime.Now;
            //Sw.Stop();
        }
        [Then(@"user redirected to page ""(.*)""")]
        public void ThenUserRedirectedToPage(string p0)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(4)).Until(
d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Assert.IsTrue(WebDriver.Url.EndsWith(p0), "redirection to " + p0 + " failed. current is "+ WebDriver.Url);
        }
                                         
        [When(@"user click on Find out more at ""(.*)""")]
        public void WhenUserClickOnFindOutMoreAt(string p0)
        {
            start = DateTime.Now;
            mainUsP.ClickFindOutMoreAtHowItWorkd(p0);
            end = DateTime.Now;
        }
        
    }
}
