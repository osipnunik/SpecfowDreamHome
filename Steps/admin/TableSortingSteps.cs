using NUnit.Framework;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    class TableSortingSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private TableSortingPage sortPage = new TableSortingPage(WebDriver);

        public TableSortingSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"click downsort IDes")]
        public void WhenClickDownsortIDes()
        {
            sortPage.ClickFirstColumnDownSort();
        }

        [When(@"change pagination (.*)")]
        public void WhenChangePagination(int p0)
        {
            sortPage.GetPagination().ChooseSelect(p0);
        }
        [When(@"click lastPage")]
        public void WhenClickLastPage()
        {
            sortPage.GetPagination().ClickLastPage();
        }

        [Then(@"all IDes should be downsorted")]
        public void ThenAllIDesShouldBeDownsorted()
        {
            var idies = sortPage.GetFirstTableDatath();
            for (int i = 0; i < idies.Count - 1; i++)
            {
                int nextMore = idies[i].CompareTo(idies[i + 1]);
                Assert.IsTrue(nextMore >= 0);
            }
        }
        [When(@"click downsorting Fixed odds idies")]
        public void WhenClickDownsortingFixedOddsIdies()
        {
            sortPage.ClickFirstColumnDownSort();
        }

        [Then(@"all Fixed odds IDes should be downsorted")]
        public void ThenAllFixedOddsIDesShouldBeDownsorted()
        {
            var idies = sortPage.GetFirstTableDatatd();
            for (int i = 0; i < idies.Count - 1; i++)
            {
                int nextMore = idies[i].CompareTo(idies[i + 1]);
                Assert.IsTrue(nextMore >= 0);
            }
        }

        [When(@"click downsort Title")]
        public void WhenClickDownsortTitle()
        {
            Thread.Sleep(1000);
            sortPage.ClickSecondColumnDownSort();
        }
        [When(@"notice titles, Number of tickets and Tickets left")]
        public void WhenNoticeTitlesNumberOfTicketsAndTicketsLeft()
        {
            List<string> titles = sortPage.GetSecondRowDatatd();
            List<string> numberOfTickets = sortPage.GetFourthRowDatatd();
            List<string> ticketsLeft = sortPage.GetFifthRowDatatd();
            FixedOdd[] fixedOdds = new FixedOdd[titles.Count];
            for(int i = 0; i < titles.Count; i++)
            {
                FixedOdd fixedOdd = new FixedOdd();
                fixedOdd.Title = titles[i];
                fixedOdd.NumberOfTickets = int.Parse(numberOfTickets[i]);
                fixedOdd.TicketsLeft = int.Parse(ticketsLeft[i]);
                fixedOdds[i] = fixedOdd;
            }
            _scenarioContext.Add("fixedOdds", fixedOdds);
        }
        [Then(@"tickets left should decrease on 2, Numbers of tickets should be the same as a Titles")]
        public void ThenTicketsLeftShouldDecreaseOnNumbersOfTicketsShouldBeTheSameAsATitles(int p0)
        {
            FixedOdd[] fixedOdds = (FixedOdd[])_scenarioContext["fixedOdds"];
            List<string> titles = sortPage.GetSecondRowDatatd();
            List<string> numberOfTickets = sortPage.GetFourthRowDatatd();
            List<string> ticketsLeft = sortPage.GetFifthRowDatatd();
            for (int i = 0; i < titles.Count; i++)
            {
                fixedOdds[i].Title.Equals(titles[0]);
                fixedOdds[i].NumberOfTickets.Equals(numberOfTickets[i]);
                fixedOdds[i]
            }
            }
        [Then(@"all Titles should be downsorted")]
        public void ThenAllTitlesShouldBeDownsorted()
        {
            var titles = sortPage.GetSecondRowDatatd();
            for (int i = 0; i < titles.Count - 1; i++)
            {
                Assert.IsTrue(titles[i].CompareTo(titles[i + 1]) >= 0);
            }
        }

        [When(@"click downsort Category")]
        public void WhenClickDownsortCategory()
        {
            sortPage.ClickThirdColumnDownSort();
        }

        [Then(@"all Categories should be downsorted")]
        public void ThenAllCategoriesShouldBeDownsorted()
        {
            var categories = sortPage.GetThirdRowDatatd();
            for (int i = 0; i < categories.Count - 1; i++)
            {
                Assert.IsTrue(categories[i].CompareTo(categories[i + 1]) >= 0, categories[i]+"~"+ categories[i + 1]+" i: "+i);
            }
        }

        [When(@"click downsort Sub-Category")]
        public void WhenClickDownsortSub_Category()
        {
            sortPage.ClickFourthColumnDownSort();
        }

        [Then(@"all Sub-Categories should be downsorted")]
        public void ThenAllSub_CategoriesShouldBeDownsorted()
        {
            var subCategories = sortPage.GetFourthRowDatatd();
            for (int i = 0; i < subCategories.Count - 1; i++)
            {
                Assert.IsTrue(subCategories[i].CompareTo(subCategories[i + 1]) >= 0);
            }
        }

        [When(@"click upsort IDes")]
        public void WhenClickUpsortIDes()
        {
            sortPage.ClickFirstColumnUpSort();
        }

        [Then(@"all IDes should be upsorted")]
        public void ThenAllIDesShouldBeUpsorted()
        {
            var idies = sortPage.GetFirstTableDatath();
            for (int i = 0; i < idies.Count - 1; i++)
            {
                Assert.IsTrue(idies[i].CompareTo(idies[i + 1]) <= 0, idies[i]+"~"+ idies[i + 1]);
            }
        }

        [When(@"click upsort Title")]
        public void WhenClickUpsortTitle()
        {
            sortPage.ClickSecondColumnUpSort();
        }

        [Then(@"all Titles should be upsorted")]
        public void ThenAllTitlesShouldBeUpsorted()
        {
            var titles = sortPage.GetSecondRowDatatd();
            for (int i = 0; i < titles.Count - 1; i++)
            {
                Assert.IsTrue(titles[i].CompareTo(titles[i + 1]) <= 0, titles[i] +"~"+titles[i+1]);
            }
        }

        [When(@"click upsort Category")]
        public void WhenClickUpsortCategory()
        {
            sortPage.ClickThirdColumnUpSort();
        }

        [Then(@"all Categories should be upsorted")]
        public void ThenAllCategoriesShouldBeUpsorted()
        {
            var categories = sortPage.GetThirdRowDatatd();
            for (int i = 0; i < categories.Count - 1; i++)
            {
                Assert.IsTrue(categories[i].CompareTo(categories[i + 1]) <= 0);
            }
        }

        [When(@"click upsort Sub-Category")]
        public void WhenClickUpsortSub_Category()
        {
            sortPage.ClickFourthColumnUpSort();
        }

        [Then(@"all Sub-Categories should be upsorted")]
        public void ThenAllSub_CategoriesShouldBeUpsorted()
        {
            var subCategories = sortPage.GetFourthRowDatatd();
            for (int i = 0; i < subCategories.Count - 1; i++)
            {
                Assert.IsTrue(subCategories[i].CompareTo(subCategories[i + 1]) <= 0);
            }
        }



        [Given(@"go to user management")]
        public void GivenGoToUserManagement()
        {
            sortPage.GoToUserManagemant();
        }
        [Given(@"go to staff management")]
        public void GivenGoToStaffManagement()
        {
            sortPage.GoToStaffManagemant();
        }

        [When(@"click downsort first name")]
        public void WhenClickDownsortFirstName()
        {
            sortPage.ClickFirstColumnDownSort();
        }

        [Then(@"all first names should be downsorted")]
        public void ThenAllFirstNamesShouldBeDownsorted()
        {
            var firstNames = sortPage.GetFirstTableDatatd();
            for (int i = 0; i < firstNames.Count - 1; i++)
            {
                int nextMore = firstNames[i].Trim().CompareTo(firstNames[i + 1].Trim());
                Assert.IsTrue(nextMore >= 0, firstNames[i]+"~"+ firstNames[i + 1]);
            }
        }

        [When(@"click downsort last name")]
        public void WhenClickDownsortLastName()
        {
            sortPage.ClickSecondColumnDownSort();
        }

        [Then(@"all last names should be downsorted")]
        public void ThenAllLastNamesShouldBeDownsorted()
        {
            var lastNames = sortPage.GetSecondRowDatatd();
            for (int i = 0; i < lastNames.Count - 1; i++)
            {
                int nextMore = lastNames[i].CompareTo(lastNames[i + 1]);
                Assert.IsTrue(nextMore >= 0);
            }
        }

        [When(@"click downsort email address")]
        public void WhenClickDownsortEmailAddress()
        {
            sortPage.ClickThirdColumnDownSort();
        }

        [Then(@"all email addresses should be downsorted")]
        public void ThenAllEmailAddressesShouldBeDownsorted()
        {
            var emailAddresses = sortPage.GetThirdRowDatatd();
            for (int i = 0; i < emailAddresses.Count - 1; i++)
            {
                int nextMore = emailAddresses[i].CompareTo(emailAddresses[i + 1]);
                Assert.IsTrue(nextMore >= 0);
            }
        }

        [When(@"click downsort phone")]
        public void WhenClickDownsortPhone()
        {
            sortPage.ClickFourthColumnDownSort();
        }

        [Then(@"all phones should be downsorted")]
        public void ThenAllPhonesShouldBeDownsorted()
        {
            var phones = sortPage.GetFourthRowDatatd();
            for (int i = 0; i < phones.Count - 1; i++)
            {
                int nextMore = phones[i].CompareTo(phones[i + 1]);
                Assert.IsTrue(nextMore >= 0);
            }
        }


        [When(@"click upsort first name")]
        public void WhenClickUpsortFirstName()
        {
            sortPage.ClickFirstColumnUpSort();
        }

        [Then(@"all first names should be upsorted")]
        public void ThenAllFirstNamesShouldBeUpsorted()
        {
            var firstNames = sortPage.GetFirstTableDatatd();
            for (int i = 0; i < firstNames.Count - 1; i++)
            {
                int nextMore = firstNames[i].Trim().CompareTo(firstNames[i + 1].Trim());
                Assert.IsTrue(nextMore <= 0, "i: "+i+ "firstNames[i]"+ "firstNames[i + 1]" + firstNames[i + 1]);
            }
        }

        [When(@"click upsort last name")]
        public void WhenClickUpsortLastName()
        {
            sortPage.ClickSecondColumnUpSort();
        }

        [Then(@"all last names should be upsorted")]
        public void ThenAllLastNamesShouldBeUpsorted()
        {
            var lastNames = sortPage.GetSecondRowDatatd();
            for (int i = 0; i < lastNames.Count - 1; i++)
            {
                int nextMore = lastNames[i].CompareTo(lastNames[i + 1]);
                Assert.IsTrue(nextMore <= 0);
            }
        }

        [When(@"click upsort email address")]
        public void WhenClickUpsortEmailAddress()
        {
            sortPage.ClickThirdColumnUpSort();
        }

        [Then(@"all email addresses should be upsorted")]
        public void ThenAllEmailAddressesShouldBeUpsorted()
        {
            var emailAddresses = sortPage.GetThirdRowDatatd();
            for (int i = 0; i < emailAddresses.Count - 1; i++)
            {
                int nextMore = emailAddresses[i].CompareTo(emailAddresses[i + 1]);
                Assert.IsTrue(nextMore <= 0);
            }
        }

        [When(@"click upsort phone")]
        public void WhenClickUpsortPhone()
        {
            sortPage.ClickFourthColumnUpSort();
        }

        [Then(@"all phones should be upsorted")]
        public void ThenAllPhonesShouldBeUpsorted()
        {
            var phones = sortPage.GetFourthRowDatatd();
            for (int i = 0; i < phones.Count - 1; i++)
            {
                int nextMore = phones[i].CompareTo(phones[i + 1]);
                Assert.IsTrue(nextMore <= 0);
            }
        }

    }
}
