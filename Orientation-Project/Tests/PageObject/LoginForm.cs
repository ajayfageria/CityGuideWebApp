using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;

namespace Tests.PageObject
{
    class LoginForm: Driver
    {
        public IWebElement UsernameInput()
        {
            return driver.FindElement(NgBy.Binding("UserName"));
        }
        public IWebElement PasswordInput()
        {
            return driver.FindElement(NgBy.Binding("Password"));
        }
        public IWebElement LoginBtn()
        {
            return driver.FindElement(By.XPath("//button[@class='btn btn-dark btn-md btn-block col-md-offset-4']"));
        }
    }
}
