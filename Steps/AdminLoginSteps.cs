using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    class AdminLoginSteps : BaseStepDefinition
    {
        private LoginAdminPage loginPg = new LoginAdminPage(WebDriver);

        [Given(@"admin logged in")]
        public void GivenAdminLoggedIn()
        {
            WebDriver.Navigate().GoToUrl(DREAM_HOME_VAL);
            loginPg.InputLogin("testqaanuitex@gmail.com");
            loginPg.InputPass("1111111");
            loginPg.ClickSignIn();
        }
    }
}
