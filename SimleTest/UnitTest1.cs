using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

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

            IWebElement webElement = driver.FindElement(_img);
            string path = "d:/AQA/C#/.NetProjects AQA/SimleTest/SimleTest/Screens/Screen.png" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            TakeSreenshot(webElement, path, ScreenshotImageFormat.Png);

            Console.WriteLine("Page title is: " + driver.Title);
        }

        public void TakeSreenshot(IWebElement webElement, string path, ScreenshotImageFormat format)
        {
            ITakesScreenshot screenshot = webElement as ITakesScreenshot;
            screenshot.GetScreenshot().SaveAsFile(path, format);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}