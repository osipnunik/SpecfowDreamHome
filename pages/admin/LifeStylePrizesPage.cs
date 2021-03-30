using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class LifeStylePrizesPage : BasePage
    {
        public static PaginationFragment Paginats;

        public LifeStylePrizesPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }

        string MainNonHomePicPath = PathGiver.GetPicturePath() + "Car.jpg";

        private IWebElement PrizeManagementHref => WebDriver.FindElement(By.XPath("//span[text()='Prize Management']"));
        private IWebElement PrizeManagementLiFirstChild => WebDriver.FindElement(By.CssSelector("div.menu-wrap li:first-child"));
        private IWebElement LifeStylePrizesLink => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[title='Lifestyle Prizes']")));
        private IWebElement LifeStyleHrefReliable => WebDriver.FindElement(By.CssSelector("a[href='#/prizes']"));


        private IWebElement LifeStylePrizesLinkNotClickable => Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("a[title='Lifestyle Prizes']")));
        private IList<IWebElement> PrizeManagementList => WebDriver.FindElements(By.CssSelector(".MuiCollapse-container a"));
        private IWebElement DiscountTicketsTab => WebDriver.FindElement(By.XPath("//span[text()='Discount & tickets']"));
        private IWebElement CategoryChooser => WebDriver.FindElement(By.Id("prizeCategory"));//"search-input"));
        private IWebElement SubCategoryChooser => WebDriver.FindElement(By.Id("subCategory"));

        private IWebElement Title => WebDriver.FindElement(By.Id("title"));
        private IWebElement GeneralPicInput => WebDriver.FindElement(By.CssSelector("input.dropzone-input"));
        private IWebElement ActiveLifeStilePrizes => WebDriver.FindElement(By.CssSelector("div.button-group button:nth-child(2)"));

        private IList<IWebElement> Titles => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(2)"));
        private IList<IWebElement> Categories => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(3)"));

        private IWebElement ActivePrizes => WebDriver.FindElement(By.CssSelector(".button-group button:nth-child(2)"));
        private IWebElement UnActivePrizes => WebDriver.FindElement(By.CssSelector(".button-group button:nth-child(3)"));

        private IList<IWebElement> SubCategories => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(4)"));
        private IList<IWebElement> Discount => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(5)"));

        string Category;
        private IWebElement CategoryItem => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul/li/span[text()='" + Category + "']")));
        
        public void InputGeneralPictureInput() => GeneralPicInput.SendKeys(MainNonHomePicPath);

        public void ClickLifeStylePrizesClosed() {
            PrizeManagementHref.Click();
            LifeStylePrizesLink.Click();
        }
        public void ClickLifeStylePrizesUniversal()
        {
            if (PrizeManagementList.Count == 0)
            {
                PrizeManagementLiFirstChild.Click();
            }
            LifeStyleHrefReliable.Click();
        }
            /* public void ClickLifeStylePrizesUniversal()
             {
                 *//*while (PrizeManagementList.Count == 0)
                 {*//*
                 try
                 {
                     if (PrizeManagementList.Count == 0)
                     {
                         PrizeManagementHref.Click();
                     }            
                     LifeStylePrizesLink.Click();
                 }
                 catch (NoSuchElementException e)
                 {
                     PrizeManagementHref.Click(); 
                     LifeStylePrizesLink.Click();
                 }
             }*/


            public void ClickLifeStylePrizesOpened()
        {
            ScrollToTop();
            ScrollToElement(PrizeManagementHref);
            Thread.Sleep(5000);
            JSClick(LifeStylePrizesLinkNotClickable);
            //LifeStylePrizesLink.Click();
        }

        internal void ClickActiveLifeStilePrizes()
        {
            JSClick(ActiveLifeStilePrizes);
            //ActiveLifeStilePrizes.Click();            
        }

        internal void ChooseCategory(string p0)
        {
            Category = p0;
            CategoryChooser.Click();
            try { CategoryItem.Click(); }
            catch (StaleElementReferenceException)
            {
                JSClick(CategoryItem);
            }                     
        }
        internal void ChooseSubCategory(string p0)
        {
            Category = p0;
            SubCategoryChooser.Click();
            try { CategoryItem.Click(); }
            catch (StaleElementReferenceException)
            {
                JSClick(CategoryItem);
            }
        }
        internal void InputTitle(string p0)
        {
            Title.SendKeys(p0);
        }

        internal void GoToDiscountTicketTab() =>  DiscountTicketsTab.Click();

        internal void UploadMainNonHomePicture()
        {
            GeneralPicInput.SendKeys(MainNonHomePicPath);
        }

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }

        internal List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < Titles.Count; i++)
            {
                Product product = new Product();
                product.Title = Titles[i].Text;
                product.CategoryName = Categories[i].Text;
                product.SubcategoryName = SubCategories[i].Text;
                products.Add(product);
            }
            return products;
        }
        public List<string> GetTitles()
        {
            List<string> titles = new List<string>();
            for (int i = 0; i < Titles.Count; i++)
            {
                titles.Add(Titles[i].Text);
            }
            return titles;
        }

        internal int GetTitesCount() => Titles.Count;    

        internal void ClickActivePrizes()
        {
            JSClick(ActivePrizes);
            Waiter.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".button-group button:nth-child(2).active-button")));
        }

        internal void ClickUnActivePrizes()
        {
            JSClick(UnActivePrizes);
            Waiter.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".button-group button:nth-child(3).active-button")));
            //Waiter.Until(ExpectedConditions.StalenessOf(WebDriver.FindElement(By.CssSelector("table.MuiTable-root"))));
        }
                
    }
}
