using OpenQA.Selenium;
using System;
using Tests.Base;

namespace Tests.CommonUtils
{
    public class CommonMethods : Driver
    {
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
            deleteCookies();
        }
        public void Open_url(String url)
        {
            webdriver.Url = url;
            webdriver.Navigate();
        }
        public bool Check_title(String title)
        {
            return title.Equals(driver.Title);
        }
        public void click(IWebElement element)
        {
            element.Click();
        }
        public void typetext(IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public String gettext(IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }
        public String getvalue(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public void wait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void deleteCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }
        public void switchWindow()
        {
            driver.SwitchTo().Window(windowHandle());
        }
        public String windowHandle()
        {
            return driver.WindowHandles[0];
        }

        public void SwitchTabs()
        {
            //ArrayList tabs = new ArrayList(driver.WindowHandles);
            //driver.SwitchTo().Window((String)tabs[1]);

        }

        public bool checkUrl(string url) {

            if (url.Equals(driver.Url))
                return true;
            else
                return false;
              
        }

    }

}
