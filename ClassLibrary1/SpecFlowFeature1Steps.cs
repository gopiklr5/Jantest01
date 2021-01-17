using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace ClassLibrary1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the first number")]
        public void GivenTheFirstNumber()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testing.todorvachev.com/");
        }
    }
}
