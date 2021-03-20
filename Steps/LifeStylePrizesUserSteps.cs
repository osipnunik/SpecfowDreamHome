using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.pages.user;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    public class LifeStylePrizesUserSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private LifeStylePrizesUsersPage lifeStylePage = new LifeStylePrizesUsersPage(WebDriver);
        private LoginUserPage logUP = new LoginUserPage(WebDriver);
        private DialogGeneralPrizeUserPage dialogP = new DialogGeneralPrizeUserPage(WebDriver);

        public LifeStylePrizesUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"user\(client\) login on web with login ""(.*)"" and pass ""(.*)""")]
        public void WhenUserClientLoginOnWebWithLoginAndPass(string email, string pass)
        {
            WebDriver.Navigate().GoToUrl(LOGIN_USER_VAL);
            logUP.InputLogin(email);
            logUP.InputPass(pass);
            logUP.ClickSignIn();
        }
        
        [When(@"user go to lifestyleprizes")]
        public void WhenUserGoToLifestyleprizes()
        {
            lifeStylePage.ClickLifeStylePrizes();
        }
        
        [When(@"notice list of categories")]
        public void WhenNoticeListOfCategories()
        {
            lifeStylePage.formList();
            List<Product> products = lifeStylePage.GetProductList();
            Console.WriteLine(products);
            _scenarioContext.Add("users_products", products);
        }
        [When(@"click on first product")]
        public void WhenClickOnFirstProduct()
        {
            lifeStylePage.ClickOnFirstProduct();
        }

        [When(@"notice all info about product\(title, nonDisc price or old price, new price, percent\)")]
        public void WhenNoticeAllInfoAboutProductTitleNonDiscPriceOrOldPriceNewPricePercent()
        {
            _scenarioContext.Add("product", lifeStylePage.GetFirstProduct());
        }

        [Then(@"product popup appeares")]
        public void ThenProductPopupAppeares()
        {
            Assert.IsTrue(lifeStylePage.IsProductPopupAppeared());
        }

        [Then(@"price should be as was on product")]
        public void ThenPriceShouldBeAsWasOnProduct()
        {
            var expectedProd = ((Product)_scenarioContext["product"]);
            if(expectedProd.NonDiscountPrice != null)
            {
                Assert.AreEqual(expectedProd.NonDiscountPrice, lifeStylePage.GetNonDiscountPrice());
            }
            else
            {
                Assert.AreEqual(expectedProd.NewPrice, lifeStylePage.GetDiscountNewPrice());
                Assert.AreEqual(expectedProd.OldPrice, lifeStylePage.GetDiscountOldPrice());
                Assert.AreEqual(expectedProd.DiscountOff, lifeStylePage.GetDiscountPercent());
            }
            
        }

        [Then(@"product name should be as noticed earlier")]
        public void ThenProductNameShouldBeAsNoticedEarlier()
        {
            var expectedProd = ((Product)_scenarioContext["product"]);
            Assert.AreEqual(expectedProd.Title, lifeStylePage.GetTitle());
        }                         

        [When(@"check total price on product dialog popup and totalSaving")]
        public void WhenCheckTotalPriceOnProductDialogPopup()
        {
            //_scenarioContext["ticketQuantity"]
            var expectedProd = ((Product)_scenarioContext["product"]);
            int productPrice = int.Parse((expectedProd.NonDiscountPrice == null ? expectedProd.NewPrice : expectedProd.NonDiscountPrice).Replace("£", ""));
            //_scenarioContext.Add("productPrice", productPrice);
            int amount = ((int)_scenarioContext["ticketQuantity"]);
            int expectedTotal = amount * productPrice;

            double totalSavingsShould = dialogP.GetAppropriateDiscount(amount) * expectedTotal / 100; //int.Parse(lifeStylePage.GetLastDiscount()
            
            string totalSavingFromDialog = lifeStylePage.GetTotalSaving();
            Assert.AreEqual("£ " + Math.Round(totalSavingsShould, 2) + ".00", totalSavingFromDialog);

            _scenarioContext.Add("totalSaving", totalSavingFromDialog);

            double expectedDoubleTotalPrice = expectedTotal - totalSavingsShould;
            _scenarioContext.Add("productPrice", expectedDoubleTotalPrice/amount);
            Assert.AreEqual("£ " + expectedDoubleTotalPrice + ".00" , lifeStylePage.GetTotalPrice());
        }

        [When(@"notice Credit earned if they exist")]
        public void WhenNoticeTotalSavingAndCreditEarnedIfTheyExist()
        {           
            _scenarioContext.Add("creditEarned", lifeStylePage.GetCreditEarned());
        }

        [When(@"user click on buy now")]
        public void WhenUserClickOnBuyNow() => lifeStylePage.ClickBuyNowBtn();

        [When(@"click Enter Now button")]
        public void WhenClickEnterNowButton() => lifeStylePage.ClickEnterNow();
        [When(@"user go to Dream Home page")]
        public void WhenUserGoToDreamHomePage()
        {
            lifeStylePage.ClickDreamHome();

            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Navigate().Refresh();
        }


    }
}
