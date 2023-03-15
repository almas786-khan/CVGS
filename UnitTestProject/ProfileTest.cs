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
    /// Summary description for ProfileTest
    /// </summary>
    [TestClass]
    public class ProfileTest
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
        public void addProfileTest()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.CssSelector(".glyphicon-log-in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("Abdul");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("zaqcde@1");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Profile")).Click();
            driver.FindElement(By.LinkText("Create Profile")).Click();
            driver.FindElement(By.Id("UserFirstName")).Click();
            driver.FindElement(By.Id("UserFirstName")).SendKeys("Abdul");
            driver.FindElement(By.Id("UserLastName")).Click();
            driver.FindElement(By.Id("UserLastName")).SendKeys("Khan");
            driver.FindElement(By.Id("Gender")).Click();
            driver.FindElement(By.Id("Birthdate")).Click();
            driver.FindElement(By.Id("Birthdate")).SendKeys("1992-01-13");
            driver.FindElement(By.CssSelector(".form-horizontal")).Click();
            driver.FindElement(By.Id("IsEmail")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Back")).Click();
        }

        [Test]
        public void modifyProfileTest()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log off")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("Abdul");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("zaqcde@1");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Profile")).Click();
            driver.FindElement(By.Id("12")).Click();
            driver.FindElement(By.Id("IsEmail")).Click();
            driver.FindElement(By.CssSelector(".form-group:nth-child(4)")).Click();
            driver.FindElement(By.Id("UserLastName")).SendKeys("Peter");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Back")).Click();
        }
    }
}
