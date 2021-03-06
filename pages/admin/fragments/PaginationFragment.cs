using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin.fragments
{
    class PaginationFragment : BasePage
    {
        public PaginationFragment(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement NextPage => WebDriver.FindElement(By.CssSelector("button[title='Next page']"));
        private IWebElement PreviousPage => WebDriver.FindElement(By.CssSelector("button[title='Previous page']"));
        private IWebElement LastPage => WebDriver.FindElement(By.CssSelector("div[title = 'Last Page']"));
        private IWebElement FirstPage => WebDriver.FindElement(By.CssSelector("div[title = 'First Page']"));

        public void ClickNextPage() => NextPage.Click();
        public void ClickPreviousPage() => PreviousPage.Click();
        public void ClickLastPage() => LastPage.Click();
        public void ClickFirstPage() => FirstPage.Click();

    }
}
