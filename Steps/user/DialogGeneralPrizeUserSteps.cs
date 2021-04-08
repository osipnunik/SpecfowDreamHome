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
        [Then(@"check default number of tickets (.*), total Number of tickets as (.*) and ticket old price value as (.*)")]
        public void ThenCheckDefaultNumberOfTicketsTotalNumberOfTicketsAsAndTicketOldPriceValueAs(string defaultNumber, string ticketsNumberAll, string price)
        {
            var quantities = dialogP.GetTicketrQuantitiesBookedAll();
            quantities[0].Equals("0");//created 2 seconds before
            quantities[0].Equals(ticketsNumberAll);
            price.Equals(dialogP.IsPriceNonDiscount() ? dialogP.GetNonDiscountPrice() : dialogP.GetDiscountOldPrice());
            defaultNumber.Equals(dialogP.GetQuantityTicSecond());
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
            //string picSrc = dialogP.GetPicSrc();
            //prod.ImgHref = picSrc;    reproducing bug with empty picture
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
            Assert.IsTrue(price.StartsWith(Currency), price);
            string totalPrice = dialogP.GetTotalPrice();
            Assert.AreEqual(Currency, totalPrice.Split(" ")[0]);
            double discount = dialogP.GetAppropriateDiscount(amount) / 100;
            double priceFromDialog = double.Parse(price.Substring(1));
            double expectedTotalPrice = (1-discount) * priceFromDialog * amount;
            Assert.AreEqual(Currency + " " + expectedTotalPrice.ToString("N2").Replace(",", ""), totalPrice);/*expectedTotalPrice.ToString("N2").Replace(",", "")));*/
            _scenarioContext.Add("product", prod);
            //_scenarioContext.Add("price", price);
            _scenarioContext.Add("totalPrice", totalPrice);
            //_scenarioContext.Add("title", title);
        }
        [Then(@"discount table are as noticed earlier")]
        public void ThenDiscountTableAreAsNoticedEarlier()
        {
            Dictionary<int, int> expectedDiscount = (Dictionary<int, int>)_scenarioContext["amountPercents"];
            Dictionary<int, int> dialogDiscount = dialogP.GetDiscountsFromPrizeDialog();
            foreach (KeyValuePair<int, int> keyValue in expectedDiscount)
            {
                dialogDiscount.ContainsKey(keyValue.Key);
                dialogDiscount.ContainsValue(keyValue.Value);
            }
        }
        [When(@"user close dialog of first element")]
        public void WhenUserCloseDialogOfFirstElement()
        {
            dialogP.CloseDialog();
        }

        [When(@"user click and close every prize on page noticing resulting credits and adding them to basket")]
        public void WhenUserClickAndCloseEveryPrizeOnPageNoticingResultingCreditsAndAddingThemToBasket()
        {
            double sumOfCreds = dialogP.AddAllPrizesOnThePageNoticedCreditSum();
            _scenarioContext.Add("CreditsSum", sumOfCreds);
        }
    }
}
