using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class CategoryPage: BasePage
    {
        public static PaginationFragment Paginats;

        public CategoryPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private IWebElement LyfeStyleManagement => WebDriver.FindElement(By.CssSelector("img[alt='settings']"));
        private By RefreshBy = By.CssSelector("button[title='Refresh']");
        private IList<IWebElement> Categories => WebDriver.FindElements(By.CssSelector("tr td:first-child"));

        private IWebElement SubCategoriesBtn => WebDriver.FindElement(By.CssSelector("div.button-group button:last-child"));

        string CategoryOrSub;
        private IWebElement CreatorHeader => WebDriver.FindElement(By.XPath("//h6[contains(text(), 'Add ') and contains(., '"+ CategoryOrSub + "')]']"));

        public List<string> GetFirstRowDatatd()
        {
            List<string> data = new List<string>();
            Waiter.Until(ExpectedConditions.ElementIsVisible(RefreshBy));
            for (int i = 0; i < Categories.Count; i++)
            {
                data.Add(Categories[i].Text);
            }
            return data;
        }

        internal bool PopupWithTextDisplayed(string text)
        {
            CategoryOrSub = text;
            return CreatorHeader.Displayed;
        }

        internal void ClickLyfeStyleManagement() => LyfeStyleManagement.Click();
        internal void ClickSubcategories() => SubCategoriesBtn.Click();

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
