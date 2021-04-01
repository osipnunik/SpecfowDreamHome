using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.Drivers
{
    class SingletonDriver : LoggerContainer
    {
        private static IWebDriver Driver;
        private PathGiver PathGiver = new PathGiver();

        private SingletonDriver()
        { }
        public static void Init()
        {
            //var option = new ChromeOptions();
            //option.AddArguments("--headless");  
            //option.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"bin/debug");
            Driver = new ChromeDriver(PathGiver.GetProjectPath());/*"C:\\Users\\PC\\source\\repos\\SpecFlowDreanLotteryHome\\SpecFlowDreanLotteryHome"*/
            //Driver = new FirefoxDriver(PathGiver.GetProjectPath());
            /*string geckoDriverDirectory = PathGiver.GetProjectPath();
            FirefoxDriverService geckoService =
            FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true;
            Driver = new FirefoxDriver(geckoService, firefoxOptions);*/

            Driver.Manage().Window.Maximize();
            Log.Info("initialized new ChromeDriver");

        }
        public static IWebDriver GetInstance()
        {
            if (Driver == null) { Init(); }
            return Driver;
        }
       
    }
}
