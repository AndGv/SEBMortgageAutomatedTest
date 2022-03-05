using OpenQA.Selenium;

namespace SebPaskolaTest.Page
{
    class BasePage
    {

        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

    }
}
