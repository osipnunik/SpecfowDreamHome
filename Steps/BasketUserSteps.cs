using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    class BasketUserSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private BasketPage basketP = new BasketPage(WebDriver);
        public BasketUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Then(@"user on basket page")]
        public void ThenUserOnBasketPage()
        {
            Waiter.Until(ExpectedConditions.ElementExists(By.XPath("//thead//th[text()='ITEMS']")));
            Assert.IsTrue(WebDriver.Url.EndsWith("basket"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }
        
        [Then(@"user see title, price per ticket, total amount of ticket and total price as expected")]
        public void ThenUserSeePricePerTicketTotalAmountOfTicketAndTotalPriceAsExpected()
        {
            var expectedProd = ((Product)_scenarioContext["product"]);
            double expectedPrice = (double)_scenarioContext["productPrice"];
            expectedPrice = Math.Round(expectedPrice, 2);
            int expectAmount = int.Parse((string)_scenarioContext["ticketQuantity"]);
            double expectedTotalPrice = expectedPrice * expectAmount;
            Assert.AreEqual(expectedProd.Title, basketP.GetFirstProductTitle());
            Assert.IsTrue(basketP.GetFirstProductPrice().StartsWith("£ " + expectedPrice.ToString()));
            Assert.AreEqual(expectAmount.ToString(), basketP.GetFirstProductAmount());
            string expectedTotalPriceRounded = "£ " + (expectedTotalPrice.ToString().Contains(".")?Math.Round(expectedTotalPrice, 2).ToString(): expectedTotalPrice+".00");
            Assert.AreEqual(expectedTotalPriceRounded, basketP.GetFirstProductTotalPrice());
            Assert.IsTrue(double.Parse(basketP.GetTotalPriceValue().Replace("£", ""))/Math.Round(expectedTotalPrice, 2) % 1 == 0);
        }

        [Then(@"user see Total Saving and Credit earned as expected if they exist")]
        public void ThenUserSeeTotalSavingAndCreditEarnedAsExpectedIfTheyExist()
        {
            string expectedTotalSavings = (string)_scenarioContext["totalSaving"];
            string expectedCreditEarned = (string)_scenarioContext["creditEarned"];
            Assert.IsTrue(double.Parse(basketP.GetTotalSaving().Replace("£", ""))/double.Parse(expectedTotalSavings.Replace("£", "")) % 1 == 0);
            Assert.AreEqual(expectedCreditEarned, basketP.GetCreditEarnedValue());
        }

        [When(@"user click Pay")]
        public void WhenUserClickPay()
        {
            basketP.ClickBasketPayButton();
        }

        [Then(@"user redirected to cards payment page")]
        public void ThenUserRedirectedToCardsPaymentPage()
        {
            Waiter.Until(ExpectedConditions.ElementExists(By.XPath("//h3[text()='Pay by Card']")));
            Assert.IsTrue(WebDriver.Url.EndsWith("basket/card/0"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }
        [When(@"user input card data")]
        public void WhenUserInputCardData()
        {
            basketP.InputCardName("5436 0310 3060 6378");
            //basketP.InputExpDate("22");
            basketP.InputExpDate("1122");
            basketP.InputCVC("257");
            Thread.Sleep(2000);
        }
        [When(@"click pay button")]
        public void WhenClickPayButton() => basketP.ClickCardPayBtn();

        [Then(@"user see order completed header")]
        public void ThenUserSeeOrderCompletedHeader() => Assert.IsTrue(basketP.OrderCompletedVisible());

    }
}
