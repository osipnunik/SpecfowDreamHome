using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class RegisterUserPage : BasePage
    {
        public RegisterUserPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement SignupFromHeader => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href = '/sign-up']")));//("a[href = '/sign-up']"));
        private IWebElement SignInHereHref => WebDriver.FindElement(By.CssSelector("div.signInHere a"));
        private By SignUpHeaderBy = By.CssSelector("div.loginGroupSignUp h3");
        private IWebElement AccountBtn => WebDriver.FindElement(By.CssSelector("button.dropdownAccount"));
        private IWebElement LogoutBtn => WebDriver.FindElement(By.CssSelector("ul li:nth-child(2) a"));
        private IWebElement SignUpHeader => WebDriver.FindElement(SignUpHeaderBy);

        private IWebElement FirstNameInput => WebDriver.FindElement(By.CssSelector("input[name='name']"));
        private IWebElement LastNameInput => WebDriver.FindElement(By.CssSelector("input[name='surname']"));
        private IWebElement PhoneNumberInput => WebDriver.FindElement(By.CssSelector("input[name='phone']"));
        private IWebElement EmailInput => WebDriver.FindElement(By.CssSelector("input[name='email']"));
        private IWebElement CountryInput => WebDriver.FindElement(By.CssSelector("input[name='country']"));
        private IWebElement CountryChooser => WebDriver.FindElement(By.Id("demo-simple-select-outlined"));
        int CuntryNumber;        
        private IWebElement RandomCantry => WebDriver.FindElement(By.CssSelector("div.MuiPopover-paper>ul>li:nth-child(" + CuntryNumber+ ")"));        
        private IWebElement PasswordInput => WebDriver.FindElement(By.CssSelector("input[name='password']"));
        private IWebElement SignUpBtn => WebDriver.FindElement(By.XPath("//button[text()='Sign up']"));
        private IWebElement AgeCheckbox => WebDriver.FindElement(By.Id("ageCheck"));
        private IWebElement SecondAgeCheckbox => WebDriver.FindElement(By.XPath("(//div[@class='mainModalBtnGroup']//input)[1]"));
        private IWebElement IAgreeSignUp => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.mainModalBtnGroup button")));
        private By LoggedNameBy => By.CssSelector("button[aria-controls='simple-menu'] div.header-drop-name span");
        private IWebElement LogedName => WebDriver.FindElement(LoggedNameBy);
        private IWebElement EighteenCheckbox => WebDriver.FindElement(By.XPath("//p[text()='I am 18 years or older']/../..//input"));
        private IWebElement LastElement => WebDriver.FindElement(By.CssSelector("div.mainModalWrap>p:last-of-type"));
        public string GetLoggedName()
        {
            //Console.WriteLine(WebDriver.FindElement(By.CssSelector("div.header-drop-name")).Text);
            //Waiter.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.headerAuth div.header-drop-name"), "Hello, "));
            //Waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("div.header-drop-name")));
            string text = LogedName.Text;
            return text;
            /*else
            {
                return GetLoggedName();
            }*/
        }
        public void WaitLoggedNameIsVisible()
        {
            Waiter.Until(ExpectedConditions.ElementIsVisible(LoggedNameBy));
        }

        internal void ClickOnCountryChooser() => CountryChooser.Click(); //CountryChooser.Click();

        internal void ClickAccountButton() => AccountBtn.Click();

        internal void ClickLogoutBtn() => LogoutBtn.Click();

        public string GetLoggedName(string nameSurname)
        {           
            Waiter.Until(ExpectedConditions.TextToBePresentInElement(LogedName, nameSurname));
            string text = LogedName.Text;
             return text; 
            /*else
            {
                return GetLoggedName();
            }*/
            
        }

        internal void ClickOnRandomCuntry()
        {
            CuntryNumber = new Random().Next(151);
            JSClick(RandomCantry);
        }

        public void ClickSignupFromHeader() => SignupFromHeader.Click();
        public void ClickSignInHereHref() => SignInHereHref.Click();
        public void ClickSignUpBtn() => SignUpBtn.Click();
        public void ClickAgeCheckbox() => AgeCheckbox.Click();
        public void ClickIAgree()
        {
            //Waiter.Until(ExpectedConditions.ElementExists(IAgree));
            IAgreeSignUp.Click();
        }

        internal void Ckeckbox18First()
        {
            try{ EighteenCheckbox.Click(); }
            catch (ElementClickInterceptedException) { JSClick(EighteenCheckbox); };
        }
        internal void ClickSecondAgeCheckbox() => JSClick(SecondAgeCheckbox);//SecondAgeCheckbox.Click();

        public void InputFirstNameInput(string inp) => FirstNameInput.SendKeys(inp);
        public void InputLastNameInput(string inp) => LastNameInput.SendKeys(inp);
        public void InputPhoneNumberInput(string inp) => PhoneNumberInput.SendKeys(inp);
        public void InputEmailInput(string inp) => EmailInput.SendKeys(inp);
        public void InputCountryInput(string inp) => CountryInput.SendKeys(inp);//needed precise country list
        public void InputPasswordInput(string inp) => PasswordInput.SendKeys(inp);

        internal void WaitWhileSignUpHeaderAppeare()
        {
            Waiter.Until(ExpectedConditions.ElementIsVisible(SignUpHeaderBy));
        }
        public void ScrollUntillIAgreeIsActive()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            //js.ExecuteScript("arguments[0].setAttribute('style', arguments[1])");
            //js.ExecuteScript("arguments[0].setAttribute('class', arguments[1])", WebDriver.FindElement(By.XPath("//input[@type='file']/../../div[2]")), "a");           
            ScrollToBottomOfElement(LastElement);
           /* Actions actions = new Actions(WebDriver);
            actions.MoveToElement(lastElement);
            actions.Perform();*/
        }
    }
}
