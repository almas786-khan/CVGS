using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for RateGameTest
    /// </summary>
    [TestClass]
    public class RateGameTest
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
        public void RateGame()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(830, 890);
            driver.FindElement(By.LinkText("CVGS")).Click();
            driver.FindElement(By.LinkText("FIFA")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
            driver.FindElement(By.LinkText("WAR")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
            driver.FindElement(By.LinkText("Online Race")).Click();
            driver.FindElement(By.LinkText("Rate")).Click();
            driver.FindElement(By.Id("Rating1")).Click();
            {
                var dropdown = driver.FindElement(By.Id("Rating1"));
                dropdown.FindElement(By.XPath("//option[. = '4']")).Click();
            }
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
        }


        [Test]
        public void EditRate()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(828, 889);
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Profile")).Click();
            driver.FindElement(By.LinkText("CVGS")).Click();
            driver.FindElement(By.LinkText("Challege")).Click();
            driver.FindElement(By.LinkText("Edit Rate")).Click();
            driver.FindElement(By.Id("Rating1")).Click();
            {
                var dropdown = driver.FindElement(By.Id("Rating1"));
                dropdown.FindElement(By.XPath("//option[. = '2']")).Click();
            }
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}
