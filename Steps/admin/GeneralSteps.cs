using NUnit.Framework;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class GeneralSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private FixedOddsPage FixedOddsP = new FixedOddsPage(WebDriver);
        private MenuExistingElsFragment menuF = new MenuExistingElsFragment(WebDriver);
        private GeneralPage generalP = new GeneralPage(WebDriver);

        public GeneralSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"go to general")]
        public void GivenGoToGeneral()
        {
            generalP.GoToGeneral();
        }
        [When(@"click on credit")]
        public void WhenClickOnCredit() => generalP.ClickCreditTab();

        [When(@"notice discounts")]
        public void WhenNoticeDiscounts()
        {
            Dictionary<int, int> amountPercents = generalP.GetDiscounts();          
            _scenarioContext.Add("amountPercents", amountPercents);
        }

        [When(@"click on discount")]
        public void WhenClickOnDiscount() => generalP.ClickDiscountTab();
        
        [Then(@"notice credits and check it with credits per Funt")]
        public void ThenNoticeCreditsAndCheckItWithCreditsPerFunt()
        {
            Dictionary<double, int> eurosPercents = generalP.GetCredits();
            List<double> euroPerCredits = generalP.GetEuroPerCredit();
            int i = 0;
            foreach(KeyValuePair<double, int> keyValue in eurosPercents)
            {
                Assert.AreEqual(Math.Round(euroPerCredits[i], 2), ((double)keyValue.Value)/100);
                i++;
            }
            _scenarioContext.Add("eurosPercentsCredits", eurosPercents);
        }
        [When(@"notice credits")]
        public void WhenNoticeCredits()
        {
            Dictionary<double, int> amountPercents = generalP.GetCredits();//Discounts();          
            _scenarioContext.Add("eurosPercentsCredits", amountPercents);
        }

        [When(@"make credit percents at Fixed Odds bigger on (.*) than on general admin page")]
        public void WhenMakeCreditPercentsAtFixedOddsBiggerOnThanOnGeneralAdminPage(int p0)
        {
            Dictionary<double, int> eurosPercents = (Dictionary<double, int>)_scenarioContext["eurosPercentsCredits"];
            Dictionary<double, int> newEurosPercents = new Dictionary<double, int>(eurosPercents.Count);
            foreach (KeyValuePair<double, int> keyValue in eurosPercents)
            {
                newEurosPercents.Add(keyValue.Key, keyValue.Value + 1);
            }            
            ScenarioContext.Current["eurosPercentsCredits"] = newEurosPercents;
        }
        [When(@"make discount percents at Fixed Odds bigger on (.*) than on general admin page")]
        public void WhenMakeDiscountPercentsAtFixedOddsBiggerOnThanOnGeneralAdminPage(int p0)
        {
            Dictionary<int, int> amountPercents = (Dictionary<int, int>)_scenarioContext["amountPercents"];
            Dictionary<int, int> newEurosPercents = new Dictionary<int, int>(amountPercents.Count);
            foreach (KeyValuePair<int, int> keyValue in amountPercents)
            {
                newEurosPercents.Add(keyValue.Key, keyValue.Value + 1);
            }
            ScenarioContext.Current["amountPercents"] = newEurosPercents;
        }

        /* [When(@"make discount percents at Fixed Odds bigger on (.*) than on general admin page")]
         public void WhenMakeDiscountPercentsAtFixedOddsBiggerOnThanOnGeneralAdminPage(int p0)
         {
             Dictionary<int, int> eurosPercents = (Dictionary<int, int>)_scenarioContext["eurosPercentsCredits"];
             Dictionary<int, int> newEurosPercents = new Dictionary<int, int>(eurosPercents.Count);
             foreach (KeyValuePair<int, int> keyValue in eurosPercents)
             {
                 newEurosPercents.Add(keyValue.Key, keyValue.Value + 1);
             }
             ScenarioContext.Current["eurosPercentsCredits"] = newEurosPercents;
         }*/

    }
}
