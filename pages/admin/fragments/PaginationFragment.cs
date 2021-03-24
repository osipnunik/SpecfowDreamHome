using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin.fragments
{
    class PaginationFragment : BasePage
    {
        //IWebDriver WebDriver;
        public PaginationFragment(IWebDriver webDriver) : base(webDriver) {  }
        private By RowsPerPageChooserBy = By.CssSelector("div.MuiTablePagination-select");
        private IWebElement RowsPerPageChooser => WebDriver.FindElement(RowsPerPageChooserBy);
        private IWebElement PaginInfo => WebDriver.FindElement(By.CssSelector("p.MuiTablePagination-caption:nth-of-type(2)"));
        private IWebElement NextPage => WebDriver.FindElement(By.CssSelector("button[title='Next page']"));
        private IWebElement PreviousPage => WebDriver.FindElement(By.CssSelector("button[title='Previous page']"));
        private IWebElement LastPage => Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("div[title = 'Last Page']")));
        private IWebElement FirstPage => WebDriver.FindElement(By.CssSelector("div[title = 'First Page']"));
        
        public void ClickNextPage() => NextPage.Click();
        public void ClickPreviousPage() => PreviousPage.Click();
        public void ClickLastPage()
        {
            Actions act = new Actions(WebDriver);
            act.MoveToElement(LastPage);
            act.Perform();
            Waiter.Until(ExpectedConditions.ElementToBeClickable(LastPage));
            LastPage.Click();
            Waiter.Until(ExpectedConditions.ElementToBeClickable(PreviousPage));
        }
        public void ClickLastPageWithWithoutScroll()
        {
            Actions act = new Actions(WebDriver);
            act.MoveToElement(LastPage);
            act.Perform();
            //ScrollDown();
            Waiter.Until(ExpectedConditions.ElementToBeClickable(LastPage));
            LastPage.Click();
            Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("button.Mui-disabled[title='Next page']")));//prev
            //Waiter.Until(ExpectedConditions.ElementToBeClickable(PreviousPage));
                
        }
        public void ClickLastPageAtDreamHome()
        {
            Thread.Sleep(2000);
            LastPage.Click();
            while(Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("button.Mui-disabled[title='Previous page']"))).Displayed);//Previous
            {
                Waiter.Until(ExpectedConditions.ElementToBeClickable(LastPage));
                LastPage.Click();
                JSClick(LastPage);
                //Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("button.Mui-disabled[title='Next page']")));
            }
            LastPage.Click();
        }
        public void ClickFirstPage() => FirstPage.Click();

        public void ChooseSelect(int perNum)
        {           
            Waiter.Until(ExpectedConditions.ElementExists(RowsPerPageChooserBy));
            RowsPerPageChooser.Click();
            WebDriver.FindElement(By.XPath("//li[text()='" + perNum + "']")).Click();
        }
        public void ChooseSelectWithWait(int perNum)
        {
            ChooseSelect(perNum);
            Waiter.Until(ExpectedConditions.TextToBePresentInElement(RowsPerPageChooser, perNum.ToString()));
        }
        internal bool IsRowsPerPageElementWithTextDisplayed(string textForElement)
        {            
            //Waiter.Until(ExpectedConditions.TextToBePresentInElementValue(RowsPerPage, textForElement));
            return RowsPerPageChooser.Displayed;
        }
        public string GetSizeOfTable()
        {
            string text = PaginInfo.Text;
            Console.WriteLine(text);
            if (text.Length == 0)
                return GetSizeOfTable();
            return text.Split(" ")[2];
        }
    }
}
