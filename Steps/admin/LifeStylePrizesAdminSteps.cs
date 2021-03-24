using NUnit.Framework;
using SpecFlowDreanLotteryHome.entities.user;
using SpecFlowDreanLotteryHome.pages.admin;
using SpecFlowDreanLotteryHome.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps.admin
{
    [Binding]
    class LifeStylePrizesAdminSteps : BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private LifeStylePrizesPage LfStylePPage = new LifeStylePrizesPage(WebDriver);
        private FixedOddsPage FixedOddsP = new FixedOddsPage(WebDriver);
        private AutogeneratorService generator = new AutogeneratorService();

        public LifeStylePrizesAdminSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"click Life Style prize")]
        public void GivenClickLifeStylePrize()
        {
            LfStylePPage.ClickLifeStylePrizes();
        }
        [Given(@"click Fixed odds")]
        public void GivenClickFixedOdds()
        {
            FixedOddsP.ClickFixedOdds();
        }

        [When(@"click add new prize")]
        public void WhenClickAddNewPrize()
        {
            LfStylePPage.ClickAddPrize();
        }
       
        [When(@"choose category ""(.*)""")]
        public void WhenChooseCategory(string p0)
        {
            LfStylePPage.ChooseCategory(p0);
        }

        [When(@"choose subcategoty ""(.*)""")]
        public void WhenChooseSubcategoty(string p0)
        {
            LfStylePPage.ChooseSubCategory(p0);
        }


        [When(@"input Life Style prize \(car\) title randomly generated")]
        public void WhenInputLifeStylePrizeTitleAs()
        {
            string title = generator.GenerateNonHouseVehiclePrizeTitle();
            _scenarioContext.Add("title", title);
            LfStylePPage.InputTitle(title);
        }
        [When(@"go to Discount & ticket tab at Life prize")]
        public void WhenGoToDiscountTicketTabAtLifePrize()
        {
            LfStylePPage.GoToDiscountTicketTab();
        }
        [When(@"upload non house main picture")]
        public void WhenUploadNonHouseMainPicture()
        {
            LfStylePPage.UploadMainNonHomePicture();
        }
        [When(@"go to active life style prizes")]
        public void WhenGoToActiveLifeStylePrizes()
        {
            LfStylePPage.ClickActiveLifeStilePrizes();
        }

        [When(@"change paginarion prizes per page as (.*)")]
        public void WhenChangePaginarionPrizesPerPageAs(int prizesPerPage)
        {
            LfStylePPage.GetPagination().ChooseSelect(prizesPerPage);
        }

        [When(@"logged admin get all lifeStylePrizes and notice them")]
        public void WhenLoggedAdminGetAllLifeStylePrizesAndNoticeThem()
        {
            _scenarioContext.Add("AdminProductCatSubcatTitles", LfStylePPage.GetAllProducts());
        }
        [Then(@"admin category, subcategory, title should be same as on user site")]
        public void ThenAdminCategorySubcategoryTitleShouldBeSameAsOnUserSite()
        {
            var adminPros = (List<Product>)_scenarioContext["AdminProductCatSubcatTitles"];
            var userProducts = (List<Product>)_scenarioContext["users_products"];
            for(int i = 0; i < adminPros.Count; i++)
            {
                bool equal = false;
                foreach (Product userProd in userProducts)
                {
                    if (userProd.Title.Equals(adminPros[i].Title))
                    {
                        Console.WriteLine("title same userProd:" + userProd);
                        if(userProd.CategoryName.Equals(adminPros[i].CategoryName) &&
                            userProd.SubcategoryName.Equals(adminPros[i].SubcategoryName))
                        {
                            equal = true;
                            break;
                        }
                        /*else
                        {
                            Assert.AreEqual(userProd.CategoryName, adminPros[i].CategoryName, "categ name, title is:"+userProd.Title);
                            Assert.AreEqual(userProd.SubcategoryName, adminPros[i].SubcategoryName, "subcateg name");
                        }*/
                    }
                    
                }
                Assert.IsTrue(equal, "no isTrue: " + adminPros[i].ToString());
            }
        }
       
        [Then(@"Life Style prize title generated earlier is present with category ""(.*)""")]
        public void ThenLifeStylePrizeTitleIsPresentWithCategory(string category)
        {
            string title = (string)_scenarioContext["title"];
            bool productSame = false;
            LfStylePPage.GetPagination().ClickLastPageWithWithoutScroll();
            var products = LfStylePPage.GetAllProducts();
            foreach(Product prod in products)
            {
                if (prod.Title.Equals(title) && prod.CategoryName.Equals(category))
                {
                    productSame = true;break;
                }
            }
            Assert.IsTrue(productSame);
        }
        [Then(@"created title exist in list")]
        public void ThenCreatedTitleExistInList()
        {
            bool titlePresent = false;
            string title = (string)_scenarioContext["title"];
            LfStylePPage.GetPagination().ClickLastPageWithWithoutScroll();
            var titles = LfStylePPage.GetTitles();
            foreach (string titleFromTable in titles)
            {
                if (titleFromTable.Equals(title))
                {
                    titlePresent = true; break;
                }
            }
            Assert.IsTrue(titlePresent);
        }

        [When(@"notice all prizes titles quantity")]
        public void WhenNoticeAllPrizesTitlesQuantity()
        {
            
            int all = LfStylePPage.GetTitesCount();
            _scenarioContext.Add("allPrizesQuantity", all);
        }

        [When(@"click on Active prizes")]
        public void WhenClickOnActivePrizes()
        {
            LfStylePPage.ClickActivePrizes();
            Thread.Sleep(300);
        }

        [When(@"notice active prizes titles quantity")]
        public void WhenNoticeActivePrizesTitlesQuantity()
        {
            int titleCount = LfStylePPage.GetTitesCount();
            string paginTableSize = LfStylePPage.GetPagination().GetSizeOfTable();
            Assert.AreEqual(titleCount.ToString(), paginTableSize);
            _scenarioContext.Add("activePrizesQuantity", titleCount);
        }

        [When(@"click on Unactive prizes")]
        public void WhenClickOnUnactivePrizes()
        {
            Thread.Sleep(500);
            LfStylePPage.ClickUnActivePrizes();
            Thread.Sleep(200);
        }

        [When(@"notice unactive prizes titles quantity")]
        public void WhenNoticeUnactivePrizesTitlesQuantity()
        {
            int titleCount = LfStylePPage.GetTitesCount();
            string paginTableSize = LfStylePPage.GetPagination().GetSizeOfTable();
            Assert.AreEqual(titleCount.ToString(), paginTableSize);
            _scenarioContext.Add("unactivePrizesQuantity", titleCount);
        }

        [Then(@"all prizes should be equal the sum of active and unactive")]
        public void ThenAllPrizesShouldBeEqualTheSumOfActiveAndUnactive()
        {
            Assert.AreEqual((int)_scenarioContext["allPrizesQuantity"],
            (int)_scenarioContext["activePrizesQuantity"] +
            (int)_scenarioContext["unactivePrizesQuantity"], "active: "+ (int)_scenarioContext["activePrizesQuantity"]);
        }

    }
}
