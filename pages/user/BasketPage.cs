using NUnit.Framework;
using OpenQA.Selenium;
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

        private IWebElement ButtonHeaderCart => WebDriver.FindElement(By.CssSelector("button.headerBtnCart"));
        private IWebElement FirstProductTitle => WebDriver.FindElement(By.CssSelector("tbody th"));
        private IWebElement FirstProductPrice => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(2)"));
        private IWebElement FirstProductAmount => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(3) span"));
        private IWebElement FirstProductTotalPrice => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(4) "));
        private IList<IWebElement> TotalPrices => WebDriver.FindElements(By.CssSelector("div.basketTableDesktop tbody td:nth-child(4)"));
        private IList<IWebElement> YourPrices => WebDriver.FindElements(By.CssSelector("div.basketTableDesktop tbody td:nth-child(5)"));
        
        private IWebElement FirstProductCloseBtn => WebDriver.FindElement(By.CssSelector("tbody td:nth-child(5) button"));

        private IWebElement LastProductTitle => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child th"));
        private IWebElement LastProductPrice => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child td:nth-child(2)"));
        private IWebElement LastProductAmount => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child td:nth-child(3) span"));
        private IWebElement LastProductTotalPrice => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child td:nth-child(4)"));
        private IWebElement LastProductTotalPriceWithDiscount => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child td:nth-child(4)"));

        private IWebElement LastProductCloseBtn => WebDriver.FindElement(By.CssSelector("div.basketTableDesktop tbody tr:last-child td:nth-child(6) button"));
        private IList<IWebElement> CloseList => WebDriver.FindElements(By.CssSelector("div.basketTableDesktop td:nth-child(6) button"));

        private By ByTotalPriceAll => By.CssSelector("div.itemPrice:first-child span");
        private IWebElement TotalPriceValue => WebDriver.FindElement(ByTotalPriceAll);       
        private IWebElement TotalSaving => WebDriver.FindElement(By.CssSelector("div.itemPrice:last-child span"));
        private IWebElement CreditEarnedValue => WebDriver.FindElement(By.CssSelector("div.earned span"));
        private IWebElement PayBtn => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.Id("pay-button")));
        private IWebElement CardNameInput => WebDriver.FindElement(By.CssSelector("input[name='cardnumber']"));
        private IWebElement ExpDateInput => WebDriver.FindElement(By.CssSelector("input[name='exp-date']"));
        private IWebElement ExpDateActivator => WebDriver.FindElement(By.CssSelector("iframe[id='expiryDate']"));

        private IWebElement CVC => WebDriver.FindElement(By.CssSelector("input[name='cvc']"));//("checkout-frames-cvv"));
        private IWebElement CvcActivator => WebDriver.FindElement(By.CssSelector("#frames-element-cvv"));
        private IWebElement CardNumberActivator => WebDriver.FindElement(By.CssSelector("iframe[name='checkout-frames-cardNumber']"));
        private IWebElement ExpDateFake => Waiter.Until(ExpectedConditions.ElementExists(By.Id("checkout-fake-input-expiryDate")));

        private IWebElement PayButton => WebDriver.FindElement(By.Id("pay-button"));
        private IWebElement OrderCompletedHeader => WebDriver.FindElement(By.CssSelector("h1.orderCompleted"));
        private IList<IWebElement> ErrorMessage => WebDriver.FindElements(By.CssSelector("span.error-message"));
        
        internal void WaitWhileBeOnBasketPage()
        {
            Waiter.Until(ExpectedConditions.ElementExists(By.XPath("//thead//th[text()='ITEMS']")));
        }
        internal double GetYourPricesSumCheckCurrency()
        {
            List<string> YourPrices = this.GetYourPrices();
            double sum = 0;
            foreach (string yourPrice in YourPrices)
            {
               // string pr = //yourPrice.Split(" ");
                Assert.AreEqual("£", yourPrice.Substring(0, 1));
                sum += double.Parse(yourPrice.Substring(1));
            }
            return sum;
        }
        internal double GetTotalPricesSumCheckCurrency()
        {
            List<string> TotalPrices = this.GetTotalPrices();
            double sum = 0;
            foreach (string totalPrice in TotalPrices)
            {
                Assert.AreEqual("£", totalPrice.Substring(0, 1));
                sum += double.Parse(totalPrice.Substring(1));
            }
            return sum;
        }
        internal List<string> GetYourPrices()
        {
            List<string> yourPrices = new List<string>(YourPrices.Count);
            for(int i = 0; i < YourPrices.Count; i++)
            {
                yourPrices.Add(YourPrices[i].Text);
            }               
            return yourPrices;
        }
        internal List<string> GetTotalPrices()
        {
            List<string> totalPricesStrings = new List<string>(TotalPrices.Count);
            for (int i = 0; i < TotalPrices.Count; i++)
            {
                totalPricesStrings.Add(TotalPrices[i].Text);
            }
            return totalPricesStrings;
        }

        internal void ClickHeaderBtnCart()
        {
            try { ButtonHeaderCart.Click(); }
            catch (ElementClickInterceptedException) { JSClick(ButtonHeaderCart); }
        }

        internal void CloseAllItemsInBasket()
        {
            /*foreach(var el in CloseList)
            {
                el.Click();
            } */
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("document.querySelectorAll('button.btnRemoveOrder').forEach(function(item){ item.click();});");
        }

        public string GetFirstProductTitle() => FirstProductTitle.Text;
        public string GetFirstProductPrice() => FirstProductPrice.Text;
        public string GetFirstProductAmount() => FirstProductAmount.Text;
        public string GetFirstProductTotalPrice() => FirstProductTotalPrice.Text;
        public void ClickFirstProductCloseBtn() => FirstProductCloseBtn.Click();

        public string GetLastProductTitle() => LastProductTitle.Text;
        public string GetLastProductPrice() => LastProductPrice.Text;
        public string GetLastProductAmount() => LastProductAmount.Text;
        public string GetLastProductTotalPrice() => LastProductTotalPrice.Text;
        public string GetLastProductTotalPriceWithDiscount() => LastProductTotalPriceWithDiscount.Text;
        public void ClickLastProductCloseBtn() => LastProductCloseBtn.Click();

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
        public string GetCardNumber() => CardNumberActivator.Text;
        public bool ErrorMessageExist() => ErrorMessage.Count > 0;
        public bool CardNumberTextEmptyNull() => CardNumberActivator.GetAttribute("value") != "";
        internal void InputCardName(string v)
        {
            /*try { CardNameInput.SendKeys(v); }
            catch (NoSuchElementException e)
            {*/
                CardNumberActivator.SendKeys(v);
                //CardNumberActivator.SendKeys("1122");           
        }
        internal void InputExpDate(string v) {
            ExpDateActivator.SendKeys(v);
            try { ExpDateInput.SendKeys(v); }
            catch (NoSuchElementException e)
            {
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            //jse.ExecuteScript("arguments[0].value=" + v + ";", WebDriver.FindElement(By.Id("checkout-frames-expiry-date")));
                //ExpDateActivator.SendKeys(Keys.Enter);
                //ExpDateActivator.SendKeys(v);
            }
        }
        internal void InputCVC(string v)
        {
            CvcActivator.SendKeys(v);
            try { CVC.Click(); CVC.SendKeys(v); }
            catch (NoSuchElementException e)
            {
                //CVCActivator.SendKeys(v);
                CVC.SendKeys(v);
            }
        }
        public bool OrderCompletedVisible() => OrderCompletedHeader.Displayed;
       
    }
}
