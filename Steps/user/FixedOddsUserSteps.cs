using NUnit.Framework;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.user
{
    [Binding]
    public class FixedOddsUserSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private FixedOddsUserPage FixedOddsP = new FixedOddsUserPage(WebDriver);

        public FixedOddsUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user go to Fexed Odds")]
        public void WhenUserGoToFexedOdds() => FixedOddsP.ClickFixedOddsHref();

        [When(@"user scroll untill additional prizes appeared")]
        public void WhenUserScrollUntillAdditionalPrizesAppeared()
        {
            FixedOddsP.ScrollAllPrizesWithJs();
        }

        [When(@"notice all info about first product from fixedOddsList")]
        public void WhenNoticeAllInfoAboutFirstProduct()
        {
            //Product prod = new Product();
            _scenarioContext.Add("titleFromList", FixedOddsP.GetFirstTitle());
            if (FixedOddsP.IsProductDiscount())
            {
                _scenarioContext.Add("OldPriceFromList", FixedOddsP.GetDiscountOldPrice());
                _scenarioContext.Add("NewPriceFromList", FixedOddsP.GetDiscountNewPrice());
                _scenarioContext.Add("DiscountFromList", FixedOddsP.GetDiscountPercent());
            }
            else
            {
                _scenarioContext.Add("NonDiscountPriceFromList", FixedOddsP.GetNonDiscountPrice());
            }
        }
        [When(@"click on first Fixed Odds prize")]
        public void WhenClickOnFirstFixedOddsPrize()
        {
            FixedOddsP.ClickOnFirstProduct();
        }  

        [When(@"user choose randomly element")]
        public void WhenUserChooseRandomlyElement()
        {
            int size = FixedOddsP.GetSizeOfFixedOddsList();
            Random r = new Random();
            int randNum = r.Next(size);
            _scenarioContext.Remove("randNum");
            _scenarioContext.Add("randNum", randNum);
        }
        [When(@"user click on this element")]
        public void WhenUserClickOnThisElement()
        {
            int randNum = (int)_scenarioContext["randNum"];
            FixedOddsP.ClickOnNthFixedOdds(randNum);
        }

        [When(@"user notice all info about this element from fixedOddsList")]
        public void WhenUserNoticeAllInfoAboutThisElementFromFixedOddsList()
        {
           /* var choosen = (int)_scenarioContext["randNum"];
            _scenarioContext.Add("titleFromList", FixedOddsP.GetNthTitle());
            if (FixedOddsP.IsProductDiscount())
            {
                _scenarioContext.Add("OldPriceFromList", FixedOddsP.GetDiscountOldPrice());
                _scenarioContext.Add("NewPriceFromList", FixedOddsP.GetDiscountNewPrice());
                _scenarioContext.Add("DiscountFromList", FixedOddsP.GetDiscountPercent());
            }
            else
            {
                _scenarioContext.Add("NonDiscountPriceFromList", FixedOddsP.GetNonDiscountPrice());
            }*/
        }
        [When(@"click on choosen earlier Fixed Odds prize")]
        public void WhenClickOnChoosenEarlierFixedOddsPrize()
        {
            FixedOddsP.ClickOnNthFixedOdds((int)_scenarioContext["randNum"]);
        }
        [When(@"notice initial credit amount")]
        public void WhenNoticeInitialCreditAmount()
        {
            _scenarioContext.Add("headerCredits", FixedOddsP.GetCreditFromHeaderBtnCart());
        }
        [Then(@"credit amount should be the sum of initial credit amount and rememberd")]
        public void ThenCreditAmountShouldBeTheSumOfInitialCreditAmountAndRememberd()
        {
            string credEarn = (string)_scenarioContext["creditEarned"];
            double dialogCredit = double.Parse(credEarn.Substring(2));
            double initialCredit = double.Parse((string)_scenarioContext["headerCredits"]);
            string actualCredit = double.Parse(FixedOddsP.GetCreditFromHeaderBtnCart()).ToString("N2");
            bool equal = (dialogCredit + initialCredit).ToString("N2").Equals(actualCredit);
            if (equal) { Assert.IsTrue(equal); }
            else {
                Thread.Sleep(2000);
                actualCredit = double.Parse(FixedOddsP.GetCreditFromHeaderBtnCart()).ToString("N2");
                Assert.AreEqual((dialogCredit + initialCredit).ToString("N2"), actualCredit, "earned not increase header cart appropriate"+ (dialogCredit + initialCredit)+
                    " "+ dialogCredit+" "+ initialCredit); 
            }
        }
        [Then(@"credit on header should be zero")]
        public void ThenCreditOnHeaderShouldBeZero()
        {
            Assert.AreEqual("0.00", FixedOddsP.GetCreditFromHeaderBtnCart());
        }
       
        [When(@"click on earlier random generated title")]
        public void WhenClickOnEarlierRandomGeneratedTitle()
        {
            string title = (string)_scenarioContext["title"];
            FixedOddsP.ClickOnProductWithTitle(title);
        }

    }
}
