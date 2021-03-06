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

    private IWebElement dreamHome => WebDriver.FindElement(By.CssSelector("a[title='Dream home']"));
              
    private IWebElement addDreamHome => WebDriver.FindElement(By.XPath("//span[text()='Add new dream home']"));

    private IWebElement title => WebDriver.FindElement(By.Id("name"));

    private IWebElement address => WebDriver.FindElement(By.CssSelector("div.MuiInput-formControl input"));

    private IWebElement ampmChooser1 => WebDriver.FindElement(By.CssSelector("select.react-datetime-picker__inputGroup__input"));

        //"button.react-datetime-picker__calendar-button")//"input[name='year']:nth-child(1)")
    private IWebElement dataTimePicker1 => WebDriver.FindElement(By.CssSelector("input[name='day']"));

    private IWebElement dataTimePicker2 => WebDriver.FindElement(By.XPath("(//input[@name='day'])[2]"));

    private IWebElement nextMonthArrow => WebDriver.FindElement(By.CssSelector("button.react-calendar__navigation__next-button"));

    private IWebElement nextMonthArrowSecond => WebDriver.FindElement(By.XPath("(//button[text()='›'])[2]"));

    private IWebElement nextYearBtn => WebDriver.FindElement(By.CssSelector("button.react-calendar__navigation__next2-button"));

    private IWebElement firstDateCell => WebDriver.FindElement(By.CssSelector("button abbr"));

    private IWebElement fifthDateCellFinishCalendar => WebDriver.FindElement(By.CssSelector("(//abbr[@aria-label='5 мая 2021 г.'])[1]"));

    private IWebElement isTrandingToggle => WebDriver.FindElement(By.Id("isTrending"));

    private IWebElement saveBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(1)"));

    private IWebElement descriptionTab => WebDriver.FindElement(By.XPath("//span[text()='Description']"));

    private IWebElement BadroomDescriptonInput => WebDriver.FindElement(By.CssSelector("div.ql-editor p"));

    private IWebElement BadroomPictureChooser => WebDriver.FindElement(By.XPath("(//div[@data-testid='dropzone'])[1]/p"));

    private IWebElement fileInput => WebDriver.FindElement(By.CssSelector("input[type=file]"));

       // @FindBy(css = "div[role='toolbar'] button:nth-child(2)")
        private IWebElement cancelBtn => WebDriver.FindElement(By.CssSelector("div[role='toolbar'] button:nth-child(2)"));

        public void clickAddNewDreamHome()
        {
            addDreamHome.Click();
        }

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

        public void clickFinishDate()
        {
            dataTimePicker2.Click();
        }

        public void clickNextMonth()
        {
            nextMonthArrow.Click();
        }

        public void clickFirstDateCell()
        {
            firstDateCell.Click();
        }

        public void clickIsTrandingToggle()
        {
            isTrandingToggle.Click();
        }

        public void goToDescription()
        {
            descriptionTab.Click();
        }

        public void inputBadroomDescription(String desc)
        {
            BadroomDescriptonInput.SendKeys(desc);
        }

        public void clickSelectBadroomPicture()
        {
            BadroomPictureChooser.Click();
            Thread.Sleep(2000);

            //let driver = new Builder().forBrowser('chrome').build();

            


            /*WebDriver.SwitchTo()
            .ActiveElement()
            .SendKeys(
                    "/home/likewise-open/GLOBAL/123/Documents/filename.txt");*/
            //IWebElement upload = WebDriver.FindElement(By.Name("uploadfile"));//By.Id("file-upload"));
            //Log.Info(upload.Displayed);
            WebDriver.FindElement(By.XPath(".//input[@type='file']")).SendKeys("your/path/here.file");

            /* String filePath = "C://Users//PC//IdeaProjects//RaffWorking//src//test//resources//G.png";
             IJavaScriptExecutor jsx = (IJavaScriptExecutor)WebDriver;

             jsx.ExecuteScript("document.getElementById('import-file-btn')");
             WebDriver.FindElement(By.Id("import-file-btn")).SendKeys(filePath);*/
            //jsx.executeScript("document.getElementById('iconFlagFile').value='" + filePath + "';");
            //getDriver().switchTo().frame(getDriver().findElement(By.xpath("//iframe")));
            //WebElement uploadElement = getDriver().findElement(By.id("uploadfile_0"));
            //uploadElement.sendKeys("hkfgdgdfg");
            //WebElement uploadElement = getDriver().findElement(By.id("uploadfile_0"));

            // enter the file path onto the file-selection input field
            //uploadElement.sendKeys("C:\\newhtml.html");

            //getDriver().findElement(By.xpath("//iinput")).sendKeys("C:\\Users\\PC\\IdeaProjects\\RaffWorking\\src\\test\\resources\\G.png");
            //getDriver().findElement(By.xpath("//input[@src='C:/Users/PC/IdeaProjects/RaffWorking/src/test/resources/G.png']")).click();

            WebDriver.FindElement(By.Id("G")).Click();
            Thread.Sleep(5000);
            fileInput.SendKeys("G.png");
        }

        public void clickDreamHome()
        {
            dreamHome.Click();
        }

        public void clickNextMonthOnFinish()
        {
            nextMonthArrowSecond.Click();
        }

        public void clickFifthDataCellFinishCalendar()
        {
            /*WebDriverWait wait = new WebDriverWait(getDriver(), 6000);
            wait.until(ExpectedConditions.presenceOfAllElementsLocatedBy(By.xpath("(//abbr[@aria-label='5 мая 2021 г.'])[1]")));
                   // (ExpectedConditions.presenceOfAllElementsLocatedBy());
            fifthDateCellFinishCalendar.click();*/
            dataTimePicker2.SendKeys("11052021120000");
            dataTimePicker2.SendKeys(Keys.Enter);
        }
    }
}
