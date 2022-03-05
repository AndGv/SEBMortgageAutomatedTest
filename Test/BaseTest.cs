using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SebPaskolaTest.Page;
using System;
using System.Collections.Generic;


namespace SebPaskolaTest.Test
{
    class BaseTest
    {

        protected static IWebDriver Driver;
        public static SebPaskolaPage Page;


        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Driver = new ChromeDriver();
            Page = new SebPaskolaPage(Driver);
            Page.NavigateToPage();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("#cookiesMessage > div > div > div > div.d-flex.flex-column.flex-sm-row.mx-n1.mt-4 > div:nth-child(1) > a")).Displayed);
            Driver.FindElement(By.CssSelector("#cookiesMessage > div > div > div > div.d-flex.flex-column.flex-sm-row.mx-n1.mt-4 > div:nth-child(1) > a")).Click();
            Driver.SwitchTo().Frame(Driver.FindElement(By.Id("lease-calculator")));
        }


        [SetUp]
        public static void setup()
        {
            int sliderSize = Driver.FindElement(By.CssSelector("div.ui-slider")).Size.Width;
            IList<IWebElement> sliderContainers = Driver.FindElements(By.CssSelector("#step1 .slider-container.small"));
            IWebElement adultsSlider = sliderContainers[0].FindElement(By.CssSelector("a.ui-slider-handle"));
            Actions adultsSliderAction = new Actions(Driver);
            adultsSliderAction.DragAndDropToOffset(adultsSlider, sliderSize * (-1), 0).Build().Perform();

            IWebElement kidsSlider = sliderContainers[1].FindElement(By.CssSelector("a.ui-slider-handle"));
            Actions kidsSliderAction = new Actions(Driver);
            kidsSliderAction.DragAndDropToOffset(kidsSlider, sliderSize * (-1), 0).Build().Perform();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Quit();
        }


    }
}
