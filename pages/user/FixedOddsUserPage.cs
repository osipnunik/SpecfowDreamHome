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
        private IWebElement FirstTitle => WebDriver.FindElement(By.CssSelector(".productTitle p"));
        private IList<IWebElement> FirstProductPricesP => WebDriver.FindElements(By.CssSelector(".lifestyleProductList.container div.lifestyleProduct-mob:first-child div.productPrices div p"));

        public void ClickFixedOddsHref() => FixedOddsHref.Click();

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
    }
}
