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
    /// Summary description for FriendAndFamilyTest
    /// </summary>
    [TestClass]
    public class FriendAndFamilyTest
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
        public void searchAndAddFriends()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Rao")).Click();
            driver.FindElement(By.LinkText("Friends & Family")).Click();
            driver.FindElement(By.LinkText("Add Friends")).Click();
            driver.FindElement(By.Id("Search")).Click();
            driver.FindElement(By.Id("Search")).SendKeys("a");
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("Search")).Click();
            driver.FindElement(By.Id("Search")).SendKeys("al");
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.CssSelector("#\\31 7 .btn")).Click();
            driver.FindElement(By.LinkText("Back to Profile")).Click();
        }

        [Test]
        public void ViewFriends()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Rao")).Click();
            driver.FindElement(By.LinkText("Friends & Family")).Click();
        }

    }
}
