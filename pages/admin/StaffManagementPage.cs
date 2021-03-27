using OpenQA.Selenium;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class StaffManagementPage : BasePage
    {
        public static PaginationFragment Paginats;

        public StaffManagementPage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private IWebElement StaffManagementHref => WebDriver.FindElement(By.CssSelector("a[title='Staff management']"));
        private IWebElement FirstNameInput => WebDriver.FindElement(By.Id("name"));
        private IWebElement LastNameInput => WebDriver.FindElement(By.Id("surname"));
        private IWebElement EmailInput => WebDriver.FindElement(By.Id("email"));
        private IWebElement SkypeInput => WebDriver.FindElement(By.Id("skype"));
        private IWebElement SaveStaffBtn => WebDriver.FindElement(By.CssSelector("button.save-button[type='submit']"));

        internal void ClickStraffMenegementHref() => StaffManagementHref.Click();

        internal void ScrollStraffMenegementHref() => ScrollToElement(StaffManagementHref);

        private IList<IWebElement> StaffUserCells => WebDriver.FindElements(By.CssSelector("tbody:last-child tr td"));

        public void InputFirstName(string input) => FirstNameInput.SendKeys(input);
        public void InputLastName(string input) => LastNameInput.SendKeys(input);
        public void InputEmail(string input) => EmailInput.SendKeys(input);
        public void InputSkype(string input) => SkypeInput.SendKeys(input);

        public User GetUser()
        {
            User user = new User();
            user.FirstName = StaffUserCells[0].Text;
            user.LastName = StaffUserCells[1].Text;
            user.Email = StaffUserCells[2].Text;
            user.Role = StaffUserCells[3].Text;
            return user;
        }

        internal void ClickSaveStaff() => SaveStaffBtn.Click();

        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
