using NUnit.Framework;
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
            catSubc.ClickAddNewCategory_Sub(); 
        }

        [Then(@"Title Add category is displayed")]
        public void ThenTitleAddCategoryIsDisplayed()
        {
            Assert.AreEqual("Add category", catSubc.GetDialogPopupText());
        }
        [Then(@"Title Add Sub-category is displayed")]
        public void ThenTitleAddSub_CategoryIsDisplayed()
        {
            Assert.AreEqual("Add sub-category", catSubc.GetDialogPopupText());
        }

        [When(@"input animal category picture")]
        public void WhenInputAnimalCategoryPicture()
        {
            catSubc.inputPicture();
        }

        [When(@"make status active")]
        public void WhenMakeStatusActive()
        {
            catSubc.ClickOnStatus();
        }

        [When(@"admin input title ""(.*)""")]
        public void WhenAdminInputTitle(string p0)
        {
            catSubc.InputTitle(p0);
        }

        [When(@"click save category")]
        public void WhenClickSaveCategory()
        {
            catSubc.ClickSaveCategSub();
        }

        [Then(@"category with title ""(.*)"" exist")]
        public void ThenCategoryWithTitleExist(string p0)
        {
            Assert.IsTrue(catSubc.GetFirstRowDatatd().Contains(p0));
        }
        [Then(@"popup with text ""(.*)"" appears")]
        public void ThenPopupWithTextAppears(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, catSubc.GetPopupText());
        }

        [When(@"click Add Sub-category")]
        public void WhenClickAddSub_Category()
        {
            catSubc.ClickAddNewCategory_Sub(); 
        }

        [When(@"input animal sub-category picture")]
        public void WhenInputAnimalSub_CategoryPicture()
        {
            catSubc.inputPicture();
        }
        [When(@"choose category in subcategory ""(.*)""")]
        public void WhenChooseCategoryInSubcategory(string p0)
        {
            catSubc.ChooseSubCategory(p0);
        }

        [Then(@"Sub-category with title ""(.*)"" exist")]
        public void ThenSub_CategoryWithTitleExist(string p0)
        {
            Assert.IsTrue(catSubc.GetFirstRowDatatd().Contains(p0));
        }


    }
}
