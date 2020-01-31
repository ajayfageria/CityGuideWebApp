
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Tests.BusinessLogic.WebApi;

namespace Tests.StepDEf.WebApi
{
    [Binding]
    public class AdminSteps
    {
        private AdminBL adminbl;
        private ScenarioContext _sceneriocontext;
        private FeatureContext _featureContext;
        public AdminSteps(ScenarioContext sceneriocontext,FeatureContext featureContext)
        {
            _sceneriocontext = sceneriocontext;
            _featureContext = featureContext;
            adminbl = new AdminBL(_sceneriocontext,_featureContext);
        }

        [When(@"user sends a request to register new admin with  '(.*)','(.*)','(.*)','(.*)'")]
        public void WhenUserSendsARequestToRegisterNewAdminWith(string email, string fullname , string username, string password)
        {
            Assert.IsTrue(adminbl.getLoginToken());
            Assert.IsTrue(adminbl.invoke());
            Assert.IsTrue(adminbl.createRegisterBody(username,password,email,fullname));
            Assert.IsTrue(adminbl.executereq());

        }

        [Then(@"user should get response with code '(.*)'")]
        public void ThenUserShouldGetResponseWithCode(string Code)
        {
            if (Code.Equals("200"))
            {
                Assert.IsTrue(adminbl.checkstatusCode(Code));
                Assert.IsTrue(adminbl.checkforsuccess());
                adminbl.clearScenerioContext();
            }
            else
            {
                Assert.IsTrue(adminbl.checkstatusCode(Code));
                adminbl.clearScenerioContext();
            }
                
        }
        [When(@"user is logged in as Admin")]
        public void WhenUserIsLoggedInAsAdmin()
        {
            ScenarioContext.Current.Pending();
        }

       
        [When(@"user sends a new request to add a (.*) Entity")]
        public void WhenUserSendsANewRequestToAddAEntity(string Entity)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
