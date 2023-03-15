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
  
    [TestClass]
    public class EventRegistrationTest
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
        public void eventRegistrationTest()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("dzisaacs");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("Test!077");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".caret")).Click();
            driver.FindElement(By.LinkText("Events")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(7) .btn")).Click();
            driver.FindElement(By.LinkText("Log off")).Click();
        }
        [Test]
        public void cancelEventRegistration()
        {
            driver.Navigate().GoToUrl("https://localhost:44339/");
            driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("dzisaacs");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("[Test]   public void eventRegistrationTest() {     driver.Navigate().GoToUrl(\"https://localhost:44339/\");     driver.Manage().Window.Size = new System.Drawing.Size(1655, 903);     driver.FindElement(By.LinkText(\"Log in\")).Click();     driver.FindElement(By.Id(\"UserName\")).Click();     driver.FindElement(By.Id(\"UserName\")).SendKeys(\"dzisaacs\");     driver.FindElement(By.Id(\"UserPassword\")).Click();     driver.FindElement(By.Id(\"UserPassword\")).SendKeys(\"Test!077\");     driver.FindElement(By.CssSelector(\".btn\")).Click();     driver.FindElement(By.CssSelector(\".caret\")).Click();     driver.FindElement(By.LinkText(\"Events\")).Click();     driver.FindElement(By.CssSelector(\"tr:nth-child(7) .btn\")).Click();     driver.FindElement(By.LinkText(\"Log off\")).Click();   }");
            {
                var element = driver.FindElement(By.LinkText("Log in"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("dzisaacs");
            driver.FindElement(By.Id("UserPassword")).Click();
            driver.FindElement(By.Id("UserPassword")).SendKeys("Test!077");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("dzisaacs")).Click();
            driver.FindElement(By.LinkText("Events")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(2) .btn")).Click();
            driver.FindElement(By.LinkText("Log off")).Click();
        }

    }
}
