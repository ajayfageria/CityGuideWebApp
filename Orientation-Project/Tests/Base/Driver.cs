using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using System;
using Tests.CommonUtils;

namespace Tests.Base
{
    public class Driver
    {
        public static IWebDriver webdriver;
        public static NgWebDriver driver;

        public static void InvokeDriver(CommonMethods commonutils)
        {
            webdriver = new ChromeDriver();
            commonutils.Open_url("http://localhost:4200/logohome");
            driver = new NgWebDriver(webdriver);
            driver.Url = webdriver.Url;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            commonutils.Maximize();
        }
        public void Close()
        {
            driver.Quit();
        }
    }
}

    