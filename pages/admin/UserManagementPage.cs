﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.entities;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class UserManagementPage : BasePage
    {
        public static PaginationFragment Paginats;

        
        public UserManagementPage(IWebDriver webDriver) : base(webDriver) {
            Paginats = new PaginationFragment(webDriver);
        }

        private IWebElement UserManagementHref => Waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='User management']")));
        private IWebElement FirstNameInput => WebDriver.FindElement(By.Name("name"));
        private IWebElement LastNameInput => WebDriver.FindElement(By.Name("surname"));
        private IWebElement EmailInput => WebDriver.FindElement(By.Name("email"));
        private IWebElement PhoneInput => WebDriver.FindElement(By.Name("phone"));
        private IWebElement CountryChooser => WebDriver.FindElement(By.Id("search-input"));
        private IList<IWebElement> UserCells => WebDriver.FindElements(By.CssSelector("tbody:last-child tr td"));
        private IList<IWebElement> TicketOrderCells => WebDriver.FindElements(By.CssSelector("tbody:last-child td"));
        private IWebElement DeleteOfLastUser => WebDriver.FindElement(By.CssSelector("tbody:last-child tr td:last-child svg.delete-icon"));
        private IWebElement EditLastTicketUserIcon => WebDriver.FindElement(By.CssSelector("table tbody:last-child td:nth-child(5) #show-tickets:nth-child(2)"));
        private IWebElement EditLastUserIcon => WebDriver.FindElement(By.CssSelector("tbody:last-child div.actions-table-body a[aria-label='Edit']"));
        private IWebElement ApproveRemove => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.user-remove-button span")));
        private By PopupTitle => By.TagName("h4");

        private IWebElement TicketsTab => WebDriver.FindElement(By.XPath("//span[text()='Tickets']"));
        private IWebElement AddTicketBtn => WebDriver.FindElement(By.XPath("//button/span[text()='Add Ticket']"));
        private IWebElement TicketTitle => WebDriver.FindElement(By.XPath("//h6[text()='Add tickets']"));
        private IWebElement TicketCompetitionInput => WebDriver.FindElement(By.CssSelector("input[name='competition']"));
        private IWebElement TicketProductInput => WebDriver.FindElement(By.CssSelector("input[name='product']"));
        private IWebElement TicketNumberInput => WebDriver.FindElement(By.CssSelector("div.add-tickets-field input[type='number']"));
        private IWebElement SaveBtn => WebDriver.FindElement(By.XPath("//div[@class='MuiDialogContent-root']//button/span[text()='Save']"));
        private IWebElement RemoveInDialog => WebDriver.FindElement(By.CssSelector("div[role='dialog'] div.actions-table-body svg"));

        public void ClickUserManagementHref() => UserManagementHref.Click();

        internal void InputFirstName(string firstName) => FirstNameInput.SendKeys(firstName);

        internal void InputLastName(string lastName) => LastNameInput.SendKeys(lastName);

        internal void InputEmail(string email) => EmailInput.SendKeys(email);

        internal void InputPhone(string phone) => PhoneInput.SendKeys(phone);

        internal void ChooseCountry(string country) { 
            CountryChooser.Click();
            var li = WebDriver.FindElement(By.CssSelector("li[data-value='" + country + "']"));
            JSClick(li);
            //li.Click();
        }

        internal User GetLastUser()
        {
            User us = new User();
            us.FirstName = UserCells[0].Text;
            us.LastName = UserCells[1].Text;
            us.Email = UserCells[2].Text;
            us.Phone = UserCells[3].Text;
            return us;
        }

        public PaginationFragment GetPaginationFragment()
        {
            return Paginats;
        }

        internal object GetTicketNumber()
        {
            return TicketNumberInput.GetAttribute("value");
        }

        internal void DeleteLastUser()
        {
            DeleteOfLastUser.Click();
            ApproveRemove.Click();
            Waiter.Until(ExpectedConditions.InvisibilityOfElementWithText(PopupTitle, "Are you sure you want to remove user account?"));
        }
        

        internal void ClickTicketsTab() => TicketsTab.Click();

        internal void ClickEditLastTicket() => EditLastTicketUserIcon.Click();

        internal void ClickSaveBtn() => SaveBtn.Click();

        internal TicketOrder GetLastTicket()
        {
            TicketOrder ticketOrder = new TicketOrder();
            ticketOrder.Competiotion = TicketOrderCells[0].Text;
            ticketOrder.Product = TicketOrderCells[1].Text;
            ticketOrder.NumberOfTicket = TicketOrderCells[2].Text;
            ticketOrder.DrawDate = TicketOrderCells[3].Text;
            return ticketOrder;
        }

        internal void ClickRemoveTickInEditTiket()
        {
            RemoveInDialog.Click();
            ApproveRemove.Click();
            Waiter.Until(ExpectedConditions.InvisibilityOfElementWithText(PopupTitle, "Are you sure you want to remove ticket?"));
        }

        internal void ClickAddTicket() => AddTicketBtn.Click();

        internal string GetTicketTitleText()
        {
            return TicketTitle.Text;
        }

        internal void ClickEditLastUser() => EditLastUserIcon.Click();

        internal string GetTicketCompetition()
        {
            string val = TicketCompetitionInput.GetAttribute("value");
            if (val.Length == 0)
            {
                return GetTicketCompetition();
            }
            return val;
        }

        internal string GetTicketProduct()
        {
            return TicketProductInput.GetAttribute("value");
        }

    }
}
