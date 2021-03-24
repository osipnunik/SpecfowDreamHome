using NUnit.Framework;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.user
{
    [Binding]
    class DialogGeneralPrizeUserSteps : BaseStepDefinition
    {
        private const string Currency = "£";
        private readonly ScenarioContext _scenarioContext;
        private DialogGeneralPrizeUserPage dialogP = new DialogGeneralPrizeUserPage(WebDriver);

        public DialogGeneralPrizeUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user choose number randomly")]
        public void WhenUserChooseNumberOfTicketAs()
        {
            int[] arr = { 1, 5, 10, 20, 50, 100 };
            int num = arr[new Random().Next(arr.Length)];
            dialogP.ClickTicketsQuantity(num);
            _scenarioContext.Add("ticketQuantity", num);
        }

        [Then(@"he will see that number in TICKETS QUANITY")]
        public void ThenHeWillSeeThatNumberInTICKETSQUANITY()
        {
            Assert.AreEqual(((int)_scenarioContext["ticketQuantity"]).ToString(), dialogP.GetQuantityTicSecond());
        }

        [Then(@"user check total price, total saving, them currency %Off")]
        public void ThenUserCheckTotalPriceTotalSaving()
        {
            string price;
            Product prod = new Product();           
            int amount = (int)_scenarioContext["ticketQuantity"];
            string title = dialogP.GetTitle();
            prod.Title = title;
            string picSrc = dialogP.GetPicSrc();
            prod.ImgHref = picSrc;
            if (dialogP.IsPriceNonDiscount())
            {
                price = dialogP.GetNonDiscountPrice();
                prod.NonDiscountPrice = price;
            }
            else { 
                price = dialogP.GetDiscountPrice();
                prod.NewPrice = price;
                prod.OldPrice = dialogP.GetDiscountOldPrice();
                prod.DiscountOff = dialogP.GetDiscountPercent();
                Assert.IsTrue(dialogP.GetDiscountPercent().Contains("%"));
            }
            Assert.IsTrue(price.StartsWith(Currency));
            string totalPrice = dialogP.GetTotalPrice();
            Assert.AreEqual(Currency, totalPrice.Split(" ")[0]);
            double discount = dialogP.GetAppropriateDiscount(amount) / 100;
            double priceFromDialog = double.Parse(price.Substring(1));
            double expectedTotalPrice = (1-discount) * priceFromDialog * amount;
            Assert.IsTrue(totalPrice.StartsWith(Currency + " " + expectedTotalPrice.ToString("N2").Replace(",", "")));
            _scenarioContext.Add("product", prod);
            _scenarioContext.Add("price", price);
            _scenarioContext.Add("totalPrice", totalPrice);
            _scenarioContext.Add("title", title);
        }

    }
}
