using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SpecFlowDreanLotteryHome.pages.admin.fragments;
using SpecFlowDreanLotteryHome.utils;
using SpecFlowDreanLotteryHome.utils.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowDreanLotteryHome.pages.admin
{
    class DreamHomePage : BasePage
    {
        public static PaginationFragment Paginats;

        public DreamHomePage(IWebDriver webDriver) : base(webDriver)
        {
            Paginats = new PaginationFragment(webDriver);
        }
        private ClearHelper Clearer = new ClearHelper();
        string MainHomePicPath = PathGiver.GetPicturePath() + "main_pic.png";
        string BadroomHomePicPath = PathGiver.GetPicturePath() + "badroom_pic.png";
        string BathroomHomePicPath = PathGiver.GetPicturePath() + "bathroom_pic.jpg";
        string OutspaceHomePicPath = PathGiver.GetPicturePath() + "outspace_pic.jpg";
        string FloorPlanHomePicPath = PathGiver.GetPicturePath() + "floor_plan_pic.png";


        private IList<IWebElement> Titles => WebDriver.FindElements(By.CssSelector("tbody tr td:nth-of-type(1)"));
        private IWebElement CheckboxOfActiveOne => WebDriver.FindElement(By.XPath("(//table)[1]/tbody/tr//label"));
        string TitleNeedBeActive;
        private IWebElement CheckOfDrHomeWithTitle => WebDriver.FindElement(By.XPath("(//table)[2]/tbody/tr/td[text()='" + TitleNeedBeActive + "']/..//label/span"));
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
        private IWebElement ActiveCheckbox => WebDriver.FindElement(By.Id("active"));
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

        private IWebElement TicketPriceInput => Waiter.Until(ExpectedConditions.ElementToBeClickable(By.Id("ticketPrice")));
        private IWebElement DefaultTicketNumberInput => WebDriver.FindElement(By.Id("defaultTickets"));
        private IWebElement TicketNumberInput => WebDriver.FindElement(By.Id("maxTickets"));

        private IWebElement DiscountFromTicket => WebDriver.FindElement(By.Id("isActiveDiscount"));
        private IWebElement PriceIs => WebDriver.FindElement(By.XPath("(//h6[text()='Tickets']/..//input)[5]"));
        private IWebElement ErrorMessage => WebDriver.FindElement(By.XPath("div.date-error"));      

        private IWebElement DiscountIs => WebDriver.FindElement(By.XPath("(//h6[text()='Tickets']/..//input)[4]"));
        private IWebElement MoneyCurrency => WebDriver.FindElement(By.XPath("(//span[@class='discount-is']/..)[2]"));
        private IWebElement DiscountNewPrice => WebDriver.FindElement(By.XPath("(//h6[text()='Discount']/..//input)[5]"));
        private IWebElement CurrencyCheckbox => WebDriver.FindElement(By.Id("discountCategory_cash"));
        private IWebElement DiscountStatus => WebDriver.FindElement(By.Id("isDiscountRates"));
        private IWebElement CreditStatus => WebDriver.FindElement(By.CssSelector("input[name='checkedB']"));//"//h6[text()='Credits']/..//input[@name='checkedB']"));
        private IWebElement CreditEuroInput => WebDriver.FindElement(By.CssSelector("input[name='count']"));
        private IWebElement CreditPercentInput => WebDriver.FindElement(By.CssSelector("input[name='percent']"));
        private IWebElement CreditLastEuroInput => WebDriver.FindElement(By.XPath("(//input[@name='count'])[last()]"));
        private IWebElement CreditLastPercentInput => WebDriver.FindElement(By.XPath("(//input[@name='percent'])[last()]"));
        private IWebElement AddCreditBtn => WebDriver.FindElement(By.CssSelector("svg.add-discount"));
        private IWebElement DiscountTicketAmountInput => WebDriver.FindElement(By.XPath("(//label[text()='threshold']/..//input)[last()]"));
        private IWebElement DiscountPercentInput => WebDriver.FindElement(By.XPath("(//label[text()='%']/..//input)[last()]"));

        private IWebElement LastHomeUpdate => WebDriver.FindElement(By.XPath("(//table//a[@aria-label='Edit'])[last()]"));
        private IWebElement LastHomeCreate => WebDriver.FindElement(By.XPath("(//table//a[@aria-label='Clone'])[last()]"));

        public void InputGeneralPictureInput() => GeneralPicInput.SendKeys(MainHomePicPath);//"C:\\Users\\PC\\G.PNG")         

        public void InputBadRoomInputPic() => BadRoomInputPic.SendKeys(BadroomHomePicPath);
        public void InputBathRoomInputPic() => BathRoomInputPic.SendKeys(BathroomHomePicPath);
        public void InputOutSpaceInputPic() => OutSpaceInputPic.SendKeys(OutspaceHomePicPath);
        public void InputAboutInput(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(AboutInput); }
            AboutInput.SendKeys(inp);
        }
        public void InputFloorPlanInputPic() => FloorPlanInputPic.SendKeys(FloorPlanHomePicPath);
        public void InputAddLink(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(AddLink); }
            AddLink.SendKeys(inp);
        }
        public void InputTour3D(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(Tour3D); }
            Tour3D.SendKeys(inp);
        }
        public void InputPriceInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(PriceInp); }
            PriceInp.SendKeys(inp);
        }
        public void InputBadInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(BadInp); }
            BadInp.SendKeys(inp);
        }
        public void InputBathDescription(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(BathDescription); }
            BathDescription.SendKeys(inp);
        }
        public void InputOutSpaceDescription(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(OutSpaceDescription); }
            OutSpaceDescription.SendKeys(inp);
        }
        internal void ClickLastUpdate() => LastHomeUpdate.Click();

        internal void ClickLastCreate() => LastHomeCreate.Click();

        internal void ClickDiscountInTicket() => DiscountFromTicket.Click();

        internal void InputDiscountIs(string p0)
        {
            DiscountIs.SendKeys(Keys.Backspace); DiscountIs.SendKeys(Keys.Backspace);
            DiscountIs.SendKeys(p0);
        }

        public void InputBathInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(BathInp); }
            BathInp.SendKeys(inp);
        }
        internal string GetPriceIs()
        {
            return PriceIs.GetAttribute("value");
        }

        public void InputGardenInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(GardenInp); }
            GardenInp.SendKeys(inp);
        }
        internal void ClickDiscountStatus() => DiscountStatus.Click();

        internal void InputPriceIs(string p0)
        {
            PriceIs.SendKeys(Keys.Backspace); PriceIs.SendKeys(Keys.Backspace); PriceIs.SendKeys(Keys.Backspace);
            PriceIs.SendKeys(p0);
        }

        internal void ClickCreditStatus() => CreditStatus.Click();

        public void InputCreditEuro(string input) {
            Clearer.ClearInput(CreditEuroInput);
            CreditEuroInput.SendKeys(input);
        }

        public void InputCreditPercent(string input) {
            Clearer.ClearInput(CreditPercentInput);
            CreditPercentInput.SendKeys(input);
        }
        public void InputCreditLastEuro(string input)
        {
            Clearer.ClearInput(CreditLastEuroInput);
            CreditLastEuroInput.SendKeys(input);
        }

        public void InputCreditLastPercent(string input)
        {
            try { Clearer.ClearInput(CreditLastPercentInput); }
            catch(ElementNotInteractableException e) { Thread.Sleep(1000); Clearer.ClearInput(CreditLastPercentInput); }
            CreditLastPercentInput.SendKeys(input);
        }
        public void ClickAddCredit() => AddCreditBtn.Click();

        public void InputDiscountLastAmount(string input)
        {
            try { Clearer.ClearInput(DiscountTicketAmountInput); }
            catch (ElementNotInteractableException) { Thread.Sleep(1000); Clearer.ClearInput(DiscountTicketAmountInput); }
            DiscountTicketAmountInput.SendKeys(input);
        }
        public void InputDiscountLastPercent(string input)
        {
            try { Clearer.ClearInput(DiscountPercentInput); }
            catch (ElementNotInteractableException) { Thread.Sleep(1000); Clearer.ClearInput(DiscountPercentInput); }
            DiscountPercentInput.SendKeys(input);
        }
        internal void InputPriceDiscountTab(string p0)
        {
            DiscountNewPrice.SendKeys(Keys.Backspace); DiscountNewPrice.SendKeys(Keys.Backspace);
            DiscountNewPrice.SendKeys(p0);
        }

        internal string GetMoneyAndCurrency()
        {
            return MoneyCurrency.Text;
        }

        internal void ClickCurrencyCheckbox() => CurrencyCheckbox.Click();

        public void InputTransportInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(TransportInp); }
            TransportInp.SendKeys(inp);
        }
        internal string GetDiscountIs()
        {
            return DiscountIs.GetAttribute("value");
        }

        internal void ClickDiscountTicketTab()
        {
            DiscountTicketTab.Click();
        }

        internal void InputDefaultNumbersOfTickets(string p0, bool update = false)
        {
            if (update) { Clearer.ClearInput(DefaultTicketNumberInput); }
            DefaultTicketNumberInput.SendKeys(p0);
        }
        internal void InputNumbersOfTickets(string p0, bool update = false)
        {
            if (update) { Clearer.ClearInput(TicketNumberInput); }
            TicketNumberInput.SendKeys(p0);
            TicketNumberInput.SendKeys(Keys.Enter);
        }
        internal bool IsNoActive()
        {
            if (noActiveMessages.Count == 1) { return true; }
            else if (noActiveMessages.Count == 0) { return false; }
            else {
                throw new Exception("it is 2 such else or else");
            }
        }

        internal void InputTicketPrice(string p0, bool update = false)
        {
            if (update) { Clearer.ClearInput(TicketPriceInput); }
            //TicketPriceInput.Click();
            TicketPriceInput.SendKeys(p0);
        }

        public void InputLocationInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(LocationInp); }
            LocationInp.SendKeys(inp);
        }
        internal List<string> GetTitles()
        {
            List<string> strTitles = new List<string>();
            for (int i = 0; i < Titles.Count; i++)
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

        public void InputFreeHoldInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(FreeHoldInp); }
            FreeHoldInp.SendKeys(inp);
        }
        public void InputTaxInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(TaxInp); }
            TaxInp.SendKeys(inp);
        }
        public void InputSizeInp(string inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(SizeInp); }
            SizeInp.SendKeys(inp);
        }
        public void InputEnergyInp(string inp , bool update = false)
        {
            if (update) { Clearer.ClearInput(EnergyInp);
            }
            EnergyInp.SendKeys(inp);
        }
        public void ClickSaveBtn() {
            Waiter.Until(ExpectedConditions.InvisibilityOfElementLocated(base.PopupBy));
            SaveBtn.Click(); 
        }
        public void ClickSaveBtnWithoutWaiting()
        {
            SaveBtn.Click();
        }
        /*public void Input(string inp) => .SendKeys(inp);
        public void Input(string inp) => .SendKeys(inp);*/

        private IWebElement cancelBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(2)"));

        public void clickAddNewDreamHome() => addDreamHome.Click();     

        public void inputTitle(String inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(title); }
            title.SendKeys(inp);
        }
        
        public void inputAddress(String inp, bool update = false)
        {
            if (update) { Clearer.ClearInput(address); }
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

        public void goToDescription()
        {
            try { DescriptionTab.Click(); }
            catch(ElementClickInterceptedException e){ Thread.Sleep(2000); JSClick(DescriptionTab); }
        }

        public void inputBadroomDescription(string desc, bool update = false)
        {
            if (update) { Clearer.ClearInput(BadroomDescriptonInput); }
            BadroomDescriptonInput.SendKeys(desc);
        }

        internal void ClickActiveCheckboxFixOdd() => ActiveCheckbox.Click();

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
        /*protected void ClearInput(IWebElement el)
        {
            el.SendKeys(Keys.Control + "a");
            el.SendKeys(Keys.Delete);
        }*/
        public PaginationFragment GetPagination()
        {
            return Paginats;
        }
    }
}
