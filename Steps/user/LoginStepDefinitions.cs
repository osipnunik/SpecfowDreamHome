
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.pages.user;
using SpecFlowDreanLotteryHome.services;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.user
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseStepDefinition
    {

        private readonly ScenarioContext _scenarioContext;
        private LoginUserPage loginPg = new LoginUserPage(WebDriver);
        private static string LoginUserURL = MainUserPageURL + "/sign-in";
        private RegisterUserPage regsPg = new RegisterUserPage(WebDriver);
        private AutogeneratorService boggus = new AutogeneratorService();

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

        [Then(@"user redirected to profile page")]
        public void ThenUserRedirectedToProfilePage()
        {
            //WebDriverWait wait = new WebDriverWait(WebDriver, 10000); // seconds
            Waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='My Details']")));

            Assert.IsTrue(WebDriver.Url.EndsWith("profile"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }

        [When(@"user click on Sign up link at top of the page")]
        public void WhenUserClickOnSignUpLinkAtTopOfThePage()
        {
            regsPg.ClickSignupFromHeader();
        }

        [Then(@"user see Sign up page")]
        public void ThenUserSeeSignUpPage()
        {
            regsPg.WaitWhileSignUpHeaderAppeare();

            Assert.IsTrue(WebDriver.Url.EndsWith("sign-up"));
        }

        [When(@"user click on Sign up here link lower of the page")]
        public void WhenUserClickOnSignUpHereLinkLowerOfThePage()
        {
            regsPg.ClickSignInHereHref();
        }

        [When(@"user autogenerate account and input all")]
        public void WhenUserAutogenerateAccountAndInputAll()
        {
            var user = boggus.GetUser();
            _scenarioContext.Add("user", user);
            regsPg.InputFirstNameInput(user.FirstName);
            regsPg.InputLastNameInput(user.LastName);
            regsPg.InputPhoneNumberInput(user.Phone);
            regsPg.InputEmailInput(user.Email);
            regsPg.InputPasswordInput("babushka66");
            regsPg.Ckeckbox18First();
        }

        [When(@"user press sign up button")]
        public void WhenUserPressSignUpButton()
        {
            regsPg.ClickSignUpBtn();
        }
        [When(@"user check i'm (.*) checkbox and scroll down")]
        public void WhenUserCheckIMCheckboxAndScrollDown(int p0)
        {
            regsPg.ScrollUntillIAgreeIsActive();
            regsPg.ClickAgeCheckbox();
            
        }
        [When(@"click i agree")]
        public void WhenClickIAgree()
        {
            regsPg.ClickIAgree();
        }
        [Then(@"name displayed at right upper footer")]
        public void ThenNameDisplayedAtRightUpperFooter()
        {
            var expected = (User)_scenarioContext["user"];
            Assert.AreEqual(expected.FirstName + " " + expected.LastName, regsPg.GetLoggedName());
        }
        [Then(@"on header should be displayed ""(.*)""")]
        public void ThenOnHeaderShouldBeDisplayed(string nameSurname)
        {
            Assert.AreEqual(nameSurname, regsPg.GetLoggedName(nameSurname));
        }


    }
}
