using NUnit.Framework;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.services;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class StaffManagementSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private AutogeneratorService bogger = new AutogeneratorService();
        private StaffManagementPage staffPage = new StaffManagementPage(WebDriver);
        private TableFilteringPage tableFiltP = new TableFilteringPage(WebDriver);
        private MenuExistingElsFragment menuF = new MenuExistingElsFragment(WebDriver);
        public StaffManagementSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"admin go to staff Management page")]
        public void WhenAdminGoToStaffManagementPage()
        {
            menuF.ClickStaffManagementHrefReliable();//or click link-active !!
        }
        [When(@"scroll to staff Management href")]
        public void WhenScrollToStaffManagementHref()
        {
            staffPage.ScrollStraffMenegementHref();
        }

        [When(@"autogenerate and notice user")]
        public void WhenAutogenerateAndNoticeUser()
        {
            var us = bogger.GetUser();
            _scenarioContext.Add("user", us);
        }
        [When(@"input first name, last name, address")]
        public void WhenInputFirstNameLastNameAddress()
        {
            var user = (User)_scenarioContext["user"];
            staffPage.InputFirstName(user.FirstName);
            staffPage.InputLastName(user.LastName);
            staffPage.InputEmail(user.Email);
        }
              
        [When(@"input skype")]
        public void WhenInputSkype()
        {
            staffPage.InputSkype("fskdfjh");
        }
        [When(@"click save staff")]
        public void WhenClickSaveStaff()
        {
            staffPage.ClickSaveStaff();
        }
        [Then(@"staff user should be created")]
        public void ThenStaffUserShouldBeCreated()
        {
            staffPage.GetPagination().ClickLastPage();
            var expectedUser = (User)_scenarioContext["user"];
            Assert.AreEqual(expectedUser.FirstName, tableFiltP.GetLastCellInFirstColumn());
            Assert.AreEqual(expectedUser.LastName, tableFiltP.GetLastCellTextInSecondColumn());
            Assert.AreEqual(expectedUser.Email, tableFiltP.GetLastCellTextInThirdColumn());
            tableFiltP.GetLastCellTextInFourthColumn();
        }

    }
}
