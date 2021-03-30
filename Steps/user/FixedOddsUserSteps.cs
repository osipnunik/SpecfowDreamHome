using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.user;
using System;
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
            FixedOddsP.ScrollAllPrizes();
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
            _scenarioContext.Add("randNum", randNum);
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

    }
}
