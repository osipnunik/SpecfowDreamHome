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
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] span.dis-none"));
        private IWebElement DiscountPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] span.dis-new-price"));
        private IWebElement DiscountOldPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] span.dis-old-price"));

        private IWebElement DiscountPercent => WebDriver.FindElement(By.CssSelector("div[role='dialog'] span.dis-percent"));
        private IList<IWebElement> Discounts => WebDriver.FindElements(By.CssSelector("div.ticketsCardDesk div.ticketCard div.ticketСardItem span"));
        private IList<IWebElement> TicketsQuantBookedAll2 => WebDriver.FindElements(By.CssSelector("div.ticketsOutInfo p"));

        private int TicketNumber;
        private IWebElement TicketQuantityElement => WebDriver.FindElement(By.XPath("//div[@class='checkQuanityBlock']/p[text()='" + TicketNumber + "']"));
        private IWebElement TotalPrice => WebDriver.FindElement(By.CssSelector("div:nth-child(2) > p.order-data.totalValue"));
        private IWebElement QuantityTicSecond => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.quantitiValue"));
        private IList<IWebElement> PricesP => WebDriver.FindElements(By.CssSelector(".infoModalMainTitle div.prize-card-price-container span"));//".infoModalMainTitle .productPrices p"));
        private IWebElement Picture => WebDriver.FindElement(By.CssSelector(".slider .slick-active img"));
        private IWebElement CloseX => WebDriver.FindElement(By.CssSelector("button.close-modal-icon"));
        private IList<IWebElement> PrizeTitles => WebDriver.FindElements(By.CssSelector("div.productTitle"));
        private IWebElement EarnedCredit => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer>div:last-child p.creditValue"));
        private IWebElement AddToBasketBtn => WebDriver.FindElement(By.CssSelector("div.priceHeadBtnGroup>button:last-child"));
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
        internal Dictionary<int, int> GetDiscountsFromPrizeDialog()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = Discounts.Count - 2; i >= 0; i = i - 2)
            {
                string percVal = (Discounts[i + 1].Text).Replace("%", "");
                int intPercVal = int.Parse(percVal);
                dict.Add(int.Parse(Discounts[i].Text),
                    intPercVal);
            }
            return dict;
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
        public string[] GetTicketrQuantitiesBookedAll()
        {
            string[] arr = new string[2];
            arr[0] = TicketsQuantBookedAll2[0].Text;
            arr[1] = TicketsQuantBookedAll2[1].Text;
            return arr;
        }
        internal double AddAllPrizesOnThePageNoticedCreditSum()
        {
            double sum = 0.0;
            for (int i = 0; i < PrizeTitles.Count; i++)
            {
                try { PrizeTitles[i].Click(); }
                catch (ElementClickInterceptedException) { JSClick(PrizeTitles[i]); }
                sum += double.Parse(EarnedCredit.Text.Substring(2));
                AddToBasketBtn.Click();
                CloseX.Click();
            }
            return sum;
        }
        public double GetCreditValueInSingleDialog()
        {
            AddToBasketBtn.Click();
            return double.Parse(EarnedCredit.Text.Substring(2));
        }
    }
}
