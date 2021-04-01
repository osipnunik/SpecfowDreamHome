using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class FixedOddsUserPage : BasePage
    {
        public FixedOddsUserPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement FixedOddsHref => WebDriver.FindElement(By.CssSelector("a[href='/fixedodds']"));
        private IList<IWebElement> FirstElementPrices => WebDriver.FindElements(By.CssSelector(".lifestyleProduct-mob:first-child .productPrices p"));
        private IList<IWebElement> FirstProductPricesP => WebDriver.FindElements(By.CssSelector(".lifestyleProductList.container div.lifestyleProduct-mob:first-child div.productPrices div p"));
        
        private IWebElement FirstTitle => WebDriver.FindElement(By.CssSelector("div.lifestyleProductList div.productTitle p"));
       
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("p.none-discount"));
        private IWebElement DiscountNewPrice => WebDriver.FindElement(By.CssSelector("p.discount-new-price"));
        private IWebElement DiscountOldPrice => WebDriver.FindElement(By.CssSelector("div.lifestyleProductList p.discount-old-price"));
        private IWebElement DiscountPercent => WebDriver.FindElement(By.CssSelector("p.discount-percent"));

        private IList<IWebElement> FixedOdds => WebDriver.FindElements(By.CssSelector(".lifestyleProduct-mob .productTitle"));//.productTitle
        private IWebElement LastFixedOddsTitle => WebDriver.FindElement(By.CssSelector(".lifestyleProduct-mob:last-child .productTitle p"));
        string ProductTitleText;
        private IWebElement ProductTitle => WebDriver.FindElement(By.XPath("//div[@class='productTitle']/p[text()='" + ProductTitleText + "']"));
        private IWebElement CartSummFromHeader => WebDriver.FindElement(By.CssSelector("button.headerBtnCart>span"));

        public void ClickFixedOddsHref() => FixedOddsHref.Click();

        internal void ClickOnFirstProduct() => JSClick(FirstTitle);//FirstTitle.Click();

        internal void ScrollAllPrizes()
        {
            string previousLastTitle;
            do
            {
                previousLastTitle = LastFixedOddsTitle.Text;
                ScrollToElement(LastFixedOddsTitle);
                Thread.Sleep(1000);
            } while (!LastFixedOddsTitle.Text.Equals(previousLastTitle));
        }
        
        internal bool IsProductDiscount()
        {
            if(FirstProductPricesP.Count == 3)
            {
                return true;
            }else if (FirstProductPricesP.Count == 1)
            {
                return false;
            }
            else
            {
                throw new Exception("1 or 3 p in prices");
            }
        }

        internal int GetSizeOfFixedOddsList() => FixedOdds.Count;

        internal string GetFirstTitle() => FirstTitle.Text;

        internal string GetDiscountNewPrice() => DiscountNewPrice.Text;

        internal string GetDiscountOldPrice() => DiscountOldPrice.Text;

        internal string GetDiscountPercent() => DiscountPercent.Text;

        internal string GetNonDiscountPrice() => NonDiscountPrice.Text;

        internal void ClickOnNthFixedOdds(int v) => JSClick(FixedOdds[v]);//FixedOdds[v].Click();

        internal void ClickOnProductWithTitle(string title)
        {
            ProductTitleText = title;
            try { ProductTitle.Click(); }
            catch(ElementClickInterceptedException e) { JSClick(ProductTitle); }
        }

        internal string GetCreditFromHeaderBtnCart()
        {
            return CartSummFromHeader.Text.Substring(2);
        }
    }
}
