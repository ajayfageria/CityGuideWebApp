using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Tests.CommonUtils;
using Tests.ViewModels;

namespace Tests.WebApi
{
    class UserAccountBL
    {
        private ScenarioContext _scenerioContext;
        private CommonMethodsApi commonMethodsApi;
        public UserAccountBL(ScenarioContext sceneriocontext)
        {
            _scenerioContext = sceneriocontext;
        }
        public bool invoke() {
            try
            {
                RestClient client = new RestClient("https://cityguidedelhi.azurewebsites.net/api/");
                _scenerioContext.Add("Client",client);
                commonMethodsApi = new CommonMethodsApi(_scenerioContext);
                return true;
            }
            catch(Exception ex) {
                return false;
                throw ex;
            }
        }

        public bool createRegBody(string Email, string FullName, string UserName, string Password, string Resource) {
            try
            {
                RestRequest req = commonMethodsApi.generate_request(Resource, "Post");
                req.RequestFormat = DataFormat.Json;
                var param = new RegViewModel { Email = Email,FullName = FullName,UserName = UserName,Password = Password };
                req.AddJsonBody(param);
                
                _scenerioContext.Add("Request", req);
                return true;
            }
            catch (Exception ex) {
                throw ex;
            }
        
        }


        public bool createLoginBody(string UserName, string Password,string Resource) {
            try
            {
                RestRequest req = commonMethodsApi.generate_request(Resource, "Post");
                req.RequestFormat = DataFormat.Json;
                var param = new LoginViewModel { UserName = UserName, Password = Password };
                req.AddJsonBody(param);
                _scenerioContext.Add("Request", req);
                return true;

            }
            catch (Exception ex) {
                throw ex;
            }

        }
        public bool executereq() {
            if (commonMethodsApi.execute_req())
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool checkStatusCode(string code) {
            return commonMethodsApi.checkStatusCode(code);

        }

        public bool checkforToken()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var token = commonMethodsApi.getFromJsonBody("token", res.Content);
            if (token != null)
            {
                return true;
            }
            else
                return false;

        }

        public bool checkforRole(string Role) {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var role = commonMethodsApi.getFromJsonBody("Role",res.Content);
            if (role.Equals(Role))
            {
                return true;
            }
            else
                return false;
        }

        public bool checkforsuccess() {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var success = commonMethodsApi.getFromJsonBody("succeeded",res.Content);
            if (success.Equals(true) )
            {
                return true;
            }
            else
                return false;

        }
        public bool checkforerrors(string Errorcode) {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var errors = commonMethodsApi.getArrayFromJson("errors", res.Content);
            var code = commonMethodsApi.getFromJsonArray("code", errors);
            if (code.Equals(Errorcode))
            {
                return true;
            }
            else
                return false;
        }

        public bool checkformessage(string error) {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var message = commonMethodsApi.getFromJsonBody("message",res.Content);
            if (message.Equals(error)) {
                return true;
            }
            else    
                return false;
        }
    }
}
