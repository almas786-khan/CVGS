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
    /// Summary description for CreditCardTest
    /// </summary>
    [TestClass]
    public class CreditCardTest
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
        public void AddCardWrongDetails()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("chinu");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("mkjy67fr@");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Log off")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("dzisaacs");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("Test!077");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Card Details")).Click();
            driver.FindElement(By.LinkText("Add Card")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("CardNumber")).SendKeys("45643222222222222222222222222222222222");
            driver.FindElement(By.Id("CardHolderName")).Click();
            driver.FindElement(By.Id("CardHolderName")).SendKeys("2222222222222222222222");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".form-group:nth-child(1) > .col-md-10")).Click();
            driver.FindElement(By.Id("CardNumber")).Click();
            driver.FindElement(By.Id("CardNumber")).Click();
            driver.FindElement(By.Id("CardNumber")).SendKeys("rdrr");
            driver.FindElement(By.Id("CardHolderName")).Click();
            driver.FindElement(By.Id("CardHolderName")).Click();
            driver.FindElement(By.Id("CardHolderName")).SendKeys("222rf");
            driver.FindElement(By.Id("Expiry")).Click();
            driver.FindElement(By.Id("Expiry")).SendKeys("2022-01");
            driver.FindElement(By.CssSelector(".body-content")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        [Test]
        public void addCard()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log off")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("dzisaacs");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("Test!077");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("dzisaacs")).Click();
            driver.FindElement(By.LinkText("Card Details")).Click();
            driver.FindElement(By.LinkText("Add Card")).Click();
            driver.FindElement(By.Id("CardNumber")).Click();
            driver.FindElement(By.Id("CardNumber")).SendKeys("1234324323423123");
            driver.FindElement(By.Id("CardHolderName")).Click();
            driver.FindElement(By.Id("CardHolderName")).Click();
            driver.FindElement(By.Id("CardHolderName")).SendKeys("Almas Khh");
            driver.FindElement(By.Id("CVC")).Click();
            driver.FindElement(By.Id("CVC")).SendKeys("113");
            driver.FindElement(By.Id("Expiry")).Click();
            driver.FindElement(By.Id("Expiry")).SendKeys("2022-12");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}
