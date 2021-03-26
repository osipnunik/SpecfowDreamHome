using SpecFlowDreanLotteryHome.pages.admin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    class LyfeStyleManagementSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        public CategoryPage catSubc = new CategoryPage(WebDriver);        

        public LyfeStyleManagementSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"click on LyfeStyle Management")]
        public void WhenClickOnLyfeStyleManagement()
        {
            catSubc.ClickLyfeStyleManagement();
        }
        [When(@"click on subcategories")]
        public void WhenClickOnSubcategories()
        {
            catSubc.ClickSubcategories();
        }

        [When(@"click add category")]
        public void WhenClickAddCategory()
        {
            catSubc.ClickAddNew(); //?will work
        }

        [Then(@"Title Add category is displayed")]
        public void ThenTitleAddCategoryIsDisplayed()
        {
            catSubc.PopupWithTextDisplayed("category");
        }

        [When(@"input animal category picture")]
        public void WhenInputAnimalCategoryPicture()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"make status active")]
        public void WhenMakeStatusActive()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"admin input title ""(.*)""")]
        public void WhenAdminInputTitle(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"click save category")]
        public void WhenClickSaveCategory()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"category with title ""(.*)"" exist")]
        public void ThenCategoryWithTitleExist(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"click Add Sub-category")]
        public void WhenClickAddSub_Category()
        {
            catSubc.ClickAddNew(); //?will work
        }

        [When(@"input animal sub-category picture")]
        public void WhenInputAnimalSub_CategoryPicture()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Sub-category with title ""(.*)"" exist")]
        public void ThenSub_CategoryWithTitleExist(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
