using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for SelectGameTest
    /// </summary>
    [TestClass]
    public class SelectGameTest
    {


        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            //ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void SearchAndSelectGame()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(820, 883);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("Rao");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("5tfdrt78@");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("Search")).Click();
            driver.FindElement(By.Id("Search")).SendKeys("ss");
            driver.FindElement(By.CssSelector("form > .btn")).Click();
            {
                var element = driver.FindElement(By.Id("Search"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).ClickAndHold().Perform();
            }
            {
                var element = driver.FindElement(By.Id("Search"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.Id("Search"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            driver.FindElement(By.Id("Search")).Click();
            driver.FindElement(By.Id("Search")).SendKeys("cha");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
        }
        [Test]
        public void ViewGameDetails()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Rao")).Click();
            driver.FindElement(By.LinkText("Profile")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
            driver.FindElement(By.LinkText("Challege")).Click();
        }
    }
}
