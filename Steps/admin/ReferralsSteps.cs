using NUnit.Framework;
using SpecFlowDreanLotteryHome.pages.admin;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class ReferralsSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        //private TableSortingPage sortPage = new TableSortingPage(WebDriver);
        private ReferralsPage reffP = new ReferralsPage(WebDriver);

        public ReferralsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"go to referrals")]
        public void GivenGoToReferrals()
        {
            //WebDriver.Manage().Cookies.DeleteAllCookies();
            //WebDriver.Navigate().Refresh();
            //WebDriver.Navigate().GoToUrl(MainAdminPageURL + "/#/referrals");
            reffP.ClickReferralsUniversal();
        }
        
        [When(@"admin check first user")]
        public void WhenAdminCheckFirstUser()
        {
            reffP.ClickFirstReferals();
        }
        
        [When(@"input in default amount random number from (.*) to (.*)")]
        public void WhenInputInDefaultAmountRandomNumberFromTo(int n1, int n2)
        {
            reffP.ClearDefaultEuro();
            Random rand = new Random(n1);
            string n = rand.Next(n2).ToString();
            _scenarioContext.Add("defaultEuro", n);
            reffP.InputDefaultEuro(n);
        }
        
        [When(@"click Save default values for users")]
        public void WhenClickSaveDefaultValuesForUsers()
        {
            reffP.ClickEuroSaveDefaultValue();
        }
        
        [Then(@"admin see referrals page")]
        public void ThenAdminSeeReferralsPage()
        {
            Assert.IsTrue(WebDriver.Url.EndsWith("referrals"));
        }
        
        [Then(@"the first user has default value as generated earlier")]
        public void ThenTheFirstUserHasDefaultValueAsGeneratedEarlier()
        {
            Assert.AreEqual("0/"+(string)_scenarioContext["defaultEuro"], reffP.GetSixthRowDatatd()[0]);
        }

        [Then(@"text message ""(.*)"" appeared")]
        public void ThenTextMessageAppeared(string p0)
        {
            Assert.AreEqual(p0, reffP.GetPopupText());
        }

    }
}
