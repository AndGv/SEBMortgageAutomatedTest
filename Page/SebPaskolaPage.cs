using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace SebPaskolaTest.Page
{
    class SebPaskolaPage : BasePage
    {
        private static readonly String PAGE_URL = "https://www.seb.lt/privatiems/kreditai/busto-kreditas#paragraph7764";
        private IList<IWebElement> sliderContainers => Driver.FindElements(By.CssSelector("#step1 .slider-container.small"));
        private IWebElement adultsSlider => sliderContainers[0].FindElement(By.CssSelector("a.ui-slider-handle"));
        private IWebElement adultsSliderValue => sliderContainers[0].FindElement(By.CssSelector("label.slider-left"));
        private IWebElement kidsSlider => sliderContainers[1].FindElement(By.CssSelector("a.ui-slider-handle"));
        private IWebElement kidsSliderValue => sliderContainers[1].FindElement(By.CssSelector("label.slider-left"));
        private IWebElement Slider => Driver.FindElement(By.CssSelector("div.ui-slider"));

        public SebPaskolaPage(IWebDriver webDriver) : base(webDriver)
        { }

        public void NavigateToPage()
        {
            Driver.Url = PAGE_URL;
            Driver.Manage().Window.Maximize();
        }

        public void FillAdultsNumber(int numberOfAdults)
        {
            Actions adultsSliderAction = new Actions(Driver);
            adultsSliderAction.DragAndDropToOffset(adultsSlider, FindSliderSize() / 3 * (numberOfAdults - 1), 0).Build().Perform();
        }

        public String GetAdultsNumber()
        {
            return adultsSliderValue.Text;
        }

        public void FillKidsNumber(int NumberOfKids)
        {
            Actions adultsSliderAction = new Actions(Driver);
            adultsSliderAction.DragAndDropToOffset(kidsSlider, FindSliderSize() / 3 * (NumberOfKids - 1), 0).Build().Perform();
        }

        private int FindSliderSize()
        {
            return Slider.Size.Width;
        }

        public void FillIncome(int monthlySalary)
        {
            IWebElement salary = Driver.FindElement(By.Id("income"));
            salary.Clear();
            salary.SendKeys(monthlySalary.ToString());
        }

        public void FillObligations(int obligationsValue)
        {
            IWebElement obligations = Driver.FindElement(By.Id("commitments"));
            obligations.Clear();
            obligations.SendKeys(obligationsValue.ToString());
        }

        public void SelectCity(string city)

        {
            new SelectElement(Driver.FindElement(By.Id("city"))).SelectByValue(city);
        }

        public void ClickCalculateButton()
        {
            Driver.FindElement(By.Id("calculate")).Click();
        }

        public int MortgageCalculatorResult()
        {
            return Convert.ToInt32(Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 strong.ng-binding")).Text.Replace(" ", ""));
        }
    }
}
