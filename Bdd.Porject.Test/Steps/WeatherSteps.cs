using System;
using TechTalk.SpecFlow;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Bdd.Porject.Test.Steps
{
    [Binding]
    public class WeatherSteps
    {
        private static string HomeUrl { get; set; }
        private static string SearchString { get; set; }
        private static string GoogleTemp { get; set; }
        private IWebDriver webDriver { get; set; }
        private IWebElement searchBox { get; set; }
        private IWebElement searchButton { get; set; }


        [BeforeFeature]
        public void Setup()
        {
            HomeUrl = ConfigurationManager.AppSettings["GoogleURL"];
            SearchString = ConfigurationManager.AppSettings["SearchValue"];
            webDriver = new ChromeDriver();
        }

        [Given(@"Call Google home URL")]
        public void GivenCallGoogleHomeURL()
        {
            webDriver.Navigate().GoToUrl(HomeUrl);
            webDriver.Manage().Window.Maximize();
        }
        
        [Then(@"Find the search box")]
        public void ThenFindTheSearchBox()
        {
            searchBox = webDriver.FindElement(By.ClassName("gLFyf"));
        }
        
        [Then(@"Enter search box text")]
        public void ThenEnterSearchBoxText()
        {
            searchBox.SendKeys(SearchString);
        }
        
        [Then(@"Find and click the search button")]
        public void ThenFindAndClickTheSearchButton()
        {
            searchButton = webDriver.FindElement(By.ClassName("gNO89b"));
        }
        
        [Then(@"Read the result Temperature")]
        public void ThenReadTheResultTemperature()
        {
            GoogleTemp = webDriver.FindElement(By.Id("wob_tm")).Text;
        }
        
        [Then(@"Call the Open weather Api")]
        public void ThenCallTheOpenWeatherApi()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Compare the temperatures")]
        public void ThenCompareTheTemperatures()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
