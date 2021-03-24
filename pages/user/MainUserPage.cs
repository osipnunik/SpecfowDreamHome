using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class MainUserPage : BasePage
    {
        public MainUserPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement FirstEnterNow => WebDriver.FindElement(By.CssSelector(".winFlatBtn"));
        private IWebElement FirstFindOutMore => WebDriver.FindElement(By.XPath("//button[text()='Find out more']"));
        private IWebElement FindOutMorAtHowItWorks => WebDriver.FindElement(By.XPath("//div[@class='howMain']/..//button"));
        private string Title;
        private IWebElement FirstFindOutMoreAtTitle => WebDriver.FindElement(By.XPath("//h3[text()='"+Title+"']/..//button"));

        public void ClickFirstEnterNow()
        {
            JSClick(FirstEnterNow);
            //FirstEnterNow.Click();
        }
        public void ClickFirstFindOutMore()
        {
            JSClick(FirstFindOutMore);
            //FirstEnterNow.Click();
        }
        public void ClickFindOutMoreAtHowItWorkd() => FindOutMorAtHowItWorks.Click();
        public void ClickFindOutMoreAtHowItWorkd(string title)
        {
            Title = title;
            JSClick(FirstFindOutMoreAtTitle);
            //FirstFindOutMoreAtTitle.Click();
        }
    }
}
