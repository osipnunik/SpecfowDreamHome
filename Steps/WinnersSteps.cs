﻿using NUnit.Framework;
using SpecFlowDreanLotteryHome.pages.admin;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    public class WinnersSteps : BaseStepDefinition
    {
        private WinnersPage WinnP = new WinnersPage(WebDriver);
        private LoginAdminPage loginPg = new LoginAdminPage(WebDriver);

        [Given(@"admin logged in")]
        public void GivenAdminLoggedIn()
        {
            WebDriver.Navigate().GoToUrl(WINNERS_ADM_VAL);
            loginPg.InputLogin("testqaanuitex@gmail.com"); 
            loginPg.InputPass("1111111");
            loginPg.ClickSignIn();
        }
        
        [When(@"admin go to Winners page")]
        public void WhenAdminGoToWinnersPage()
        {
            WinnP.ClickSettings();
            WinnP.ClickWinners();
        }
        
        [When(@"admin click on down sorting button")]
        public void WhenAdminClickOnDownSortingButton()
        {
            WinnP.ClickCompetitionHeaderDownSort();
            WinnP.ClickCompetitionSharpHeaderDownSort();
            WinnP.ClickFinishDateHeaderDownSort();
            WinnP.ClickTitleHeaderDownSort();
        }
        
        [When(@"user click on up sorting button")]
        public void WhenUserClickOnUpSortingButton()
        {
            WinnP.ClickCompetitionHeaderUpSort();
            WinnP.ClickCompetitionSharpHeaderUpSort();
            WinnP.ClickFinishDateHeaderUpSort();
            WinnP.ClickTitleHeaderUpSort();
        }
        
        [Then(@"admin see following colume:")]
        public void ThenAdminSeeFollowingColume(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.IsTrue(WinnP.IsColumnHeaderVisible(row[0]));                
            }
        }      
       
        [When(@"admin click downsorting on column CompetitionSharp")]
        public void WhenAdminClickDownsortingOnColumnCompetitionSharp()
        {
            WinnP.ClickCompetitionSharpHeaderDownSort();
        }

        [Then(@"All competitionSharp sorted downward")]
        public void ThenAllCompetitionSharpSortedDownward()
        {
            Log.Info("size: " + WinnP.GetSizeOfWinnersTable());
            Console.WriteLine("Logging like sysout!!!");
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetCompetitionShartData()[i].CompareTo(WinnP.GetCompetitionShartData()[i+1]) > 0);              
            }
        }

        [When(@"admin click downsorting on column Competition")]
        public void WhenAdminClickDownsortingOnColumnCompetition()
        {
            WinnP.ClickCompetitionHeaderDownSort();
        }

        [Then(@"All competition sorted downward")]
        public void ThenAllCompetitionSortedDownward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetCompetitionData()[i].CompareTo(WinnP.GetCompetitionData()[i+1]) > 0);               
            }
        }

        [When(@"admin click downsorting on column FinishDate")]
        public void WhenAdminClickDownsortingOnColumnFinishDate()
        {
            WinnP.ClickFinishDateHeaderDownSort();
        }

        [Then(@"All FinishDate sorted downward")]
        public void ThenAllFinishDateSortedDownward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {              
                Assert.IsTrue(WinnP.GetFinishDateData()[i].CompareTo(WinnP.GetFinishDateData()[i+1]) > 0);
            }
        }

        [When(@"admin click downsorting on column Title")]
        public void WhenAdminClickDownsortingOnColumnTitle()
        {
            WinnP.ClickTitleHeaderDownSort();
        }

        [Then(@"All Titles sorted downward")]
        public void ThenAllTitlesSortedDownward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {               
                Assert.IsTrue(WinnP.GetTitleData()[i].CompareTo(WinnP.GetTitleData()[i+1]) > 0);
            }
        }

        [When(@"admin click upsorting on column CompetitionSharp")]
        public void WhenAdminClickUpsortingOnColumnCompetitionSharp()
        {
            WinnP.ClickCompetitionSharpHeaderUpSort();
        }

        [Then(@"All competitionSharp sorted upward")]
        public void ThenAllCompetitionSharpSortedUpward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetCompetitionShartData()[i].CompareTo(WinnP.GetCompetitionShartData()[i + 1]) < 0);
            }
        }

        [When(@"admin click upsorting on column Competition")]
        public void WhenAdminClickUpsortingOnColumnCompetition()
        {
            WinnP.ClickCompetitionHeaderUpSort();
        }

        [Then(@"All competition sorted upward")]
        public void ThenAllCompetitionSortedUpward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetCompetitionData()[i].CompareTo(WinnP.GetCompetitionData()[i + 1]) < 0);
            }
        }

        [When(@"admin click upsorting on column FinishDate")]
        public void WhenAdminClickUpsortingOnColumnFinishDate()
        {
            WinnP.ClickFinishDateHeaderUpSort();
        }

        [Then(@"All FinishDate sorted upward")]
        public void ThenAllFinishDateSortedUpward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetFinishDateData()[i].CompareTo(WinnP.GetFinishDateData()[i+1]) < 0);
            }
        }

        [When(@"admin click upsorting on column Title")]
        public void WhenAdminClickUpsortingOnColumnTitle()
        {
            WinnP.ClickTitleHeaderUpSort();
        }

        [Then(@"All Titles sorted upward")]
        public void ThenAllTitlesSortedUpward()
        {
            for (int i = 0; i > WinnP.GetSizeOfWinnersTable() - 1; i++)
            {
                Assert.IsTrue(WinnP.GetTitleData()[i].CompareTo(WinnP.GetTitleData()[i+1]) < 0);
            }
        }

        [When(@"admin click on add new winner")]
        public void WhenAdminClickOnAddNewWinner()
        {
            WinnP.ClickAddNew();
        }
        [When(@"admin choose product ""(.*)""")]
        public void WhenAdminChooseProduct(string p0)
        {
            WinnP.ChooseProduct(p0);
        }

        [When(@"go to description")]
        public void WhenGoToDescription()
        {
            WinnP.ClickDescription();
        }
        [When(@"input title as ""(.*)""")]
        public void WhenInputTitleAs(string p0)
        {
            WinnP.InputDescriptTitle(p0);
        }

        [When(@"input picture")]
        public void WhenInputPicture()
        {
            WinnP.instertPic();
        }
        [When(@"click Save")]
        public void WhenClickSave()
        {
            WinnP.ClickSave();
        }


    }
}