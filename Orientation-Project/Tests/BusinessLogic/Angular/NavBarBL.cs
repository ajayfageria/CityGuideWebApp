
using OpenQA.Selenium;
using System;
using Tests.Base;
using Tests.CommonUtils;
using Tests.PageObject;

namespace Tests.BusinessLogic.Angular

{
    class NavBarBL 
    {
        CommonMethods commonuitils = new CommonMethods();
        NavBar navBar;

        public bool invokeDriver()
        {
            try
            {
                Driver.InvokeDriver(commonuitils);
                return true;
            }
            catch (Exception e){
                return false;
                throw e;
            }
        }   
        public bool verifyTitle(String title) {
            
            return commonuitils.Check_title(title);
        }
        public bool clickonOpt(String opt)
        {
            try
            {
                navBar = new NavBar();
                commonuitils.click(findopt(opt));
                return true;
            }
            catch{
                return false;
            }
        }
        public IWebElement findopt(String opt) {
            if (opt.Equals("Register"))
            {
                return navBar.Registeropt();
            }
            else if (opt.Equals("Login"))
            {
                return navBar.Loginopt();
            }
            else return null;
        }

        public bool checkurl(string url)
        {
            return commonuitils.checkUrl(url);
        }
    }
}
