using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
   
    [TestFixture]
    public class WishListTest
    {
            private IWebDriver driver;
            public IDictionary<string, object> vars { get; private set; }
            private IJavaScriptExecutor js;
            [SetUp]
            public void SetUp()
            {
                driver = new FirefoxDriver();
                js = (IJavaScriptExecutor)driver;
                vars = new Dictionary<string, object>();
            }
            [TearDown]
            protected void TearDown()
            {
                driver.Quit();
            }
            [Test]
            public void WishListClickAddWishListButton()
            {
                driver.Navigate().GoToUrl("https://localhost:44339/Member");
                driver.Manage().Window.Size = new System.Drawing.Size(909, 720);
                driver.FindElement(By.CssSelector("tr:nth-child(4) .btn")).Click();
                driver.FindElement(By.CssSelector("tr:nth-child(4) .btn")).Click();
            }
         
           
            [Test]
            public void gameStoreWishListClickCancelWishListButton()
            {
                driver.Navigate().GoToUrl("https://localhost:44339/Member");
                driver.Manage().Window.Size = new System.Drawing.Size(909, 720);
                driver.FindElement(By.CssSelector("tr:nth-child(3) .btn")).Click();
                driver.FindElement(By.CssSelector("tr:nth-child(3) .btn")).Click();
            }
      
            [Test]
            public void gameStoreWishListClickShareButton()
            {
                driver.Navigate().GoToUrl("https://localhost:44339/Member/WishList");
                driver.Manage().Window.Size = new System.Drawing.Size(909, 720);
                driver.FindElement(By.CssSelector(".good-share")).Click();
                driver.FindElement(By.CssSelector(".twitter-btn")).Click();
            }
        }
}
