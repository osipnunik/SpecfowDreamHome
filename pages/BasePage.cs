using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages
{
     class BasePage : LoggerContainer
    {
        public IWebDriver WebDriver { get;}
        public WebDriverWait Waiter { get; }

        /*protected IWebElement SuccessPopup => WebDriver.FindElement(By.Id("client-snackbar"));
        public string GetPopupText() => SuccessPopup.Text;*/
        protected By PopupBy => By.CssSelector("div.MuiSnackbarContent-message");
        protected IWebElement Popup => WebDriver.FindElement(PopupBy);
        public string GetPopupText()
        {
           if(Popup.Text.Length == 0)
            {
                return GetPopupText();
            }else return Popup.Text;
        }

        private IWebElement AddPrize => WebDriver.FindElement(By.CssSelector("a.add-button"));
        public void ClickAddPrize() => AddPrize.Click();

        private IWebElement Addnew => WebDriver.FindElement(By.CssSelector("a[aria-label = 'Add new ']"));
        public void ClickAddNew() => Addnew.Click();

        private IWebElement SaveBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(1)"));
        public void ClickSave() => SaveBtn.Click();

        public void ScrollDown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("scroll(0, 800)"); // if the element is on top.                       
        }
        public void ScrollToBottomOfElement(IWebElement el)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", el);
        }
        public void JSClick(IWebElement el)
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click();", el);//scrollIntoView()
        }
        public BasePage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            Waiter = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(6_000));
        }
    }
}
