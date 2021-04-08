using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities.user;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class LifeStylePrizesUsersPage : BasePage
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LifeStylePrizesUsersPage(IWebDriver webDriver) : base(webDriver) { }

        private List<Product> ProductList = new List<Product>();

        private IList<IWebElement> CategoryNames => WebDriver.FindElements(By.CssSelector("div.cardsItems:first-child div.itemName"));
        private IList<IWebElement> CategoryItems => WebDriver.FindElements(By.CssSelector("div.cardsItems:first-child .buttonItem"));
        string CategoryNameString;
        private IWebElement CategoryOfLSP => WebDriver.FindElement(By.XPath("//div[@class='itemName' and text()='"+CategoryNameString+"']"));
        string SubCategoryNameString;
        private IWebElement SubCategoryOfLSP => WebDriver.FindElement(By.XPath("//div[@class='cardsItems secondItem']//div[@class='itemName' and text()='" + SubCategoryNameString + "']"));
        string TitleString;
        private IWebElement PrizeTitle => WebDriver.FindElement(By.XPath("//div[@class='productTitle']/p[text()='"+TitleString+"']"));
        private IList<IWebElement> SubCategoryNames => WebDriver.FindElements(By.CssSelector("div.secondItem div.itemName"));
        private IList<IWebElement> Products => WebDriver.FindElements(By.CssSelector("div.lifestyleProduct-mob"));
        private IWebElement FirstProductTitle => WebDriver.FindElement(By.CssSelector("div.productTitle p"));
        private IWebElement DreamHomeHref => WebDriver.FindElement(By.CssSelector("a[href = '/dreamhome']"));
        private IWebElement LifeStylePrizesHref => WebDriver.FindElement(By.CssSelector("a[href='/lifestyleprizes']"));

        private IWebElement ProductContainer => WebDriver.FindElement(By.CssSelector("div.lifestyleProductList"));
        private IWebElement ActiveCategoryName => WebDriver.FindElement(By.CssSelector("div.buttonItem.active div.itemName"));
        private IWebElement ActiveSubcategName => WebDriver.FindElement(By.CssSelector("div.secondItem div.buttonItem.active div.itemName"));
        private IWebElement FirstProduct => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.lifestyleProduct-mob:first-child img")));//"div.productTitle"));
        internal void ClickLifeStylePrizes() => LifeStylePrizesHref.Click();

        private By ProductImages => By.CssSelector("div.productImage img");
        private By ProductTitles => By.CssSelector("div.productTitle p");
        private By PricesNonDiscount => By.CssSelector("div.productPrices p.none-discount");
        
        internal void ClickOnFirstProduct()
        {
            ScrollDown();          
            //Actions actions = new Actions(WebDriver);
            //actions.MoveToElement(FirstProduct)/*.Click()*/.Perform();
            //Thread.Sleep(2000);
            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.lifestyleProduct-mob:first-child img")));
            //Waiter.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.lifestyleProduct-mob:first-child img")));
            FirstProduct.Click();
        }

        private By PricesOld => By.CssSelector("p.discount-old-price");
        private By DialogPopupBy => By.CssSelector("div[role = 'dialog']");
        private IWebElement ProductPopup => Waiter.Until(ExpectedConditions.ElementExists(DialogPopupBy));
        private IList<IWebElement> DialogPopupForExist => WebDriver.FindElements(DialogPopupBy);

        private IWebElement Title => WebDriver.FindElement(By.CssSelector("div.ModalInfoTitle h3"));
        private IWebElement NonDiscountPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.none-discount"));
        private IWebElement DiscountOldPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-old-price"));                      
        private IWebElement DiscountNewPrice => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-new-price"));
        private IWebElement DiscountPercent => WebDriver.FindElement(By.CssSelector("div[role='dialog'] p.discount-percent"));
        private IWebElement BuyNowBtn => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.price button:first-child")));
        private IWebElement TotalPrice => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.totalValue"));
        private IWebElement TotalSaving => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.savingValue"));
        private IWebElement CreditEarned => WebDriver.FindElement(By.CssSelector("div.priceGreyContainer div:last-child p.creditValue"));
        private IWebElement LastDiscount => WebDriver.FindElement(By.CssSelector("div.ticketCard:last-child .ticketСardItem:last-child span"));
        private IWebElement EnterNowBtn => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(/*"button.enterBtn")));*/"button.winFlatBtn")));


        public string GetTitle()
        {
            string s = Title.Text;
            if (s.Length != 0) return s;
            else {
                Console.WriteLine("!!s Title.Text.Length == 0");
                return Title.Text; }
        }
        public string GetNonDiscountPrice() => NonDiscountPrice.Text;
        public string GetDiscountOldPrice() => DiscountOldPrice.Text;

        internal string GetLastDiscount() => LastDiscount.Text;

        public string GetDiscountNewPrice() => DiscountNewPrice.Text;              
                
        internal void ClickDreamHome() => DreamHomeHref.Click(); 

        public string GetDiscountPercent() => DiscountPercent.Text;
        
        public string GetTotalPrice() => TotalPrice.Text;
        public string GetTotalSaving() => TotalSaving.Text;
        public string GetCreditEarned() => CreditEarned.Text;

        internal Product GetFirstProduct()
        {
            Console.WriteLine("Get first product - i: 0");
            entities.user.Product product = new Product();
            product.CategoryName = ActiveCategoryName.Text;
            product.SubcategoryName = ActiveSubcategName.Text;
            product.ImgHref = /*Products[0]*/WebDriver.FindElement(ProductImages).Text;
            try { product.Title = /*Products[0]*/WebDriver.FindElement(ProductTitles).Text; }
            catch (StaleElementReferenceException e)
            {
                product.Title = /*Products[0]*/WebDriver.FindElement(ProductTitles).Text;
            }
            if (Products[0].FindElements(PricesNonDiscount).Count >= 1)
            {
                product.NonDiscountPrice = /*Products[0]*/WebDriver.FindElement(PricesNonDiscount).Text;
            }
            else
            {
                product.OldPrice = /*Products[0]*/WebDriver.FindElement(PricesOld).Text;
                product.NewPrice = /*Products[0]*/WebDriver.FindElement(PricesNewDiscount).Text;
                product.DiscountOff = /*Products[0]*/WebDriver.FindElement(DiscountPercents).Text;
            }
            return product;
        }

        internal bool IsProductPopupAppeared() => ProductPopup.Displayed;
        
        internal bool IsProductPopupDisAppeared() => DialogPopupForExist.Count == 0;
                
        private By PricesNewDiscount => By.CssSelector("p.discount-new-price");
        private By DiscountPercents => By.CssSelector("p.discount-percent");

        public void formList()
        {
            for(int i = 0; i < CategoryNames.Count; i++)//int i = CategoryNames.Count-1; i >= 0; i--)
            {
                try
                {
                    Console.WriteLine("categories - i: " + i);
                    CategoryItems[i].Click();
                    WaitUntilPreviosProductShouldHaveDifferentTitle();
                }
                catch(ElementNotInteractableException e)
                {
                    Actions actions = new Actions(WebDriver);
                    actions.MoveToElement(CategoryNames[i]);
                    actions.Perform();
                    Console.WriteLine("categoryName - i: " + i);
                    CategoryNames[i].Click();
                    WaitUntilPreviosProductShouldHaveDifferentTitle();
                }
                if (SubCategoryNames.Count == 0)
                {
                   AddProducts();
                }
                else
                {                   
                    for (int j = 0; j < SubCategoryNames.Count; j++)
                    {
                        //SubCategoryNames[j].Click();
                        AddProducts(SubCategoryNames[j].Text);
                        if((j + 1) < SubCategoryNames.Count)
                        {
                            JSClick(SubCategoryNames[j + 1]);
                            //SubCategoryNames[j + 1].Click();
                            WaitUntilPreviosProductShouldHaveDifferentTitle();
                        }
                    }
                }
            }
        }

        internal void ClickOnRandomCategory()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("let categs = document.querySelectorAll('.buttonItem');var size = categs.length;let randNum = Math.random(size);categs.item(randNum).click();");
            Thread.Sleep(1000);
            //WaitUntilPreviosProductShouldHaveDifferentTitle();
        }

        private void WaitUntilPreviosProductShouldHaveDifferentTitle()
        {
            if (ProductList.Count != 0) //wait until previos product(if exist) should have different title
            {
                //Waiter.Until(ExpectedConditions.TextToBePresentInElement(FirstProductTitle,  ProductList[ProductList.Count - 1].Title));
                Waiter.Until(ExpectedConditions.InvisibilityOfElementWithText(ProductTitles, ProductList[ProductList.Count - 1].Title));
            }
        }
        private void AddProducts(string subcategory = "")
        {
            string category = ActiveCategoryName.Text;
            WaitUntilPreviosProductShouldHaveDifferentTitle();
            for (int i = 0; i < Products.Count; i++) {
                Console.WriteLine("product - i: " + i);
                entities.user.Product product = new Product();
                bool stale = true;
                while (stale)
                {
                    try
                    {
                        product.CategoryName = category;
                        product.SubcategoryName = subcategory;
                        product.ImgHref = Products[i].FindElement(ProductImages).Text;
                        try { 
                            product.Title = Products[i].FindElement(ProductTitles).Text;
                        }
                        catch (StaleElementReferenceException e)
                        {
                            product.Title = Products[i].FindElement(ProductTitles).Text;
                        }
                        if (Products[i].
                            FindElements(PricesNonDiscount).Count >= 1)
                        {
                            product.NonDiscountPrice = Products[i].FindElement(PricesNonDiscount).Text;
                        }
                        else
                        {
                            product.OldPrice = Products[i].FindElement(PricesOld).Text;
                            product.NewPrice = Products[i].FindElement(PricesNewDiscount).Text;
                            product.DiscountOff = Products[i].FindElement(DiscountPercents).Text;
                        }
                        stale = false;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        stale = true;
                    }
                }
                ProductList.Add(product);
                }
        }

        public List<Product> GetProductList()
        {
            return ProductList;
        }
        public void ClickBuyNowBtn()
        {
            try { BuyNowBtn.Click(); }
            catch (ElementClickInterceptedException) { JSClick(BuyNowBtn); }
        }
        internal void ClickEnterNow() => EnterNowBtn.Click();

        internal void ClickCategoryOfLSP(string categName)
        {
            CategoryNameString = categName;
            CategoryOfLSP.Click();
        }
        internal void ClickSubCategoryOfLSP(string subCategName)
        {
            SubCategoryNameString = subCategName;
            SubCategoryOfLSP.Click();
        }
        internal void ClickPrizeTitleLSP(string titleName)
        {
            TitleString = titleName;
            try { PrizeTitle.Click(); }
            catch (ElementClickInterceptedException) { JSClick(PrizeTitle); }
        }
    }
}
