using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class LoginUserPage : BasePage
    {

        public LoginUserPage(IWebDriver webDriver) : base(webDriver) { }
        
        private IWebElement Login => WebDriver.FindElement(By.Name("email"));
        private IWebElement Password => WebDriver.FindElement(By.Name("password"));
        private IWebElement SignInBtn => WebDriver.FindElement(By.CssSelector(".loginGroupSignIn button.rafflebtn"));

        public void InputLogin(string login) => Login.SendKeys(login);
        public void InputPass(string pass) => Password.SendKeys(pass);
        public void ClickSignIn() => SignInBtn.Click();
    }
}
