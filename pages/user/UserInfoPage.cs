using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.user
{
    class UserInfoPage : BasePage
    {
        public UserInfoPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement FirstName => WebDriver.FindElement(By.CssSelector("input[name='name']"));
        private IWebElement LastName => WebDriver.FindElement(By.CssSelector("input[name='surname']"));
        private IWebElement Email => WebDriver.FindElement(By.CssSelector("input[name='email']"));
        private IWebElement Phone => WebDriver.FindElement(By.CssSelector("input[name='phone']"));
        private string valAtr = "value";
        public string GetFirstName() => FirstName.GetAttribute(valAtr);
        public string GetLastName() => LastName.GetAttribute(valAtr);
        public string GetEmail() => Email.GetAttribute(valAtr);
        public string GetPhone() => Phone.GetAttribute(valAtr);

    }
}
