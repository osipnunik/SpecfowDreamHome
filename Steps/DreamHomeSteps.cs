using SpecFlowDreanLotteryHome.pages.admin;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
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
            WebDriver.Navigate().GoToUrl(LoginAdminUrl);
            loginPg.InputLogin(p0);
            loginPg.InputPass(p1);
            loginPg.ClickSignIn();
        }
        
        [Given(@"click add new dream home")]
        public void GivenClickAddNewDreamHome()
        {
            dreamHomePg.clickAddNewDreamHome();
        }
        
        [When(@"admin input title as ""(.*)""")]
        public void WhenAdminInputTitleAs(string p0)
        {
            dreamHomePg.inputTitle(p0);
        }
        
        [When(@"admin input address as ""(.*)""")]
        public void WhenAdminInputAddressAs(string p0)
        {
            dreamHomePg.inputAddress(p0);
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
        
        [When(@"download badroom picture")]
        public void WhenDownloadBadroomPicture()
        {
            dreamHomePg.clickSelectBadroomPicture();
        }
        
        /*[When(@"input bathroom desctiption as ""(.*)""")]
        public void WhenInputBathroomDesctiptionAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"download bathroom picture")]
        public void WhenDownloadBathroomPicture()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"input Outspace  desctiption as ""(.*)""")]
        public void WhenInputOutspaceDesctiptionAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"download Outspace picture")]
        public void WhenDownloadOutspacePicture()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"add about descrition as ""(.*)""")]
        public void WhenAddAboutDescritionAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"go to discount & ticket tab")]
        public void WhenGoToDiscountTicketTab()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"input price as (.*)")]
        public void WhenInputPriceAs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Click Save")]
        public void WhenClickSave()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"user login as user on web")]
        public void ThenUserLoginAsUserOnWeb()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
