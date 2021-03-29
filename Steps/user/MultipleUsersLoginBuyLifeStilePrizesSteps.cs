using NUnit.Framework;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.pages.user;
using SpecFlowDreanLotteryHome.services;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.user
{
    [Binding]
    public class MultipleUsersLoginBuyLifeStilePrizesSteps : BaseStepDefinition
    {
        private string[] emails = new EmailGeverService().GetEmails();
        private const string PASSW = "q111111!";
        int[] quantities = new int[] { 1, 5, 10, 20, 50, 100 };
        Random rand = new Random();

        private LoginUserPage loginPg = new LoginUserPage(WebDriver);
        private RegisterUserPage regsPg = new RegisterUserPage(WebDriver);
        private LifeStylePrizesUsersPage lifeStylePage = new LifeStylePrizesUsersPage(WebDriver);
        private DialogGeneralPrizeUserPage dialogP = new DialogGeneralPrizeUserPage(WebDriver);
        private BasketPage baskP = new BasketPage(WebDriver);
        [When(@"DoCicle")]
        public void WhenDoCicle()
        {
            string cardNumb = "5436 0310 3060 6378";
            string expDate = "1122";
            string cvc = "257";
            
            for (int i = 0; i < emails.Length; i++)
            {
                WebDriver.Navigate().GoToUrl(LOGIN_USER_VAL);

                Console.WriteLine("email: " + emails[i]+ " i: " + i);
                loginPg.InputLogin(emails[i]);
                loginPg.InputPass(PASSW);
                loginPg.ClickSignIn();

                regsPg.WaitLoggedNameIsVisible();
                lifeStylePage.ClickLifeStylePrizes();

                lifeStylePage.ClickOnFirstProduct();
                
                int num = quantities[rand.Next(quantities.Length)];
                dialogP.ClickTicketsQuantity(num);

                lifeStylePage.ClickBuyNowBtn();

                baskP.ClickBasketPayButton();

                Thread.Sleep(1000);
                baskP.InputCardName(cardNumb);
                //basketP.InputExpDate("22");
                Thread.Sleep(1000);
                baskP.InputExpDate(expDate);
                baskP.InputCVC(cvc);
                Thread.Sleep(1000);

                baskP.ClickCardPayBtn();
                if (baskP.ErrorMessageExist()/*ErrorMessageExist()*/) {
                    Thread.Sleep(1000);
                    baskP.InputCardName(cardNumb);
                    //basketP.InputExpDate("22");
                    Thread.Sleep(800);
                    baskP.InputExpDate(expDate);
                    baskP.InputCVC(cvc);
                    Thread.Sleep(1000);
                }

                string newUrl = WebDriver.Url.Replace("http://localhost:8000/", "https://staging.rafflehouse.com/");
                WebDriver.Navigate().GoToUrl(newUrl);
                Assert.IsTrue(baskP.OrderCompletedVisible(), "Order Completed is not Visible");

                regsPg.ClickAccountButton();
                regsPg.ClickLogoutBtn();
            }
        }
    }
}
