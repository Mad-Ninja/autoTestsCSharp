using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumExtras.WaitHelpers;


namespace NewProject
{
    [TestFixture]
    public class UnitTest
    {
        private IWebDriver _webDriver;
        
        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
            
            
        }
        [TearDown]
        public void TearDown()
        {
            
            _webDriver.Quit();
        }

        [Test]
        public void Test_1()
        {
            //a:
            _webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            //b:
            _webDriver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys("shirts");
            //c:
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //d:
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class='ac_even']"))).Click();
            //e:
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='center_column']/div/div/div[3]")));
            Assert.AreEqual("Faded Short Sleeve T-shirts", 
                            _webDriver.FindElement(By.XPath("//h1[@itemprop='name']")).Text);
            //f:
            _webDriver.FindElement(By.XPath("//p[@id = 'add_to_cart']//child::button")).Click();
            //g:
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='layer_cart']/div[1]/div[1]/h2")));
            Assert.AreEqual("Product successfully added to your shopping cart",
                            _webDriver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[1]/h2")).Text);
            
        }
    }
}