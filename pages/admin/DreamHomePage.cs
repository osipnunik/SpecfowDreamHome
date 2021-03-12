using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class DreamHomePage : BasePage
    {
        public DreamHomePage(IWebDriver webDriver) : base(webDriver) { }

        string MainHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\main_pic.png");
        string BadroomHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\badroom_pic.png");
        string BathroomHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\bathroom_pic.jpg");
        string OutspaceHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\outspace_pic.jpg");
        string FloorPlanHomePicPath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\floor_plan_pic.png");


        private IList<IWebElement> Titles => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-of-type(1)"));
        private IWebElement CheckboxOfActiveOne => WebDriver.FindElement(By.XPath("(//table)[1]/tbody/tr//label"));
        string TitleNeedBeActive;
        private IWebElement CheckOfDrHomeWithTitle => WebDriver.FindElement(By.XPath("(//table)[2]/tbody/tr/td[text()='"+ TitleNeedBeActive + "']/..//label/span"));
        private IList<IWebElement> noActiveMessages => WebDriver.FindElements(By.CssSelector("div.no-active h6"));

        private IWebElement dreamHome => WebDriver.FindElement(By.CssSelector("a[title='Dream home']"));

        private IWebElement addDreamHome => WebDriver.FindElement(By.CssSelector("a.add-button"));

        private IWebElement title => WebDriver.FindElement(By.Id("name"));

        private IWebElement address => WebDriver.FindElement(By.CssSelector("div.MuiInput-formControl input"));

        private IWebElement ampmChooser1 => WebDriver.FindElement(By.CssSelector("select.react-datetime-picker__inputGroup__input"));

        //"button.react-datetime-picker__calendar-button")//"input[name='year']:nth-child(1)")
        private IWebElement dataTimePicker1 => WebDriver.FindElement(By.CssSelector("input[name='day']"));

        private IWebElement dataTimePicker2 => WebDriver.FindElement(By.XPath("(//input[@name='day'])[2]"));
        private IWebElement AmPm2 => WebDriver.FindElement(By.Name("amPm"));

        private IWebElement nextMonthArrow => WebDriver.FindElement(By.CssSelector("button.react-calendar__navigation__next-button"));

        private IWebElement nextMonthArrowSecond => WebDriver.FindElement(By.XPath("(//button[text()='›'])[2]"));

        private IWebElement nextYearBtn => WebDriver.FindElement(By.CssSelector("button.react-calendar__navigation__next2-button"));

        private IWebElement firstDateCell => WebDriver.FindElement(By.CssSelector("button abbr"));

        private IWebElement fifthDateCellFinishCalendar => WebDriver.FindElement(By.CssSelector("(//abbr[@aria-label='5 мая 2021 г.'])[1]"));

        private IWebElement isTrandingToggle => WebDriver.FindElement(By.Id("isTrending"));
        private IWebElement GeneralPicInput => WebDriver.FindElement(By.CssSelector("input.dropzone-input"));
        private IWebElement SaveBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(1)"));

        private IWebElement DescriptionTab => WebDriver.FindElement(By.XPath("//span[text()='Description']"));
        private IWebElement DiscountTicketTab => WebDriver.FindElement(By.CssSelector("a.form-tab:nth-child(3) span"));

        private IWebElement BadroomDescriptonInput => WebDriver.FindElement(By.CssSelector("div.ql-editor p"));
        private IWebElement BadroomPictureChooser => WebDriver.FindElement(By.XPath("(//div[@data-testid='dropzone'])[1]/p"));
        private IWebElement BadRoomInputPic => WebDriver.FindElement(By.Id("property.filesBedroom"));
        private IWebElement BathDescription => WebDriver.FindElement(By.CssSelector("div.text-parent:nth-of-type(2) div[data-testid='quill'] p"));
        private IWebElement BathRoomInputPic => WebDriver.FindElement(By.Id("property.filesBathroom"));
        private IWebElement OutSpaceDescription => WebDriver.FindElement(By.CssSelector("div.text-parent:nth-of-type(3) div[data-testid='quill'] p"));

        private IWebElement OutSpaceInputPic => WebDriver.FindElement(By.Id("property.filesOutspace"));
        private IWebElement AboutInput => WebDriver.FindElement(By.CssSelector("div.about-section div.ql-editor"));
        private IWebElement FloorPlanInputPic => WebDriver.FindElement(By.Id("property.filesFloorPlan"));

        private IWebElement AddLink => WebDriver.FindElement(By.Id("property.tourLink"));
        private IWebElement Tour3D => WebDriver.FindElement(By.Id("property.pixangleSource"));

        private IWebElement PriceInp => WebDriver.FindElement(By.Id("property.propertyPrice"));
        private IWebElement BadInp => WebDriver.FindElement(By.Id("property.bedroomCount"));
        private IWebElement BathInp => WebDriver.FindElement(By.Id("property.bathroomCount"));
        private IWebElement GardenInp => WebDriver.FindElement(By.Id("property.garden"));
        private IWebElement TransportInp => WebDriver.FindElement(By.Id("property.transportText"));
        private IWebElement LocationInp => WebDriver.FindElement(By.Id("property.adress"));
        private IWebElement FreeHoldInp => WebDriver.FindElement(By.Id("property.freehold"));
        private IWebElement TaxInp => WebDriver.FindElement(By.Id("property.tax"));
        private IWebElement SizeInp => WebDriver.FindElement(By.Id("property.area"));
        private IWebElement EnergyInp => WebDriver.FindElement(By.Id("property.energy"));

        private IWebElement TicketPriceInput => WebDriver.FindElement(By.Id("ticketPrice"));
        private IWebElement DefaultTicketNumberInput => WebDriver.FindElement(By.Id("defaultTickets"));
        private IWebElement DiscountFromTicket => WebDriver.FindElement(By.Id("isActiveDiscount"));
        private IWebElement PriceIs => WebDriver.FindElement(By.XPath("(//h6[text()='Tickets']/..//input)[5]"));
        private IWebElement ErrorMessage => WebDriver.FindElement(By.XPath("div.date-error"));
        private IWebElement DiscountIs => WebDriver.FindElement(By.XPath("(//h6[text()='Tickets']/..//input)[4]"));
        private IWebElement MoneyCurrency => WebDriver.FindElement(By.XPath("(//span[@class='discount-is']/..)[2]"));
        private IWebElement DiscountNewPrice => WebDriver.FindElement(By.XPath("(//h6[text()='Discount']/..//input)[5]"));
        private IWebElement CurrencyCheckbox => WebDriver.FindElement(By.Id("property.discountCategory_cash"));
        private IWebElement DiscountStatus => WebDriver.FindElement(By.Id("isDiscountRates"));

        public void InputGeneralPictureInput() => GeneralPicInput.SendKeys(MainHomePicPath);//"C:\\Users\\PC\\G.PNG")         
        
        public void InputBadRoomInputPic() => BadRoomInputPic.SendKeys(BadroomHomePicPath);
        public void InputBathRoomInputPic() => BathRoomInputPic.SendKeys(BathroomHomePicPath);
        public void InputOutSpaceInputPic() => OutSpaceInputPic.SendKeys(OutspaceHomePicPath);
        public void InputAboutInput(string inp) => AboutInput.SendKeys(inp);
        public void InputFloorPlanInputPic() => FloorPlanInputPic.SendKeys(FloorPlanHomePicPath);
        public void InputAddLink(string inp) => AddLink.SendKeys(inp);
        public void InputTour3D(string inp) => Tour3D.SendKeys(inp);
        public void InputPriceInp(string inp) => PriceInp.SendKeys(inp);
        public void InputBadInp(string inp) => BadInp.SendKeys(inp);
        public void InputBathDescription(string inp) => BathDescription.SendKeys(inp);
        public void InputOutSpaceDescription(string inp) => OutSpaceDescription.SendKeys(inp);

        internal void ClickDiscountInTicket()
        {
            DiscountFromTicket.Click();
        }

        internal void InputDiscountIs(string p0)
        {
            DiscountIs.SendKeys(Keys.Backspace); DiscountIs.SendKeys(Keys.Backspace); 
            DiscountIs.SendKeys(p0);
        }

        public void InputBathInp(string inp) => BathInp.SendKeys(inp);

        internal string GetPriceIs()
        {
            return PriceIs.GetAttribute("value");
        }

        public void InputGardenInp(string inp) => GardenInp.SendKeys(inp);

        internal void ClickDiscountStatus() => DiscountStatus.Click();

        internal void InputPriceIs(string p0)
        {
            PriceIs.SendKeys(Keys.Backspace); PriceIs.SendKeys(Keys.Backspace); PriceIs.SendKeys(Keys.Backspace);
            PriceIs.SendKeys(p0);
        }

        internal void InputPriceDiscountTab(string p0)
        {
            DiscountNewPrice.SendKeys(Keys.Backspace);DiscountNewPrice.SendKeys(Keys.Backspace);  
            DiscountNewPrice.SendKeys(p0);
        }

        internal string GetMoneyAndCurrency()
        {
            return MoneyCurrency.Text;
        }

        internal void ClickCurrencyCheckbox() => CurrencyCheckbox.Click();

        public void InputTransportInp(string inp) => TransportInp.SendKeys(inp);

        internal string GetDiscountIs()
        {
            return DiscountIs.GetAttribute("value");
        }

        internal void ClickDiscountTicketTab()
        {
            DiscountTicketTab.Click();
        }

        internal void InputDefaultNumbersOfTickets(string p0)
        {
            DefaultTicketNumberInput.SendKeys(p0);
        }

        internal bool IsNoActive()
        {
            if(noActiveMessages.Count == 1) { return true; }
            else if (noActiveMessages.Count == 0){return false;}
            else{
                throw new Exception("it is 2 such else or else");
            }
        }

        internal void InputTicketPrice(string p0)
        {
            //TicketPriceInput.Click();
            TicketPriceInput.SendKeys(p0);            
        }

        public void InputLocationInp(string inp) => LocationInp.SendKeys(inp);

        internal List<string> GetTitles()
        {
            List<string> strTitles = new List<string>();
            for(int i = 0; i < Titles.Count; i++)
            {
                strTitles.Add(Titles[i].Text);
            }
            return strTitles;
        }

        internal void SetActiveDreamHomeWithTitle(string p0)
        {
            TitleNeedBeActive = p0;
            CheckOfDrHomeWithTitle.Click();
        }

        internal void MakeActiveDreamHomeUnactive()
        {
            CheckboxOfActiveOne.Click();
        }

        public void InputFreeHoldInp(string inp) => FreeHoldInp.SendKeys(inp);
        public void InputTaxInp(string inp) => TaxInp.SendKeys(inp);
        public void InputSizeInp(string inp) => SizeInp.SendKeys(inp);
        public void InputEnergyInp(string inp) => EnergyInp.SendKeys(inp);

        public void ClickSaveBtn() => SaveBtn.Click();
        /*public void Input(string inp) => .SendKeys(inp);
        public void Input(string inp) => .SendKeys(inp);*/

        private IWebElement cancelBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(2)"));

        public void clickAddNewDreamHome() => addDreamHome.Click();
        

        public void inputTitle(String inp)
        {
            title.SendKeys(inp);
        }

        public void inputAddress(String inp)
        {
            address.SendKeys(inp);
        }

        public void clickStartDate()
        {
            /*dataTimePicker1.sendKeys(Keys.TAB);
            //Fill time as 02:45 PM
            dataTimePicker1.sendKeys("0245PM");*/
            dataTimePicker1.Click();
        }

        public void clickFinishDate() => dataTimePicker2.Click();

        public void clickNextMonth() => nextMonthArrow.Click();
        
        public void clickFirstDateCell() => firstDateCell.Click();
        
        public void clickIsTrandingToggle() => isTrandingToggle.Click();

        public void goToDescription() => DescriptionTab.Click();

        public void inputBadroomDescription(string desc)
        {
            BadroomDescriptonInput.SendKeys(desc);
        }

        public void clickDreamHome() => dreamHome.Click();

        public void clickNextMonthOnFinish() => nextMonthArrowSecond.Click();
        
        public void clickFifthDataCellFinishCalendar()
        {
            /*WebDriverWait wait = new WebDriverWait(getDriver(), 6000);
            wait.until(ExpectedConditions.presenceOfAllElementsLocatedBy(By.xpath("(//abbr[@aria-label='5 мая 2021 г.'])[1]")));
                   // (ExpectedConditions.presenceOfAllElementsLocatedBy());
            fifthDateCellFinishCalendar.click();*/
            dataTimePicker2.SendKeys("1152021120000");
            AmPm2.Click();
            WebDriver.FindElement(By.XPath("//p[text()='Finish date']/..//option[@value='am']")).Click();
            /*AmPm2.SendKeys("A");
            AmPm2.SendKeys(Keys.Enter);*/
            //dataTimePicker2.SendKeys(Keys.Enter);
        }
    }
}
