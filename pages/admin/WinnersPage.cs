using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class WinnersPage : BasePage
    {
        private string MainHomePicPath = PathGiver.GetPicturePath() + "main_pic.png";
        public static PaginationFragment Paginats;

        public WinnersPage(IWebDriver webDriver) : base(webDriver) {
            Paginats = new PaginationFragment(webDriver);
        }

        private IWebElement SettingsHref => WebDriver.FindElement(By.CssSelector(".menu-wrap>li:nth-of-type(2)"));
        private IWebElement WinnersHref => WebDriver.FindElement(By.CssSelector("a[href='#/winners']"));
        private IWebElement DeleteIcon4 => WebDriver.FindElement(By.CssSelector("tbody:nth-child(5) div svg.delete-icon"));
        private IWebElement Addnew => WebDriver.FindElement(By.CssSelector("a[aria-label = 'Add new ']"));
        private IWebElement ProductChooser => WebDriver.FindElement(By.Id("search-input"));//By.Id("search-input"));

        //private IWebElement CompetitionSharpHeaderDownSort => WebDriver.FindElement(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:last-child"));
        //private IWebElement CompetitionSharpHeaderUpSort => WebDriver.FindElement(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:first-child"));
        //private IWebElement CompetitionHeader => WebDriver.FindElement(By.CssSelector("th:nth-child(2) span.column-title"));
        //private IWebElement CompetitionHeaderDownSort => WebDriver.FindElement(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:last-child"));
        //private IWebElement CompetitionHeaderUpSort => WebDriver.FindElement(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:first-child"));
        private IWebElement FinishDate => WebDriver.FindElement(By.CssSelector("th:nth-child(1) span.column-title"));
        private IWebElement FinishDateHeaderDownSort => WebDriver.FindElement(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:last-child"));
        private IWebElement FinishDateHeaderUpSort => WebDriver.FindElement(By.CssSelector("th:nth-child(1) div.arrow-wrapper svg:first-child"));
        private IWebElement Title => WebDriver.FindElement(By.CssSelector("th:nth-child(2) span.column-title"));
        private IWebElement TitleHeaderDownSort => WebDriver.FindElement(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:last-child"));
        private IWebElement TitleHeaderUpSort => WebDriver.FindElement(By.CssSelector("th:nth-child(2) div.arrow-wrapper svg:first-child"));

        private IWebElement ActionsHeader => WebDriver.FindElement(By.CssSelector("th:nth-child(3)"));

        //private IList<IWebElement> CompetitionShartData => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(1)"));
        //private IList<IWebElement> CompetitionData => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(2)"));
        private IList<IWebElement> FinishDateData => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(1)"));
        private IList<IWebElement> TitleData => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-child(2)"));
        string TitleText;
        private IWebElement DeleteTitle => WebDriver.FindElement(By.XPath("//tbody/tr/td[text()='"+TitleText+"']/following-sibling::td//*[@class='MuiSvgIcon-root delete-icon']"));
        private IWebElement ApproveRemove => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.user-remove-button span")));
        private By PopupTitle => By.TagName("h4");
        string ColumnName;
        private IWebElement Header => WebDriver.FindElement(By.XPath("//thead/tr//*[text()='" + ColumnName + "']"));

        private IWebElement Description => WebDriver.FindElement(By.XPath("//span[text()='Description']"));
        private IWebElement InputDescrTitle => WebDriver.FindElement(By.Id("name"));

        private IWebElement PictureToUploadAria => WebDriver.FindElement(By.CssSelector("div[data-testid='dropzone']"));//(By.Id("photoUrl"));
        private IWebElement InputPicture => WebDriver.FindElement(By.Id("photoUrl"));//(By.Id("photoUrl"));
        private IWebElement DrawDateInput => WebDriver.FindElement(By.Id("drawDate"));
        //private IWebElement DrawDateInput => WebDriver.FindElement(By.Id("drawDate"));
        private IWebElement SaveBtn => WebDriver.FindElement(By.XPath("//button/span[text()='Save']"));

        internal void ClickWinners() => WinnersHref.Click();
        internal void ClickSettings() => SettingsHref.Click();

        internal bool IsColumnHeaderVisible(string colName)
        {
            ColumnName = colName;
            return Header.Displayed;
        }

        public void ClickAddNew() => Addnew.Click();
        //public void ClickCompetitionSharpHeaderDownSort() => CompetitionSharpHeaderDownSort.Click();
        //public void ClickCompetitionHeaderDownSort() => CompetitionHeaderDownSort.Click();
        public void ClickFinishDateHeaderDownSort() => FinishDateHeaderDownSort.Click();
        public void ClickTitleHeaderDownSort() => TitleHeaderDownSort.Click();

        //public void ClickCompetitionSharpHeaderUpSort() => CompetitionSharpHeaderUpSort.Click();
        //public void ClickCompetitionHeaderUpSort() => CompetitionHeaderUpSort.Click();
        public void ClickFinishDateHeaderUpSort() => FinishDateHeaderUpSort.Click();
        public void ClickTitleHeaderUpSort() => TitleHeaderUpSort.Click();

        public static int WinnerSize = 0;

        public int GetSizeOfWinnersTable()
        {
            if (WinnerSize > 0)
            {
                return WinnerSize;
            }
            else
            {
                WinnerSize = TitleData.Count;
            }
            return WinnerSize;
        }

       /* public List<string> GetCompetitionShartData()
        {
            List<string> data = new List<string>();
            foreach(var el in CompetitionShartData)
            {
                data.Add(el.Text);
            }
            return data;
        }*/
        /*public List<string> GetCompetitionData()
        {
            List<string> data = new List<string>();
            foreach (var el in CompetitionData)
            {
                data.Add(el.Text);
            }
            return data;
        }*/
        public List<string> GetFinishDateData()
        {
            List<string> data = new List<string>();
            foreach (var el in FinishDateData)
            {
                Log.Info(el.Text);
                data.Add(el.Text);
            }
            return data;
        }
        public List<string> GetTitleData()
        {
            List<string> data = new List<string>();
            try
            {
                foreach (var el in TitleData)
                {
                    data.Add(el.Text);
                }
            }catch(StaleElementReferenceException e)
            {
                return GetTitleData();
            }

            return data;
        }
        public void instertPic()
        {            
            InputPicture.SendKeys(MainHomePicPath);        
        }

        internal void InputDateTime()
        {
            DrawDateInput.SendKeys("06052020"+ Keys.ArrowRight+ "1051");
            //DrawDateInput.SendKeys(Keys.ArrowRight+ Keys.ArrowLeft+ Keys.ArrowLeft);
           // DrawDateInput.SendKeys("1051");
        }

        internal void ClickDescription()
        {
            Description.Click();
        }

        internal void InputDescriptTitle(string p0)
        {
            InputDescrTitle.SendKeys(p0);
        }

        internal void ChooseProduct(string p0)
        {
            ProductChooser.Click();
            WebDriver.FindElement(By.XPath("//li[text()='" + p0 + "']")).Click();
        }

        internal void ClickSave() => SaveBtn.Click();

        public PaginationFragment GetPaginationF()
        {
            return Paginats;
        }

        internal void DeleteWinnersWithTitle(string title)
        {
            TitleText = title;
            DeleteTitle.Click();
            ApproveRemove.Click();
            Waiter.Until(ExpectedConditions.InvisibilityOfElementWithText(PopupTitle, "Are you sure you want to remove winner?"));
        }
    }
}
