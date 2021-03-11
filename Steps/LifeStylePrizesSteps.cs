using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    class LifeStylePrizesSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private LifeStylePrizesPage LfStylePPage = new LifeStylePrizesPage(WebDriver);
        private FixedOddsPage FixedOddsP = new FixedOddsPage(WebDriver); 

        public LifeStylePrizesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"click Life Style prize")]
        public void GivenClickLifeStylePrize()
        {
            LfStylePPage.ClickLifeStylePrizes();
        }
        [Given(@"click Fixed odds")]
        public void GivenClickFixedOdds()
        {
            FixedOddsP.ClickFixedOdds();
        }

        [When(@"click add new prize")]
        public void WhenClickAddNewPrize()
        {
            LfStylePPage.ClickAddPrize();
        }
       
        [When(@"choose category ""(.*)""")]
        public void WhenChooseCategory(string p0)
        {
            LfStylePPage.ChooseCategory(p0);
        }
        [When(@"input Life Style prize title as ""(.*)""")]
        public void WhenInputLifeStylePrizeTitleAs(string p0)
        {
            LfStylePPage.InputTitle(p0);
        }
        [When(@"go to Discount & ticket tab at Life prize")]
        public void WhenGoToDiscountTicketTabAtLifePrize()
        {
            LfStylePPage.GoToDiscountTicketTab();
        }
        [When(@"upload non house main picture")]
        public void WhenUploadNonHouseMainPicture()
        {
            LfStylePPage.UploadMainNonHomePicture();
        }

    }
}
