using NUnit.Framework;
using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    public class TableFilteringColumnSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private TableFilteringPage filterPage = new TableFilteringPage(WebDriver);

        public TableFilteringColumnSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"notice first title")]
        public void WhenNoticeFirstTitle()
        {
            _scenarioContext.Add("title", filterPage.GetFirstCellTextInSecondColumn());
        }
        [When(@"notice last title")]
        public void WhenNoticeLastTitle()
        {
            _scenarioContext.Add("title", filterPage.GetLastCellTextInSecondColumn());
        }
        [When(@"notice last title and category and subcategory")]
        public void WhenNoticeLastTitleAndCategoryAndSubcategory()
        {
            _scenarioContext.Add("title", filterPage.GetLastCellTextInSecondColumn());
            _scenarioContext.Add("category", filterPage.GetLastCellTextInThirdColumn());
            _scenarioContext.Add("subCategory", filterPage.GetLastCellTextInFourthColumn());
        }

        [When(@"notice all categories")]
        public void WhenNoticeAllCategories()
        {
            //filterPage.ScrollToUserManagementHref();
            Thread.Sleep(1500);
            _scenarioContext.Add("categories", filterPage.GetFirstRowDatatdWithoutWaitForDown());
        }
        [When(@"notice all subCategories")]
        public void WhenNoticeAllSubCategories()
        {
            _scenarioContext.Add("subCategories", filterPage.GetFirstRowDatatdWithoutWaitForDown());
        }
        [When(@"click on title dropdown")]
        public void WhenClickOnTitleDropdown()
        {
            filterPage.ClickSecondHeader();
        }
        
        [When(@"input noticed title in filter input")]
        public void WhenInputNoticedTitleInFilterInput()
        {
            filterPage.InputFilter((string)_scenarioContext["title"]);
        }

        [When(@"choose first appeared")]
        public void WhenChooseFirstAppeared()
        {
            filterPage.ClickFirstFilterItemCheckbox();
        }
        [When(@"choose noticed earlier title")]
        public void WhenChooseNoticedEarlierTitle()
        {
            filterPage.ChooseTitle((string)_scenarioContext["title"]);
        }

        [When(@"click filter button")]
        public void WhenClickFilterButton()
        {
            
            filterPage.ClickFilterBtn();
            //Thread.Sleep(1000);
        }
        
        [When(@"close second filter popup")]
        public void WhenCloseFilterPopup()
        {
            filterPage.ClickSecondHeader();
        }
        [When(@"close third filter popup")]
        public void WhenCloseThirdFilterPopup()
        {
            filterPage.ClickThirdHeader();
        }
        [When(@"check pagination to (.*)")]
        public void WhenCheckPaginationTo(int p0)
        {
            filterPage.GetPagination().ChooseSelectWithWait(p0);
        }

        [Then(@"all titles in table should be as noticed earlier")]
        public void ThenAllTitlesInTableShouldBeAsNoticedEarlier()
        {
            string expectedTitle = (string)_scenarioContext["title"];           
            List<string> titles = filterPage.GetSecondRowDatatd();
            for(int i = 0; i < titles.Count; i++)
            {
                Assert.AreEqual(expectedTitle, titles[i]);
            }
        }
        [Then(@"categories should be the same")]
        public void ThenCategoryShouldBeTheSame()
        {           
            string expectedCategory = (string)_scenarioContext["category"];
            List<string> categories = filterPage.GetThirdRowDatatd();
            for (int i = 0; i < categories.Count; i++)
            {
                Assert.AreEqual(expectedCategory, categories[i]);
            }
        }

        [Then(@"subcategories should be the same")]
        public void ThenSubcategoryShouldBeTheSame()
        {
            string expectedSubCategory = (string)_scenarioContext["subCategory"];
            List<string> subCategories = filterPage.GetFourthRowDatatd();
            for (int i = 0; i < subCategories.Count; i++)
            {
                Assert.AreEqual(expectedSubCategory, subCategories[i]);
            }
        }

        [When(@"click on Category dropdown")]
        public void WhenClickOnCategoryDropdown()
        {
            filterPage.ClickThirdHeader();
        }

        [Then(@"in list should be all categories")]
        public void ThenInListShouldBeAllCategories()
        {
            List<string> expectedCategories = (List<string>)_scenarioContext["categories"];
            List<string> filterItemsNames = filterPage.GetFilterItemsNames();
            Assert.AreEqual(expectedCategories.Count, filterItemsNames.Count);
            for(int i = 0; i < expectedCategories.Count; i++)
            {
                Assert.IsTrue(expectedCategories.Contains(filterItemsNames[i]), filterItemsNames[i]);
            }
        }
        [When(@"click on Sub-Category dropdown")]
        public void WhenClickOnSub_CategoryDropdown()
        {
            filterPage.ClickFourthHeader();
        }

        [Then(@"in list should be all sub categories")]
        public void ThenInListShouldBeAllSubCategories()
        {
            List<string> expectedSubCategories = (List<string>)_scenarioContext["subCategories"];
            List<string> filterItemsNames = filterPage.GetFilterItemsNames();
            Assert.AreEqual(expectedSubCategories.Count, filterItemsNames.Count);
            for (int i = 0; i < expectedSubCategories.Count; i++)
            {
                Assert.IsTrue(expectedSubCategories.Contains(filterItemsNames[i]), filterItemsNames[i]);
            }
        }

    }
}
