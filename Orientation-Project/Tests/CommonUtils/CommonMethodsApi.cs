using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Tests.CommonUtils
{
    class CommonMethodsApi
    {
        private ScenarioContext _scenerioContext;

        public CommonMethodsApi(ScenarioContext scenerioContext)
        {
            _scenerioContext = scenerioContext; 
        }
        public RestRequest generate_request(String Resource, String Type)
        {
            RestRequest req;
            try
            {
                if (Type.Equals("Get"))
                {
                    req = new RestRequest(Resource, Method.GET);
                    return req;
                }
                else if (Type.Equals("Post"))
                {
                    req = new RestRequest(Resource, Method.POST);
                    return req;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool execute_req() {
            try
            {
                RestRequest Request =_scenerioContext.Get<RestRequest>("Request");
                RestClient client = _scenerioContext.Get<RestClient>("Client");
                IRestResponse res = client.Execute(Request);
                _scenerioContext.Add("Response", res);
                return true;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public string getFromJsonBody(string token,string content) {
           
            var obj = JObject.Parse(content);
            string tokenValue =(string) obj.SelectToken(token);
            return tokenValue;
        }
        public JArray getArrayFromJson(string token, string content) {
            var obj = JObject.Parse(content);
            try
            {
                JArray tokenArray = obj.SelectToken(token).ToObject<JArray>();
                return tokenArray;
            }
            catch (NullReferenceException e) {
                return null;
                throw e;
            }
        }
        public string getFromJsonArray(string token,JArray arr) {
            var obj = JObject.Parse(arr[0].ToString());
            try
            {
                var tokenValue = obj.SelectToken(token);
                return tokenValue.ToString();
            }
            catch (NullReferenceException e) {
                return null;
                throw e;
            }

        }
        public object getobjectfromJson(string token, string Content)
        {
            var obj = JObject.Parse(Content);
            try
            {
                Object tokenValue = obj.SelectToken(token);
                return tokenValue;
            }
            catch (NullReferenceException e) {
                return null;
                throw e;
            }

        }

        public int getCategoryid(string entity) {
            int id = 0;
            if (entity.Equals("Tourist") || entity.Equals("tourist"))
                id = 1;
            else if (entity.Equals("Activities") || entity.Equals("activities"))
                id = 2;
            else if (entity.Equals("Restaurants") || entity.Equals("Restaurants")||entity.Equals("Food")||entity.Equals("food"))
                id = 3;
            else if (entity.Equals("Accomodation") || entity.Equals("accomodation"))
                id = 4;
            
            return id;

        }

        public bool checkStatusCode(string code)
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            int statuscode = int.Parse(code);
            if (statuscode == (int)res.StatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Object> getlistfromjson(string Content)
        {
            List<Object> list = JsonConvert.DeserializeObject<List<Object>>(Content);
            return list;

        }
    }
}
