using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.WebApi;

namespace Tests.StepDef.WebApi
{
    [Binding]
    public class EntitySteps
    {
        private EntityBL entbl;
        private ScenarioContext _sceneriocontext;
        public EntitySteps(ScenarioContext sceneriocontext)
        {
            _sceneriocontext = sceneriocontext;
        }
        [When(@"user sends a request fo a specific entity '(.*)' with placeName '(.*)'")]
        public void WhenUserSendsARequestFoASpecificEntityWithPlaceName(string entity, string placeName)
        {
            entbl = new EntityBL(_sceneriocontext);
            Assert.IsTrue(entbl.invoke());
            Assert.IsTrue(entbl.createRequest(entity,placeName));
            Assert.IsTrue(entbl.executereq());

        }

        [Then(@"user should be a able to get the deatils abt the entity with its defined Amenities with code '(.*)'")]
        public void ThenUserShouldBeAAbleToGetTheDeatilsAbtTheEntityWithItsDefinedAmenitiesWithCode(string Code)
        {
            if (Code.Equals("200"))
            {
                Assert.IsTrue(entbl.checkStatusCode(Code));
                Assert.IsTrue(entbl.checkforDetails());
                Assert.IsTrue(entbl.checkforimages());
                Assert.IsTrue(entbl.verifyplaceNameandcategoryid());
            }
            else { 
                Assert.IsTrue(entbl.checkStatusCode(Code));
                Assert.IsFalse(entbl.checkforDetails());
                Assert.IsFalse(entbl.checkforimages());
                Assert.IsFalse(entbl.verifyplaceNameandcategoryid());
            }
        }

        [When(@"user sends a request for a specific entity '(.*)'")]
        public void WhenUserSendsARequestForASpecificEntity(string entity)
        {
            entbl = new EntityBL(_sceneriocontext);
            Assert.IsTrue(entbl.invoke());
            Assert.IsTrue(entbl.createget3requst(entity));
            Assert.IsTrue(entbl.executereq());
        }

        [Then(@"user should be able to get the deatils abt the entity with its defined Amenities with code '(.*)' in the size (.*)")]
        public void ThenUserShouldBeAbleToGetTheDeatilsAbtTheEntityWithItsDefinedAmenitiesWithCodeInTheSize(string Code, int size)
        {
            Assert.IsTrue(entbl.checkStatusCode(Code));
            Assert.IsTrue(entbl.checkforsize(size));
            
        }


    }
}