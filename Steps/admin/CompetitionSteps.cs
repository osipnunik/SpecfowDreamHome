using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    class CompetitionSteps : BaseStepDefinition
    {
        private CompetitionPage compP = new CompetitionPage(WebDriver);


    }
}
