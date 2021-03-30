using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class DialogGeneralPrizeUserPage : BasePage
    {
        public DialogGeneralPrizeUserPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement Title => WebDriver.FindElement(By.CssSelector("div[role='dialog'] div.ModalInfoTitle h3"));
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.none-discount"));
        private IWebElement DiscountPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-new-price"));
        private IWebElement DiscountOldPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-old-price"));

        private IWebElement DiscountPercent => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-percent"));
        private IList<IWebElement> Discounts => WebDriver.FindElements(By.CssSelector("div.ticketsCardDesk div.ticketCard div.ticketСardItem span"));
        private int TicketNumber;
        private IWebElement TicketQuantityElement => WebDriver.FindElement(By.XPath("//div[@class='checkQuanityBlock']/p[text()='" + TicketNumber + "']"));
        private IWebElement TotalPrice => WebDriver.FindElement(By.CssSelector("div:nth-child(2) > p.order-data.totalValue"));
        private IWebElement QuantityTicSecond => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.quantitiValue"));
        private IList<IWebElement> PricesP => WebDriver.FindElements(By.CssSelector(".infoModalMainTitle .productPrices p"));
        private IWebElement Picture => WebDriver.FindElement(By.CssSelector(".slider .slick-active img"));
        private IWebElement CloseX => WebDriver.FindElement(By.CssSelector("button.close-modal-icon"));

        public string GetQuantityTicSecond() => QuantityTicSecond.Text;

        internal string GetPicSrc() => Picture.GetAttribute("src");

        internal void ClickTicketsQuantity(int ticketNumb)
        {
            TicketNumber = ticketNumb;
            TicketQuantityElement.Click();
        }

        internal double GetAppropriateDiscount(int amount)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();
            for (int i = Discounts.Count - 2; i >= 0; i = i - 2)
            {
                string percVal = (Discounts[i + 1].Text).Replace("%", "");
                double doublePercVal = double.Parse(percVal);
                dict.Add(int.Parse(Discounts[i].Text),
                    doublePercVal);
                if (double.Parse(Discounts[i].Text) <= amount)
                {
                    Assert.IsTrue(amount >= int.Parse(Discounts[i].Text));
                    return doublePercVal;
                }
                else if (int.Parse(Discounts[i].Text) < amount)
                {
                    continue;
                }
            }
            return 0;
        }

        internal string GetTitle() => Title.Text;

        internal string GetTotalPrice() => TotalPrice.Text;

        internal string GetDiscountPrice() => DiscountPrice.Text;

        internal string GetDiscountOldPrice() => DiscountOldPrice.Text;

        internal void CloseDialog() => CloseX.Click();

        internal string GetDiscountPercent() => DiscountPercent.Text;

        internal string GetNonDiscountPrice() => NonDiscountPrice.Text;

        internal bool IsPriceNonDiscount()
        {
            int c = PricesP.Count;
            return c == 1;

        }
    }
}
