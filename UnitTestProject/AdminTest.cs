using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class AdminTest
    {

        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
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
        public void adminAddGame()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("chinu");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("mkjy67fr@");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("GameName")).Click();
            driver.FindElement(By.Id("GameName")).SendKeys("Online Race");
            driver.FindElement(By.Id("GameDescription")).Click();
            driver.FindElement(By.Id("GameDescription")).SendKeys("Challenge multiplayer");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("GamePrice")).Click();
            driver.FindElement(By.Id("GamePrice")).SendKeys("20");
            driver.FindElement(By.Name("ImageFile")).Click();
            driver.FindElement(By.Name("ImageFile")).SendKeys("C:\\fakepath\\10.jpg");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Log off")).Click();
        }

        [Test]
        public void adminAddEvent()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(951, 890);
            driver.FindElement(By.LinkText("Log off")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("chinu");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.Close();
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("chinu");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("mkjy67fr@");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("chinu")).Click();
            driver.FindElement(By.LinkText("Event")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("EventName")).Click();
            driver.FindElement(By.Id("EventName")).SendKeys("Online Challenge");
            driver.FindElement(By.Id("EventDescription")).Click();
            driver.FindElement(By.Id("EventDescription")).SendKeys("Multiplayer");
            driver.FindElement(By.Id("EventDate")).Click();
            driver.FindElement(By.Id("EventDate")).SendKeys("2022-11-06");
            driver.FindElement(By.CssSelector(".form-group:nth-child(6)")).Click();
            driver.FindElement(By.Name("ImageFile")).Click();
            driver.FindElement(By.Name("ImageFile")).SendKeys("C:\\fakepath\\8.jpg");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("EventDate")).Click();
            driver.FindElement(By.Id("EventDate")).SendKeys("2022-11-24");
            driver.FindElement(By.CssSelector(".form-group:nth-child(7)")).Click();
            driver.FindElement(By.Name("ImageFile")).Click();
            driver.FindElement(By.Name("ImageFile")).SendKeys("C:\\fakepath\\8.jpg");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Log off")).Click();
        }
    }
}
