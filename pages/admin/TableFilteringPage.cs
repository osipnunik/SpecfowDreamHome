using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class TableFilteringPage : BasePage
    {
        public static PaginationFragment Paginats;

        public TableFilteringPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private By RefreshBy = By.CssSelector("button[title='Refresh']");
        private IWebElement UserManagementHref => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[title='User management']")));
        private IWebElement StaffManagementHref => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[title='Staff management']")));

        private IWebElement FilterBtn => WebDriver.FindElement(By.Id("apply-button"));
        private IWebElement ClearBtn => WebDriver.FindElement(By.Id("clear-button"));
        private IWebElement FilterInput => WebDriver.FindElement(By.CssSelector("div.filter-dropdown input"));//"input[name='selectedPrizes']"));
        private IList<IWebElement> FilterItems => WebDriver.FindElements(By.CssSelector("div.filter-item span"));
              
        private IWebElement FilterItemSpan => WebDriver.FindElement(By.CssSelector("div.filter-item span"));
        private IWebElement FirstFilterItemCheckbox => WebDriver.FindElement(By.CssSelector("div.filter-item span"));
        string TitleLi;
        private IWebElement TitleLiEl => WebDriver.FindElement(By.XPath("//span[@class='category-title' and text()='" +TitleLi+"']"));
        private IWebElement FirstHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(1) div.title-dropdown")));
        private IWebElement SecondHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(2) div.title-dropdown")));

       

        private IWebElement ThirdHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(3) div.title-dropdown")));
        private IWebElement FourthHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(4) div.title-dropdown")));
        private IWebElement FifthHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("th:nth-child(5) div.title-dropdown")));

        private IList<IWebElement> FirstRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(1)"));
        By SecondData = By.CssSelector("tbody tr td:nth-child(2)");
        private IList<IWebElement> SecondRowDatatd => WebDriver.FindElements(SecondData);
        private IWebElement LastCellInFirstColumn => WebDriver.FindElement(By.CssSelector("tbody:last-child tr td:nth-child(1)"));
        private IWebElement FirstCellInSecondColumn => WebDriver.FindElement(SecondData);
        private IWebElement LastCellInSecondColumn => WebDriver.FindElement(By.CssSelector("tbody:last-child tr td:nth-child(2)"));
        private IWebElement LastCellInThirdColumn => WebDriver.FindElement(By.CssSelector("tbody:last-child tr td:nth-child(3)"));
        private IWebElement LastCellInFourthColumn => WebDriver.FindElement(By.CssSelector("tbody:last-child tr td:nth-child(4)"));

        private IList<IWebElement> ThirdRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(3)"));
        private IList<IWebElement> FourthRowDatatd => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(4)"));

        public void ClickFirstHeader() => FirstHeader.Click();
        public void ClickSecondHeader() => SecondHeader.Click();
        public void ClickThirdHeader() => ThirdHeader.Click();
        public void ClickFourthHeader() => FourthHeader.Click();
        public void ClickFifthHeader() => FifthHeader.Click();

        public List<string> GetFirstRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < FirstRowDatatd.Count; i++)
            {
                data.Add(FirstRowDatatd[i].Text);
            }
            return data;
        }
        internal string GetLastCellInFirstColumn() => LastCellInFirstColumn.Text;
        public string GetFirstCellTextInSecondColumn() => FirstCellInSecondColumn.Text;
        public string GetLastCellTextInSecondColumn() => LastCellInSecondColumn.Text;

        internal object GetLastCellTextInThirdColumn() => LastCellInThirdColumn.Text;
        internal object GetLastCellTextInFourthColumn() => LastCellInFourthColumn.Text;

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

        internal void GoToStaffManagemant() => StaffManagementHref.Click();

        internal void GoToUserManagemant() => UserManagementHref.Click();

        public void ClickFilterBtn() => FilterBtn.Click();
        public void ClickClearBtn() => ClearBtn.Click();
        public void InputFilter(string input) => FilterInput.SendKeys(input);
        public void ClickFirstFilterItemCheckbox() => FirstFilterItemCheckbox.Click();
        public void ChooseTitle(string input)
        {
            TitleLi = input;
            TitleLiEl.Click();
        }
        public List<string> GetFilterItemsNames()
        {
            List<string> filterItemns = new List<string>();
            //Waiter.Until(ExpectedConditions.ElementIsVisible());
            for (int i = 0; i < FilterItems.Count; i++)
            {
                filterItemns.Add(FilterItems[i].Text);
            }
            return filterItemns;
        }

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
