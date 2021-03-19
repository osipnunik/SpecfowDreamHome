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
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("p.none-discount"));
        private IList<IWebElement> Discounts => WebDriver.FindElements(By.CssSelector("div.ticketCard div.ticketСardItem span"));
        private string TicketNumber;
        private IWebElement TicketQuantityElement => WebDriver.FindElement(By.XPath("//div[@class='checkQuanityBlock']/p[text()='" + TicketNumber + "']"));
        
        internal void ClickTicketsQuantity(string ticketNumb)
        {
            TicketNumber = ticketNumb;
            TicketQuantityElement.Click();
        }

        internal int GetAppropriateDiscount(double amount)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = Discounts.Count - 2; i >= 0; i = i - 2)
            {
                dict.Add(int.Parse(Discounts[i].Text),
                    int.Parse(Discounts[i + 1].Text));
                if (double.Parse(Discounts[i].Text) <= amount)
                {
                    Assert.IsTrue(amount >= double.Parse(Discounts[i].Text));
                    return int.Parse(Discounts[i + 1].Text);
                }
                else if (int.Parse(Discounts[i].Text) < amount)
                {
                    continue;
                }
            }
            return 0;
        }


    }
}
