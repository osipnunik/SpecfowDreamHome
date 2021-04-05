using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages
{
     class BasePage : LoggerContainer
    {
        public IWebDriver WebDriver { get;}
        public WebDriverWait Waiter { get; }
        //private WebDriverWait FrequentWebDriverWait;

        /*protected IWebElement SuccessPopup => WebDriver.FindElement(By.Id("client-snackbar"));
        public string GetPopupText() => SuccessPopup.Text;*/
        protected By PopupBy => By.CssSelector("div.MuiSnackbarContent-message");
        protected By RefreshBy = By.CssSelector("button[title='Refresh']");
        protected IWebElement Popup => Waiter.Until(ExpectedConditions.ElementExists(PopupBy));
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
        public void ScrollToTop()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("window.scrollTo(0,0);");
        }
        public void ScrollAllElementOnFixedOdds(IWebElement el)
        {
            string s = "let i = 0;while(true){let lastTitleCss='.lifestyleProduct-mob:last-child .productTitle p'; let firstT = document.querySelector(lastTitleCss).innerText; document.querySelector(lastTitleCss).scrollIntoView();await new Promise(resolve => setTimeout(resolve, 1000));if (document.querySelector(lastTitleCss).innerHTML == (firstT)){ i++;if(i >= 3){break;}}else{i = 0;}}";

            //string s = "let i = 0;while(true){let firstT = arguments[0].innerText; arguments[0].scrollIntoView();await new Promise(resolve => setTimeout(resolve, 800));if (arguments[0].innerHTML == (firstT)){ i++;if (i >= 4) { break; }}}";
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;

            try { jse.ExecuteAsyncScript(s); }
            catch(WebDriverTimeoutException) { }
            Thread.Sleep(1000);
        }
        public void ScrollToElement(IWebElement el)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
            jse.ExecuteScript("arguments[0].scrollIntoView();", el);
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
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            Waiter = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(8_000));

            //FrequentWebDriverWait = new WebDriverWait(, WebDriver, TimeSpan.FromMilliseconds(6_000), TimeSpan.FromMilliseconds(500))
        }
    }
}
