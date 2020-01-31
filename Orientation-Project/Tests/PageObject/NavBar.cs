using OpenQA.Selenium;
using Protractor;
using Tests.Base;

namespace Tests.PageObject
{
    class NavBar : Driver
    {
        public IWebElement Registeropt()
        {
            return driver.FindElement(By.XPath("//*[@id='myNavbar']/ul/li[9]/a"));
        }
        public IWebElement Loginopt()
        {
            return driver.FindElement(By.XPath("//*[@id='myNavbar']/ul/li[8]/a"));
        }
    }
}
