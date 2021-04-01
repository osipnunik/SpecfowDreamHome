﻿using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.services;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class UserManagementSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private UserManagementPage usersP = new UserManagementPage(WebDriver);
        private AutogeneratorService bogger = new AutogeneratorService(); 
        public UserManagementSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"admin go to UserManagement page")]
        public void WhenAdminGoToUserManagementPage()
        {
            usersP.ClickUserManagementHref();
        }
        [When(@"admin click on add new user")]
        public void WhenAdminClickOnAddNewUser()
        {
            usersP.ClickAddNew();
        }

        [When(@"input autogenerated user")]
        public void WhenInputAutogeneratedUser()
        {
            var user = bogger.GetUser();
            Console.WriteLine(user);
            Console.WriteLine(user.Email);
            _scenarioContext.Add("user", user);
            usersP.InputFirstName(user.FirstName);
            usersP.InputLastName(user.LastName);
            usersP.InputEmail(user.Email);
            usersP.InputPhone(user.Phone);
            usersP.ChooseCountry(user.Country);
        }
        [When(@"click save user button")]
        public void WhenClickSaveUserButton()
        {
            usersP.ClickSave();
        }
        [Then(@"message with text ""(.*)"" should appeared")]
        public void ThenMessageWithTextShouldAppeared(string p0)
        {
            Assert.AreEqual(p0, usersP.GetPopupText());
        }

        [Then(@"last user should be as generated")]
        public void ThenLastUserShouldBeAsGenerated()
        {
            usersP.GetPaginationFragment().ClickLastPage();
            var lastUser = usersP.GetLastUser();
            Assert.AreEqual((User)_scenarioContext["user"], lastUser);
        }
        [When(@"delete last user")]
        public void WhenDeleteLastUser()
        {
            usersP.DeleteLastUser();
        }

        [Then(@"last user should not be as generated")]
        public void ThenLastUserShouldNotBeAsGenerated()
        {
            var lastUser = usersP.GetLastUser();
            Assert.AreNotEqual((User)_scenarioContext["user"], lastUser);
        }
        [When(@"click edit last user")]
        public void WhenClickEditLastUser()
        {
            usersP.ClickEditLastUser();
        }

        [When(@"go to ticket tab")]
        public void WhenGoToTicketTab()
        {
            usersP.ClickTicketsTab();
        }                

        [When(@"click Add ticket")]
        public void WhenClickAddTicket()
        {
            usersP.ClickAddTicket();
        }
        [When(@"go to credit tab")]
        public void WhenGoToCreditTab()
        {
            usersP.ClickCreditTab();
        }

        [When(@"click Add credit")]
        public void WhenClickAddCredit()
        {
            usersP.ClickAddCredits();
        }
        [When(@"input credit")]
        public void WhenInputCredit()
        {
            usersP.InputCredit("112");
        }

        [When(@"add first 10 fixed odds tickets")]
        public void WhenAddFirstFixedOddsTickets()
        {

            FixedOdd[] fixedOdds = (FixedOdd[])_scenarioContext["fixedOdds"];
            //Assert.AreEqual("Add tickets" , usersP.GetTicketTitleText());   after addTicket
            for (int i = 0; i < fixedOdds.Length; i++)
            {
                usersP.ClickAddTicket();
                usersP.ChooseCompetitionFixedOdds();
                usersP.ChooseProduct(fixedOdds[i].Title);
                if (fixedOdds[i].TicketsLeft < 0)
                {
                    throw new Exception("your " + fixedOdds[i].Title + " has negative TicketsLeft " + fixedOdds[i].TicketsLeft);
                }
                else
                if (fixedOdds[i].TicketsLeft > 1)
                {

                    try { usersP.SetTicketsAmountTwo(); }
                    catch (ElementNotInteractableException e)
                    {
                        Console.WriteLine("NotInteract. " + fixedOdds[i].Title);
                        usersP.ChooseProduct(fixedOdds[i].Title);
                    }
                }
                else if (fixedOdds[i].TicketsLeft == 1)
                { }
                usersP.ClickSaveBtn();
            }
        }
        [Then(@"form with title ""(.*)"" should appeared")]
        public void ThenFormWithTitleShouldAppeared(string p0)
        {
            Assert.AreEqual(p0, usersP.GetTicketTitleText());
        }

        [When(@"notice Competition and Product and number")]
        public void WhenNoticeCompetitionAndProductAndNumber()
        {
            _scenarioContext.Add("competition", usersP.GetTicketCompetition());
            _scenarioContext.Add("product", usersP.GetTicketProduct());
            _scenarioContext.Add("number", usersP.GetTicketNumber());
        }

        [When(@"click save")]
        public void WhenClickSave()
        {
            usersP.ClickSaveBtn();
        }

        [Then(@"last ticket should be with product and competition type as expected")]
        public void ThenLastTicketShouldBeWithProductAndCompetitionTypeAsExpected()
        {
            TicketOrder expected = new TicketOrder();
            expected.Competiotion = (string)_scenarioContext["competition"];
            expected.Product = (string)_scenarioContext["product"];
            expected.NumberOfTicket = (string)_scenarioContext["number"];
            TicketOrder actualTicket = usersP.GetLastTicket();
            Assert.AreEqual(expected, actualTicket);
        }
        [When(@"click edit on last ticket order")]
        public void WhenClickEditOnLastTicketOrder()
        {
            usersP.ClickEditLastTicket();
        }

        [When(@"click remove icon in new form")]
        public void WhenClickRemoveIconInNewForm()
        {
            usersP.ClickRemoveTickInEditTiket();
        }

        [Then(@"last ticket should not be with product and competition type as expected")]
        public void ThenLastTicketShouldNotBeWithProductAndCompetitionTypeAsExpected()
        {
            TicketOrder expected = new TicketOrder();
            expected.Competiotion = (string)_scenarioContext["competition"];
            expected.Product = (string)_scenarioContext["product"];
            expected.NumberOfTicket = (string)_scenarioContext["number"];
            TicketOrder actualTicket = usersP.GetLastTicket();
            Assert.AreNotEqual(expected, actualTicket);
        }

    }
}
