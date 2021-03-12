using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class CompetitionPage : BasePage
    {
        public CompetitionPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement LifeStylePrizesLink => WebDriver.FindElement(By.CssSelector("a[title='Lifestyle Prizes']"));


    }
}
