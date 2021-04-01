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

namespace SpecFlowDreanLotteryHome.Steps.user
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
            basketP.WaitWhileBeOnBasketPage();
            Assert.IsTrue(WebDriver.Url.EndsWith("basket"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }
        
        [Then(@"user see title, price per ticket, total amount of ticket and total price as expected")]
        public void ThenUserSeePricePerTicketTotalAmountOfTicketAndTotalPriceAsExpected()
        {
            var expectedProd = ((Product)_scenarioContext["product"]);
            double expectedPrice = double.Parse((expectedProd.NonDiscountPrice == null ? expectedProd.OldPrice : expectedProd.NonDiscountPrice).Substring(1));
            int expectAmount = (int)_scenarioContext["ticketQuantity"];
            double expectedTotalPrice = expectedPrice * expectAmount;
            Assert.AreEqual(expectedProd.Title, basketP.GetLastProductTitle());
            Assert.AreEqual("£ " + expectedPrice.ToString("N2").Replace(",", ""), basketP.GetLastProductPrice());
            Assert.AreEqual(expectAmount.ToString(), basketP.GetLastProductAmount());
            string expectedTotalPriceRounded = "£ " + expectedTotalPrice.ToString("N2").Replace(",", "");
            Assert.IsTrue(expectedTotalPriceRounded.StartsWith(basketP.GetLastProductTotalPrice()));
            //Assert.IsTrue(double.Parse(basketP.GetTotalPriceValue().Replace("£", ""))/Math.Round(expectedTotalPrice, 2) % 1 == 0);
        }
        [Then(@"user calculate data from multiple products")]
        public void ThenUserCalculateDataFromMultipleProducts()
        {
            double yourPricesSum = basketP.GetYourPricesSumCheckCurrency();
            Assert.AreEqual("£ " + yourPricesSum.ToString("N2").Replace(",", ""), basketP.GetTotalPriceValue());
            string diff = (basketP.GetTotalPricesSumCheckCurrency() - yourPricesSum).ToString("N2").Replace(",", "");
            Assert.AreEqual("£ " + diff, basketP.GetTotalSaving());
        }

        [Then(@"user see Total Saving and Credit earned as expected if they exist")]
        public void ThenUserSeeTotalSavingAndCreditEarnedAsExpectedIfTheyExist()
        {
            //string expectedTotalSavings = (string)_scenarioContext["totalSaving"];  not used but used in previous
            string expectedCreditEarned = (string)_scenarioContext["creditEarned"];
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
            Assert.IsTrue(WebDriver.Url.Contains("basket/card/0/"));
            Assert.AreEqual("Raffle House", WebDriver.Title);
        }
        [When(@"user input card data")]
        public void WhenUserInputCardData()
        {
            Thread.Sleep(1000);
            basketP.InputCardName("5436 0310 3060 6378");
            //basketP.InputExpDate("22");
            Thread.Sleep(1000);
            basketP.InputExpDate("1122");
            basketP.InputCVC("257");
            Thread.Sleep(1000);
            
        }
        [When(@"click pay button")]
        public void WhenClickPayButton()
        {
            basketP.ClickCardPayBtn();
            if (basketP.ErrorMessageExist()) { WhenUserInputCardData(); WhenClickPayButton(); }
            if (WebDriver.Url.Contains("basket/card/0/")) { WhenUserInputCardData(); WhenClickPayButton(); }
        }

        [Then(@"user see order completed header")]
        public void ThenUserSeeOrderCompletedHeader()
        {
            string newUrl = WebDriver.Url.Replace("http://localhost:8000/", "https://staging.rafflehouse.com/");
            WebDriver.Navigate().GoToUrl(newUrl);
            Assert.IsTrue(basketP.OrderCompletedVisible());
        }

    }
}
