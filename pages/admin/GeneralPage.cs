﻿using OpenQA.Selenium;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class GeneralPage : BasePage
    {


        public GeneralPage(IWebDriver webDriver) : base(webDriver) { }
        //click on Setting(on menu page) then if childs exist
        private IWebElement GeneralHrefReliable => WebDriver.FindElement(By.CssSelector("a[href='#/general']"));
        private IList<IWebElement> SettingsList => WebDriver.FindElements(By.CssSelector(".MuiCollapse-container a[href='#/general']"));
        private IWebElement SettingLiFirstChild => WebDriver.FindElement(By.CssSelector("div.menu-wrap li:last-of-type"));
        private IWebElement DiscountTab => WebDriver.FindElement(By.CssSelector("ul div:nth-of-type(1)>div.tabWrapper>div"));
        private IWebElement CreditTab => WebDriver.FindElement(By.CssSelector("ul div:nth-of-type(2)>div.tabWrapper>div"));
        private IWebElement Documentations => WebDriver.FindElement(By.CssSelector("ul div:nth-of-type(3)>div.tabWrapper>div"));
        private IList<IWebElement> CurrencyInputs => WebDriver.FindElements(By.CssSelector("input[name='count']"));
        private IList<IWebElement> PercentInputs => WebDriver.FindElements(By.CssSelector("input[name='percent']"));
        private IList<IWebElement> ResultPFromInput => WebDriver.FindElements(By.CssSelector("p.MuiTypography-root:last-child"));

        public void ClickDiscountTab() => DiscountTab.Click();
        public void ClickCreditTab() => CreditTab.Click();
        public void ClickDocumentations() => Documentations.Click();
        
        public Dictionary<int, int> GetCredits()
        {
            Dictionary<int, int> credits = new Dictionary<int, int>();
            for(int i = 0; i < CurrencyInputs.Count; i++)
            {
                credits.Add(int.Parse(CurrencyInputs[i].GetAttribute("value")), int.Parse(PercentInputs[i].GetAttribute("value")));
            }
            return credits;
        }
        public List<double> GetEuroPerCredit()
        {
            List<double> creditsPerEuro = new List<double>();
            for (int i = 0; i < ResultPFromInput.Count; i++)
            {
                creditsPerEuro.Add(double.Parse(ResultPFromInput[i].Text.Split(" ")[2]));
            }
            return creditsPerEuro;
        }
        public void GoToGeneral()
        {
            //SettingLiFirstChild.Click();
            if (SettingsList.Count == 0)
            {
                SettingLiFirstChild.Click();
            }
            GeneralHrefReliable.Click();
        }
    }
}
