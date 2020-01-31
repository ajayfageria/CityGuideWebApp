using RestSharp;
using System;
using TechTalk.SpecFlow;
using Tests.CommonUtils;
using Tests.ViewModels;

namespace Tests.BusinessLogic.WebApi
{
    class AdminBL
    {
        private ScenarioContext _scenerioContext;
        private CommonMethodsApi commonMethodsApi;
        private FeatureContext _featureContext;
        public AdminBL(ScenarioContext sceneriocontext, FeatureContext featureContext)
        {
            _scenerioContext = sceneriocontext;
            commonMethodsApi = new CommonMethodsApi(_scenerioContext);
            _featureContext = featureContext;
        }

        public bool invoke()
        {
            try
            {
                RestClient client = new RestClient("https://cityguidedelhi.azurewebsites.net/api/");
                _scenerioContext.Add("Client", client);
                commonMethodsApi = new CommonMethodsApi(_scenerioContext);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool getLoginToken()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var token = commonMethodsApi.getFromJsonBody("token", res.Content);
            if (token != null)
            {
                clearScenerioContext();
                clearFeatureContext();
                _featureContext.Add("Role", commonMethodsApi.getFromJsonBody("Role", res.Content));
                _featureContext.Add("token", token);
                return true;
            }
            else
                return false;
        }

        public bool createRegisterBody(string Username, string password, string Email, string FullName)
        {
            try
            {
                RestRequest req = commonMethodsApi.generate_request("Admin/RegisterAdmin", "Post");
                var Admin = new RegViewModel { UserName = Username, Password = password, FullName = FullName, Email = Email };
                req.AddHeader("Authorization", string.Format("Bearer {0}", _featureContext.Get<string>("token")));
                req.AddJsonBody(Admin);
                _scenerioContext.Add("Request", req);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }

        }
        public bool executereq()
        {
            if (commonMethodsApi.execute_req())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkforsuccess()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var success = commonMethodsApi.getFromJsonBody("succeeded", res.Content);
            if (success.Equals("False"))
            {
                return true;
            }
            else
                return false;
        }
        public bool checkstatusCode(string Code)
        {
            return commonMethodsApi.checkStatusCode(Code);
        }

        public void clearScenerioContext()
        {
            _scenerioContext.Clear();
        }

        public bool Checkloggedinas(string Role)
        {
            if (_featureContext.ContainsKey("token"))
            {
                if (_featureContext.ContainsValue(Role))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        public void clearFeatureContext()
        {
           _featureContext.Clear();
        }
        
    }

}
