using OpenQA.Selenium;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class LifeStylePrizesPage : BasePage
    {
        public static PaginationFragment Paginats;

        public LifeStylePrizesPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }

        string MainNonHomePicPath = PathGiver.GetPicturePath() + "watch_xiaomi.png";

        private IWebElement PrizeManagementHref => WebDriver.FindElement(By.XPath("//span[text()='Prize Management']"));
        private IWebElement LifeStylePrizesLink => WebDriver.FindElement(By.CssSelector("a[title='Lifestyle Prizes']"));
        private IWebElement DiscountTicketsTab => WebDriver.FindElement(By.XPath("//span[text()='Discount & tickets']"));
        private IWebElement CategoryChooser => WebDriver.FindElement(By.Id("prizeCategory"));
        private IWebElement Title => WebDriver.FindElement(By.Id("title"));
        private IWebElement GeneralPicInput => WebDriver.FindElement(By.CssSelector("input.dropzone-input"));
        private IWebElement ActiveLifeStilePrizes => WebDriver.FindElement(By.CssSelector("div.button-group button:nth-child(2)"));

        private IList<IWebElement> Titles => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(2)"));
        private IList<IWebElement> Categories => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(3)"));
        private IList<IWebElement> SubCategories => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(4)"));
        private IList<IWebElement> Discount => WebDriver.FindElements(By.CssSelector("table tbody tr td:nth-child(5)"));

        public void InputGeneralPictureInput() => GeneralPicInput.SendKeys(MainNonHomePicPath);

        public void ClickLifeStylePrizes() {
            PrizeManagementHref.Click();
            LifeStylePrizesLink.Click();
        }

        internal void ClickActiveLifeStilePrizes()
        {
            JSClick(ActiveLifeStilePrizes);
            //ActiveLifeStilePrizes.Click();
        }

        internal void ChooseCategory(string p0)
        {          
           CategoryChooser.Click();
           WebDriver.FindElement(By.XPath("//li/span[text()='" + p0 + "']")).Click();          
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
    }
}
