using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class ReferralsPage : BasePage
    {
        public static PaginationFragment Paginats;

        public ReferralsPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }

        private IList<IWebElement> SettingList => WebDriver.FindElements(By.CssSelector(".MuiCollapse-container a"));
        private IWebElement SettingHref => WebDriver.FindElement(By.XPath("//span[text()='Settings']"));
        private IList<IWebElement> ReferralsLinks => WebDriver.FindElements/*Waiter.Until(ExpectedConditions.ElementToBeClickable*/(By.CssSelector("a[title='Refferals']"));

        private IWebElement ReferralsLink => WebDriver.FindElement/*Waiter.Until(ExpectedConditions.ElementToBeClickable*/(By.CssSelector("a[title='Refferals']"));
        private IWebElement DefaultEuroInput => WebDriver.FindElement(By.CssSelector("input[name='defaultNeededToSpentAmount']"));
        private IWebElement DefaultCreditsInput => WebDriver.FindElement(By.CssSelector("input[name='defaultCreditsAmount']"));

        internal void ClearDefaultEuro() { 
            DefaultEuroInput.Clear();
            DefaultEuroInput.SendKeys(Keys.Control + "a");
            DefaultEuroInput.SendKeys(Keys.Delete);
        }

        private IWebElement EuroSaveBtn => WebDriver.FindElement(By.XPath("(//button/span[contains(text(), 'Save')])[1]"));
        private IWebElement CreditsSaveBtn => WebDriver.FindElement(By.XPath("(//button/span[contains(text(), 'Save')])[2]"));
        private IWebElement FirstRefferalCheckbox => WebDriver.FindElement(By.CssSelector("table tbody:nth-child(2) tr td input"));


        internal void ClickFirstReferals() => JSClick(FirstRefferalCheckbox);//FirstRefferalCheckbox.Click();

        private IList<IWebElement> SixthRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(6)"));

        internal void InputDefaultEuro(string n)
        {
            DefaultEuroInput.SendKeys(n);
        }

        public void ClickReferralsUniversal()
        {
            SettingHref.Click();
            //Thread.Sleep(500);
            while (!WebDriver.Url.EndsWith("referrals"))
            {
                if (ReferralsLinks.Count == 0/*SettingList.Count == 0*/)
                {
                    SettingHref.Click();                   
                }
                //Thread.Sleep(500);
                if(ReferralsLinks.Count == 0) { continue; }
                JSClick(ReferralsLink);
            }
        }

        internal void ClickEuroSaveDefaultValue() => EuroSaveBtn.Click();
        internal void ClickDefaultCreditsSaveDefaultValue() => CreditsSaveBtn.Click();

        public List<string> GetSixthRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < SixthRowDatatd.Count; i++)
            {
                data.Add(SixthRowDatatd[i].Text);
            }
            return data;
        }

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
