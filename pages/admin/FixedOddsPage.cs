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
        private IList<IWebElement> PrizeManagementList => WebDriver.FindElements(By.CssSelector(".MuiCollapse-container a"));

        internal void ClickFixedOddsUniversal()
        {
            if(PrizeManagementList.Count == 0)
            {
                PrizeManagementHref.Click();
            }
            FixedOddsLink.Click();
        }
    }
}
