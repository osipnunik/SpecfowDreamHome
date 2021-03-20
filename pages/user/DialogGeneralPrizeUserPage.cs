﻿using NUnit.Framework;
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
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("p.none-discount"));
        private IWebElement DiscountPrice => WebDriver.FindElement(By.CssSelector("p.discount-new-price"));
        private IWebElement DiscountPercent => WebDriver.FindElement(By.CssSelector("p.discount-percent"));
        private IList<IWebElement> Discounts => WebDriver.FindElements(By.CssSelector("div.ticketCard div.ticketСardItem span"));
        private int TicketNumber;
        private IWebElement TicketQuantityElement => WebDriver.FindElement(By.XPath("//div[@class='checkQuanityBlock']/p[text()='" + TicketNumber + "']"));
        private IWebElement TotalPrice => WebDriver.FindElement(By.CssSelector("div:nth-child(2) > p.order-data.totalValue"));
        private IWebElement QuantityTicSecond => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.quantitiValue"));
        private IList<IWebElement> PricesP => WebDriver.FindElements(By.CssSelector(".productPrices p"));
        private IWebElement Picture => WebDriver.FindElement(By.CssSelector(".slider .slick-active img"));

        public string GetQuantityTicSecond() => QuantityTicSecond.Text;

        internal string GetPicSrc() => Picture.GetAttribute("src");

        internal void ClickTicketsQuantity(int ticketNumb)
        {
            TicketNumber = ticketNumb;
            TicketQuantityElement.Click();
        }

        internal double GetAppropriateDiscount(int amount)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = Discounts.Count - 2; i >= 0; i = i - 2)
            {
                dict.Add(int.Parse(Discounts[i].Text),
                    int.Parse(Discounts[i + 1].Text));
                if (double.Parse(Discounts[i].Text) <= amount)
                {
                    Assert.IsTrue(amount >= double.Parse(Discounts[i].Text));
                    return double.Parse(Discounts[i + 1].Text);
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

        internal string GetDiscountPercent() => DiscountPercent.Text;

        internal string GetNonDiscountPrice() => NonDiscountPrice.Text;

        internal bool IsPriceNonDiscount() => PricesP.Count == 1;
    }
}