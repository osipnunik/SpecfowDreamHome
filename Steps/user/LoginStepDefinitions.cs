
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
        private UserInfoPage UserInfoP = new UserInfoPage(WebDriver);
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }     

        [When(@"user go to login page")]
        public void WhenUserGoToLoginPage()
        {
             WebDriver.Navigate().GoToUrl(LoginUserURL);
            if (!WebDriver.Url.Equals(LoginUserURL))
            {
                WhenUserLogOut();
            }
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

        [Then(@"user redirected to user-info page")]
        public void ThenUserRedirectedToProfilePage()
        {
            //WebDriverWait wait = new WebDriverWait(WebDriver, 10000); // seconds
            Waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='My Details']")));

            Assert.IsTrue(WebDriver.Url.EndsWith("profile/user-info"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }

        [When(@"user click on Sign up link at top of the page")]
        public void WhenUserClickOnSignUpLinkAtTopOfThePage()
        {
            regsPg.ClickSignupFromHeader();
        }
        [When(@"user log out")]
        public void WhenUserLogOut()
        {
            regsPg.ClickAccountButton();
            regsPg.ClickLogoutBtn();
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
            regsPg.InputEmailInput(user.Email);
            regsPg.InputPhoneNumberInput(user.Phone);      
            regsPg.InputPasswordInput("babushka66");
            regsPg.ClickOnCountryChooser();
            regsPg.ClickOnRandomCuntry(); 
            regsPg.Ckeckbox18First();
        }
        [Then(@"user on user-info page should be as expected")]
        public void ThenUserOnUser_InfoPageShouldBeAsExpected()
        {
            User user = (User)_scenarioContext["user"];
            Assert.AreEqual(UserInfoP.GetFirstName(), user.FirstName);
            Assert.AreEqual(UserInfoP.GetLastName(), user.LastName);
            Assert.AreEqual(UserInfoP.GetEmail(), user.Email);
            Assert.AreEqual(UserInfoP.GetPhone(), user.Phone);
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
            //regsPg.ClickAgeCheckbox();  elem not exist
            regsPg.ClickSecondAgeCheckbox();
            
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
            Assert.AreEqual(expected.FirstName /*+ " " + expected.LastName*/, regsPg.GetLoggedName());
        }
        [Then(@"on header should be displayed ""(.*)""")]
        public void ThenOnHeaderShouldBeDisplayed(string nameSurname)
        {
            Assert.AreEqual(nameSurname, regsPg.GetLoggedName(nameSurname));
        }

    }
}
