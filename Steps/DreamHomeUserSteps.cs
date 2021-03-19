using SpecFlowDreanLotteryHome.pages.user;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    public class DreamHomeUserSteps : BaseStepDefinition
    {
        private DialogGeneralPrizeUserPage DreamHomeUsrPage = new DialogGeneralPrizeUserPage(WebDriver);
        private LifeStylePrizesUsersPage lifeStylePage = new LifeStylePrizesUsersPage(WebDriver);

        /*[When(@"notice price, total price,")]
        public void WhenNoticePriceTotalPrice()
        {
            bool discountPresent = DreamHomeUsrPage.
            lifeStylePage.GetTitle();
            if (!discountPresent) { lifeStylePage.GetNonDiscountPrice(); }
            else {
                lifeStylePage.GetDiscountNewPrice();
                lifeStylePage.GetDiscountOldPrice();
                lifeStylePage.GetDiscountPercent(); 
            }           
        }
        
        [Then(@"user check total price, total saving")]
        public void ThenUserCheckTotalPriceTotalSaving()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
