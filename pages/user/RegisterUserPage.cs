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

        private IWebElement SignupFromHeader => WebDriver.FindElement(By.CssSelector("a.btnSignUpHeader"));
        private IWebElement SignInHereHref => WebDriver.FindElement(By.CssSelector("div.signInHere a"));
        private By SignUpHeaderBy = By.CssSelector("div.loginGroupSignUp h3");
        private IWebElement SignUpHeader => WebDriver.FindElement(SignUpHeaderBy);

        private IWebElement FirstNameInput => WebDriver.FindElement(By.CssSelector("input[name='name']"));
        private IWebElement LastNameInput => WebDriver.FindElement(By.CssSelector("input[name='surname']"));
        private IWebElement PhoneNumberInput => WebDriver.FindElement(By.CssSelector("input[name='phone']"));
        private IWebElement EmailInput => WebDriver.FindElement(By.CssSelector("input[name='email']"));
        private IWebElement CountryInput => WebDriver.FindElement(By.CssSelector("input[name='country']"));
        private IWebElement PasswordInput => WebDriver.FindElement(By.CssSelector("input[name='password']"));
        private IWebElement SignUpBtn => WebDriver.FindElement(By.CssSelector("button.signUpBtnUp"));
        private IWebElement AgeCheckbox => WebDriver.FindElement(By.Id("ageCheck"));
        private IWebElement IAgree => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.yellow-btn-round")));
        private IWebElement LogedName => WebDriver.FindElement(By.CssSelector("button[aria-controls='simple-menu'] div.header-drop-name span"));
        private IWebElement EighteenCheckbox => WebDriver.FindElement(By.XPath("//p[text()='I am 18 years or older']/../..//input"));

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
        public void ClickSignupFromHeader() => SignupFromHeader.Click();
        public void ClickSignInHereHref() => SignInHereHref.Click();
        public void ClickSignUpBtn() => SignUpBtn.Click();
        public void ClickAgeCheckbox() => AgeCheckbox.Click();
        public void ClickIAgree()
        {
            //Waiter.Until(ExpectedConditions.ElementExists(IAgree));
            IAgree.Click();
        }

        internal void Ckeckbox18First()
        {
            EighteenCheckbox.Click();
        }

        public void InputFirstNameInput(string inp) => FirstNameInput.SendKeys(inp);
        public void InputLastNameInput(string inp) => LastNameInput.SendKeys(inp);
        public void InputPhoneNumberInput(string inp) => PhoneNumberInput.SendKeys(inp);
        public void InputEmailInput(string inp) => EmailInput.SendKeys(inp);
        public void InputCountryInput(string inp) => CountryInput.SendKeys(inp);
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
            var lastElement = WebDriver.FindElement(By.CssSelector("body div > p:nth-child(128)"));
            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(lastElement);
            actions.Perform();
        }
    }
}
