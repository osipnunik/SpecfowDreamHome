using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using RestSharp.Authenticators;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.services;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class DreamHomeSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private LoginAdminPage loginPg = new LoginAdminPage(WebDriver);
        private DreamHomePage dreamHomePg = new DreamHomePage(WebDriver);
        private static string LoginAdminUrl = LOGIN_ADMiN_VAL;

        public DreamHomeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user logged in as admin with ""(.*)"" email and ""(.*)"" password")]
        public void GivenUserLoggedInAsAdminWithEmailAndPassword(string p0, string p1)
        {
            WebDriver.Navigate().GoToUrl(DREAM_HOME_ADM_VAL);
            if (WebDriver.Url.Equals(LoginAdminUrl))
            {
                loginPg.InputLogin(p0);
                loginPg.InputPass(p1);
                loginPg.ClickSignIn();
            }
        }

        [Given(@"click add new dream home")]
        public void GivenClickAddNewDreamHome()
        {
            dreamHomePg.clickAddNewDreamHome();
        }

        [When(@"admin input title randomly generated")]
        public void WhenAdminInputTitleAs()
        {
            string title = new AutogeneratorService().GenerateStreetAddressTitle();
            _scenarioContext.Add("address_title", title);
            dreamHomePg.inputTitle(title);//p0
        }

        [When(@"admin input address from adress title")]
        public void WhenAdminInputAddressAs()
        {
            dreamHomePg.inputAddress((string)_scenarioContext["address_title"]);
        }

        [When(@"choose start and finish date")]
        public void WhenChooseStartAndFinishDate()
        {
            dreamHomePg.clickStartDate();
            dreamHomePg.clickNextMonth();
            dreamHomePg.clickFirstDateCell();

            dreamHomePg.clickFinishDate();
            dreamHomePg.clickNextMonthOnFinish();
            dreamHomePg.clickNextMonthOnFinish();
            dreamHomePg.clickFifthDataCellFinishCalendar();
        }

        [When(@"upload main picture")]
        public void WhenUploadMainPicture()
        {
            dreamHomePg.InputGeneralPictureInput();
        }

        [When(@"go to Description tab")]
        public void WhenGoToDescriptionTab()
        {
            dreamHomePg.goToDescription();
        }

        [When(@"input badroom desctiption as ""(.*)""")]
        public void WhenInputBadroomDesctiptionAs(string p0)
        {
            dreamHomePg.inputBadroomDescription(p0);
        }

        [When(@"input bathroom desctiption as ""(.*)""")]
        public void WhenInputBathroomDesctiptionAs(string p0)
        {
            dreamHomePg.InputBathDescription(p0);
        }

        [When(@"input Outspace desctiption as ""(.*)""")]
        public void WhenInputOutspaceDesctiptionAs(string p0)
        {
            dreamHomePg.InputOutSpaceDescription(p0);
        }


        [When(@"upload badroom picture")]
        public void WhenUploadBadroomPicture()
        {
            dreamHomePg.InputBadRoomInputPic();
        }

        [When(@"upload bathroom picture")]
        public void WhenUploadBathroomPicture()
        {
            dreamHomePg.InputBathRoomInputPic();
        }

        [When(@"upload Outspace picture")]
        public void WhenUploadOutspacePicture()
        {
            dreamHomePg.InputOutSpaceInputPic();
        }

        [When(@"input in about ""(.*)"" text")]
        public void WhenInputInAboutText(string p0)
        {
            Console.WriteLine(p0);
            dreamHomePg.InputAboutInput(p0);
        }

        [When(@"upload floor plan picture")]
        public void WhenUploadFloorPlanPicture()
        {
            dreamHomePg.InputFloorPlanInputPic();
        }

        [When(@"input in Take a Tour with Sara ""(.*)"" text")]
        public void WhenInputInTakeATourWithSaraText(string p0)
        {
            dreamHomePg.InputAddLink(p0);
        }

        [When(@"input in 3d Tour ""(.*)"" text")]
        public void WhenInputIn3DTourText(string p1)
        {
            dreamHomePg.InputTour3D(p1);
        }

        [When(@"input price as ""(.*)""")]
        public void WhenInputPriceAs(string p0)
        {
            dreamHomePg.InputPriceInp(p0);
        }

        [When(@"input Bed as ""(.*)""")]
        public void WhenInputBedAs(string p0)
        {
            dreamHomePg.InputBadInp(p0);
        }

        [When(@"input Bath as ""(.*)""")]
        public void WhenInputBathAs(string p0)
        {
            dreamHomePg.InputBathInp(p0);
        }

        [When(@"input Garden as ""(.*)""")]
        public void WhenInputGardenAs(string p0)
        {
            dreamHomePg.InputGardenInp(p0);
        }

        [When(@"input Transport as ""(.*)""")]
        public void WhenInputTransportAs(string p0)
        {
            dreamHomePg.InputTransportInp(p0);
        }

        [When(@"input location as ""(.*)""")]
        public void WhenInputLocationAs(string p0)
        {
            dreamHomePg.InputLocationInp(p0);
        }

        [When(@"input Freehold as ""(.*)""")]
        public void WhenInputFreeholdAs(string p0)
        {
            dreamHomePg.InputFreeHoldInp(p0);
        }

        [When(@"input Tax as ""(.*)""")]
        public void WhenInputTaxAs(string p0)
        {
            dreamHomePg.InputTaxInp(p0);
        }

        [When(@"input Size as (.*)")]
        public void WhenInputSizeAs(string p0)
        {
            dreamHomePg.InputSizeInp(p0);
        }

        [When(@"input Energy as ""(.*)""")]
        public void WhenInputEnergyAs(string p0)
        {
            dreamHomePg.InputEnergyInp(p0);
        }
        [When(@"go to Discount & ticket tab")]
        public void WhenGoToDiscountTicketTab()
        {
            dreamHomePg.ClickDiscountTicketTab();
        }

        [When(@"input ticket price value (.*)")]
        public void WhenInputTicketPriceValue(string p0)
        {
            dreamHomePg.InputTicketPrice(p0);
        }
        [When(@"click active checkbox")]
        public void WhenClickActiveCheckbox() => dreamHomePg.ClickActiveCheckboxFixOdd();

        [When(@"input default number of tickets (.*)")]
        public void WhenInputDefaultNumberOfTickets(string p0)
        {
            dreamHomePg.InputDefaultNumbersOfTickets(p0);
        }
        [When(@"input Number of tickets value (.*)")]
        public void WhenInputNumberOfTicketsValue(string p0)
        {
            dreamHomePg.InputNumbersOfTickets(p0);
        }        

        [When(@"click save button at dreamHome")]
        public void WhenClickSaveButtonAtDreamHome()
        {
            dreamHomePg.ClickSaveBtnWithoutWaiting();
        }

        [When(@"click save button")]
        public void WhenClickSaveButton()
        {
            dreamHomePg.ClickSaveBtn();
        }

        [When(@"user reload page")]
        public void WhenUserReloadPage()
        {
            WebDriver.Navigate().Refresh();
        }

        [Then(@"popup with message ""(.*)"" appears")]
        public void ThenPopupWithMessageAppears(string message)
        {
            string popupText;
            try {
                popupText = dreamHomePg.GetPopupText();
            
            }catch(StaleElementReferenceException e)
            {
                popupText = dreamHomePg.GetPopupText();
            }
            Assert.AreEqual(message, popupText);
        }

        [When(@"click Last page at Dream home")]
        public void WhenClickLastPageAtDreamHome()
        {
            dreamHomePg.GetPagination().ClickLastPage();
        }
        [When(@"click edit at last user")]
        public void WhenClickAditAtLastUser()
        {
            dreamHomePg.ClickLastUpdate();
        }
        [When(@"click clone at last user")]
        public void WhenClickCloneAtLastUser()
        {
            dreamHomePg.ClickLastCreate();
        }
        [Then(@"in new dream home table should be title generated earlier")]
        public void ThenInNewDreamHomeTableShouldBeTitle()
        {
            //dreamHomePg.GetPagination().ClickLastPageAtDreamHome();
            string title = (string)_scenarioContext["address_title"];
            bool areOnFirstPage = dreamHomePg.GetTitles().Contains(title); //p0
            if (areOnFirstPage) return; 
            dreamHomePg.GetPagination().ClickLastPage();
            bool areOnLastPage = dreamHomePg.GetTitles().Contains(title);
            Assert.IsTrue(areOnFirstPage || areOnLastPage);
        }

        [When(@"make ""(.*)"" active")]
        public void WhenMakeActive(string p0)
        {
            if (!dreamHomePg.IsNoActive())
            {
                dreamHomePg.MakeActiveDreamHomeUnactive();
            }
            dreamHomePg.SetActiveDreamHomeWithTitle(p0);
        }
        
        [When(@"click Discount in ticket")]
        public void WhenClickDiscountInTicket()
        {
            dreamHomePg.ClickDiscountInTicket();
        }

        [When(@"user input in discount is (.*)")]
        public void WhenUserInputInDiscountIs(string p0)
        {
            dreamHomePg.InputDiscountIs(p0);
        }

        [Then(@"new price is should be (.*)")]
        public void ThenNewPriceIsShouldBe(string p0)
        {
            Assert.AreEqual(p0, dreamHomePg.GetPriceIs());
        }

        [When(@"user input in new price is (.*)")]
        public void WhenUserInputInNewPriceIs(string p0)
        {
            dreamHomePg.InputPriceIs(p0);
        }

        [Then(@"discount is should be (.*)")]
        public void ThenDiscountIsShouldBe(string p0)
        {
            Assert.AreEqual(p0, dreamHomePg.GetDiscountIs());
        }
        [When(@"click on status in Discount tab")]
        public void WhenClickOnStatusInDiscountTab()
        {
            dreamHomePg.ClickDiscountStatus();
        }
        [When(@"click on status in credits tab")]
        public void WhenClickOnStatusInCreditsTab()
        {
            dreamHomePg.ClickCreditStatus();
        }
        [When(@"click on status in discounts tab")]
        public void WhenClickOnStatusInDiscountsTab()
        {
            dreamHomePg.ClickDiscountStatus();
        }        

        [When(@"input new price is in discount tab (.*)")]
        public void WhenInputNewPriceIsInDiscountTab(string p0)
        {
            dreamHomePg.InputPriceDiscountTab(p0);
        }

        [Then(@"""(.*)"" should be seen")]
        public void ThenShouldBeSeen(string p0)
        {
            Assert.AreEqual(p0, dreamHomePg.GetMoneyAndCurrency());
        }

        [When(@"user click on £ checkbox")]
        public void WhenUserClickOnCheckbox()
        {
            dreamHomePg.ClickCurrencyCheckbox();
        }

        [When(@"admin update title randomly generated")]
        public void WhenAdminUpdateTitleRandomlyGenerated()
        {
            string title = new AutogeneratorService().GenerateStreetAddressTitle();
            _scenarioContext.Add("address_title", title);
            dreamHomePg.inputTitle(title, true);
        }

        [When(@"admin update address from adress title")]
        public void WhenAdminUpdateAddressFromAdressTitle()
        {
            dreamHomePg.inputAddress((string)_scenarioContext["address_title"], true);
        }

        [When(@"update start and finish date")]
        public void WhenUpdateStartAndFinishDate()
        {
            
        }

        [When(@"update badroom desctiption as ""(.*)""")]
        public void WhenUpdateBadroomDesctiptionAs(string p0)
        {
            dreamHomePg.inputBadroomDescription(p0, true);
        }

        [When(@"update bathroom desctiption as ""(.*)""")]
        public void WhenUpdateBathroomDesctiptionAs(string p0)
        {
            dreamHomePg.InputBathDescription(p0, true);
        }

        [When(@"update Outspace desctiption as ""(.*)""")]
        public void WhenUpdateOutspaceDesctiptionAs(string p0)
        {
            dreamHomePg.InputOutSpaceDescription(p0, true);
        }

        [When(@"update in about ""(.*)"" text")]
        public void WhenUpdateInAboutText(string p0)
        {
            dreamHomePg.InputAboutInput(p0, true);
        }

        [When(@"update in Take a Tour with Sara ""(.*)"" text")]
        public void WhenUpdateInTakeATourWithSaraText(string p0)
        {
            dreamHomePg.InputAddLink(p0, true);
        }

        [When(@"update in (.*)d Tour ""(.*)"" text")]
        public void WhenUpdateInDTourText(int p0, string p1)
        {
            dreamHomePg.InputTour3D(p1, true);
        }

        [When(@"update price as ""(.*)""")]
        public void WhenUpdatePriceAs(string p0)
        {
            dreamHomePg.InputPriceInp(p0, true);
        }

        [When(@"update Bed as ""(.*)""")]
        public void WhenUpdateBedAs(string p0)
        {
            dreamHomePg.InputBadInp(p0, true);
        }

        [When(@"update Bath as ""(.*)""")]
        public void WhenUpdateBathAs(string p0)
        {
            dreamHomePg.InputBathInp(p0, true);
        }

        [When(@"update Garden as ""(.*)""")]
        public void WhenUpdateGardenAs(string p0)
        {
            dreamHomePg.InputGardenInp(p0, true);
        }

        [When(@"update Transport as ""(.*)""")]
        public void WhenUpdateTransportAs(string p0)
        {
            dreamHomePg.InputTransportInp(p0, true);
        }

        [When(@"update location as ""(.*)""")]
        public void WhenUpdateLocationAs(string p0)
        {
            dreamHomePg.InputLocationInp(p0, true);
        }

        [When(@"update Freehold as ""(.*)""")]
        public void WhenUpdateFreeholdAs(string p0)
        {
            dreamHomePg.InputFreeHoldInp(p0, true);
        }

        [When(@"update Tax as ""(.*)""")]
        public void WhenUpdateTaxAs(string p0)
        {
            dreamHomePg.InputTaxInp(p0, true);
        }

        [When(@"update Size as (.*)")]
        public void WhenUpdateSizeAs(string p0)
        {
            dreamHomePg.InputSizeInp(p0, true);
        }
        [When(@"update Energy as ""(.*)""")]
        public void WhenUpdateEnergyAs(string p0)
        {
            dreamHomePg.InputEnergyInp(p0, true);
        }
        [When(@"update ticket price value (.*)")]
        public void WhenUpdateTicketPriceValue(string p0)
        {
            dreamHomePg.InputTicketPrice(p0, true);
        }
        [When(@"update default number of tickets (.*)")]
        public void WhenUpdateDefaultNumberOfTickets(string p0)
        {
            dreamHomePg.InputDefaultNumbersOfTickets(p0, true);
        }
        [When(@"set credits euroes and percents as defined earlier")]
        public void WhenSetCreditsEuroesAndPercentsAsDefinedEarlier()
        {
            Dictionary<double, int> eurosPercents = (Dictionary<double, int>)_scenarioContext["eurosPercentsCredits"];
            int i = 0;
            foreach (KeyValuePair<double, int> keyValue in eurosPercents)
            {               
                dreamHomePg.InputCreditLastEuro(keyValue.Key.ToString());
                dreamHomePg.InputCreditLastPercent(keyValue.Value.ToString());
                i++;
                if(i <= eurosPercents.Count - 1) { dreamHomePg.ClickAddCredit(); }
            }
            if(eurosPercents.Count == 0)
            {
                dreamHomePg.InputCreditLastEuro("20");
                dreamHomePg.InputCreditLastPercent("31");
                eurosPercents.Add(20, 31); //default value seted by default
                _scenarioContext.Remove("eurosPercentsCredits");
                _scenarioContext.Add("eurosPercentsCredits", eurosPercents);
            }
        }
        [When(@"set discounts amount and percents as defined earlier")]
        public void WhenSetDiscountsAmountAndPercentsAsDefinedEarlier()
        {
            Dictionary<int, int> amountPercents = (Dictionary<int, int>)_scenarioContext["amountPercents"];
            int i = 0;
            foreach (KeyValuePair<int, int> keyValue in amountPercents)
            {
                dreamHomePg.InputDiscountLastAmount(keyValue.Key.ToString());
                dreamHomePg.InputDiscountLastPercent(keyValue.Value.ToString());
                i++;
                if (i <= amountPercents.Count - 1) { dreamHomePg.ClickAddCredit(); }
            }
        }
    }
}
