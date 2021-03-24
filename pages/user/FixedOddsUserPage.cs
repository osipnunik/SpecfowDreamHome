using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void ClickFixedOddsHref() => FixedOddsHref.Click();

        internal void ClickOnFirstProduct() => FirstTitle.Click();

        /*public bool IsFirstProductDiscount()
        {
            if(FirstElementPrices.Count == 3)
            {
                return true;
            }else if (FirstElementPrices.Count == 1)
            {
                return false;
            }
            else { throw new Exception("1 or 3 p in .productPrices"); }
        }*/

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

        internal string GetFirstTitle() => FirstTitle.Text;

        internal string GetDiscountNewPrice() => DiscountNewPrice.Text;

        internal string GetDiscountOldPrice() => DiscountOldPrice.Text;

        internal string GetDiscountPercent() => DiscountPercent.Text;

        internal string GetNonDiscountPrice() => NonDiscountPrice.Text;

    }
}
