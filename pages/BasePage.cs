using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages
{
     class BasePage : LoggerContainer
    {
        public IWebDriver WebDriver { get;}
        public WebDriverWait Waiter { get; }

        protected IWebElement SuccessPopup => WebDriver.FindElement(By.Id("client-snackbar"));
        public string GetPopupText() => SuccessPopup.Text;

        private IWebElement AddPrize => WebDriver.FindElement(By.CssSelector("a.add-button"));
        public void ClickAddPrize() => AddPrize.Click();

        public BasePage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            Waiter = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(6_000));
        }
    }
}
