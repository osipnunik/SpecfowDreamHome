using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    class AdminLoginSteps : BaseStepDefinition
    {
        private LoginAdminPage loginPg = new LoginAdminPage(WebDriver);

        [Given(@"admin logged in")]
        public void GivenAdminLoggedIn()
        {
            WebDriver.Navigate().GoToUrl(DREAM_HOME_ADM_VAL);
            if (WebDriver.Url.Equals(LOGIN_ADMiN_VAL))
            {
                loginPg.InputLogin("testqaanuitex@mail.com");
                loginPg.InputPass("000000");
                loginPg.ClickSignIn();
            }
        }
    }
}
