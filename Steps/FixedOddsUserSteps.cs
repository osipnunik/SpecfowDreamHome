using SpecFlowDreanLotteryHome.pages.user;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
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
            FixedOddsP.GetFirstTitle();
            if (FixedOddsP.IsProductDiscount())
            {
                _scenarioContext.Add("OldPriceFromList",FixedOddsP.GetOldPrice());
                _scenarioContext.Add("NewPriceFromList", FixedOddsP.GetNewPrice());
                _scenarioContext.Add("DiscountFromList", FixedOddsP.GetDiscount());
            }
            else
            {
                _scenarioContext.Add("NonDiscountPriceFromList", FixedOddsP.GetNonDiscountPrice());
            }
        }
    }
}
