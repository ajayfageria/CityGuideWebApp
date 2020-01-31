
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
    class RegistrationForm : Driver
    {
        public IWebElement UsernameInput()
        {
            return driver.FindElement(NgBy.Binding("UserName"));
        }
        public IWebElement FullNameInput()
        {
            return driver.FindElement(NgBy.Binding("FullName"));
        }
        public IWebElement EmailInput()
        {
            return driver.FindElement(NgBy.Binding("Email"));
        }
        public IWebElement PasswordInput()
        {
            return driver.FindElement(NgBy.Binding("Password"));
        }
        public IWebElement SignupBtn()
        {
            return driver.FindElement(By.XPath("//button[@class='btn btn - dark btn - lg   btn - block col - md - offset - 3']"));
        }
    }
}
