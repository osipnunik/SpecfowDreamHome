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

    }
}
