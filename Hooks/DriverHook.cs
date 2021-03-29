using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDreanLotteryHome.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Hooks
{
    [Binding]
    class DriverHook
    {
        [BeforeScenario]
        public static void initializeDriver(){ }

        [AfterScenario]
        public static void After()
        {
            // SingletonDriver.GetInstance().Manage().Cookies.DeleteAllCookies();
            //SingletonDriver.GetInstance().Navigate().Refresh();
            //Thread.Sleep(2);
        }
        /*[AfterTestRun]
        public static void Quete()
        {
           SingletonDriver.GetInstance().Quit();
        }*/
        //[AfterStep]
        public void Step()
        {
            Thread.Sleep(1000);
        }
        
    }
}
