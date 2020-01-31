using TechTalk.SpecFlow;

namespace Tests.Helper
{
    [Binding]
    public class Binding
    {
        private FeatureContext _featureContext;

        public Binding(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }
    }
}
