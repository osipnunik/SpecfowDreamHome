using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    class DialogGeneralPrizeUserSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private DialogGeneralPrizeUserPage dialogP = new DialogGeneralPrizeUserPage(WebDriver);
        public DialogGeneralPrizeUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user choose number randomly")]
        public void WhenUserChooseNumberOfTicketAs()
        {
            int[] arr = { 1, 5, 10, 20, 50, 100 };
            int num = arr[new Random().Next(arr.Length)];
            dialogP.ClickTicketsQuantity(num.ToString());
            _scenarioContext.Add("ticketQuantity", num.ToString());
        }
    }
}
