using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin.fragments
{
    class PaginationFragment /*: BasePage*/
    {
        IWebDriver WebDriver;
        public PaginationFragment(IWebDriver webDriver) /*: base(webDriver)*/ { WebDriver = webDriver; }
        private By RowsPerPageChooserBy = By.CssSelector("div.MuiTablePagination-select");
        private IWebElement RowsPerPageChooser => WebDriver.FindElement(RowsPerPageChooserBy);
        private IWebElement NextPage => WebDriver.FindElement(By.CssSelector("button[title='Next page']"));
        private IWebElement PreviousPage => WebDriver.FindElement(By.CssSelector("button[title='Previous page']"));
        private IWebElement LastPage => WebDriver.FindElement(By.CssSelector("div[title = 'Last Page']"));
        private IWebElement FirstPage => WebDriver.FindElement(By.CssSelector("div[title = 'First Page']"));

        public void ClickNextPage() => NextPage.Click();
        public void ClickPreviousPage() => PreviousPage.Click();
        public void ClickLastPage()
        {
            Actions act = new Actions(WebDriver);
            act.MoveToElement(LastPage);
            act.Perform();
            LastPage.Click();
        }
        public void ClickFirstPage() => FirstPage.Click();

        public void ChooseSelect(int perNum)
        {
            //Waiter.Until(ExpectedConditions.ElementExists(RowsPerPageChooserBy));
            RowsPerPageChooser.Click();
            WebDriver.FindElement(By.XPath("//li[text()='" + perNum + "']")).Click();
        }

        internal bool IsRowsPerPageElementWithTextDisplayed(string textForElement)
        {            
            //Waiter.Until(ExpectedConditions.TextToBePresentInElementValue(RowsPerPage, textForElement));
            return RowsPerPageChooser.Displayed;
        }
    }
}
