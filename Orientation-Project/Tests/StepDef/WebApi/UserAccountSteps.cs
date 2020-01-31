using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.WebApi;

namespace Tests.StepDef.WebApi
{
    [Binding]
    class UserAccountSteps
    {
        private ScenarioContext _sceneriocontext;
        public UserAccountSteps(ScenarioContext sceneriocontext)
        {
            _sceneriocontext = sceneriocontext;
        }
        private UserAccountBL UAbl;
        [When(@"user register a new user with  '(.*)','(.*)','(.*)','(.*)'")]
        public void WhenUserRegisterANewUserWith(string Email, string FullName, string UserName, string Password)
        {
            UAbl = new UserAccountBL(_sceneriocontext);
            Assert.IsTrue(UAbl.invoke());
            Assert.IsTrue(UAbl.createRegBody( Email,FullName,UserName,Password, "ApplicationUser/Register"));
            Assert.IsTrue(UAbl.executereq());
        }

        [Then(@"user should be successfully registered")]
        public void ThenUserShouldBeSuccessfullyRegistered()
        {
            Assert.IsTrue(UAbl.checkStatusCode("200"));
        }

        [When(@"user logs in with '(.*)' and '(.*)'")]
        public void WhenUserLogsInWithAnd(string username, string password)
        {
            UAbl = new UserAccountBL(_sceneriocontext);
            Assert.IsTrue(UAbl.invoke());
            Assert.IsTrue(UAbl.createLoginBody(username,password,"ApplicationUser/Login"));
            Assert.IsTrue(UAbl.executereq());

        }

        [Then(@"user should get a token with the Role '(.*)' with status code (.*)")]
        public void ThenUserShouldGetATokenWithTheRoleWithStatusCode(string Role, string statusCode)
        {
            if (statusCode.Equals("200"))
            {
                Assert.IsTrue(UAbl.checkStatusCode(statusCode));
                Assert.IsTrue(UAbl.checkforToken());
                Assert.IsTrue(UAbl.checkforRole(Role));
            }
            else
                Assert.IsTrue(UAbl.checkStatusCode(statusCode));
        }

        [Then(@"user should not get a token with a status code (.*) with error message '(.*)'")]
        public void ThenUserShouldNotGetATokenWithAStatusCodeWithErrorMessage(string statusCode, string error)
        {
            Assert.IsTrue(UAbl.checkStatusCode(statusCode));
            Assert.IsFalse(UAbl.checkforToken());
            Assert.IsTrue(UAbl.checkformessage(error));
        }



        [Then(@"user should not be able to register the user due to '(.*)' and '(.*)'")]
        public void ThenUserShouldNotBeAbleToRegisterTheUserDueToAnd(string error, string Code)
        
        {
            Assert.IsTrue(UAbl.checkStatusCode(Code));
            Assert.IsTrue(UAbl.checkforerrors(error));

        }



}
}
