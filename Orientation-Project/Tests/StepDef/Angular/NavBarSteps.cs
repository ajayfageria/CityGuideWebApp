
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.BusinessLogic.Angular;

namespace Tests.StepDef.Angular
{
    [Binding]
    public class NavBarSteps
    {
        NavBarBL navBarBL;
        [Given(@"user is on home page")]
        public void GivenUserIsOnHomePage()
        {
            navBarBL = new NavBarBL();
            Assert.IsTrue(navBarBL.invokeDriver());
            Assert.IsTrue(navBarBL.verifyTitle("CityPortal"));
        }
        
        [When(@"user click on register option")]
        public void WhenUserClickOnRegisterOption()
        {
            Assert.IsTrue( navBarBL.clickonOpt("Register"));
        }


        [When(@"user click on (.*) option")]
        public void WhenUserClickOnOption(string opt)
        {
            if (opt.Equals("Register"))
            {
                Assert.IsTrue(navBarBL.clickonOpt("Register"));
            }
            else if (opt.Equals("Login"))
            {
                Assert.IsTrue(navBarBL.clickonOpt("Login"));
            }
            else
                Assert.IsTrue(false);
        }

        [Then(@"user is redirected to (.*) page")]
        public void ThenUserIsRedirectedToPage(string opt)
        {
            if (opt.Equals("Register"))
            {
                Assert.IsTrue(navBarBL.checkurl("http://localhost:4200/user/registration"));
            }
            else if (opt.Equals("Login"))
            {   
                Assert.IsTrue(navBarBL.checkurl("http://localhost:4200/user/login"));
            }
            else
                Assert.IsTrue(false);
        }

    }
}
