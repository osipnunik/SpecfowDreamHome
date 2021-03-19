﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class BasketPage : BasePage
    {
        public BasketPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement FirstProductTitle => WebDriver.FindElement(By.CssSelector("tbody th"));
        private IWebElement FirstProductPrice => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(2)"));
        private IWebElement FirstProductAmount => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(3) span"));
        private IWebElement FirstProductTotalPrice => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(4) "));
        private IWebElement FirstProductCloseBtn => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(5) button"));

        private IWebElement TotalPriceValue => WebDriver.FindElement(By.CssSelector("div.itemPrice:first-child span"));
        private IWebElement TotalSaving => WebDriver.FindElement(By.CssSelector("div.itemPrice:last-child span"));
        private IWebElement CreditEarnedValue => WebDriver.FindElement(By.CssSelector("div.earned span"));
        private IWebElement PayBtn => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.Id("pay-button")));
        private IWebElement CardNameInput => WebDriver.FindElement(By.CssSelector("input[name='cardnumber']"));
        private IWebElement ExpDateInput => WebDriver.FindElement(By.CssSelector("input[name='exp-date']"));
        private IWebElement CVC => WebDriver.FindElement(By.Id("checkout-frames-cvv"));
        private IWebElement CardNumberActivator => WebDriver.FindElement(By.CssSelector("iframe[name='checkout-frames-cardNumber']"));
        private IWebElement ExpDateActivator => WebDriver.FindElement(By.Id("expiryDate"));
        private IWebElement CVCActivator => WebDriver.FindElement(By.Id("cvv"));
        private IWebElement PayButton => WebDriver.FindElement(By.Id("pay-button"));
        private IWebElement OrderCompletedHeader => WebDriver.FindElement(By.CssSelector("h1.orderCompleted"));

        public string GetFirstProductTitle() => FirstProductTitle.Text;
        public string GetFirstProductPrice() => FirstProductPrice.Text;
        public string GetFirstProductAmount() => FirstProductAmount.Text;
        public string GetFirstProductTotalPrice() => FirstProductTotalPrice.Text;
        public void ClickFirstProductCloseBtn() => FirstProductCloseBtn.Click();
        public string GetTotalPriceValue() => TotalPriceValue.Text;
        public string GetTotalSaving() => TotalSaving.Text;
        public string GetCreditEarnedValue() => CreditEarnedValue.Text;
        public void ClickBasketPayButton()
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click();", PayButton);
           /* Actions actions = new Actions(WebDriver);
            actions.MoveToElement(PayButton).Click().Perform();*/
            //PayBtn.Click();
        }
        internal void ClickCardPayBtn()
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click();", PayButton);
        }

        internal void InputCardName(string v)
        {
            
            try { CardNameInput.SendKeys(v); }
            catch (NoSuchElementException e)
            {
                
                CardNumberActivator.SendKeys(v);
                //CardNumberActivator.SendKeys("1122");
            }
        }
        internal void InputExpDate(string v) {
            try { ExpDateInput.SendKeys(v); }
            catch (NoSuchElementException e)
            {
                ExpDateActivator.SendKeys(Keys.Enter);
                ExpDateActivator.SendKeys(v);
            }
        }
        internal void InputCVC(string v)
        {
            try { CVC.SendKeys(v); }
            catch (NoSuchElementException e)
            {
                CVCActivator.SendKeys(v);
            }
        }
        public bool OrderCompletedVisible() => OrderCompletedHeader.Displayed;
    }
}
