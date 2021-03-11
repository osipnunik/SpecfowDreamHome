using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class FixedOddsPage : BasePage
    {
        public FixedOddsPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement PrizeManagementHref => WebDriver.FindElement(By.XPath("//span[text()='Prize Management']"));
        private IWebElement FixedOddsLink => WebDriver.FindElement(By.CssSelector("a[title='Fixed Odds']"));

        internal void ClickFixedOdds()
        {
            PrizeManagementHref.Click();
            FixedOddsLink.Click();

        }
    }
}
