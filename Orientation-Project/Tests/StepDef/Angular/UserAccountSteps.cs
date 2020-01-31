using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Tests.BusinessLogic.Angular;

namespace Tests.StepDEf.Angular
{
    [Binding]
    public class UserAccountSteps
    {
        private UserAccountBL userAccountBL;
        [Then(@"user register a new user with  '(.*)','(.*)','(.*)','(.*)' in the Registeration form")]
        public void ThenUserRegisterANewUserWithInTheRegisterationForm(string Email, string FullName, string username, string password)
        {
            userAccountBL = new UserAccountBL();
            Assert.IsTrue(userAccountBL.fillupRegistrationform(username, password, Email, FullName));
            Assert.IsTrue(userAccountBL.clickOnBtn("Signup"));
        }
        
        [Then(@"user should be successfully registered from the page")]
        public void ThenUserShouldBeSuccessfullyRegisteredFromThePage()
        {
            Assert.IsTrue(userAccountBL.successinreg());
        }
    }
}
