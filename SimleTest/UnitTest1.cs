using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.IO;
using System.Collections;

namespace SimleTest
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _img = By.XPath("//div[@id='slim_appbar']");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese");
            query.Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });
            ((ITakesScreenshot)driver.FindElement(_img)).GetScreenshot().SaveAsFile("d:/C# Tests/SimleTest/SimleTest/Screens/Screen.png" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"), ScreenshotImageFormat.Png);
            Console.WriteLine("Page title is: " + driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}