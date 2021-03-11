using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.Drivers;
using SpecFlowDreanLotteryHome.utils;
using System;

namespace SpecFlowDreanLotteryHome.Steps
{
    public class BaseStepDefinition : LoggerContainer {
        protected static IWebDriver WebDriver = SingletonDriver.GetInstance();
        public WebDriverWait Waiter { get; }

        protected static string MainUserPageURL =
            //""
            "http://localhost:8000"
            
            ;
        public static string LOGIN_USER_VAL = MainUserPageURL + "/sign-in";


        protected static string MainAdminPageURL =
            //""
            //"http://localhost:3000/"
            "https://admin-staging.rafflehouse.com"
            ;


        public static string DREAM_HOME_VAL = MainAdminPageURL + "/#/dreamHome";
        public static string LIFE_STYLEPRIZES_VAL = MainAdminPageURL + "/#/prizes";
        public static string FIXED_ODDS_VAL = MainAdminPageURL + "/#/fixedOdds";
        public static string LOGIN_ADMiN_VAL = MainAdminPageURL + "/#/login";
        public static string WINNERS_ADM_VAL = MainAdminPageURL + "/#/winners";
        public BaseStepDefinition() { Waiter = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(6_000)); }
        
     }
}
