using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SebPaskolaTest.Test
{
    class SebPaskolaTest : BaseTest
    {
       
        [TestCase(1, 0, 1000, 0, "Klaipeda", 75000, TestName = "1 + 0 + 1500 + 0 + Klaipeda = 75000")]
        [TestCase(2, 0, 5000, 900, "Vilnius", 75000, TestName = "2 + 2 + 2000 + 2 + Vilnius = 75000")]


        public static void Loan(int numberOfAdults, int numberOfKids, int monthlySalary, int commitments, string city, int result)
        {
            Page.FillAdultsNumber(numberOfAdults);
            Page.FillKidsNumber(numberOfKids);
            Page.FillIncome(monthlySalary);
            Page.FillObligations(commitments);
            Page.SelectCity(city);
            Page.ClickCalculateButton();
            Assert.IsTrue(Page.MortgageCalculatorResult() >= result, "Actual result differs from expected");
        }
    }
}
