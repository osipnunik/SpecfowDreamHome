using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin.fragments
{
    class MenuExistingElsFragment : BasePage
    {
        public MenuExistingElsFragment(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement UniversalPrizeManagement => WebDriver.FindElement(By.CssSelector("div.menu-wrap li:first-child"));
        private IWebElement UniversalSetting => WebDriver.FindElement(By.CssSelector("div.menu-wrap li:last-of-type"));

        private IWebElement TitledOpenizerPrizeManagement => WebDriver.FindElement(By.CssSelector("li[title='Prize Management']"));
        private IWebElement TitledOpenizerSetting => WebDriver.FindElement(By.CssSelector("li[title='Settings']"));
        private IWebElement UntitledLiFirst => WebDriver.FindElement(By.CssSelector("li:not([title])"));
        private IWebElement UntitledLiSecond => WebDriver.FindElement(By.CssSelector("li:not([title]):nth-of-type(2)"));

        private IWebElement ActiveLink => WebDriver.FindElement(By.CssSelector("a.link-active"));
        private IWebElement TitledDreamHomeLink => WebDriver.FindElement(By.CssSelector("a[title = 'Dream home']"));
        private IWebElement TitledLifeStylePrizeLink => WebDriver.FindElement(By.CssSelector("a[title='Lifestyle Prizes']"));
        private IWebElement TitledFixedOddsLink => WebDriver.FindElement(By.CssSelector("a[title='Fixed Odds']"));

        private IWebElement LifeStyleHrefReliable => WebDriver.FindElement(By.CssSelector("a[href='#/prizes']"));
        private IWebElement StaffManagementHrefReliable => WebDriver.FindElement(By.CssSelector("a[href='#/staffUsers']"));
        
        private IWebElement FixedOddsHrefReliable => WebDriver.FindElement(By.CssSelector("a[href='#/fixedOdds']"));

        public void ClickTitledOpenizerPrizeManagement ()=> TitledOpenizerPrizeManagement.Click();
        public void ClickTitledOpenizerSetting() => TitledOpenizerSetting.Click();
        public void ClickUntitledLiFirst() => UntitledLiFirst.Click();
        public void ClickUntitledLiSecond() => UntitledLiSecond.Click();
        public void ClickActiveLink() => ActiveLink.Click();
        public void ClickTitledDreamHomeLink() => TitledDreamHomeLink.Click();
        public void ClickTitledLifeStylePrizeLink() => TitledLifeStylePrizeLink.Click();
        public void ClickTitledFixedOddsLink() => TitledFixedOddsLink.Click();

        public void ClickLifeStylePrizeHrefReliable() => LifeStyleHrefReliable.Click();
        public void ClickStaffManagementHrefReliable() => StaffManagementHrefReliable.Click();
        public void ClickFixedOddsHrefReliable() => FixedOddsHrefReliable.Click();

        

    }

}

