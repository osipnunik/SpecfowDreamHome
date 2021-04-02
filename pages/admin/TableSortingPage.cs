using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class TableSortingPage : BasePage
    {
        public static PaginationFragment Paginats;

        public TableSortingPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private By RefreshBy = By.CssSelector("button[title='Refresh']");
        private IWebElement UserManagementHref => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[title='User management']")));
        private IWebElement StaffManagementHref => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#/staffUsers']")));//"a[title='Staff management']")));
        private IWebElement FirstColumnDownSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:last-child")));
        private IWebElement FirstColumnUpSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:first-child")));
        private IWebElement SecondColumnDownSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:last-child")));
        private IWebElement SecondColumnUpSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:first-child")));
        
        private IWebElement ThirdColumnDownSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(3) div.arrow-wrapper svg:last-child")));
        private IWebElement ThirdColumnUpSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(3) div.arrow-wrapper svg:first-child")));
        private IWebElement FourthColumnDownSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(4) div.arrow-wrapper svg:last-child")));
        private IWebElement FourthColumnUpSort => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(4) div.arrow-wrapper svg:first-child")));

        private IList<IWebElement> FirstRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(1)"));
        private IList<IWebElement> SecondRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(2)"));
        private IList<IWebElement> ThirdRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(3)"));
        private IList<IWebElement> FourthRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(4)"));
        private IList<IWebElement> FifthRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(5)"));

        private IList<IWebElement> FirstRowDatath => WebDriver.FindElements(By.CssSelector("tbody tr th:nth-child(1)"));
        private IList<IWebElement> SecondRowDatath => WebDriver.FindElements(By.CssSelector("tbody tr th:nth-child(2)"));
        private IList<IWebElement> ThirdRowDatath => WebDriver.FindElements(By.CssSelector("tbody tr th:nth-child(3)"));
        private IList<IWebElement> FourthRowDatath => WebDriver.FindElements(By.CssSelector("tbody tr th:nth-child(4)"));

        public void ClickFirstColumnDownSort() => FirstColumnDownSort.Click();
        public void ClickFirstColumnUpSort() => FirstColumnUpSort.Click();
        public void ClickSecondColumnDownSort()
        {
            ScrollToElement(WebDriver.FindElement(RefreshBy));
            SecondColumnDownSort.Click();
            //JSClick(SecondColumnDownSort);
        }
        public void ClickSecondColumnUpSort() => SecondColumnUpSort.Click();

        public void ClickThirdColumnDownSort() => ThirdColumnDownSort.Click();
        public void ClickThirdColumnUpSort() => ThirdColumnUpSort.Click();
        public void ClickFourthColumnDownSort() => FourthColumnDownSort.Click();
        public void ClickFourthColumnUpSort() => FourthColumnUpSort.Click();

        public List<string> GetFirstTableDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < FirstRowDatatd.Count; i++)
            {
                data.Add(FirstRowDatatd[i].Text);
            }
            return data;
        }

        public List<string> GetFirstTableDatath()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < FirstRowDatath.Count; i++)
            {
                data.Add(FirstRowDatath[i].Text);
            }
            return data;
        }

        public List<string> GetSecondRowDatatd()
        {            
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy)); //WebDriver.FindElement(
            for (int i = 0; i < SecondRowDatatd.Count; i++)
            {
                data.Add(SecondRowDatatd[i].Text);
            }
            return data;
        }
        public List<string> GetSecondRowDatath()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < SecondRowDatath.Count; i++)
            {
                data.Add(SecondRowDatath[i].Text);
            }
            return data;
        }
        public List<string> GetThirdRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < ThirdRowDatatd.Count; i++)
            {
                data.Add(ThirdRowDatatd[i].Text);
            }
            return data;
        }
        public List<string> GetThirdRowDatath()
        {
            List<string> data = new List<string>();
            for (int i = 0; i < ThirdRowDatath.Count; i++)
            {
                data.Add(ThirdRowDatath[i].Text);
            }
            return data;
        }
        public List<string> GetFourthRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < FourthRowDatatd.Count; i++)
            {
                data.Add(FourthRowDatatd[i].Text);
            }
            return data;
        }
        public List<string> GetFifthRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < FifthRowDatatd.Count; i++)
            {
                data.Add(FifthRowDatatd[i].Text);
            }
            return data;
        }

        internal void GoToStaffManagemant() => StaffManagementHref.Click();

        internal void GoToUserManagemant() => UserManagementHref.Click();

        public List<string> GetFourthRowDatath()
        {
            List<string> data = new List<string>();
            for (int i = 0; i < FourthRowDatath.Count; i++)
            {
                data.Add(FourthRowDatath[i].Text);
            }
            return data;
        }
        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
