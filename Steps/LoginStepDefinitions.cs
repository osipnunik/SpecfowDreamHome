
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseStepDefinition
    {

        private readonly ScenarioContext _scenarioContext;
        private LoginUserPage loginPg = new LoginUserPage(WebDriver);
        private static string LoginUserURL = MainUserPageURL + "/sign-in";

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }     

        [When(@"user go to login page")]
        public void WhenUserGoToLoginPage()
        {
                WebDriver.Navigate().GoToUrl(LoginUserURL);
        }

        [When(@"input in email value ""(.*)""")]
        public void WhenInputInEmailValue(string p0)
        {
            loginPg.InputLogin(p0);
        }

        [When(@"input in password ""(.*)""")]
        public void WhenInputInPassword(string p0)
        {
            loginPg.InputPass(p0);
        }

        [When(@"click submit")]
        public void WhenClickSubmit()
        {
            loginPg.ClickSignIn();
        }

        [Then(@"user redirected to dream house page")]
        public void ThenUserRedirectedToDreamHousePage()
        {
            //WebDriverWait wait = new WebDriverWait(WebDriver, 10000); // seconds
            Waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='My Details']")));

            Assert.IsTrue(WebDriver.Url.EndsWith("profile"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }


    }
}
