using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class CategoryPage: BasePage
    {
        public static PaginationFragment Paginats;
        private PathGiver Path = new PathGiver();
        string PandaPic = PathGiver.GetPicturePath() + "Panda_big.jpg";
        public CategoryPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private IWebElement LyfeStyleManagement => WebDriver.FindElement(By.CssSelector("img[alt='settings']"));
        private By RefreshBy = By.CssSelector("button[title='Refresh']");
        private IList<IWebElement> Categories => WebDriver.FindElements(By.CssSelector("tr td:first-child"));
        private IWebElement AddNewCatSub => WebDriver.FindElement(By.XPath("//button/span[contains(text(), 'Add')]"));
        private IWebElement SubCategoriesBtn => WebDriver.FindElement(By.CssSelector("div.button-group button:last-child"));
        private IWebElement GeneralPicInput => WebDriver.FindElement(By.CssSelector("input.dropzone-input"));
        //string CategoryOrSub;
        private IWebElement CreatorHeader => WebDriver.FindElement(By.XPath("//h6[starts-with(text(), 'Add ')]"));
        private IWebElement SaveBtn => WebDriver.FindElement(By.CssSelector("div.MuiDialogContent-root button:first-child"));
        private IWebElement CancelBtn => WebDriver.FindElement(By.CssSelector("div.MuiDialogContent-root button:last-child"));
        private IWebElement StatusCheckbox => WebDriver.FindElement(By.CssSelector("div.MuiDialogContent-root input[type='checkbox']"));
        private IWebElement TitleInput => WebDriver.FindElement(By.CssSelector("div.MuiDialogContent-root input[name='name']"));
        private IWebElement SubCategoryChooser => WebDriver.FindElement(By.Id("search-input"));
        string SubCategory;
        private IWebElement SubCategoryItem => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul/li[text()='" + SubCategory + "']"))); 

        internal void ClickAddNewCategory_Sub() => AddNewCatSub.Click();

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

        internal void ClickOnStatus() => JSClick(StatusCheckbox);//StatusCheckbox.Click();

        internal void InputTitle(string p0)
        {
            TitleInput.SendKeys(p0);
        }

        internal void ClickSaveCategSub() => SaveBtn.Click();
        internal void ClickCancelCategSub() => CancelBtn.Click();

        internal string GetDialogPopupText()
        {
            string text = CreatorHeader.Text;
            if (text.Length != 0) { return text; }
            else return GetDialogPopupText();
        }

        internal void inputPicture() => GeneralPicInput.SendKeys(PandaPic);               

        internal void ClickLyfeStyleManagement() => LyfeStyleManagement.Click();
        internal void ClickSubcategories()
        {
            SubCategoriesBtn.Click();
            Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector(".button-group button.active-button:last-child")));
        }

        internal void ChooseSubCategory(string p0)
        {
            SubCategory = p0;
            SubCategoryChooser.Click();
            try { SubCategoryItem.Click(); }
            catch (StaleElementReferenceException)
            {
                JSClick(SubCategoryItem);
            }
        }

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
