using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class LifeStylePrizesPage : BasePage
    {
        public LifeStylePrizesPage(IWebDriver webDriver) : base(webDriver) { }

        string MainNonHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\watch_xiaomi.png");


        private IWebElement PrizeManagementHref => WebDriver.FindElement(By.XPath("//span[text()='Prize Management']"));
        private IWebElement LifeStylePrizesLink => WebDriver.FindElement(By.CssSelector("a[title='Lifestyle Prizes']"));
        private IWebElement DiscountTicketsTab => WebDriver.FindElement(By.XPath("//span[text()='Discount & tickets']"));
        private IWebElement CategoryChooser => WebDriver.FindElement(By.Id("prizeCategory"));
        private IWebElement Title => WebDriver.FindElement(By.Id("title"));

        private IWebElement GeneralPicInput => WebDriver.FindElement(By.CssSelector("input.dropzone-input"));


        public void InputGeneralPictureInput() => GeneralPicInput.SendKeys(MainNonHomePicPath);

        public void ClickLifeStylePrizes() {
            PrizeManagementHref.Click();
            LifeStylePrizesLink.Click();
        }

        internal void ChooseCategory(string p0)
        {          
           CategoryChooser.Click();
           WebDriver.FindElement(By.XPath("//li/span[text()='" + p0 + "']")).Click();          
        }

        internal void InputTitle(string p0)
        {
            Title.SendKeys(p0);
        }

        internal void GoToDiscountTicketTab() =>  DiscountTicketsTab.Click();

        internal void UploadMainNonHomePicture()
        {
            throw new NotImplementedException();
        }
    }
}
