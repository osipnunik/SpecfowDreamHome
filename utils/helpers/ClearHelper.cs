using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.utils.helpers
{
    class ClearHelper
    {
        private string ControlA = Keys.Control + "a";
        private string Del = Keys.Delete;

        public void ClearInput(IWebElement el)
        {
            el.SendKeys(ControlA);
            el.SendKeys(Del);
        }
    }
}
