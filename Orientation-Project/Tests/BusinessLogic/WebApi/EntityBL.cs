using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Tests.CommonUtils;

namespace Tests.WebApi
{
    class EntityBL
    {
        private ScenarioContext _scenerioContext;
        private CommonMethodsApi commonMethodsApi;
        public EntityBL(ScenarioContext sceneriocontext)
        {
            _scenerioContext = sceneriocontext;
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

        public bool createRequest(string Entity,string PlaceName) {
            try
            {
                RestRequest req = commonMethodsApi.generate_request("Base/GetEntity", "Get");
                if (req != null)
                {
                    req.AddParameter("Id", commonMethodsApi.getCategoryid(Entity));
                    req.AddParameter("PlaceName", PlaceName);
                    _scenerioContext.Add("PlaceName", PlaceName);
                    _scenerioContext.Add("CatId", commonMethodsApi.getCategoryid(Entity));
                    _scenerioContext.Add("Request", req);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e) {
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

        public bool checkStatusCode(string code)
        {
            return commonMethodsApi.checkStatusCode(code);

        }

        public bool checkforDetails()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var Details = commonMethodsApi.getobjectfromJson("Details", res.Content);
            var Amenities = commonMethodsApi.getobjectfromJson("Amenities", res.Content);
            if (Details != null)
            {
                if (Amenities != null)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool verifyplaceNameandcategoryid()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var Details = commonMethodsApi.getobjectfromJson("Details", res.Content);
            if (Details != null) { 
                var placeName = commonMethodsApi.getFromJsonBody("name", Details.ToString());
                if (placeName != null)
                {
                    var catId = commonMethodsApi.getFromJsonBody("categoryId", Details.ToString());
                    if (catId != null)
                    {
                        if (catId.Equals(_scenerioContext.Get<int>("CatId").ToString()))
                        {
                            if (placeName.Equals(_scenerioContext.Get<string>("PlaceName")))
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool checkforimages()
        {
            IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
            var Images = commonMethodsApi.getArrayFromJson("Images",res.Content);
            if (Images != null)
                return true;
            else
                return false;
        }

        public bool createget3requst(string Entity)
        {
            try
            {
                var id = commonMethodsApi.getCategoryid(Entity);
                RestRequest req = commonMethodsApi.generate_request("Base/GetAll/"+id, "Get");
                if (req != null)
                {
                    _scenerioContext.Add("CatId", commonMethodsApi.getCategoryid(Entity));
                    _scenerioContext.Add("Request", req);
                    return true;
                }
                else
                    return false;
            }
            catch {
                return false;
            }
        }
        public bool checkforsize(int size) {
            try
            {
                IRestResponse res = _scenerioContext.Get<IRestResponse>("Response");
                var list = commonMethodsApi.getlistfromjson(res.Content);
                if (list.Count == size)
                {
                    return true;
                }
                else
                    return false;
            }
            catch {
                return false;
            }
        }
    }
}
